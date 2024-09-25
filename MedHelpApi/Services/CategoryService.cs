using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class CategoryService : ICategoryService
{
    private IRepository<Category> _categoryRepository;
    private IMapper _mapper;

    public CategoryService(
        IRepository<Category> categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
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
        var category = _mapper.Map<Category>(categoryInsertDto);

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
        var category = await _categoryRepository.GetById(id);

        if(category != null)
        {
            category.Name = categoryUpdateDto.Name;
            category.Description = categoryUpdateDto.Description;

            _categoryRepository.Update(category);
            await _categoryRepository.Save();

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
        var category = await _categoryRepository.GetById(id);

        if( category != null)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.CategoryID,
                Name = category.Name,
                Description = category.Description

            };
            
            _categoryRepository.Delete(category);
            await _categoryRepository.Save();
            return categoryDto;
        }

        return null;

    }
}
