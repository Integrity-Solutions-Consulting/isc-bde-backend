using isc.bempleo.be.application.Interfaces.Repository.Catalogs;
using isc.bempleo.be.domain.Entity.Catalogs;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.Catalogs;
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
            return await _dbContext.ApplicationStatus
                .AsNoTracking()
                .Where(a => a.Status == isActive)
                .ToListAsync();
        }

        public async Task<List<Career>> GetAllCareerAsync(bool isActive)
        {
            return await _dbContext.Careers
                .AsNoTracking()
                .Where(c => c.Status == isActive)
                .ToListAsync();
        }

        public async Task<List<Certification>> GetAllCertificationsAsync(bool isActive, string? search)
        {
            var normalized = search?.Trim().ToLowerInvariant();

            return await _dbContext.Certifications
                .AsNoTracking()
                .Where(c => c.Status == isActive)
                .Where(c => string.IsNullOrWhiteSpace(normalized) ||
                            (c.CertificationName != null && c.CertificationName.ToLower().Contains(normalized)))
                .OrderBy(c => c.CertificationName)
                .ToListAsync();
        }

        public async Task<List<Document>> GetAllDocumentsAsync(bool isActive)
        {
            return await _dbContext.Documents
                .AsNoTracking()
                .Where(d => d.Status == isActive)
                .ToListAsync();
        }

        public async Task<List<Knowledge>> GetAllKnowledgesAsync(bool isActive, string? search)
        {
            var normalizedSearch = search?.Trim().ToLowerInvariant();

            return await _dbContext.Knowledges
                .AsNoTracking()
                .Where(k => k.Status == isActive)
                .Where(k => string.IsNullOrWhiteSpace(normalizedSearch) ||
                            (k.KnowledgeName != null && k.KnowledgeName.ToLower().Contains(normalizedSearch)))
                .OrderBy(k => k.KnowledgeName)
                .ToListAsync();
        }

        public async Task<List<MaritalStatu>> GetAllMaritalStatusAsync(bool isActive)
        {
            return await _dbContext.MaritalStatus
                .AsNoTracking()
                .Where(m => m.Status == isActive)
                .ToListAsync();
        }

        public async Task<List<Skill>> GetAllSkillsAsync(bool isActive, string? search)
        {
            var normalized = search?.Trim().ToLowerInvariant();

            return await _dbContext.Skills
                .AsNoTracking()
                .Where(s => s.Status == isActive)
                .Where(s => string.IsNullOrWhiteSpace(normalized) ||
                            (s.SkillName != null && s.SkillName.ToLower().Contains(normalized)))
                .OrderBy(s => s.SkillName)
                .ToListAsync();
        }

        public async Task<List<StudyStatuResponse>> GetAllStudyStatusAsync()
        {
            return await _dbContext
                .Set<StudyStatuResponse>()
                .FromSqlRaw("CALL SP_GetEducationStatus()")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Tool>> GetAllToolsAsync(bool isActive, string? search)
        {
            var normalized = search?.Trim().ToLowerInvariant();

            return await _dbContext.Tools
                .AsNoTracking()
                .Where(t => t.Status == isActive)
                .Where(t => string.IsNullOrWhiteSpace(normalized) ||
                            (t.ToolName != null && t.ToolName.ToLower().Contains(normalized)))
                .OrderBy(t => t.ToolName)
                .ToListAsync();
        }

        public async Task<List<Vacancy>> GetAllVacanciesAsync(bool isActive)
        {
            return await _dbContext.Vacancies
                .Where(v => v.Status == isActive)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<EducationLevelResponse>> GetAllEducationLevelAsync()
        {
            return await _dbContext
                .Set<EducationLevelResponse>()
                .FromSqlRaw("CALL SP_GetEducationLevel()")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<EnglishLevelResponse>> GetEnglishLevelAsync()
        {
            return await _dbContext
                .Set<EnglishLevelResponse>()
                .FromSqlRaw("CALL SP_GetEnglishLevel()")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<WorkCityResponse>> GetWorkCityAsync()
        {
            return await _dbContext
                .Set<WorkCityResponse>()
                .FromSqlRaw("CALL SP_GetWorkCity()")
                .AsNoTracking()
                .ToListAsync();

        }
    }
}
