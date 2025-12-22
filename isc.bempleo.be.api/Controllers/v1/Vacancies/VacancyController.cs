using isc.bempleo.be.application.Interfaces.Service.Vacancies;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Response.Vacancies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Vacancies
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class VacancyController : Controller
    {
        private readonly IVacancyService _service;

        public VacancyController(IVacancyService vacancyService)
        {
            _service = vacancyService;
        }

        [HttpGet("get-all-vacancies")]
        public async Task<ActionResult<SuccessResponse<List<VacancyResponse>>>>GetAllAsync([FromQuery] bool isActive)
        {
            var result = await _service.GetAllAsync(isActive);
            return Ok(result);
        }

    }
}
