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
    public List<string> Errors { get; }

    public DoctorService(
        IDoctorRepository doctorRepository,
        IMapper mapper,
        DoctorInsertValidator doctorInsertValidator,
        DoctorUpdateValidator doctorUpdateValidator
         )
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
        _doctorInsertValidator = doctorInsertValidator;
        _doctorUpdateValidator = doctorUpdateValidator;
        Errors = new List<string>();
    }

    public async Task<IEnumerable<DoctorDto>> Get()
    {
        var doctors = await _doctorRepository.Get();
        return doctors.Select(d => _mapper.Map<DoctorDto>(d));
    }

    public async Task<DoctorDto> GetById(int id)
    {
        var doctor = await _doctorRepository.GetById(id);

        if (doctor != null)
        {
            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            return doctorDto;
        }
        return null;


    }
    public async Task<DoctorDto> Add(DoctorInsertDto doctorInsertDto)
    {

        var doctor = _mapper.Map<Doctor>(doctorInsertDto);
        await _doctorRepository.Add(doctor);
        await _doctorRepository.Save();

        var doctorDto = _mapper.Map<DoctorDto>(doctor);
        return doctorDto;
    }

    public async Task<DoctorDto> Update(int id, DoctorUpdateDto doctorUpdateDto)
    {
        var doctor = await _doctorRepository.GetById(id);

        if (doctor != null)
        {
            doctor = _mapper.Map<DoctorUpdateDto, Doctor>(doctorUpdateDto, doctor);
            _doctorRepository.Update(doctor);
            await _doctorRepository.Save();

            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return doctorDto;
        }

        return null;
    }
    public async Task<DoctorDto> Delete(int id)
    {
        var doctor = await _doctorRepository.GetById(id);

        if( doctor != null)
        {
            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            _doctorRepository.Delete(doctor);
            await _doctorRepository.Save();

            return doctorDto;
        }

        return null;
    }


    public bool Validate(DoctorInsertDto doctorInsertDto)
    {
        if( _doctorRepository.Search(d => d.UserName == doctorInsertDto.UserName).Count() > 0 ){
            Errors.Add("This username already exists");
            return false;
        }
        return true;
    }

    public bool Validate(DoctorUpdateDto doctorUpdateDto)
    {
        if(_doctorRepository.Search(d => d.UserName == doctorUpdateDto.UserName 
        && d.DoctorID != doctorUpdateDto.Id).Count() > 0){
            Errors.Add("This username already exists");
            return false;
        }
        
        return true;
    }
}
