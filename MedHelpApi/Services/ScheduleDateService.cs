using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository.Interfaces;
using MedHelpApi.Services.Interfaces;

namespace MedHelpApi.Services;

public class ScheduleDateService : IScheduleDateService<ScheduleDateDto, ScheduleDateInsertDto, ScheduleDateUpdateDto>
{
  private IScheduleDateRepository _scheduleDateRepository;
  private IMapper _mapper;
  public List<string> Errors {get;}

  public ScheduleDateService(IScheduleDateRepository scheduleDateRepository,
  IMapper mapper
  )
  {
    _scheduleDateRepository = scheduleDateRepository;
    _mapper = mapper;
    Errors = new List<string>();    
  }

    public async Task<IEnumerable<ScheduleDateDto>> Get()
    {
      var doctors = await _scheduleDateRepository.Get();

      return doctors.Select( s => _mapper.Map<ScheduleDateDto>(s));  
    }

    public async Task<ScheduleDateDto> GetById(int id)
    {
      var doctor = await _scheduleDateRepository.GetById(id);

      if( doctor != null ){

        var doctorDto = _mapper.Map<ScheduleDateDto>(doctor);

        return doctorDto;
      }
      return null;
    }

    public async Task<ScheduleDateDto> Add(ScheduleDateInsertDto scheduleDateInsertDto)
    {
      var scheduleDate = _mapper.Map<ScheduleDate>(scheduleDateInsertDto);

      await _scheduleDateRepository.Add(scheduleDate);
      await _scheduleDateRepository.Save();

      var ScheduleDateDto = _mapper.Map<ScheduleDateDto>(scheduleDate);

      return ScheduleDateDto;

    }

    public async Task<ScheduleDateDto> Update(int id, ScheduleDateUpdateDto scheduleDateUpdateDto)
    {
      var scheduleDate = await _scheduleDateRepository.GetById(id);

      if( scheduleDate != null) {
        scheduleDate = _mapper.Map<ScheduleDateUpdateDto, ScheduleDate>(scheduleDateUpdateDto, scheduleDate);
        
        _scheduleDateRepository.Update(scheduleDate);
        await _scheduleDateRepository.Save();

        var scheduleDateDto = _mapper.Map<ScheduleDateDto>(scheduleDate);

        return scheduleDateDto;
      }

      return null;
    }
    public async Task<ScheduleDateDto> Delete(int id)
    {
      var scheduleDate = await _scheduleDateRepository.GetById(id);

      if(scheduleDate != null){
        _scheduleDateRepository.Delete(scheduleDate);
        await _scheduleDateRepository.Save();
      }

      return null;
    }

}
