using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Knowledges;
using isc.bempleo.be.application.Interfaces.Service.Knowledges;
using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.domain.Models.Request.Knowledges;
using isc.bempleo.be.domain.Models.Response.Knowledges;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Knowledges
{
    public class KnowledgeService : IKnowledgeService
    {
        private readonly IKnowledgeRepository _repo;
        private readonly IMapper _mapper;

        public KnowledgeService(IKnowledgeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<KnowledgeResponse>> GetAllKnowledgesAsync(bool isActive, string? search = null)
        {
            var all = await _repo.GetAllKnowledgesAsync(isActive, search);
            return _mapper.Map<List<KnowledgeResponse>>(all);
        }


        public async Task<KnowledgeResponse> GetKnowledgeById(int knowledgeId)
        {
            var entity = await _repo.GetKnowledgeByIdAsync(knowledgeId);
            if (entity == null) throw new System.Exception("No existe Knowledge con ese ID");
            return _mapper.Map<KnowledgeResponse>(entity);
        }

        public async Task<KnowledgeResponse> CreateKnowledgeAsync(KnowledgeRequest request)
        {
            var entity = _mapper.Map<Knowledge>(request);
            var created = await _repo.CreateKnowledgeAsync(entity);
            return _mapper.Map<KnowledgeResponse>(created);
        }

        public async Task<KnowledgeResponse> UpdateKnowledgeAsync(int knowledgeId, KnowledgeRequest request)
        {
            var entity = _mapper.Map<Knowledge>(request);
            entity.Id = knowledgeId;
            var updated = await _repo.UpdateKnowledgeAsync(entity);
            return _mapper.Map<KnowledgeResponse>(updated);
        }

        public async Task<int> ActiveInactiveKnowledgeAsync(int knowledgeId, bool status)
        {
            return await _repo.ActiveInactiveKnowledgeAsync(knowledgeId, status);
        }
    }
}
