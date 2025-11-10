using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly Mapper _mapper;
        public ProfileService(IProfileRepository profileRepository, Mapper mapper) {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }
        

        public async Task<List<ProfileResponse>> GetAllProfileAsync(bool isActive)
        {
            var allprofiles = await _profileRepository.GetAllProfilesAsync(isActive);
            if (allprofiles == null || !allprofiles.Any())
            {
                return new List<ProfileResponse>();
            }   
               var mapping = _mapper.Map<List<ProfileResponse>>(allprofiles);

               return mapping;

        }


        public async Task<ProfileResponse> GetProfileById (int profileId)
        {
            var profile = await _profileRepository.GetProfileByIdAsync(profileId);
            if(profile == null)
            {
                new Exception("No existe ningun perfil con ese ID");
            }
            var mapping = _mapper.Map<ProfileResponse>(profile);
            return mapping;
        }
        public async Task<ProfileResponse> CreateProfileAsync(PersonalDataRequest request)
        {
            var entity = _mapper.Map<domain.Entity.Profiles.Profile>(request);
            var createdEntity = await _profileRepository.CreateProfileAsync(entity);
            var response = _mapper.Map<ProfileResponse>(createdEntity);
            return response;
        }

        public async Task<ProfileResponse> CreateProfileAsync(FormationRequest request)
        {
            var entity = _mapper.Map<domain.Entity.Profiles.Profile>(request);
            var createdEntity = await _profileRepository.CreateProfileAsync(entity);
            var response = _mapper.Map<ProfileResponse>(createdEntity);
            return response;
        }

        public async Task<SkillsResponse> CreateProfileAsync (SkillsRequest request)
        {
            
        }
        
    }
}
