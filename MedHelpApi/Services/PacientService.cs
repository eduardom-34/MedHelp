using System;
using System.Security.Cryptography;
using System.Text;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<PacientDto> GetById(int id)
    {
        var pacient = await _pacientRepository.GetById(id);

        if( pacient != null )
        {
            var pacientDto = new PacientDto
            {
                Id = pacient.PacientID,
                Name = pacient.Name,
                Username = pacient.Username,
                BirthDate = pacient.BirthDate,
                SignUpDate = pacient.SignUpDate,
                PasswordHash = pacient.PasswordHash,
                PasswordSalt = pacient.PasswordSalt
            };

            return pacientDto;
        }

        return null;
        
    }

    public async Task<PacientDto> Add(PacientInsertDto specialtyInsertDto)
    {
        using var hmac = new HMACSHA512();
        var pacient = new Pacient
        {
            Name = specialtyInsertDto.Name,
            Username = specialtyInsertDto.Username,
            BirthDate = specialtyInsertDto.BirthDate,
            SignUpDate = DateTime.Now,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(specialtyInsertDto.Password)),
            PasswordSalt = hmac.Key
        };

        await _pacientRepository.Add(pacient);
        await _pacientRepository.Save();

        var PacientDto = new PacientDto
        {
            Id = pacient.PacientID,
            Name = pacient.Name,
            BirthDate = pacient.BirthDate,
            SignUpDate = pacient.SignUpDate,
            PasswordHash = pacient.PasswordHash,
            PasswordSalt = pacient.PasswordSalt
        };

        return PacientDto;
        
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
