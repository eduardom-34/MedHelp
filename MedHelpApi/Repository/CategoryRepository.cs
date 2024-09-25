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
    

    public async Task Add(Category entity)
    => await _context.Categories.AddAsync(entity);

    public void Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task Save()
      => await  _context.SaveChangesAsync();

    public IEnumerable<Category> Search(Func<Category, bool> filter)
    {
        throw new NotImplementedException();
    }
}
