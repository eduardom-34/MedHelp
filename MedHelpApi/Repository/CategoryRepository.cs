using System;
using MedHelpApi.Models;

namespace MedHelpApi.Repository;

public class CategoryRepository : IRepository<Category>
{

    public Task<IEnumerable<Category>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetById(int id)
    {
        throw new NotImplementedException();
    }
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
