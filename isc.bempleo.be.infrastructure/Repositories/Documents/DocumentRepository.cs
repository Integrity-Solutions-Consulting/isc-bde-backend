using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.domain.Entity.Certifications;
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
        private readonly DBContext _dbContext;


        public DocumentRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Document> CreateAsync(Document document)
        {
            _dbContext.Documents.Add(document);
            await _dbContext.SaveChangesAsync();
            return document;
        }

        public async Task<Document> GetByProfileId(int profileId)
        {
            return await _dbContext.Documents
                .FirstOrDefaultAsync(d => d.ProfileId == profileId);
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _dbContext.Documents.ToListAsync();
        }

        public async Task<Document> UpdateAsync(Document document)
        {
            _dbContext.Entry(document).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return document;
        }

    }
}
