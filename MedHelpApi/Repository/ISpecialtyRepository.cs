using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public interface ISpecialtyRepository: IRepository<Specialty>
{
  Task<List<int>> GetValidSpecialtyIds(IEnumerable<int> specialtyIds);
  Task<List<Specialty>> GetSpecialtiesByIds(IEnumerable<int> specialtyIds);
}
