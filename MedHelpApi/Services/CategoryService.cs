using System;
using AutoMapper;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Services;

public class CategoryService : ICategoryService
{
    private IRepository<Category> _categoryRepository;
    private ISpecialtyRepository _specialtyRepository;
    private IMapper _mapper;
    public List<string> Errors { get; }

    public CategoryService(
        IRepository<Category> categoryRepository,
        ISpecialtyRepository specialtyRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        Errors = new List<string>();
        _specialtyRepository = specialtyRepository;
    }
    public async Task<IEnumerable<CategoryDto>> Get()
    {
        var categories = await _categoryRepository.Get();
        return categories.Select(c => _mapper.Map<CategoryDto>(c));
    }

    public async Task<CategoryDto> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);

        if (category != null)
        {
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        return null;
    }
    public async Task<CategoryDto> Add(CategoryInsertDto categoryInsertDto)
    {

        //see if the user added an specialty
        if (categoryInsertDto.SpecialtyID == null)
        {
            Errors.Add("At least one Specialty is required");
            return null;
        }

        var validSpecialtyIds = await _specialtyRepository.GetValidSpecialtyIds(categoryInsertDto.SpecialtyID);

        if (validSpecialtyIds.Count < categoryInsertDto.SpecialtyID.Count)
        {
            Errors.Add("One or more specialties you entered are not valid");
            return null;
        }

        var specialties = await _specialtyRepository.GetSpecialtiesByIds(validSpecialtyIds);

        var category = _mapper.Map<Category>(categoryInsertDto);
        category.Specialties = specialties;

        await _categoryRepository.Add(category);
        await _categoryRepository.Save();

        var categoryDto = _mapper.Map<CategoryDto>(category);

        return categoryDto;
    }

    public async Task<CategoryDto> Update(int id, CategoryUpdateDto categoryUpdateDto)
    {
        var category = await _categoryRepository.GetById(id);

        if (category == null)
        {
            // category.Name = categoryUpdateDto.Name;
            // category.Description = categoryUpdateDto.Description;

            return null;
        }

        category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, category);
        
        var validSpecialtyIds = await _specialtyRepository.GetValidSpecialtyIds(categoryUpdateDto.SpecialtyID);
        
        if(validSpecialtyIds.Count < categoryUpdateDto.SpecialtyID.Count){
            Errors.Add("One or more specialties you entered are not valid");
            return null;
        }

        var specialties = await _specialtyRepository.GetSpecialtiesByIds(validSpecialtyIds);
        _categoryRepository.Update(category);
        category.Specialties = specialties;

        await _categoryRepository.Save();

        var categoryDto = _mapper.Map<CategoryDto>(category);

        return categoryDto;
    }

    public async Task<CategoryDto> Delete(int id)
    {
        var category = await _categoryRepository.GetById(id);

        if (category != null)
        {
            var categoryDto = _mapper.Map<CategoryDto>(category);

            _categoryRepository.Delete(category);
            await _categoryRepository.Save();
            return categoryDto;
        }

        return null;

    }

    public bool Validate(CategoryInsertDto categoryInsertDto)
    {
        if (_categoryRepository.Search(c => c.Name == categoryInsertDto.Name).Count() > 0)
        {
            Errors.Add("This Category already exists");
            return false;
        }
        return true;
    }

    public bool Validate(CategoryUpdateDto categoryUpdateDto)
    {
        if (_categoryRepository.Search(c => c.Name == categoryUpdateDto.Name
        && categoryUpdateDto.Id != c.CategoryID).Count() > 0)
        {
            Errors.Add("This Category already exists");
            return false;
        }

        return true;
    }
}
