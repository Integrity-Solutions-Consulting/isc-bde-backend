using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.S3Minio
{
    public interface IS3MinioService
    {
        Task UploadAsync(string bucket, string objectName, Stream data, string contentType, int profileId);
        Task<MemoryStream> DownloadAsync(string bucket, string objectName);
        //Task<bool> ExistsAsync(string bucket, string objectName);
        //Task<string> GeneratePresignedUrlAsync(string bucket, string objectName, int expiresInSeconds);
    }
}
