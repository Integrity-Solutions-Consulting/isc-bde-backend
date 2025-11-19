using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Skills;
using isc.bempleo.be.application.Interfaces.Service.Skills;
using isc.bempleo.be.domain.Entity.Skills;
using isc.bempleo.be.domain.Models.Request.Skills;
using isc.bempleo.be.domain.Models.Response.Skills;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<List<SkillResponse>> GetAllSkillsAsync(bool isActive, string? search)
        {
            var entities = await _skillRepository.GetAllSkillsAsync(isActive, search);
            return _mapper.Map<List<SkillResponse>>(entities);
        }

        public async Task<SkillResponse> GetSkillByIdAsync(int skillId)
        {
            var entity = await _skillRepository.GetSkillByIdAsync(skillId);
            if (entity == null)
            {
                throw new Exception("No existe ninguna skill con ese ID");
            }

            return _mapper.Map<SkillResponse>(entity);
        }

        public async Task<SkillResponse> CreateSkillAsync(SkillRequest request)
        {
            var entity = _mapper.Map<Skill>(request);
            var created = await _skillRepository.CreateSkillAsync(entity);
            return _mapper.Map<SkillResponse>(created);
        }

        public async Task<SkillResponse> UpdateSkillAsync(int skillId, SkillRequest request)
        {
            var entity = _mapper.Map<Skill>(request);
            entity.Id = skillId;

            var updated = await _skillRepository.UpdateSkillAsync(entity);
            return _mapper.Map<SkillResponse>(updated);
        }

        public async Task<int> ActiveInactiveSkillAsync(int skillId, bool status)
        {
            return await _skillRepository.ActiveInactiveSkillAsync(skillId, status);
        }
    }
}
