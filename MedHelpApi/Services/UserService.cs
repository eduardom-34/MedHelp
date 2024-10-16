using System;
using System.Security.Cryptography;
using System.Text;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Repository;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace MedHelpApi.Services;

public class UserService : IUserService<UserDto, UserInsertDto, UserUpdateDto, UserTokenDto>
{
    private IUserRepository _userRepository;
    public List<string> Errors { get; }
    private readonly ITokenService<UserDto> _tokenService;

    public UserService(
        IUserRepository userRepository,
        ITokenService<UserDto> tokenService

    )
    {
        _userRepository = userRepository;
        Errors = new List<string>();
        _tokenService = tokenService;
    }

    public async Task<IEnumerable<UserDto>> Get()
    {
        var users = await _userRepository.Get();

        return users.Select(u => new UserDto
        {
            Id = u.UserID,
            FirstName = u.FirstName,
            LastName = u.LastName,
            UserName = u.UserName,
            Email = u.Email,
            BirthDate = u.BirthDate,
            SignUpDate = u.SignUpDate,
            PasswordHash = u.PasswordHash,
            PasswordSalt = u.PasswordSalt,
        });
    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _userRepository.GetById(id);

        if (user == null)
        {
            Errors.Add($"This id {id} was not found");
            return null;
        }

        var userDto = new UserDto
        {
            Id = user.UserID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            BirthDate = user.BirthDate,
            SignUpDate = user.SignUpDate,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt
        };

        return userDto;
    }

    public async Task<UserDto> GetByUsername(string username)
    {
        var user = await _userRepository.GetByUsername(username);

        if (user == null)
        {
            Errors.Add("This username was not found");
            return null;
        }

        var userDto = new UserDto
        {
            Id = user.UserID,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.UserName,
            Email = user.Email,
            BirthDate = user.BirthDate,
            SignUpDate = user.SignUpDate,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt
        };

        return userDto;
    }

    public async Task<UserTokenDto> Add(UserInsertDto userInsertDto)
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

        var userTokenDto = new UserTokenDto
        {
            UserName = user.UserName,
            Token = _tokenService.CreateToken(userDto)
        };

        return userTokenDto;

    }
    public async Task<UserDto> Update(int id, UserUpdateDto userUpdateDto)
    {
        using var hmac = new HMACSHA512();
        var user = await _userRepository.GetById(id);

        if (user != null)
        {
            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.UserName = userUpdateDto.UserName;
            user.Email = userUpdateDto.Email;
            user.BirthDate = userUpdateDto.BirthDate;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userUpdateDto.Password!));
            user.PasswordSalt = hmac.Key;

            await _userRepository.Save();

            var userDto = new UserDto
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt

            };
            return userDto;
        }

        return null;
    }

    public async Task<UserDto> Delete(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user != null)
        {
            var userDto = new UserDto
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                SignUpDate = user.SignUpDate,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };

            _userRepository.Delete(user);
            await _userRepository.Save();
            return userDto;
        }

        return null;
    }
    public async Task<UserTokenDto> Login(string username, string password)
    {
        // var user = _userRepository.
        var user = await _userRepository.GetByUsername(username);

        if (user != null)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt!);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash![i])
                {

                    Errors.Add("The password is incorret, please try again");
                    return null;
                }
            }

            var userDto = new UserDto
            {
                Id = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                SignUpDate = user.SignUpDate,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };

            var userTokenDto = new UserTokenDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(userDto)
            };
            return userTokenDto;

        }
        Errors.Add("This username does not exist,  please try again or create an account");
        return null;
    }

    public bool Validate(UserInsertDto userInsertDto)
    {
        if (_userRepository.Search(u => u.UserName == userInsertDto.UserName).Count() > 0)
        {
            Errors.Add("This Usernames is alreay being used, please user another one");
            return false;
        }

        return true;
    }

    public bool Validate(UserUpdateDto userUpdateDto)
    {
        if (_userRepository.Search(u => u.UserName == userUpdateDto.UserName
        && userUpdateDto.Id != u.UserID).Count() > 0)
        {
            Errors.Add("This username is already in used, please use another one");
            return false;
        }

        return true;
    }

    public bool ValidateEmail(UserInsertDto userInsertDto)
    {
        if (_userRepository.Search(u => u.Email == userInsertDto.Email).Count() > 0)
        {
            Errors.Add("This Email is already being used, please use another one");
            return false;
        }
        return true;
    }
}
