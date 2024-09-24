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
        await _context.Categories.Select(c => new CategoryDto
        {
            Id = c.CategoryID,
            Name = c.Name,
            Description = c.Description
        }).ToListAsync();

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category != null)
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
        var category = new Category()
        {
            Name = categoryInsertDto.Name,
            Description = categoryInsertDto.Description
        };

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        var categoryDto = new CategoryDto
        {
            Id = category.CategoryID,
            Name = category.Name,
            Description = category.Description
        };

        return categoryDto;
    }

    public async Task<CategoryDto> Update(int id, CategoryUpdateDto categoryUpdateDto)
    {
        var category = await _context.Categories.FindAsync(id);

        if(category != null)
        {
            category.Name = categoryUpdateDto.Name;
            category.Description = categoryUpdateDto.Description;

            await _context.SaveChangesAsync();

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

    public async Task<CategoryDto> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
