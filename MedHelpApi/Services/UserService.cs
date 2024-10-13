using System;
using MedHelpApi.DTOs;
using MedHelpApi.Services.Interfaces;

namespace MedHelpApi.Services;

public class UserService : IUserService<UserDto, UserInsertDto, UserUpdateDto>
{
    public List<string> Errors => throw new NotImplementedException();

    public Task<IEnumerable<UserDto>> Get()
    {
        throw new NotImplementedException();
    }
    public Task<UserDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Add(UserInsertDto specialtyInsertDto)
    {
        throw new NotImplementedException();
    }
    public Task<UserDto> Update(int id, UserUpdateDto specialtyUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Delete(int id)
    {
        throw new NotImplementedException();
    }
    public bool Validate(UserInsertDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Validate(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
