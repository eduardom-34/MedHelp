using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using MedHelpApi.Validators;

namespace MedHelpApi.Services;

public class DoctorService : IDoctorService

{

    private IDoctorRepository _doctorRepository;
    private IMapper _mapper;
    private DoctorInsertValidator _doctorInsertValidator;
    private DoctorUpdateValidator _doctorUpdateValidator;

    public DoctorService( 
        IDoctorRepository doctorRepository, 
        IMapper mapper,
        DoctorInsertValidator doctorInsertValidator,
        DoctorUpdateValidator doctorUpdateValidator
         ) {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
        _doctorInsertValidator = doctorInsertValidator;
        _doctorUpdateValidator = doctorUpdateValidator;
    }

    public List<string> Errors => throw new NotImplementedException();


    public async Task<IEnumerable<DoctorDto>> Get()
    {
        var doctors = await _doctorRepository.Get();
        return doctors.Select(d => _mapper.Map<DoctorDto>(d));
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
