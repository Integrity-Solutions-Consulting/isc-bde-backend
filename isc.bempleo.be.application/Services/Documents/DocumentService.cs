using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.application.Interfaces.Service.Documents;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Models.Request.Documents;
using isc.bempleo.be.domain.Models.Response.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IMapper _mapper;
        private const string HardcodedPath = "C:\\BEmpleo\\Documentos"; 

        public DocumentService(IDocumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DocumentResponse> UploadDocumentAsync(DocumentUploadForm form)
        {
            if (form?.File == null || form.File.Length == 0)
                throw new Exception("Debe adjuntar un archivo válido.");

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await form.File.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            // Validaciones
            if (fileBytes.Length > 5 * 1024 * 1024)
                throw new Exception("El archivo no puede superar los 5 MB.");

            var fileName = form.File.FileName.Trim();
            var ext = Path.GetExtension(fileName)?.ToLowerInvariant();
            if (ext is not (".pdf" or ".doc" or ".docx"))
                throw new Exception("Solo se permiten archivos PDF o Word.");

            // Evitar ejecutables
            if (fileBytes.Length >= 2 && fileBytes[0] == 0x4D && fileBytes[1] == 0x5A)
                throw new Exception("Archivo potencialmente malicioso (firma 'MZ').");

            var processName = string.IsNullOrWhiteSpace(form.ProcessName)
                ? "Ofertas laborales"
                : form.ProcessName.Trim();

            var entity = new DocumentData
            {
                ProcessId = form.ProcessId,
                ProcessName = processName,
                FileName = fileName,
                FileExtension = ext,
                FilePath = HardcodedPath,
                FileData = fileBytes,
                Status = true
            };

            var saved = await _repository.CreateDocumentAsync(entity);
            return _mapper.Map<DocumentResponse>(saved);
        }

        public async Task<DocumentResponse> GetDocumentByIdAsync(int id)
        {
            var doc = await _repository.GetDocumentByIdAsync(id)
                ?? throw new Exception("No se encontró el documento.");
            return _mapper.Map<DocumentResponse>(doc);
        }

        public async Task<List<DocumentResponse>> GetAllDocumentsAsync(bool isActive)
        {
            var list = await _repository.GetAllDocumentsAsync(isActive);
            return _mapper.Map<List<DocumentResponse>>(list);
        }

        public async Task<DocumentDownloadResponse?> DownloadDocumentAsync(int id)
        {
            var doc = await _repository.GetDocumentByIdAsync(id);

            if (doc == null || doc.FileData == null || doc.FileData.Length == 0)
                return null;

            var contentType = GetContentTypeFromExtension(doc.FileExtension);

            return new DocumentDownloadResponse
            {
                Id = doc.Id,
                FileName = doc.FileName,
                ContentType = contentType,
                FileData = doc.FileData
            };
        }

        private static string GetContentTypeFromExtension(string? ext)
        {
            ext = ext?.ToLowerInvariant();

            return ext switch
            {
                ".pdf" => "application/pdf",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                _ => "application/octet-stream"
            };
        }


    }
}
