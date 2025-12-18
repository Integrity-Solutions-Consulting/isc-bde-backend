using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Experiences;
using isc.bempleo.be.application.Interfaces.Service.Experiences;
using isc.bempleo.be.domain.Entity.Experiences;
using isc.bempleo.be.domain.Models.Request.Experiences;
using isc.bempleo.be.domain.Models.Response.Experiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public ExperienceService(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<List<ExperienceResponse>> GetAllExperiencesAsync(bool isActive, int? profileId, string? search)
        {
            var experiences = await _experienceRepository.GetAllExperiencesAsync(isActive, profileId, search);
            return _mapper.Map<List<ExperienceResponse>>(experiences);
        }

        //public async Task<ExperienceResponse> GetExperienceById(int experienceId)
        //{
        //    var exp = await _experienceRepository.GetExperienceByIdAsync(experienceId);
        //    if (exp == null)
        //        throw new Exception("No existe ninguna experiencia con ese ID");

        //    return _mapper.Map<ExperienceResponse>(exp);
        //}

        public async Task<ExperienceResponse> CreateExperienceAsync(ExperienceRequest request)
        {
            var entity = _mapper.Map<Experience>(request);
            var created = await _experienceRepository.CreateExperienceAsync(entity);
            return _mapper.Map<ExperienceResponse>(created);
        }

        //public async Task<ExperienceResponse> UpdateExperienceAsync(int experienceId, ExperienceUpdateRequest request)
        //{
        //    var current = await _experienceRepository.GetExperienceByIdAsync(experienceId);
        //    if (current == null)
        //        throw new Exception($"No existe una experiencia con ID {experienceId}");

        //    current.CompanyName = request.CompanyName;
        //    current.PositionHeld = request.PositionHeld;
        //    current.ExperienceTime = request.ExperienceTime;

        //    var updated = await _experienceRepository.UpdateExperienceAsync(current);
        //    return _mapper.Map<ExperienceResponse>(updated);
        //}

        //public async Task<int> ActiveInactiveExperienceAsync(int experienceId, bool status)
        //{
        //    return await _experienceRepository.ActiveInactiveExperienceAsync(experienceId, status);
        //}

    }
}
