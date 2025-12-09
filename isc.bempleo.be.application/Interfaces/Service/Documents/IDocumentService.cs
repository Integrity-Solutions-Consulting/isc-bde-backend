using isc.bempleo.be.application.Services.Documents;
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
        Task<DocumentResponse> GetDocumentByIdentificationAsync(string identification);
        Task<DocumentResponse> CreateDocumentAsync(DocumentRequest request);
    }
}
