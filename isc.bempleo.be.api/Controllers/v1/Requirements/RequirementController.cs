using isc.bempleo.be.application.Interfaces.Service.Requirements;
using isc.bempleo.be.domain.Models.Request.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Request.Requirements;
using isc.bempleo.be.domain.Models.Response.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Response.Requirements;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.Requirements
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RequirementController : ControllerBase
    {
        private readonly IRequirementService _requirementService;

        public RequirementController(IRequirementService requirementService)
        {
            _requirementService = requirementService;
        }

        [HttpPost("create-requirement")]
        public async Task<ActionResult<RequirementResponse>> CreateRequirementAsync([FromBody] RequirementRequest request)
        {
            var response = await _requirementService.CreateRequirement(request);
            return Ok(response);
        }

    }
}
