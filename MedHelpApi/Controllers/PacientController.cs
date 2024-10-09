using MedHelpApi.DTOs;
using MedHelpApi.Models;
using MedHelpApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private IPacientService _pacientService;

        public PacientController( IPacientService pacientService)
        {
            _pacientService = pacientService;
        }

        [HttpGet]
        public async Task<IEnumerable<PacientDto>> Get()
            => await _pacientService.Get();
    }
}
