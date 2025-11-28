using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.S3Minio
{
    public interface IS3NimioRepository
    {
        Task UploadAsync(string bucket, string objectName, Stream data, string contentType);
        Task<string> GeneratePresignedUrlAsync(string bucket, string objectName, int expiryInSeconds);
        Task<bool> ExistsAsync(string bucket, string objectName);
        Task<MemoryStream> DownloadAsync(string bucket, string objectName);
        Task<List<string>> ListObjectsAsync(string bucket, string prefix);

    }
}
