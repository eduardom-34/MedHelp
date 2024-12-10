using System;
using System.Resources;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Repository.Interfaces;
using MedHelpApi.Services.Interfaces;

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
    }

    var schedule = _mapper.Map<Schedule>(scheduleInsertDto);

    await _scheduleRepository.Add(schedule);
    await _scheduleRepository.Save();

    var scheduleDto = _mapper.Map<ScheduleDto>(schedule);

    return scheduleDto;

  }

  public Task<ScheduleDto> Update(int id, ScheduleUpdateDto scheduleUpdateDto)
  {
    throw new NotImplementedException();
  }
  public Task<ScheduleDto> Delete(int id)
  {
    throw new NotImplementedException();
  }

}
