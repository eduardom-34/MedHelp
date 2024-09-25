using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MedHelpApi.AutoMappers;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<SpecialtyInsertDto, Specialty>();
    CreateMap<Specialty, SpecialtyDto>()
      .ForMember(dto => dto.Id,
                m => m.MapFrom(s => s.SpecialtyID));
    CreateMap<SpecialtyUpdateDto, Specialty>();

    //Categories mapping
    CreateMap<CategoryInsertDto, Category>();
    CreateMap<Category, CategoryDto>()
          .ForMember(dto => dto.Id,
                    m => m.MapFrom(c => c.CategoryID));
    CreateMap<CategoryUpdateDto, Category>();
  }
}
