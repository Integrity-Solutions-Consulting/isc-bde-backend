using isc.bempleo.be.application.Interfaces.Service.Catalogs;
using isc.bempleo.be.domain.Models.DTOs.Exceptions;
using isc.bempleo.be.domain.Models.Response.Catalogs;
using isc.bempleo.be.domain.Models.Response.Documents;
using Microsoft.AspNetCore.Mvc;

namespace isc.bempleo.be.api.Controllers.v1.Catalogs
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("get-all-application-status")]
        public async Task<ActionResult<SuccessResponse<List<ApplicationStatuResponse>>>> GetAllApplicationStatusAsync(bool isActive)
        {
            var result = await _catalogService.GetAllApplicationStatus(isActive);
            return Ok(result);
        }

        [HttpGet("get-all-careers")]
        public async Task<ActionResult<SuccessResponse<List<CareerResponse>>>> GetAllCareerAsync(bool isActive)
        {
            var result = await _catalogService.GetAllCareer(isActive);
            return Ok(result);
        }

        [HttpGet("get-all-certifications")]
        public async Task<ActionResult<SuccessResponse<List<CertificationResponse>>>> GetAllCertificationsAsync(bool isActive, string? search)
        {
            var result = await _catalogService.GetAllCertifications(isActive, search);
            return Ok(result);
        }

        [HttpGet("get-all-documents")]
        public async Task<ActionResult<SuccessResponse<List<DocumentResponse>>>> GetAllDocumentsAsync(bool isActive)
        {
            var result = await _catalogService.GetAllDocuments(isActive);
            return Ok(result);
        }

        [HttpGet("get-all-knowledges")]
        public async Task<ActionResult<SuccessResponse<List<KnowledgeResponse>>>> GetAllKnowledgesAsync(bool isActive, string? search)
        {
            var result = await _catalogService.GetAllKnowledges(isActive, search);
            return Ok(result);
        }

        [HttpGet("get-all-marital-status")]
        public async Task<ActionResult<SuccessResponse<List<MaritalStatuResponse>>>> GetAllMaritalStatusAsync(bool isActive)
        {
            var result = await _catalogService.GetAllMaritalStatus(isActive);
            return Ok(result);
        }

        [HttpGet("get-all-skills")]
        public async Task<ActionResult<SuccessResponse<List<SkillResponse>>>> GetAllSkillsAsync(bool isActive, string? search)
        {
            var result = await _catalogService.GetAllSkills(isActive, search);
            return Ok(result);
        }

        [HttpGet("get-all-tools")]
        public async Task<ActionResult<SuccessResponse<List<ToolResponse>>>> GetAllToolsAsync(bool isActive, string? search)
        {
            var result = await _catalogService.GetAllTools(isActive, search);
            return Ok(result);
        }

        [HttpGet("get-all-vacancies")]
        public async Task<ActionResult<SuccessResponse<List<VacancyResponse>>>> GetAllVacanciesAsync(bool isActive)
        {
            var result = await _catalogService.GetAllVacancies(isActive);
            return Ok(result);
        }

        [HttpGet("get-all-study-status")]
        public async Task<ActionResult<SuccessResponse<List<StudyStatuResponse>>>> GetAllStudyStatusAsync()
        {
            var result = await _catalogService.GetAllStudyStatus();
            return Ok(result);
        }

        [HttpGet("get-all-study-status")]
        public async Task<ActionResult<SuccessResponse<List<EducationLevelResponse>>>> GetAllEducationLevelAsync()
        {
            var result = await _catalogService.GetAllEducationLevel();
            return Ok(result);
        }

        [HttpGet("get-all-study-status")]
        public async Task<ActionResult<SuccessResponse<List<EnglishLevelResponse>>>> GetAllEnglishLevelAsync()
        {
            var result = await _catalogService.GetAllEnglishLevel();
            return Ok(result);
        }

    }
}
