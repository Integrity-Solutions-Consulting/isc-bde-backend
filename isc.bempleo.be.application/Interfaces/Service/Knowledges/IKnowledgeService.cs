using isc.bempleo.be.domain.Models.Request.Knowledges;
using isc.bempleo.be.domain.Models.Response.Knowledges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Knowledges
{
    public interface IKnowledgeService
    {
        Task<List<KnowledgeResponse>> GetAllKnowledgesAsync(bool isActive, string? search = null);
        Task<KnowledgeResponse> GetKnowledgeById(int knowledgeId);
        Task<KnowledgeResponse> CreateKnowledgeAsync(KnowledgeRequest request);
        Task<KnowledgeResponse> UpdateKnowledgeAsync(int knowledgeId, KnowledgeRequest request);
        Task<int> ActiveInactiveKnowledgeAsync(int knowledgeId, bool status);
    }
}
