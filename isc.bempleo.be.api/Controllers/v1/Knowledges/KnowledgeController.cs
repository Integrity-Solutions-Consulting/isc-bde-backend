using isc.bempleo.be.application.Interfaces.Service.Knowledges;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Request.Knowledges;
using isc.bempleo.be.domain.Models.Response.Knowledges;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Knowledges
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class KnowledgeController : ControllerBase
    {
        private readonly IKnowledgeService _service;
        public KnowledgeController(IKnowledgeService service)
        {
            _service = service;
        }

        [HttpGet("get-all-knowledges")]
        public async Task<ActionResult<SuccessResponse<List<KnowledgeResponse>>>> GetAllAsync(
        [FromQuery] bool isActive = true,
        [FromQuery] string? search = null)
        {
            var result = await _service.GetAllKnowledgesAsync(isActive, search);
            return Ok(result);
        }


        //[HttpGet("get-by-id-{id}")]
        //public async Task<ActionResult<KnowledgeResponse>> GetById(int id)
        //{
        //    var result = await _service.GetKnowledgeById(id);
        //    return Ok(result);
        //}

        //[HttpPost("create-knowledge")]
        //public async Task<ActionResult<KnowledgeResponse>> Create(KnowledgeRequest request)
        //{
        //    var result = await _service.CreateKnowledgeAsync(request);
        //    return Ok(result);
        //}

        //[HttpPut("update-knowledge-{id}")]
        //public async Task<ActionResult<KnowledgeResponse>> Update(int id, KnowledgeRequest request)
        //{
        //    var result = await _service.UpdateKnowledgeAsync(id, request);
        //    return Ok(result);
        //}

        //[HttpPatch("active-inactive-knowledge-{id}")]
        //public async Task<IActionResult> ActiveInactive(int id, [FromQuery] bool status)
        //{
        //    var rows = await _service.ActiveInactiveKnowledgeAsync(id, status);
        //    if (rows == 0) return NotFound($"No existe el knowledge con ID {id}");
        //    return NoContent();
        //}
    }
}
