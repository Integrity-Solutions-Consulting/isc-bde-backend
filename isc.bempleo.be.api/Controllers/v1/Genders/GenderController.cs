using isc.bempleo.be.application.Interfaces.Service.Genders;
using isc.bempleo.be.application.Services.Genders;
using isc.bempleo.be.domain.Models.Response.Genders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Genders
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class GenderController : Controller
    {
        private readonly IGenderService _service;

        public GenderController(IGenderService catalogService)
        {
            _service = catalogService;
        }

        [HttpGet("get-all-genders")]
        public async Task<ActionResult<List<GenderResponse>>> GetAllAsync(bool isActive)
        {
            var result = await _service.GetAllGenderAsync(isActive);
            return Ok(result);
        }


    }
}
