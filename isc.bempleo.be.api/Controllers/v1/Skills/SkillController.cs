using isc.bempleo.be.application.Interfaces.Service.Skills;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Request.Skills;
using isc.bempleo.be.domain.Models.Response.Skills;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace isc.bempleo.be.api.Controllers.v1.Skills
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillController(ISkillService service)
        {
            _service = service;
        }

        [HttpGet("get-all-skills")]
        public async Task<ActionResult<SuccessResponse<List<SkillResponse>>>> GetAllAsync(
            [FromQuery] bool isActive,
            [FromQuery] string? search)
        {
            var result = await _service.GetAllSkillsAsync(isActive, search);
            return Ok(result);
        }

        //[HttpGet("get-by-id-{id}")]
        //public async Task<ActionResult<SkillResponse>> GetById(int id)
        //{
        //    var result = await _service.GetSkillByIdAsync(id);
        //    return Ok(result);
        //}

        [HttpPost("create-skill")]
        public async Task<ActionResult<SuccessResponse<SkillResponse>>> Create([FromBody] SkillRequest request)
        {
            var result = await _service.CreateSkillAsync(request);
            return Ok(result);
        }

        //[HttpPut("update-skill-{id}")]
        //public async Task<ActionResult<SkillResponse>> Update(int id, SkillRequest request)
        //{
        //    var result = await _service.UpdateSkillAsync(id, request);
        //    return Ok(result);
        //}

        //[HttpPatch("active-inactive-skill-{id}")]
        //public async Task<IActionResult> ActiveInactive(int id, [FromQuery] bool status)
        //{
        //    var rows = await _service.ActiveInactiveSkillAsync(id, status);
        //    if (rows == 0) return NotFound($"No existe la skill con ID {id}");
        //    return NoContent();
        //}
    }
}
