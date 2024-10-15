using System.Collections;
using System.Security.Cryptography;
using FluentValidation;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService<UserDto, UserInsertDto, UserUpdateDto> _userService;
        private IValidator<UserInsertDto> _userInsertValidator;
        private IValidator<UserUpdateDto> _userUpdateValidator;

        public UserController(
            [FromKeyedServices("userService")] IUserService<UserDto, UserInsertDto, UserUpdateDto> userService,
            IValidator<UserInsertDto> userInsertValidator,
            IValidator<UserUpdateDto> userUpdateValidator
        )
        {
            _userService = userService;
            _userInsertValidator = userInsertValidator;
            _userUpdateValidator = userUpdateValidator;
        }

// TODO: Add the other endpoint, get, getById etc...
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
            => await _userService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var userDto = await _userService.GetById(id);
            
            return userDto == null ? NotFound() : Ok(userDto);

        }

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

            if( !_userService.ValidateEmail(userInsertDto)){
                return BadRequest(_userService.Errors);
            }
            
            var userDto = await _userService.Add(userInsertDto);

            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }
    }
}
