using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using Minio;
using Minio.ApiEndpoints;
using Minio.DataModel;
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

        public async Task<bool> ExistsAsync(string bucket, string objectName)
        {
            try
            {
                await _client.StatObjectAsync(new StatObjectArgs()
                    .WithBucket(bucket)
                    .WithObject(objectName));

                return true;
            }
            catch (Minio.Exceptions.ObjectNotFoundException)
            {
                return false;
            }
        }


        public async Task<MemoryStream> DownloadAsync(string bucket, string objectName)
        {
            var ms = new MemoryStream();

            await _client.GetObjectAsync(new GetObjectArgs()
                .WithBucket(bucket)
                .WithObject(objectName)
                .WithCallbackStream(stream =>
                {
                    stream.CopyTo(ms);
                }));

            ms.Position = 0;
            return ms;
        }

        public async Task<List<string>> ListObjectsAsync(string bucket, string prefix)
        {
            var results = new List<string>();

            var listArgs = new ListObjectsArgs()
                .WithBucket(bucket)
                .WithPrefix(prefix)
                .WithRecursive(true);

            var asyncEnumerable = _client.ListObjectsEnumAsync(listArgs);

            await foreach (var item in asyncEnumerable)
            {
                results.Add(item.Key);
            }

            return results;
        }



    }

    // Helper para manejar callbacks del listado
    public class MinioCallbackObserver<T> : IObserver<T>
    {
        private readonly Action<T>? _onNext;
        private readonly Action<Exception>? _onError;
        private readonly Action? _onCompleted;

        public MinioCallbackObserver(Action<T>? onNext, Action<Exception>? onError, Action? onCompleted)
        {
            _onNext = onNext;
            _onError = onError;
            _onCompleted = onCompleted;
        }

        public void OnCompleted() => _onCompleted?.Invoke();

        public void OnError(Exception error) => _onError?.Invoke(error);

        public void OnNext(T value) => _onNext?.Invoke(value);
    }

}

