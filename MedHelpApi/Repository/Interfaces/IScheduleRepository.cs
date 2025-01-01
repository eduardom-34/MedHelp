using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository.Interfaces;

public interface IScheduleRepository: IRepository<Schedule>
{
  Task<List<Schedule>> GetByDoctorId(int id);

}
