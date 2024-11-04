using System;
using MedHelpApi.DTOs;
using MedHelpApi.Services.Interfaces;

namespace MedHelpApi.Services;

public class DoctorService : IDoctorService

{
    public List<string> Errors => throw new NotImplementedException();


    public Task<IEnumerable<DoctorDto>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto> GetById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<DoctorDto> Add(DoctorInsertDto categoryInsertDto)
    {
        throw new NotImplementedException();
    }

    public Task<DoctorDto> Update(int id, DoctorUpdateDto categoryUpdateDto)
    {
        throw new NotImplementedException();
    }
    public Task<DoctorDto> Delete(int id)
    {
        throw new NotImplementedException();
    }


    public bool Validate(DoctorInsertDto categoryInsertDto)
    {
        throw new NotImplementedException();
    }

    public bool Validate(DoctorUpdateDto doctorUpdateDto)
    {
        throw new NotImplementedException();
    }
}
