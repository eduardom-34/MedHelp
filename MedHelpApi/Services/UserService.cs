using System;
using System.Security.Cryptography;
using System.Text;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace MedHelpApi.Services;

public class UserService : IUserService<UserDto, UserInsertDto, UserUpdateDto>
{
    private IRepository<User> _userRepository;
    public List<string> Errors { get; }

    public UserService(
        IRepository<User> userRepository
    )
    {
        _userRepository = userRepository;
        Errors = new List<string>();
    }

    public async Task<IEnumerable<UserDto>> Get()
    {
        var users = await _userRepository.Get();

        return users.Select( u => new UserDto{
            Id = u.UserID,
            FirstName = u.FirstName,
            LastName = u.LastName,
            UserName = u.UserName,
            BirthDate = u.BirthDate,
            SignUpDate = u.SignUpDate,
            PasswordHash = u.PasswordHash,
            PasswordSalt = u.PasswordSalt,
        });
    }
    
    public Task<UserDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> Add(UserInsertDto userInsertDto)
    {
        using var hmac = new HMACSHA512();
        var user = new User
        {
            FirstName = userInsertDto.FirstName,
            LastName = userInsertDto.LastName,
            UserName = userInsertDto.UserName!.ToLower(),
            Email = userInsertDto.Email,
            BirthDate = userInsertDto.BirthDate,
            SignUpDate = DateTime.Now,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userInsertDto.Password!)),
            PasswordSalt = hmac.Key
        };

        await _userRepository.Add(user);
        await _userRepository.Save();

        var userDto = new UserDto
        {
            Id = user.UserID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            BirthDate = user.BirthDate,
            SignUpDate = DateTime.Now,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userInsertDto.Password!)),
            PasswordSalt = hmac.Key

        };

        return userDto;

    }
    public Task<UserDto> Update(int id, UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Delete(int id)
    {
        throw new NotImplementedException();
    }
    public bool Validate(UserInsertDto userInsertDto)
    {
        if( _userRepository.Search(u => u.UserName == userInsertDto.UserName).Count() > 0)
        {
            Errors.Add("This Usernames is alreay being used, please user another one");
            return false;
        }

        return true;
    }

    public bool Validate(UserUpdateDto userUpdateDto)
    {
        if( _userRepository.Search(u => u.UserName == userUpdateDto.UserName 
        && userUpdateDto.Id !=  u.UserID).Count() > 0)
        {
            Errors.Add("This username is already in used, please use another one");
            return false;
        }

        return true;
    }

    public bool ValidateEmail(UserInsertDto userInsertDto)
    {
        if( _userRepository.Search(u => u.Email == userInsertDto.Email).Count() > 0)
        {
            Errors.Add("This Email is already being used, please use another one");
            return false;
        }
        return true;
    }
}
