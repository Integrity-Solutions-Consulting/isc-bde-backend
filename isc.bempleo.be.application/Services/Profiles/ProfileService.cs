using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Models.Request.Knowledges;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Request.Tools;
using isc.bempleo.be.domain.Models.Response.Knowledges;
using isc.bempleo.be.domain.Models.Response.Profiles;
using isc.bempleo.be.domain.Models.Response.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        public ProfileService(IProfileRepository profileRepository, IMapper mapper) {
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
                throw new Exception("No existe ningun perfil con ese ID");
            }
            var mapping = _mapper.Map<ProfileResponse>(profile);
            //aqui haces un mapping.y tras el atributo de tu lista y lo deserializas para mosotrarlo 
            //aqui haces un mapping.y tras el atributo de tu lista y lo deserializas para mosotrarlo 
            
            return mapping;
        }
        public async Task<ProfileResponse> CreateProfileAsync(PersonalDataRequest request)
        {
            var existingProfile = await _profileRepository
                .GetProfileByEmailOrIdentificationAsync(request.Email, request.IdentificationNumber);

            if (existingProfile != null)
            {
                if (existingProfile.Email == request.Email)
                    throw new Exception("El correo electrónico ya está registrado en otro perfil.");

                if (existingProfile.IdentificationNumber == request.IdentificationNumber)
                    throw new Exception("El número de identificación ya está registrado en otro perfil.");
            }

            var entity = _mapper.Map<domain.Entity.Profiles.Profile>(request);
            var profile = await _profileRepository.GetProfileByEmailOrIdentificationAsync(request.Email, request.IdentificationNumber);
            var createdEntity = await _profileRepository.CreateProfileAsync(entity);
            var response = _mapper.Map<ProfileResponse>(createdEntity);

            return response;
        }

        public async Task<ProfileResponse> CreateProfileAsync(FormationRequest request,int profileId)
        {
            var entity = await _profileRepository.GetProfileByIdAsync(profileId);
            var mapping = _mapper.Map(request, entity);
            //mapping.
            var updateEntity = await _profileRepository.UpdateProfileAsync(entity);
            var response = _mapper.Map<ProfileResponse>(updateEntity);
            return response;
        }

        public async Task<ProfileResponse> UpdateProfile (PersonalDataRequest request, int profileId)
        {
            var entity = await _profileRepository.GetProfileByIdAsync(profileId);
            if (entity == null)
            {
                throw new Exception("No existe el perfil con ese ID");
            }
            var existingProfile = await _profileRepository.GetProfileByEmailOrIdentificationAsync(request.Email, request.IdentificationNumber);

            if (existingProfile != null && existingProfile.Id != profileId)
            {
                if (existingProfile.Email == request.Email)
                    throw new Exception("El correo electronico ya esta registrado en otro perfil.");

                if (existingProfile.IdentificationNumber == request.IdentificationNumber)
                    throw new Exception("El numero de identificacion ya esta registrado en otro perfil.");
            }


            entity.GenderId = request.GenderId;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.IdentificationNumber = request.IdentificationNumber;
            entity.Phone = request.Phone;
            entity.Address = request.Address;
            entity.MaritalStatus = request.MaritalStatus;
            entity.BirthDate = request.BirthDate;
            entity.Nationality = request.Nationality;
            entity.DisabilityCard = request.DisabilityCard;

            await _profileRepository.UpdateProfileAsync(entity);

            var response = _mapper.Map<ProfileResponse>(entity);
            return response;


        }
        public async Task<ProfileResponse> UpdateProfile(FormationRequest request, int profileId)
        {
            var entity = await _profileRepository.GetProfileByIdAsync(profileId);
            if (entity == null)
            {
                throw new Exception("No existe el perfil con ese ID");
            }
            entity.EducationLevel = request.EducationLevel;
            entity.EducationStatus = request.EducationStatus;
            entity.Carer = request.Carer;
            entity.AcademicInstitution = request.AcademicInstitution;
            entity.CountryOfStudy = request.CountryOfStudy;
            entity.EnglishLevel = request.EnglishLevel;

            await _profileRepository.UpdateProfileAsync(entity);

            var response = _mapper.Map<ProfileResponse>(entity);
            return response;

        }
        public async Task ActivateInactiveResourceAsync(int profileId, bool active)
        {
            var rowsAffected = await _profileRepository.ActiveInactiveProfileAsync(profileId, active);

            if (rowsAffected == 0)
            {
                throw new Exception($"El Perfil {profileId} no existe");
            }
        }

        public async Task<SkillsResponse> GetProfileSkillsAsync(int profileId)
        {
            var profile = await _profileRepository.GetProfileByIdAsync(profileId);
            if (profile == null)
            {
                throw new Exception("No existe el perfil con ese ID");
            }

            var knowledges = string.IsNullOrEmpty(profile.KnowledgeList)? 
                new List<KnowledgeRequestForProfile>(): 
                JsonSerializer.Deserialize<List<KnowledgeRequestForProfile>>(profile.KnowledgeList);

            var tools = string.IsNullOrEmpty(profile.ToolList)?
                new List<ToolRequestForProfile>():
                JsonSerializer.Deserialize<List<ToolRequestForProfile>>(profile.ToolList);

            return new SkillsResponse
            {
                ProfileId = profileId,
                Knowledges = _mapper.Map<List<KnowledgeResponseForProfile>>(knowledges),
                Tools = _mapper.Map<List<ToolResponseForProfile>>(tools)
            };
        }

        public async Task<SkillsResponse> CreateProfileAsync(SkillsRequest request)
        {
            var profile = await _profileRepository.GetProfileByIdAsync(request.ProfileId);
            if (profile == null)
            {
                throw new Exception("No existe el perfil con ese ID");
            }

            profile.KnowledgeList = JsonSerializer.Serialize(request.Knowledges);
            profile.ToolList = JsonSerializer.Serialize(request.Tools);

            await _profileRepository.UpdateProfileAsync(profile);

            return new SkillsResponse
            {
                ProfileId = request.ProfileId,
                Knowledges = _mapper.Map<List<KnowledgeResponseForProfile>>(request.Knowledges),
                Tools = _mapper.Map<List<ToolResponseForProfile>>(request.Tools)
            };
        }
        // publicasunc task<el response que esat arriba> UpdateListCampInProfile (el request que esta arriba){
           //este metodo tiene que llamar a la 

        //}




    }
}
