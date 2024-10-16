using System;
using System.Runtime.CompilerServices;
using MedHelpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedHelpApi.Repository;

public class UserRepository : IUserRepository
{
    private MedHelpContext _context;

    public UserRepository(MedHelpContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> Get()
        => await _context.Users.ToListAsync();

    public async Task<User> GetById(int id)
        => await _context.Users.FindAsync(id);
    public async Task Add(User user)
        => await _context.Users.AddAsync(user);


    public void Update(User user)
    {
        _context.Users.Attach(user);
        _context.Users.Entry(user).State = EntityState.Modified;
    }

    public async Task<User> GetByUsername(string username)
    => await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);

    public void Delete(User user)
        => _context.Users.Remove(user);


    public async Task Save()
        => await _context.SaveChangesAsync();

    public IEnumerable<User> Search(Func<User, bool> filter)
    => _context.Users.Where(filter).ToList();
}
