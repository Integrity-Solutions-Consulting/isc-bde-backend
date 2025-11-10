using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace isc.bempleo.be.api.Controllers.v1
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

        [HttpPost("create-profile-personal-data")]
        public async Task<ActionResult<ProfileResponse>> CreateAsync (PersonalDataRequest request)
        {
            var result = await _service.CreateProfileAsync(request);
            return Ok(result);
        }
        [HttpPost("create-profile-formation")]
        public async Task<ActionResult<ProfileResponse>> CreateAsync(FormationRequest request, int profileId)
        {
            var result = await _service.CreateProfileAsync(request, profileId);
            return Ok(result);
        }


        [HttpPut("update-personal-data")]
        public async Task<ActionResult<ProfileResponse>> UpdateAsync (int id, PersonalDataRequest request)
        {
            var result = await _service.UpdateProfile(request, id);
            return Ok(result);

        }
        [HttpPut("update-formation")]
        public async Task<ActionResult<ProfileResponse>> UpdateAsync(int id, FormationRequest request)
        {
            var result = await _service.UpdateProfile(request, id);
            return Ok(result);

        }

        [HttpPut("active-inactive-profile")]
        public async Task<ActionResult> ActiveInactiveAsync(int id, [FromQuery] bool isActive)
        {
            await _service.ActivateInactiveResourceAsync(id, isActive);
            return NoContent();
        }





    }
}
