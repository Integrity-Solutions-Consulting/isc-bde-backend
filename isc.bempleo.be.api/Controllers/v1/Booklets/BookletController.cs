using isc.bempleo.be.application.Interfaces.Service.Booklets;
using isc.bempleo.be.application.Interfaces.Service.Catalogs;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace isc.bempleo.be.api.Controllers.v1.Booklets
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BookletController : ControllerBase
    {
        private readonly IBookletService _bookletService;

        public BookletController(IBookletService bookletService)
        {
            _bookletService = bookletService;
        }

        [HttpGet("get-booklet-by-id")]
        public async Task<ActionResult<List<SuccessResponse<BookletResponse>>>> GetBooklet()
        {
            var result = await _bookletService.GetBooklet();
            return Ok(result);
        }

        [HttpPost("create-booklet")]
        public async Task<ActionResult<SuccessResponse<BookletResponse>>> CreateBooklet([FromBody] BookletRequest request)
        {
            var result = await _bookletService.CreateBooklet(request);
            return Ok(result);
        }
    }
}
