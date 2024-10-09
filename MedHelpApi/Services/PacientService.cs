using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class PacientService : ICommonService<PacientDto, PacientInsertDto, PacientUpdateDto>
{
    private IRepository<Pacient> _pacientRepository;
    public PacientService(IRepository<Pacient> pacientRepository)
    {
        _pacientRepository = pacientRepository;
    }

    public List<string> Errors => throw new NotImplementedException();
    public async Task<IEnumerable<PacientDto>> Get()
    {
        var pacients = await _pacientRepository.Get();
        return pacients.Select(p => new PacientDto() {
            Id = p.PacientID,
            Name = p.Name,
            Username = p.Username,
            BirthDate = p.BirthDate,
            SignUpDate = p.SignUpDate,
            PasswordHash = p.PasswordHash,
            PasswordSalt = p.PasswordSalt
        });
    }

    public Task<PacientDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PacientDto> Add(PacientInsertDto specialtyInsertDto)
    {
        throw new NotImplementedException();
    }
    public Task<PacientDto> Update(int id, PacientUpdateDto specialtyUpdateDto)
    {
        throw new NotImplementedException();
    }


    public Task<PacientDto> Delete(int id)
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
