using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Exceptions;
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
        private readonly DBContext _dbContext;


        public DocumentRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Document>> GetAllDocumentsAsync(bool isActive)
        {
            return await _dbContext.Documents
                .AsNoTracking()
                .Where(d => d.Status == isActive)
                .ToListAsync();
        }

        public async Task<Document> CreateAsync(Document document)
        {
            _dbContext.Documents.Add(document);
            await _dbContext.SaveChangesAsync();
            return document;
        }

    }
}