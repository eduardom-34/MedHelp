using System.Security.Cryptography;
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

        public UserController(
            [FromKeyedServices("userService")] IUserService<UserDto, UserInsertDto, UserUpdateDto> userService
        )
        {
            _userService = userService;
        }


        [HttpPost("register")] //POST: api/user/register
        public async Task<ActionResult<User>> Register(UserInsertDto userInsertDto)
        {
            if( !_userService.Validate(userInsertDto)){
                return BadRequest(_userService.Errors);
            }
            
            var userDto = await _userService.Add(userInsertDto);
            return Ok(userDto);

        }
    }
}
