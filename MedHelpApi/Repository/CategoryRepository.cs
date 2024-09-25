using System;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class CategoryRepository : IRepository<Category>
{

  private MedHelpContext _context;

    public CategoryRepository(MedHelpContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> Get()
      => await _context.Categories.ToListAsync();

    public async Task<Category> GetById(int id)
      => await _context.Categories.FindAsync(id);
    

    public Task Add(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
    public IEnumerable<Category> Search(Func<Category, bool> filter)
    {
        throw new NotImplementedException();
    }
}
