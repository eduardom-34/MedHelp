using System;
using System.Resources;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Repository.Interfaces;
using MedHelpApi.Services.Interfaces;
using Microsoft.VisualBasic;

namespace MedHelpApi.Services;

public class ScheduleService : IScheduleService<ScheduleDto, ScheduleInsertDto, ScheduleUpdateDto>
{

  private IScheduleRepository _scheduleRepository;
  private IMapper _mapper;
  public List<string> Errors {get;}

  public ScheduleService(
    IScheduleRepository scheduleRepository,
    IMapper mapper
    )
  {
    _scheduleRepository = scheduleRepository;
    _mapper = mapper;
    Errors = new List<string>();
  }


  public async Task<IEnumerable<ScheduleDto>> Get()
  {
    var schedules = await _scheduleRepository.Get();
    
    return schedules.Select(s => _mapper.Map<ScheduleDto>(s));
  }

  public async Task<ScheduleDto> GetById(int id)
  {
    var schedule = await _scheduleRepository.GetById(id);

    if( schedule != null ){
      var scheduleDto = _mapper.Map<ScheduleDto>(schedule);
      
      return scheduleDto;
    }

    return null;
    
  }
  public async Task<ScheduleDto> Add(ScheduleInsertDto scheduleInsertDto)
  {
    
    if( scheduleInsertDto.DoctorID < 0 ){
      Errors.Add("You need to select a doctor ID");
      return null;
    }

    var schedule = _mapper.Map<Schedule>(scheduleInsertDto);

    if (!schedule.IsValidTimeRange)
    {
        Errors.Add("StartTime must be earlier than EndTime");
        return null;
    }

    await _scheduleRepository.Add(schedule);
    await _scheduleRepository.Save();

    var scheduleDto = _mapper.Map<ScheduleDto>(schedule);

    return scheduleDto;

  }

  public async Task<ScheduleDto> Update(int id, ScheduleUpdateDto scheduleUpdateDto)
  {
    var schedule = await _scheduleRepository.GetById(scheduleUpdateDto.ScheduleId);

    if( schedule != null ){
      schedule = _mapper.Map<ScheduleUpdateDto, Schedule>(scheduleUpdateDto, schedule);

      _scheduleRepository.Update(schedule);
      await _scheduleRepository.Save();

      var scheduleDto = _mapper.Map<ScheduleDto>(schedule);
      return scheduleDto;
    }

    return null;

  }
  public  async Task<ScheduleDto> Delete(int id)
  {
    var schedule = await _scheduleRepository.GetById(id);

    if( schedule != null ){
      _scheduleRepository.Delete(schedule);
      await _scheduleRepository.Save();
      return _mapper.Map<ScheduleDto>(schedule);
    }

    return null;
  }

    public async Task<IEnumerable<ScheduleDto>> GetByDoctorId(int id)
    {
      var schedules = await _scheduleRepository.GetByDoctorId( id );

      if( schedules!= null ){
        var schedulesDto = schedules.Select(s => _mapper.Map<ScheduleDto>(s));

        return schedulesDto;
      }
      return null;
    }
}
