using isc.bempleo.be.application.Interfaces.Service.Experiences;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Request.Experiences;
using isc.bempleo.be.domain.Models.Response.Experiences;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.Experiences
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _service;

        public ExperienceController(IExperienceService service)
        {
            _service = service;
        }

        [HttpGet("get-all-experiences-by-profile")]
        public async Task<ActionResult<SuccessResponse<List<ExperienceResponse>>>> GetAllAsync(
            [FromQuery] int profileId,
            [FromQuery] bool isActive = true,
            [FromQuery] string? search = null)
        {
            var result = await _service.GetAllExperiencesAsync(profileId, isActive, search);
            return Ok(result);
        }

        [HttpPost("create-experience")]
        public async Task<ActionResult<SuccessResponse<ExperienceResponse>>> Create([FromBody] ExperienceRequest request)
        {
            var result = await _service.CreateExperienceAsync(request);
            return Ok(result);
        }

        //[HttpPut("update-experience-{id}")]
        //public async Task<ActionResult<ExperienceResponse>> Update(int id, [FromBody] ExperienceUpdateRequest request)
        //{
        //    var result = await _service.UpdateExperienceAsync(id, request);
        //    return Ok(result);
        //}

        //[HttpPatch("active-inactive-experience-{id}")]
        //public async Task<IActionResult> ActiveInactive(int id, [FromQuery] bool status)
        //{
        //    var rows = await _service.ActiveInactiveExperienceAsync(id, status);
        //    if (rows == 0) return NotFound($"No existe la experiencia con ID {id}");
        //    return NoContent();
        //}


    }
}
