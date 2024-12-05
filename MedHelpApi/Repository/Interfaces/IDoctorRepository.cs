using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public interface IDoctorRepository : IRepository<Doctor>
{
  Task<IEnumerable<Doctor>> GetBySpecialty(int specialtyId );

}
