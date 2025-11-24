using isc.bempleo.be.application.Interfaces.Service.Certifications;
using isc.bempleo.be.domain.Models.Request.Certifications;
using isc.bempleo.be.domain.Models.Response.Certifications;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Certifications
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _service;

        public CertificationController(ICertificationService service)
        {
            _service = service;
        }

        [HttpGet("get-all-certifications")]
        public async Task<ActionResult<List<CertificationResponse>>> GetAllAsync(
            [FromQuery] bool isActive = true,
            [FromQuery] string? search = null)
        {
            var result = await _service.GetAllCertificationsAsync(isActive, search);
            return Ok(result);
        }

        [HttpGet("get-by-id-{id}")]
        public async Task<ActionResult<CertificationResponse>> GetById(int id)
        {
            var result = await _service.GetCertificationByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create-certification")]
        public async Task<ActionResult<CertificationResponse>> Create(CertificationRequest request)
        {
            var result = await _service.CreateCertificationAsync(request);
            return Ok(result);
        }

        [HttpPut("update-certification-{id}")]
        public async Task<ActionResult<CertificationResponse>> Update(int id, CertificationRequest request)
        {
            var result = await _service.UpdateCertificationAsync(id, request);
            return Ok(result);
        }

        [HttpPatch("active-inactive-certification-{id}")]
        public async Task<IActionResult> ActiveInactive(int id, [FromQuery] bool status)
        {
            var rows = await _service.ActiveInactiveCertificationAsync(id, status);
            if (rows == 0) return NotFound($"No existe la certificación con ID {id}");
            return NoContent();
        }
    }
}
