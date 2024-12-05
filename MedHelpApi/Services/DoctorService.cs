using System;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using MedHelpApi.Validators;

namespace MedHelpApi.Services;

public class DoctorService : IDoctorService<DoctorDto, DoctorInsertDto, DoctorUpdateDto>

{

    private IDoctorRepository _doctorRepository;
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;
    
    public List<string> Errors { get; }

    public DoctorService(
        IDoctorRepository doctorRepository,
        ISpecialtyRepository specialtyRepository,
        IMapper mapper
         )
    {
        _doctorRepository = doctorRepository;
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;
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

    public async Task<IEnumerable<DoctorDto>> GetBySpecialties(IEnumerable<int> specialtiesId)
    {


        throw new NotImplementedException();
    }

    public async Task<DoctorDto> Add(DoctorInsertDto doctorInsertDto)
    {
        using var hmac = new HMACSHA512();

        if( doctorInsertDto.SpecialtyIds == null || !doctorInsertDto.SpecialtyIds.Any())
        {
            Errors.Add("SpecialtyIds is required");
            return null;
        }

        var validSpecialtyIds = await _specialtyRepository.GetValidSpecialtyIds(doctorInsertDto.SpecialtyIds);

        if( validSpecialtyIds.Count < doctorInsertDto.SpecialtyIds.Count )
        {
            Errors.Add("One or more specialties you entered are not valid");
            return null;
        }
        

        var specialties = await _specialtyRepository.GetSpecialtiesByIds(validSpecialtyIds);

        var doctor = _mapper.Map<Doctor>(doctorInsertDto);
        doctor.Specialties = specialties;
        doctor.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(doctorInsertDto.Password!));
        doctor.PasswordSalt = hmac.Key;

        await _doctorRepository.Add(doctor);
        await _doctorRepository.Save();

        //This mapper is for the return answer
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
