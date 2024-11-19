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
      => await _context.Categories
      .Include(c => c.Specialties)
      .ToListAsync();

    public async Task<Category> GetById(int id)
      => await _context.Categories
      .Include(c => c.Specialties)
      .FirstOrDefaultAsync(c => c.CategoryID == id);
    

    public async Task Add(Category entity)
    => await _context.Categories.AddAsync(entity);

    public void Update(Category entity)
    {
      _context.Attach(entity);
      _context.Categories.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Category entity)
      => _context.Categories.Remove(entity);

    public async Task Save()
      => await  _context.SaveChangesAsync();

    public IEnumerable<Category> Search(Func<Category, bool> filter)
    {
      return _context.Categories.Where(filter).ToList();
    }
}
