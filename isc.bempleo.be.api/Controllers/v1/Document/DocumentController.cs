using isc.bempleo.be.application.Interfaces.Service.Documents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Document
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _service;


        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        //[HttpGet("by-identification")]
        //public async Task<ActionResult> GetByIdentification([FromQuery] string identification)
        //{
        //    var result = await _service.GetDocumentByIdentificationAsync(identification);
        //    return Ok(result);
        //}

    }
}
