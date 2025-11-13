using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Documents
{
    public class DocumentRepository : IDocumentRepository
    {

        private readonly DBContext _context;
        public DocumentRepository(DBContext context) => _context = context;

        public async Task<DocumentData> CreateDocumentAsync(DocumentData document)
        {
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<List<DocumentData>> GetAllDocumentsAsync(bool isActive)
        {
            return await _context.Documents
                .Where(d => d.Status == isActive)
                .ToListAsync();
        }

        public async Task<DocumentData?> GetDocumentByIdAsync(int id)
        {
            return await _context.Documents
                .FirstOrDefaultAsync(d => d.Id == id);
        }

    }
}
