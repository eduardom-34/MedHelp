using System;
using MedHelpApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MedHelpApi.Services.Interfaces;

public interface ICategoryService
{
  Task<IEnumerable<CategoryDto>> Get();
  Task<CategoryDto> GetById(int id);
  Task<CategoryDto> Add(CategoryInsertDto categoryInsertDto);
  Task<CategoryDto> Update(int id, CategoryUpdateDto categoryUpdateDto);
  Task<CategoryDto> Delete(int id);

}
