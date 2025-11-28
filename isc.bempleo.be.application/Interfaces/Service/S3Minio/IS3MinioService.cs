using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.S3Minio
{
    public interface IS3MinioService
    {
        Task UploadPdfAsync(string bucket, string objectName, Stream data);
        Task<string> GetPresignedUrlAsync(string bucket, string objectName, int expiresInSeconds);
        Task<bool> ExistsAsync(string bucket, string objectName);
        Task<MemoryStream> DownloadAsync(string bucket, string objectName);
        Task<List<string>> ListObjectsAsync(string bucket, string prefix);
    }
}
