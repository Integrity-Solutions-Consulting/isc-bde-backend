using isc.bempleo.be.domain.Models.Request.Documents;
using isc.bempleo.be.domain.Models.Response.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Documents
{
    public interface IDocumentService
    {
        Task<DocumentResponse> UploadDocumentAsync(DocumentUploadForm form);
        Task<DocumentDownloadResponse?> DownloadDocumentAsync(int id);
        Task<DocumentResponse> GetDocumentByIdAsync(int id);
        Task<List<DocumentResponse>> GetAllDocumentsAsync(bool isActive);
    }
}
