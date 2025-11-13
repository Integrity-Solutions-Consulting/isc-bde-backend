using isc.bempleo.be.application.Interfaces.Service.Documents;
using isc.bempleo.be.domain.Models.Request.Documents;
using isc.bempleo.be.domain.Models.Response.Documents;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _service;
        public DocumentController(IDocumentService service) => _service = service;

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(5 * 1024 * 1024)]
        [RequestFormLimits(MultipartBodyLengthLimit = 5 * 1024 * 1024)]
        public async Task<ActionResult<DocumentResponse>> Upload([FromForm] DocumentUploadForm form)
        {
            var result = await _service.UploadDocumentAsync(form);
            return Ok(result);
        }

        [HttpGet("get-by-id-{id}")]
        public async Task<ActionResult<DocumentResponse>> GetById(int id)
        {
            var result = await _service.GetDocumentByIdAsync(id);
            return result;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<DocumentResponse>>> GetAll([FromQuery] bool isActive = true)
        {
            var result = Ok(await _service.GetAllDocumentsAsync(isActive));
            return result;
        }

        [HttpGet("{id:int}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var doc = await _service.DownloadDocumentAsync(id);

            if (doc == null)
                return NotFound("Documento no encontrado.");

            return File(doc.FileData, doc.ContentType, doc.FileName);
        }


    }
}
