using MedHelpApi.DTOs;
using MedHelpApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private MedHelpContext _context;

        public SpecialtyController(MedHelpContext context){
            _context = context;
        }

        // [HttpGet]
        // public async Task<IEnumerable<SpecialtyDto>> Get() => 
        // await _context.Specialty.Select(s => new SpecialtyDto{
        //     Id = s.ID
        // }).ToListAsync();

    }
}
