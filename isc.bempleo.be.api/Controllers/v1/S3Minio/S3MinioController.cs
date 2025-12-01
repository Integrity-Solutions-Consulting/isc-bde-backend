using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using isc.bempleo.be.application.Interfaces.Service.S3Minio;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Upload(
            string name,
            IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var newFileName = $"{name}{Path.GetExtension(file.FileName)}";

            await _service.UploadAsync(
                "cvs",
                newFileName,
                stream,
                file.ContentType
            );
            return Ok("Archivo subido");
        }



        // DESCARGAR ARCHIVO
        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            var stream = await _service.DownloadAsync("cvs", fileName);

            return File(stream.ToArray(), "application/octet-stream", fileName);
        }

        // VERIFICAR EXISTENCIA
        [HttpGet("exists/{fileName}")]
        public async Task<IActionResult> Exists(string fileName)
        {
            bool exists = await _service.ExistsAsync("cvs", fileName);
            return Ok(exists);
        }

        // URL FIRMADA
        [HttpGet("url/{fileName}")]
        public async Task<IActionResult> GetUrl(string fileName)
        {
            var url = await _service.GeneratePresignedUrlAsync("cvs", fileName, 3600);
            return Ok(url);
        }
    }
}
