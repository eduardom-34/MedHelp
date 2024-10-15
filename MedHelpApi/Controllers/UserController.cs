using System.Security.Cryptography;
using FluentValidation;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService<UserDto, UserInsertDto, UserUpdateDto> _userService;
        private IValidator<UserInsertDto> _userInsertValidator;

        public UserController(
            [FromKeyedServices("userService")] IUserService<UserDto, UserInsertDto, UserUpdateDto> userService,
            IValidator<UserInsertDto> userInsertValidator
        )
        {
            _userService = userService;
            _userInsertValidator = userInsertValidator;
        }

// TODO: I have to Add validators
// TODO: Add the other endpoing, get, getById etc...

        [HttpPost("register")] //POST: api/user/register
        public async Task<ActionResult<User>> Register(UserInsertDto userInsertDto)
        {
            var validationResult = await  _userInsertValidator.ValidateAsync(userInsertDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if( !_userService.Validate(userInsertDto)){
                return BadRequest(_userService.Errors);
            }
            
            var userDto = await _userService.Add(userInsertDto);
            return Ok(userDto);

        }
    }
}
