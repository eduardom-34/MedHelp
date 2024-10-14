using MedHelpApi.DTOs;
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
    }
}
