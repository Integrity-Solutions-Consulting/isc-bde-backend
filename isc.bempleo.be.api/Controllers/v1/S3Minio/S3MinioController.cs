using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using isc.bempleo.be.application.Interfaces.Service.S3Minio;
using Microsoft.AspNetCore.Mvc;
using Minio;

namespace isc.bempleo.be.api.Controllers.v1.S3Minio
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class S3MinioController : ControllerBase
    {
        private readonly IS3MinioService _service;

        public S3MinioController(IS3MinioService service)
        {
            _service = service;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromQuery] string bucket, [FromQuery] string objectName)
        {
            using var stream = file.OpenReadStream();
            await _service.UploadPdfAsync(bucket, objectName, stream);

            return Ok(new { Message = "Archivo subido exitosamente", Object = objectName });
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download([FromQuery] string bucket, [FromQuery] string objectName)
        {
            var memory = await _service.DownloadAsync(bucket, objectName);
            return File(memory.ToArray(), "application/pdf", objectName);
        }

        // PRESIGNED URL
        [HttpGet("presigned")]
        public async Task<IActionResult> GetPresignedUrl([FromQuery] string bucket, [FromQuery] string objectName)
        {
            var url = await _service.GetPresignedUrlAsync(bucket, objectName, expiresInSeconds: 3600);
            return Ok(new { Url = url });
        }

        // EXISTE?
        [HttpGet("exists-cv")]
        public async Task<IActionResult> Exists([FromQuery] string bucket, [FromQuery] string objectName)
        {
            var exists = await _service.ExistsAsync(bucket, objectName);
            return Ok(new { Exists = exists });
        }

        // LISTAR POR PREFIJO
        [HttpGet("list-cvs")]
        public async Task<IActionResult> List([FromQuery] string bucket, [FromQuery] string prefix)
        {
            var list = await _service.ListObjectsAsync(bucket, prefix);
            return Ok(list);
        }
    }
}
