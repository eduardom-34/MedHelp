using System;

namespace MedHelpApi.Services.Interfaces;

public interface IScheduleService<T, TI, TU>
{

  public List<string> Errors{ get; }
  Task<IEnumerable<T>> Get();
  Task<T> GetById(int id);
  Task<IEnumerable<T>> GetByDoctorId(int id);
  Task<T> Add(TI scheduleInsertDto);
  Task<T> Update(int id, TU scheduleUpdateDto);
  Task<T> Delete(int id);

}
