using isc.bempleo.be.domain.Entity.Knowledges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Knowledges
{
    public interface IKnowledgeRepository
    {
        Task<List<Knowledge>> GetAllKnowledgesAsync(bool isActive, string? search = null);
        Task<Knowledge> GetKnowledgeByIdAsync(int knowledgeId);
        Task<Knowledge> CreateKnowledgeAsync(Knowledge knowledge);
        Task<Knowledge> UpdateKnowledgeAsync(Knowledge knowledge);
        Task<int> ActiveInactiveKnowledgeAsync(int knowledgeId, bool status);
    }
}
