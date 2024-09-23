using System;
using MedHelpApi.DTOs;
using MedHelpApi.Services.Interfaces;

namespace MedHelpApi.Services;

public class CategoryService : ICategoryService
{
    public Task<IEnumerable<CategoryDto>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> GetById(int id)
    {
        throw new NotImplementedException();
    }
    public Task<CategoryDto> Add(CategoryInsertDto categoryInsertDto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> Update(int id, CategoryInsertDto categoryInsertDto)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryDto> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
