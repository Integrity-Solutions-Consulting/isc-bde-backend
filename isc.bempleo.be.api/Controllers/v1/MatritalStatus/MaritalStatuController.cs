using isc.bempleo.be.application.Interfaces.Service.MaritalStatus;
using isc.bempleo.be.application.Services.MaritalStatus;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Response.MaritalStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.MatritalStatus
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMaritalStatuService _maritalStatusService;

        public MaritalStatusController(IMaritalStatuService maritalStatusService)
        {
            _maritalStatusService = maritalStatusService;
        }

        [HttpGet("get-all-marital-status")]
        public async Task<ActionResult<SuccessResponse<List<MaritalStatuResponse>>>> GetAllAsync(bool isActive)
        {
            var result = await _maritalStatusService.GetAllMaritalStatusAsync(isActive);
            return Ok(result);
        }

    }
}