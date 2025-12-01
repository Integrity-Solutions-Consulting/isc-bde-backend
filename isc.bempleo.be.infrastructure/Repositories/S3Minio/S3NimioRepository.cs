using Amazon.S3;
using Amazon.S3.Model;
using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.S3Minio
{
    public class S3NimioRepository : IS3NimioRepository
    {
        private readonly IAmazonS3 _s3;

        public S3NimioRepository(IAmazonS3 s3)
        {
            _s3 = s3;
        }

        public async Task UploadAsync(string bucket, string objectName, Stream data, string contentType)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = bucket,
                Key = objectName,
                InputStream = data,
                ContentType = contentType
            };

            await _s3.PutObjectAsync(putRequest);
        }

        public async Task<MemoryStream> DownloadAsync(string bucket, string objectName)
        {
            var response = await _s3.GetObjectAsync(bucket, objectName);

            var ms = new MemoryStream();
            await response.ResponseStream.CopyToAsync(ms);
            ms.Position = 0;

            return ms;
        }

        public async Task<bool> ExistsAsync(string bucket, string objectName)
        {
            try
            {
                await _s3.GetObjectMetadataAsync(bucket, objectName);
                return true;
            }
            catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public async Task<string> GeneratePresignedUrlAsync(string bucket, string objectName, int expirySeconds)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = objectName,
                Expires = DateTime.UtcNow.AddSeconds(expirySeconds)
            };

            return _s3.GetPreSignedURL(request);
        }

    }

}