using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.domain.Models.Response.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Booklets
{
    public interface ITemplateRepository
    {
        Task<List<TemplateResponse>> GetBookletAsync();
        Task<TemplateDetailResponse> GetTemplateByIdAsync(int id);
        Task<int> CreateTemplateAsync(string name, string knowledgeIdsJson, string toolIdsJson);
    }
}
