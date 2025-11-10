using isc.bempleo.be.application.Interfaces.Service.Tools;
using isc.bempleo.be.domain.Models.Request.Tools;
using isc.bempleo.be.domain.Models.Response.Tools;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Tools
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _service;

        public ToolController(IToolService service)
        {
            _service = service;
        }

        [HttpGet("get-all-tools")]
        public async Task<ActionResult<List<ToolResponse>>> GetAllAsync(
            [FromQuery] bool isActive = true,
            [FromQuery] string? search = null)
        {
            var result = await _service.GetAllToolsAsync(isActive, search);
            return Ok(result);
        }


        [HttpGet("get-by-id-{id}")]
        public async Task<ActionResult<ToolResponse>> GetById(int id)
        {
            var result = await _service.GetToolById(id);
            return Ok(result);
        }

        [HttpPost("create-tool")]
        public async Task<ActionResult<ToolResponse>> Create(ToolRequest request)
        {
            var result = await _service.CreateToolAsync(request);
            return Ok(result);
        }

        [HttpPut("update-tool-{id}")]
        public async Task<ActionResult<ToolResponse>> Update(int id, ToolRequest request)
        {
            var result = await _service.UpdateToolAsync(id, request);
            return Ok(result);
        }

        [HttpPatch("active-inactive-tool-{id}")]
        public async Task<IActionResult> ActiveInactive(int id, [FromQuery] bool status)
        {
            var rows = await _service.ActiveInactiveToolAsync(id, status);
            if (rows == 0) return NotFound($"No existe la herramienta con ID {id}");
            return NoContent();
        }
    }
}
