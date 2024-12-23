using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class SpecialtyService : ICommonService<SpecialtyDto, SpecialtyInsertDto, SpecialtyUpdateDto>
{
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;
    public List<string> Errors { get; }

    public SpecialtyService(ISpecialtyRepository specialtyRepository,
        IMapper mapper
    )
    {
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;
        Errors = new List<string>();
    }
    public async Task<IEnumerable<SpecialtyDto>> Get()
    {
        var specialties = await _specialtyRepository.Get();
        
        return specialties.Select( s => _mapper.Map<SpecialtyDto>(s));
    }
        
    public async Task<SpecialtyDto> GetById(int id)
    {
        var specialty = await _specialtyRepository.GetById(id);

        if (specialty != null)
        {
            var specialtyDto = _mapper.Map<SpecialtyDto>(specialty);

            return specialtyDto;
        }

        return null;
    }
    public async Task<SpecialtyDto> Add(SpecialtyInsertDto specialtyInsertDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyInsertDto);

        await _specialtyRepository.Add(specialty);
        await _specialtyRepository.Save();

        var specialtyDto =  _mapper.Map<SpecialtyDto>(specialty);
        
        return specialtyDto;
    }

    public async Task<SpecialtyDto> Update(int id, SpecialtyUpdateDto specialtyUpdateDto)
    {
        var specialty = await _specialtyRepository.GetById(id);

        if ( specialty != null)
        {
            specialty = _mapper.Map<SpecialtyUpdateDto, Specialty>(specialtyUpdateDto, specialty);
            
            _specialtyRepository.Update(specialty);
            await _specialtyRepository.Save();
            
            var specialtyDto = _mapper.Map<SpecialtyDto>(specialty);

            return specialtyDto;
        }

        return null;
    }

    public async Task<SpecialtyDto> Delete(int id)
    {
        var specialty = await _specialtyRepository.GetById(id);

        if ( specialty != null)
        {
            var specialtyDto = _mapper.Map<SpecialtyDto>(specialty);
            
            _specialtyRepository.Delete(specialty);
            await  _specialtyRepository.Save();
            return specialtyDto;
        }

        return null;
    }

    public bool Validate(SpecialtyInsertDto specialtyInsertDto)
    {
        if (_specialtyRepository.Search(s => s.Name == specialtyInsertDto.Name).Count() > 0)
        {
            Errors.Add($"You can't add and specialty more then once. This name was already added");
            return false;
        }
        return true;
    }

    public  bool Validate(SpecialtyUpdateDto specialtyUpdateDto)
    {
        if (_specialtyRepository.Search(s => s.Name == specialtyUpdateDto.Name 
        && specialtyUpdateDto.Id != s.SpecialtyID ).Count() > 0)
        {
            Errors.Add($"You can't add and specialty mora then once. This name was already added");
            return false;
        }
        return true;
    }

}
