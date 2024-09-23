using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class CategoryService : ICategoryService
{
    private MedHelpContext _context;

    public CategoryService(MedHelpContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<CategoryDto>> Get() =>
        await _context.Categories.Select( c => new CategoryDto{
                Id = c.CategoryID,
                Name = c.Name,
                Description = c.Description
            }).ToListAsync();

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);

            if(category != null)
            {
                var categoryDto = new CategoryDto
                {
                    Id = category.CategoryID,
                    Name = category.Name,
                    Description = category.Description
                };

                return categoryDto;
            }
            
            return null;
    }
    public async Task<CategoryDto> Add(CategoryInsertDto categoryInsertDto)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDto> Update(int id, CategoryInsertDto categoryInsertDto)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryDto> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
