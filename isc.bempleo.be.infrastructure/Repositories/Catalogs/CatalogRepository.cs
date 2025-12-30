using isc.bempleo.be.application.Interfaces.Repository.Catalogs;
using isc.bempleo.be.domain.Entity.Catalogs;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Catalogs
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly DBContext _dbContext;

        public CatalogRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ApplicationStatu>> GetAllApplicationStatusAsync(bool isActive)
        {
            try
            {
                var statuses = await _dbContext.ApplicationStatus
                    .Where(a => a.Status == isActive)
                    .ToListAsync();

                return statuses;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar ApplicationStatus.",
                    500,
                    ex
                );
            }
        }

        public async Task<List<Career>> GetAllCareerAsync(bool isActive)
        {
            try
            {
                var careers = await _dbContext.Careers.Where(c => c.Status == isActive).ToListAsync();
                return careers;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Careers.",
                    500,
                    ex
                );
            }
        }

        public async Task<List<Certification>> GetAllCertificationsAsync(bool isActive, string? search)
        {
            try
            {
                var query = _dbContext.Certifications
                    .AsQueryable()
                    .Where(c => c.Status == isActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var normalized = search.Trim().ToLowerInvariant();
                    query = query.Where(c =>
                        c.CertificationName != null &&
                        c.CertificationName.ToLower().Contains(normalized));
                }

                query = query.OrderBy(c => c.CertificationName);

                return await query.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Certifications.",
                    500,
                    ex
                );
            }
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

        public async Task<List<Knowledge>> GetAllKnowledgesAsync(bool isActive, string? search)
        {
            try
            {
                var query = _dbContext.Knowledges
                    .AsQueryable()
                    .Where(k => k.Status == isActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var normalizedSearch = search.Trim().ToLowerInvariant();

                    query = query.Where(k =>
                        k.KnowledgeName != null &&
                        k.KnowledgeName.ToLower().Contains(normalizedSearch)
                    );
                }

                return await query
                    .OrderBy(k => k.KnowledgeName)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Knowledges.",
                    500,
                    ex
                );
            }
        }

        public async Task<List<MaritalStatu>> GetAllMaritalStatusAsync(bool isActive)
        {
            try
            {
                return await _dbContext.MaritalStatus
                    .Where(m => m.Status == isActive)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar MaritalStatus.",
                    500,
                    ex
                );
            }
        }

        public async Task<List<Skill>> GetAllSkillsAsync(bool isActive, string? search)
        {
            try
            {
                var query = _dbContext.Skills
                    .Where(s => s.Status == isActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var normalized = search.Trim().ToLowerInvariant();
                    query = query.Where(s =>
                        s.SkillName != null &&
                        s.SkillName.ToLower().Contains(normalized));
                }

                return await query
                    .OrderBy(s => s.SkillName)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Skills.",
                    500,
                    ex
                );
            }
        }

        public async Task<List<Tool>> GetAllToolsAsync(bool isActive, string? search)
        {
            try
            {
                var query = _dbContext.Tools
                    .Where(t => t.Status == isActive);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var normalized = search.Trim().ToLowerInvariant();
                    query = query.Where(t =>
                        t.ToolName != null &&
                        t.ToolName.ToLower().Contains(normalized));
                }

                return await query
                    .OrderBy(t => t.ToolName)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Tools.",
                    500,
                    ex
                );
            }
        }

        public async Task<List<Vacancy>> GetAllVacanciesAsync(bool isActive)
        {
            try
            {
                return await _dbContext.Vacancies
                    .Where(v => v.Status == isActive)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Vacancies.",
                    500,
                    ex
                );
            }
        }



    }
}
