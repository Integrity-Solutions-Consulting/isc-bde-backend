using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Models.Request.Profiles;
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
        [HttpGet("get-by-email-cedula")]
        public async Task<ActionResult<ProfileResponse>> GetById (string cedula, string email)
        {
            var result = await _service.GetProfileByCedulaEmail(cedula, email);
            return Ok(result);
        }

        // Pantalla 1 del formulario
        [HttpPost("create-profile-personal-data")]
        public async Task<ActionResult<ProfileResponse>> CreateAsync (PersonalDataRequest request)
        {
            var result = await _service.CreateProfileAsync(request);
            return Ok(result);
        }
        // Pantalla 2 del formulario
        [HttpPost("create-profile-formation")]
        public async Task<ActionResult<ProfileResponse>> CreateAsync(FormationRequest request, int profileId)
        {
            var result = await _service.CreateProfileAsync(request, profileId);
            return Ok(result);
        }
        // Pantalla 3 del formulario
        [HttpPost("create-profile-skills")]
        public async Task<ActionResult<SkillsResponse>> CreateSkillsAsync(SkillsRequest request, int profileId)
        {
            var result = await _service.CreateProfileAsync(request, profileId);
            return Ok(result);
        }

        [HttpGet("get-profile-skills")]
        public async Task<ActionResult<SkillsResponse>> GetProfileSkills(int profileId)
        {
            var result = await _service.GetProfileSkillsAsync(profileId);
            return Ok(result);
        }


        //[HttpPut("update-profile-skills")]
        //public async Task<ActionResult<SkillsResponse>> UpdateSkillsAsync(SkillsRequest request, int profileId)
        //{
        //    var result = await _service.UpdateProfile(request, profileId);
        //    return Ok(result);
        //}

        //[HttpGet("get-profile-skills/{profileId}")]
        //public async Task<ActionResult<SkillsResponse>> GetSkillsAsync(int profileId)
        //{
        //    var result = await _service.GetProfileSkillsAsync(profileId);
        //    return Ok(result);
        //}



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

        [HttpPut("update-profile-skills")]
        public async Task<ActionResult<SkillsResponse>> UpdateSkillsAsync(int profileId, SkillsRequest request)

        {
            var result = await _service.UpdateProfileSkillsAsync(request, profileId);
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
