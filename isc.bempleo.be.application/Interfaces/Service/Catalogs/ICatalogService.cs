using isc.bempleo.be.domain.Models.Response.Catalogs;
using isc.bempleo.be.domain.Models.Response.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Catalogs
{
    public interface ICatalogService
    {
        Task<List<ApplicationStatuResponse>> GetAllApplicationStatus(bool isActive);
        Task<List<CareerResponse>> GetAllCareer(bool isActive);
        Task<List<CertificationResponse>> GetAllCertifications(bool isActive, string? search);
        Task<List<DocumentResponse>> GetAllDocuments(bool isActive);
        Task<List<KnowledgeResponse>> GetAllKnowledges(bool isActive, string? search);
        Task<List<MaritalStatuResponse>> GetAllMaritalStatus(bool isActive);
        Task<List<SkillResponse>> GetAllSkills(bool isActive, string? search);
        Task<List<ToolResponse>> GetAllTools(bool isActive, string? search);
        Task<List<VacancyResponse>> GetAllVacancies(bool isActive);
        Task<List<StudyStatuResponse>> GetAllStudyStatus();
    }
}
