using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;

namespace MedHelpApi.Services;

public class ScheduleService : IScheduleService<ScheduleDto, ScheduleInsertDto, ScheduleUpdateDto>
{

  private ScheduleRepository _scheduleRepository;
  private Mapper _mapper;
  public List<string> Errors {get;}

  public ScheduleService(
    ScheduleRepository scheduleRepository,
    Mapper mapper
    )
  {
    _scheduleRepository = scheduleRepository;
    _mapper = mapper;
    Errors = new List<string>();
  }

  public Task<ScheduleDto> Add(ScheduleInsertDto scheduleInsertDto)
  {
    throw new NotImplementedException();
  }

  public Task<ScheduleDto> Delete(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<ScheduleDto>> Get()
  {
    throw new NotImplementedException();
  }

  public Task<ScheduleDto> GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Task<ScheduleDto> Update(int id, ScheduleUpdateDto scheduleUpdateDto)
  {
    throw new NotImplementedException();
  }
}
