using isc.bempleo.be.application.Interfaces.Repository.Documents;
using isc.bempleo.be.domain.Entity.Certifications;
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
            try
            {
                return await _dbContext.Documents
                    .Where(d => d.Status == isActive)
                    // .Include(d => d.Profile) // Descomenta si necesitas datos del perfil
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Documents.",
                    500,
                    ex
                );
            }
        }

        public async Task<Document> CreateAsync(Document document)
        {
            _dbContext.Documents.Add(document);
            await _dbContext.SaveChangesAsync();
            return document;
        }

    }
}