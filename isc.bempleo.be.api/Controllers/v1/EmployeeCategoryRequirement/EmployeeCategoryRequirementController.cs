using isc.bempleo.be.application.Interfaces.Service.Contacts;
using isc.bempleo.be.application.Interfaces.Service.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Request.Contacts;
using isc.bempleo.be.domain.Models.Request.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Response.Contacts;
using isc.bempleo.be.domain.Models.Response.EmployeeCategoryRequirement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.EmployeeCategoryRequirement
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EmployeeCategoryRequirementController : ControllerBase
    {
        private readonly IEmployeeCategoryRequirementService _requirementService;

        public EmployeeCategoryRequirementController(IEmployeeCategoryRequirementService requirementService)
        {
            _requirementService = requirementService;
        }

        [HttpPost("employee-category-requirement")]
        public async Task<ActionResult<List<EmployeeCategoryRequirementResponse>>> CreateBatchAsync([FromBody] List<EmployeeCategoryRequirementRequest> requestList)
        {
            var response = await _requirementService.AddEmployeeCategoryRequirements(requestList);
            return Ok(response);
        }

    }
}
