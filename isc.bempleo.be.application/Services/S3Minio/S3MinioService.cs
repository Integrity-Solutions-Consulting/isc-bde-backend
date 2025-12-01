using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using isc.bempleo.be.application.Interfaces.Service.S3Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.S3Minio
{
    public class S3MinioService : IS3MinioService
    {
        private readonly IS3NimioRepository _repository;

        public S3MinioService(IS3NimioRepository repository)
        {
            _repository = repository;
        }

        public async Task UploadAsync(string bucket, string objectName, Stream data, string contentType)
        {
            await _repository.UploadAsync(bucket, objectName, data, contentType);
        }

        public async Task<MemoryStream> DownloadAsync(string bucket, string objectName)
        {
            return await _repository.DownloadAsync(bucket, objectName);
        }

        public async Task<bool> ExistsAsync(string bucket, string objectName)
        {
            return await _repository.ExistsAsync(bucket, objectName);
        }

        public async Task<string> GeneratePresignedUrlAsync(string bucket, string objectName, int expiresInSeconds)
        {
            return await _repository.GeneratePresignedUrlAsync(bucket, objectName, expiresInSeconds);
        }
    }
}