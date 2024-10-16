using System.Collections;
using System.Security.Cryptography;
using FluentValidation;
using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.VisualBasic;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService<UserDto, UserInsertDto, UserUpdateDto> _userService;
        private IValidator<UserInsertDto> _userInsertValidator;
        private IValidator<UserUpdateDto> _userUpdateValidator;
        private IValidator<UserLoginDto> _userLoginValidator;
        private readonly ITokenService<UserTokenDto> _tokenService;

        public UserController(
            [FromKeyedServices("userService")] IUserService<UserDto, UserInsertDto, UserUpdateDto> userService,
            IValidator<UserInsertDto> userInsertValidator,
            IValidator<UserUpdateDto> userUpdateValidator,
            IValidator<UserLoginDto> userLoginValidator,
            ITokenService<UserTokenDto> tokenService
        )
        {
            _userService = userService;
            _userInsertValidator = userInsertValidator;
            _userUpdateValidator = userUpdateValidator;
            _userLoginValidator = userLoginValidator;
            _tokenService = tokenService;
        }

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

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, UserUpdateDto userUpdateDto)
        {
            var validationResult = await _userUpdateValidator.ValidateAsync(userUpdateDto);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if( !_userService.Validate(userUpdateDto)){
                return BadRequest(_userService.Errors);
            }

            var userDto = await _userService.Update(id, userUpdateDto);

            return userDto == null ? BadRequest(_userService.Errors) : Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            var userDto = await _userService.Delete(id);
            return userDto == null ? NotFound() : Ok(userDto);
        }

        [HttpPost("login")] //POST: api/user/login
        public async Task<ActionResult<UserLoginDto>> Login(UserLoginDto userLoginDto)
        {
            var validationResult = await _userLoginValidator.ValidateAsync(userLoginDto);
            
            if( !validationResult.IsValid ){
                return BadRequest(validationResult.Errors);
            }

            var userDto = await _userService.Login(userLoginDto.Username!, userLoginDto.Password!);

            if( userDto == null)
            {
                return BadRequest(_userService.Errors);
            }

            return Ok(userDto);
        }
    }
}
