using isc.bempleo.be.domain.Entity.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Documents
{
    public interface IDocumentRepository
    {
        Task<DocumentData> CreateDocumentAsync(DocumentData document);
        Task<List<DocumentData>> GetAllDocumentsAsync(bool isActive);
        Task<DocumentData?> GetDocumentByIdAsync(int id);
    }
}
