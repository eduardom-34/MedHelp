using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class SpecialtyService : ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto>
{
    private MedHelpContext _context;
    private IRepository<Specialty> _specialtyRepository;

    public SpecialtyService(MedHelpContext context, IRepository<Specialty> specialtyRepository)
    {
        _context = context;
        _specialtyRepository = specialtyRepository;
    }
    public async Task<IEnumerable<SpecialtyDto>> Get()
    {
        var specialties = await _specialtyRepository.Get();
        
        return specialties.Select( s => new SpecialtyDto()
        {
            Id = s.SpecialtyID,
            Name = s.Name,
            Description = s.Description,
            CategoryID = s.CategoryID

        });
    }
        
    public async Task<SpecialtyDto> GetById(int id)
    {
        var specialty = await _specialtyRepository.GetById(id);

        if (specialty != null)
        {
            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };

            return specialtyDto;
        }

        return null;
    }
    public async Task<SpecialtyDto> Add(SpecialtyInsertDto specialtyInsertDto)
    {
        var specialty = new Specialty()
            {
                Name = specialtyInsertDto.Name,
                Description = specialtyInsertDto.Description,
                CategoryID = specialtyInsertDto.CategoryID

            };

            await _specialtyRepository.Add(specialty);
            await _specialtyRepository.Save();

            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };
            
            return specialtyDto;
    }

    public async Task<SpecialtyDto> Update(int id, SpecialtyUpdateDto specialtyUpdateDto)
    {
        var specialty = await _context.Specialties.FindAsync(id);

        if ( specialty != null)
        {
            specialty.Name = specialtyUpdateDto.Name;
            specialty.Description = specialtyUpdateDto.Description;
            specialty.CategoryID = specialtyUpdateDto.CategoryID;

            await _context.SaveChangesAsync();
            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };

            return specialtyDto;
        }

        return null;
    }

    public async Task<SpecialtyDto> Delete(int id)
    {
        var specialty = await _context.Specialties.FindAsync(id);

        if ( specialty != null)
        {
            var specialtyDto = new SpecialtyDto
            {
                Id = specialty.SpecialtyID,
                Name = specialty.Name,
                Description = specialty.Description,
                CategoryID = specialty.CategoryID
            };

            _context.Remove(specialty);
            await _context.SaveChangesAsync();
            return specialtyDto;
        }

        return null;
    }
}
