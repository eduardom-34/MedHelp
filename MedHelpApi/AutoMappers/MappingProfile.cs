using System;
using System.Xml;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MedHelpApi.AutoMappers;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    //mapping for spcialty
    CreateMap<SpecialtyInsertDto, Specialty>();
    CreateMap<Specialty, SpecialtyDto>()
      .ForMember(dto => dto.Id,
                m => m.MapFrom(s => s.SpecialtyID))
      .ForMember(dto => dto.DoctorID,
                  m => m.MapFrom(s => s.Doctors.Select(d => d.DoctorID)));
    CreateMap<SpecialtyUpdateDto, Specialty>();

    //Categories mapping
    CreateMap<CategoryInsertDto, Category>();
    CreateMap<Category, CategoryDto>()
          .ForMember(dto => dto.Id,
                    m => m.MapFrom(c => c.CategoryID))
          .ForMember(dto => dto.SpecialtyNames,
                      m => m.MapFrom(c => c.Specialties.Select(s => s.Name)));

          // .ForMember(dto => dto.SpecialtyID,
          //           m => m.MapFrom(c => c.Specialties.Select(s => s.SpecialtyID)));

    CreateMap<CategoryUpdateDto, Category>();

    //Users mapping
    // <OrigenDeInformacion, DevolverDatos>
    CreateMap<UserInsertDto, User>();
    CreateMap<User, UserDto>()
    .ForMember(dto => dto.Id,
              m => m.MapFrom(u => u.UserID));
    CreateMap<UserUpdateDto, User>();

    //Doctors mapping
    //Origen de informacion, Devolver Datos
    CreateMap<DoctorInsertDto, Doctor>();
    // .ForMember(dto => dto.Specialties,
    //             m => m.MapFrom(d => d.SpecialtyIds));


    CreateMap<Doctor, DoctorDto>()
    .ForMember(dto => dto.Id,
              m => m.MapFrom(d => d.DoctorID))
    .ForMember(dto => dto.SpecialtyNames,
              m => m.MapFrom(d => d.Specialties.Select(s => s.Name)))
    .ForMember( dto => dto.SpecialtiesId,
               m => m.MapFrom(d => d.Specialties.Select(s => s.SpecialtyID)))
    .ForMember( dto => dto.SchedulesId,
                m => m.MapFrom(d => d.Schedules.Select(s => s.ScheduleID )));
    CreateMap<DoctorUpdateDto, Doctor>();

    // For Schedules 
    CreateMap<ScheduleUpdateDto, Schedule>(); 
    CreateMap<ScheduleInsertDto, Schedule>();
    CreateMap<Schedule, ScheduleDto>()
    .ForMember(dto => dto.ScheduleId,
              m => m.MapFrom(s => s.ScheduleID));


    // For ScheduleDate
    CreateMap<ScheduleDateDto, ScheduleDate>();
    CreateMap<ScheduleDateInsertDto, Schedule>();
    CreateMap<Schedule, ScheduleDateDto>()
    .ForMember(dto => dto.ScheduleID,
                m => m.MapFrom(s => s.ScheduleID));
    
  }
}
