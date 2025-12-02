using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.application.Services.Profiles;
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
                
        [HttpGet("get-profile-by-email-cedula-code")]
        public async Task<ActionResult<ProfileResponse>> GetProfileByCode(string cedula, string email, string code)
        {
            var result = await _service.GetProfileByCodeAsync(cedula, email, code);
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

        // Pantalla 3 - guardar herramientas, habilidadesBlandas, cursos y certificaciones asociadas al perfil
        [HttpPut("update-profile-technologies-{profileId}")]
        public async Task<IActionResult> UpdateTechnologies(int profileId,ProfileTechnologiesRequest request)
        {
            await _service.UpdateProfileTechnologiesAsync(profileId, request);
            return NoContent();
        }

        // Pantalla 3 - obtener tecnologías asociadas (para editar)
        [HttpGet("get-profile-technologies-{profileId}")]
        public async Task<ActionResult<ProfileTechnologiesRequest>> GetTechnologies(int profileId)
        {
            var result = await _service.GetProfileTechnologiesAsync(profileId);
            return Ok(result);
        }

        // Actualizar datos personales (pantalla 1)
        [HttpPut("update-personal-data")]
        public async Task<ActionResult<ProfileResponse>> UpdateAsync (int id, PersonalDataRequest request)
        {
            var result = await _service.UpdateProfile(request, id);
            return Ok(result);

        }

        // Actualizar formación (pantalla 2)
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
