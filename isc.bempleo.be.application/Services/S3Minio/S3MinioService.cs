using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.application.Interfaces.Repository.S3Minio;
using isc.bempleo.be.application.Interfaces.Service.S3Minio;
using isc.bempleo.be.domain.Entity.Documents;
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
        private readonly IDocumentRepository _documentRepository;
        private const long MaxFileSizeBytes = 5 * 1024 * 1024;
        private static readonly string[] AllowedContentTypes = new[]
        {
            "application/pdf",
            "application/msword",
            "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        };
        private static readonly string[] AllowedExtensions = new[]
        {
            ".pdf",
            ".doc",
            ".docx"
        };

        public S3MinioService(IS3NimioRepository repository, IDocumentRepository documentRepository)
        {
            _repository = repository;
            _documentRepository = documentRepository;
        }

        public async Task UploadAsync(string bucket, string objectName, Stream data, string contentType)
        {
            if (data.CanSeek && data.Length > MaxFileSizeBytes)
                throw new Exception("El archivo excede el tamaño máximo permitido de 5 MB.");

            if (!AllowedContentTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase))
                throw new Exception("Solo se permiten archivos PDF o Word (.pdf, .doc, .docx).");

            var extension = Path.GetExtension(objectName);
            if (string.IsNullOrWhiteSpace(extension) ||
                !AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                throw new Exception("La extensión del archivo no es válida. Solo se permiten .pdf, .doc y .docx.");

            var document = new Document
            {
                Document_name = objectName
            };

            await _documentRepository.CreateAsync(document);
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