using isc.bempleo.be.application.Interfaces.Service.Careers;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Response.Careers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Career
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CareerController : Controller
    {
        private readonly ICareerService _service;

        public CareerController(ICareerService careerService)
        {
            _service = careerService;
        }

        [HttpGet("get-all-careers")]
        public async Task<ActionResult<SuccessResponse<List<CareerResponse>>>> GetAllAsync(bool isActive)
        {
            var result = await _service.GetAllAsync(isActive);
            return Ok(result);
        }


    }
}
