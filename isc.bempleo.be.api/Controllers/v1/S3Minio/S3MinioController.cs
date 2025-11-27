using Microsoft.AspNetCore.Mvc;
using Minio;

namespace isc.bempleo.be.api.Controllers.v1.S3Minio
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class S3MinioController : ControllerBase
    {
        private readonly IMinioClient minioClient;

        public S3MinioController(IMinioClient minioClient)
        {
            this.minioClient = minioClient;
        }


    }
}
