using System;
using AutoMapper;
using MedHelpApi.DTOs;
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



    throw new NotImplementedException();
  }

  public Task<ScheduleDto> GetById(int id)
  {
    throw new NotImplementedException();
  }
  public Task<ScheduleDto> Add(ScheduleInsertDto scheduleInsertDto)
  {
    throw new NotImplementedException();
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
