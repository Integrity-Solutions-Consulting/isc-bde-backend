using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Models.Response.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace isc.bempleo.be.api.Controllers.v1.Profiles
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _service;


        public ProfileController (IProfileService service)
        {
            _service = service;
        }

        [HttpGet("get-all-profiles")]
        public async Task<ActionResult<List<ProfileResponse>>> GetAllAsync ([FromQuery] bool isActive)
        {
            var result = await _service.GetAllProfileAsync(isActive);
            return Ok(result);

        }
        [HttpGet("get-by-id-{id}")]
        public async Task<ActionResult<ProfileResponse>> GetById (int id)
        {
            var result = await _service.GetProfileById(id);
            return Ok(result);
        }



        
    }
}
