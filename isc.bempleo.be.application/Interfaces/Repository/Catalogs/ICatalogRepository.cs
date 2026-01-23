using isc.bempleo.be.domain.Entity.Catalogs;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Models.Response.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Catalogs
{
    public interface ICatalogRepository
    {
        Task<List<ApplicationStatu>> GetAllApplicationStatusAsync(bool isActive);
        Task<List<Career>> GetAllCareerAsync(bool isActive);
        Task<List<Certification>> GetAllCertificationsAsync(bool isActive, string? search);
        Task<List<Document>> GetAllDocumentsAsync(bool isActive);
        Task<List<MaritalStatu>> GetAllMaritalStatusAsync(bool isActive);
        Task<List<Knowledge>> GetAllKnowledgesAsync(bool isActive, string? search);
        Task<List<Skill>> GetAllSkillsAsync(bool isActive, string? search);
        Task<List<Tool>> GetAllToolsAsync(bool isActive, string? search);
        Task<List<Vacancy>> GetAllVacanciesAsync(bool isActive);
        Task<List<StudyStatuResponse>> GetAllStudyStatusAsync();
        Task<List<EducationLevelResponse>> GetAllEducationLevelAsync();
        Task<List<EnglishLevelResponse>> GetEnglishLevelAsync();
    }
}
