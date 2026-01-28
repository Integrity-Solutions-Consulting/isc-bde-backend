using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Catalogs;
using isc.bempleo.be.application.Interfaces.Service.Catalogs;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.Catalogs;
using isc.bempleo.be.domain.Models.Response.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Catalogs
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;

        public CatalogService(ICatalogRepository catalogRepository, IMapper mapper)
        {
            _catalogRepository = catalogRepository;
            _mapper = mapper;
        }

        public async Task<List<ApplicationStatuResponse>> GetAllApplicationStatus(bool isActive)
        {
            var statuses = await _catalogRepository.GetAllApplicationStatusAsync(isActive);

            if (statuses == null)
                throw new ServerFaultException("Error al obtener los estados de aplicación (resultado null).");

            if (!statuses.Any())
                return new List<ApplicationStatuResponse>();

            return _mapper.Map<List<ApplicationStatuResponse>>(statuses);
        }

        public async Task<List<CareerResponse>> GetAllCareer(bool isActive)
        {
            var careers = await _catalogRepository.GetAllCareerAsync(isActive);

            if (careers == null)
                throw new ServerFaultException("Error al obtener las carreras (resultado null).");

            if (!careers.Any())
                return new List<CareerResponse>();

            return _mapper.Map<List<CareerResponse>>(careers);
        }

        public async Task<List<CertificationResponse>> GetAllCertifications(bool isActive, string? search)
        {
            var entities = await _catalogRepository.GetAllCertificationsAsync(isActive, search);

            if (entities == null)
                throw new ServerFaultException("Error al obtener las certificaciones (resultado null).");

            if (!entities.Any())
                return new List<CertificationResponse>();

            return _mapper.Map<List<CertificationResponse>>(entities);
        }

        public async Task<List<DocumentResponse>> GetAllDocuments(bool isActive)
        {
            var allDocuments = await _catalogRepository.GetAllDocumentsAsync(isActive);

            if (allDocuments == null)
                throw new ServerFaultException("Error al obtener los documentos (resultado null).");

            if (!allDocuments.Any())
                return new List<DocumentResponse>();

            return _mapper.Map<List<DocumentResponse>>(allDocuments);
        }

        public async Task<List<KnowledgeResponse>> GetAllKnowledges(bool isActive, string? search)
        {
            var knowledges = await _catalogRepository.GetAllKnowledgesAsync(isActive, search);

            if (knowledges == null)
                throw new ServerFaultException(
                    "Error al obtener los conocimientos (resultado null)."
                );

            if (!knowledges.Any())
                return new List<KnowledgeResponse>();

            return _mapper.Map<List<KnowledgeResponse>>(knowledges);
        }

        public async Task<List<MaritalStatuResponse>> GetAllMaritalStatus(bool isActive)
        {
            var statuses = await _catalogRepository.GetAllMaritalStatusAsync(isActive);

            if (statuses == null)
                throw new ServerFaultException(
                    "Error al obtener los estados civiles (resultado null)."
                );

            if (!statuses.Any())
                return new List<MaritalStatuResponse>();

            return _mapper.Map<List<MaritalStatuResponse>>(statuses);
        }

        public async Task<List<SkillResponse>> GetAllSkills(bool isActive, string? search)
        {
            var skills = await _catalogRepository.GetAllSkillsAsync(isActive, search);

            if (skills == null)
                throw new ServerFaultException(
                    "Error al obtener las skills (resultado null)."
                );
            if (!skills.Any())
                return new List<SkillResponse>();

            return _mapper.Map<List<SkillResponse>>(skills);
        }

        public async Task<List<StudyStatuResponse>> GetAllStudyStatus()
        {
            var studyStatus = await _catalogRepository.GetAllStudyStatusAsync();

            if (studyStatus == null)
            {
                throw new ServerFaultException(
                    "Error interno: La consulta de estatus de estudio retornó un valor nulo."
                );
            }
            if (!studyStatus.Any())
            {
                return new List<StudyStatuResponse>();
            }

            return studyStatus;
        }

        public async Task<List<ToolResponse>> GetAllTools(bool isActive, string? search)
        {
            var tools = await _catalogRepository.GetAllToolsAsync(isActive, search);

            if (tools == null)
                throw new ServerFaultException(
                    "Error al obtener las herramientas."
                );
           
            if (!tools.Any())
                return new List<ToolResponse>();

            return _mapper.Map<List<ToolResponse>>(tools);
        }

        public async Task<List<VacancyResponse>> GetAllVacancies(bool isActive)
        {
            var vacancies = await _catalogRepository.GetAllVacanciesAsync(isActive);

            if (vacancies == null)
                throw new ServerFaultException(
                    "Error al obtener las vacantes (resultado null)."
                );

            if (!vacancies.Any())
                return new List<VacancyResponse>();

            return _mapper.Map<List<VacancyResponse>>(vacancies);
        }

        public async Task<List<EducationLevelResponse>> GetAllEducationLevel()
        {
            var educationLevel = await _catalogRepository.GetAllEducationLevelAsync();

            if (educationLevel == null)
            {
                throw new ServerFaultException(
                    "Error interno: La consulta de estatus de estudio retornó un valor nulo."
                );
            }
            if (!educationLevel.Any())
            {
                return new List<EducationLevelResponse>();
            }

            return educationLevel;
        }


        public async Task<List<EnglishLevelResponse>> GetAllEnglishLevel()
        {
            var englishLevel = await _catalogRepository.GetEnglishLevelAsync();

            if (englishLevel == null)
            {
                throw new ServerFaultException(
                    "Error interno: La consulta de estatus de estudio retornó un valor nulo."
                );
            }
            if (!englishLevel.Any())
            {
                return new List<EnglishLevelResponse>();
            }

            return englishLevel;
        }

        public async Task<List<WorkCityResponse>> GetAllWorkCity()
        {
            var workcity = await _catalogRepository.GetWorkCityAsync();
            if(workcity== null)
            {
                throw new ServerFaultException(
                  "Error interno: La consulta de estatus de estudio retornó un valor nulo."
                );
            }
            if (!workcity.Any())
            {
                return new List<WorkCityResponse>();
            }
            return workcity;


        }
    }
}
