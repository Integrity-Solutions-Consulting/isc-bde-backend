using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.domain.Models.Response.Template;

namespace isc.bempleo.be.application.Interfaces.Service.Booklets
{
    public interface ITemplateService
    {
        Task<List<TemplateResponse>> GetBooklet();
        Task<TemplateDetailResponse> GetTemplateById(int id);
        Task<TemplateResponse> CreateTemplate(TemplateRequest requests);    
    }
}
