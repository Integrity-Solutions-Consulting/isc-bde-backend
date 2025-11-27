using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using Minio;
using Minio.DataModel.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.S3Minio
{
    public class S3NimioRepository : IS3NimioRepository
    {
        private readonly MinioClient _client;

        public S3NimioRepository(MinioClient client)
        {
            _client = client;
        }

        public async Task UploadAsync(string bucket, string objectName, Stream data, string contentType)
        {
            await _client.PutObjectAsync(new PutObjectArgs()
                .WithBucket(bucket)
                .WithObject(objectName)
                .WithStreamData(data)
                .WithObjectSize(data.Length)
                .WithContentType(contentType));
        }

        public async Task<string> GeneratePresignedUrlAsync(string bucket, string objectName, int expiryInSeconds)
        {
            return await _client.PresignedGetObjectAsync(new PresignedGetObjectArgs()
                .WithBucket(bucket)
                .WithObject(objectName)
                .WithExpiry(expiryInSeconds));
        }

    }
}
