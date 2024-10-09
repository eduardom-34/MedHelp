using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class PacientService : ICommonService<Pacient, PacientInsertDto, PacientUpdateDto>
{
    public List<string> Errors => throw new NotImplementedException();
    public Task<IEnumerable<Pacient>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Pacient> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pacient> Add(PacientInsertDto specialtyInsertDto)
    {
        throw new NotImplementedException();
    }
    public Task<Pacient> Update(int id, PacientUpdateDto specialtyUpdateDto)
    {
        throw new NotImplementedException();
    }


    public Task<Pacient> Delete(int id)
    {
        throw new NotImplementedException();
    }


    public bool Validate(PacientInsertDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Validate(PacientUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
