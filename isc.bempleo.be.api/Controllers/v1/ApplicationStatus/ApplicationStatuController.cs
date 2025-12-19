using isc.bempleo.be.application.Interfaces.Service.ApplicationStatus;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Response.ApplicationStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.ApplicationStatus
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ApplicationStatuController : Controller
    {
        private readonly IApplicationStatuService _service;

        public ApplicationStatuController(IApplicationStatuService service)
        {
            _service = service;
        }

        [HttpGet("get-all-application-status")]
        public async Task<ActionResult<SuccessResponse<List<ApplicationStatuResponse>>>> GetAllAsync([FromQuery] bool isActive)
        {
            var result = await _service.GetAllAsync(isActive);
            return Ok(result);
        }

    }
}
