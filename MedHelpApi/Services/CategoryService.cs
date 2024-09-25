using System;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class CategoryService : ICategoryService
{
    private MedHelpContext _context;
    private IRepository<Category> _categoryRepository;

    public CategoryService(MedHelpContext context,
        IRepository<Category> categoryRepository)
    {
        _context = context;
        _categoryRepository = categoryRepository;
        
    }
    public async Task<IEnumerable<CategoryDto>> Get()
    {
        var categories = await _categoryRepository.Get();
        return categories.Select(c => new CategoryDto() {
            Id = c.CategoryID,
            Name = c.Name,
            Description = c.Description
        });
    }

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);

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

        await _categoryRepository.Add(category);
        await _categoryRepository.Save();

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
        var category = await _context.Categories.FindAsync(id);

        if( category != null)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.CategoryID,
                Name = category.Name,
                Description = category.Description

            };

            _context.Remove(category);
            await _context.SaveChangesAsync();
            return categoryDto;
        }

        return null;

    }
}
