using isc.bempleo.be.application.Interfaces.Service.ProfileVacancies;
using isc.bempleo.be.domain.Models.Request.ProfileVacancies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.ProfileVacancies
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProfileVacancyController : Controller
    {
        private readonly IProfileVacancyService _service;

        public ProfileVacancyController(IProfileVacancyService service)
        {
            _service = service;
        }

        [HttpGet("get-all-profile-vacancies")]
        public async Task<ActionResult> GetAllAsync([FromQuery] bool isActive)
        {
            var result = await _service.GetAllAsync(isActive);
            return Ok(result);
        }

        [HttpPost("create-profile-vacancy")]
        public async Task<ActionResult> CreateAsync([FromBody] ProfileVacancyRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }


    }
}
