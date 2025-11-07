using isc.bempleo.be.application.Interfaces.Service;
using isc.bempleo.be.domain.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ISC.BEmpleo.BE.api.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IProjectionService _service;

        public WeatherForecastController (IProjectionService service)
        {
            _service = service;
        }

        [HttpGet("{projectId:int}/get-all-projection-by-projectId")]
        public async Task<ActionResult<List<ProjectionHoursProjectResponse>>> GetProjectionOfProject(int projectId)
        {
            var result = await _service.GetAllProjectionByProjectId(projectId);
            return Ok(result);
        }
    }
}
