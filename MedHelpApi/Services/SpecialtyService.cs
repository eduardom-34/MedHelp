using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class SpecialtyService : ISpecialtyService
{
    private MedHelpContext _context;

    public SpecialtyService(MedHelpContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<SpecialtyDto>> Get() => 
    await _context.Specialty.Select(s => new SpecialtyDto{
            Id = s.SpecialtyID,
            Name = s.Name,
            Description = s.Description,
            CategoryID = s.CategoryID

        }).ToListAsync();
        
    public async Task<SpecialtyDto> GetById(int id)
    {
        var specialty = await _context.Specialty.FindAsync(id);

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

            await _context.Specialty.AddAsync(specialty);
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

    public async Task<SpecialtyDto> Update(int id, SpecialtyUpdateDto specialtyUpdateDto)
    {
        var specialty = await _context.Specialty.FindAsync(id);

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
        throw new NotImplementedException();
    }
}
