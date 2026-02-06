using isc.bempleo.be.application.Interfaces.Service.Booklets;
using isc.bempleo.be.application.Interfaces.Service.Catalogs;
using isc.bempleo.be.application.Services.Booklets;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.domain.Models.Response.Template;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.Booklets
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _bookletService;

        public TemplateController(ITemplateService bookletService)
        {
            _bookletService = bookletService;
        }

        [HttpGet("get-all-template")]
        public async Task<ActionResult<List<SuccessResponse<TemplateResponse>>>> GetBooklet()
        {
            var result = await _bookletService.GetBooklet();
            return Ok(result);
        }

        //[HttpGet("get-all-template-by-id")]
        //public async Task<ActionResult<List<SuccessResponse<TemplateResponse>>>> GetTemplateByIdAsync(int id)
        //{
        //    var result = await _bookletService.GetTemplateById(id);
        //    return Ok(result);
        //}

        [HttpGet("get-template-detail-by-id")]
        public async Task<ActionResult<SuccessResponse<TemplateDetailResponse>>> GetTemplateByIdAsync(int id)
        {
            var result = await _bookletService.GetTemplateById(id);
            return Ok(result);
        }

        [HttpPost("create-template")]
        public async Task<ActionResult<TemplateCreateResponse>> CreateTemplateAsync(
            [FromBody] TemplateRequest request)
        {
            var response = await _bookletService.CreateTemplate(request);
            return Ok(response);
        }


    }
}
