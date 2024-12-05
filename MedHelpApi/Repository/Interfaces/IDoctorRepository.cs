using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public interface IDoctorRepository : IRepository<Doctor>
{
  Task<List<Doctor>> GetBySpecialties(IEnumerable<int> specialtyIds);

}
