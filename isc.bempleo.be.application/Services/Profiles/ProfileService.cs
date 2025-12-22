using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes;
using isc.bempleo.be.application.Interfaces.Service.Profiles;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Profiles;
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
        private readonly IProfileAccessCodeService _serviceCode;
        private readonly IProfileAccessCodeRepository _codeAccessRepository;
        public ProfileService(IProfileRepository profileRepository, IMapper mapper, IProfileAccessCodeService code, IProfileAccessCodeRepository codeAccessRepository) {
            _profileRepository = profileRepository;
            _mapper = mapper;
            _serviceCode = code;
            _codeAccessRepository = codeAccessRepository;
        }

        public async Task<List<ProfileResponse>> GetAllProfileAsync(bool isActive)
        {
            var allprofiles = await _profileRepository.GetAllProfilesAsync(isActive);

            if (allprofiles == null || !allprofiles.Any())
            {
                throw new ClientFaultException("No existe ningún perfil con esos datos.");
            }

            var result = new List<ProfileResponse>();

            foreach (var profile in allprofiles)
            {
                var response = MapProfileWithLists(profile);
                result.Add(response);
            }

            return result;
        }

        public async Task<ProfileResponse> GetProfileByCodeAsync(string cedula, string email, string code)
        {
            var codeAccess = await _codeAccessRepository.ValidateCode(code);
            if (codeAccess == null)
            {
                throw new ClientFaultException("El código de acceso proporcionado no es válido.");
            }

            var profile = await _profileRepository.GetProfileByEmailOrIdentificationAsync(email, cedula);

            if (profile == null)
            {
                throw new ClientFaultException("No existe ningún perfil con esos datos.");
            }

            var response = MapProfileWithLists(profile);

            return response;
        }

        public async Task<ProfileResponse> GetProfileForGenerateCode(string cedula, string email)
        {
            var profile = await _profileRepository.GetProfileByEmailOrIdentificationAsync(email, cedula);

            if (profile == null)
            {
                throw new ClientFaultException("No existe ningún perfil con esos datos.");
            }

            var response = MapProfileWithLists(profile);

            return response;
        }

        //Pantalla 1 del formulario
        public async Task<ProfileResponse> CreateProfileAsync(PersonalDataRequest request)
        {
            var existingProfile = await _profileRepository
                .GetProfileByEmailOrIdentificationAsync(request.Email, request.IdentificationNumber);

            if (existingProfile != null)
            {
                if (existingProfile.Email == request.Email)
                    throw new ClientFaultException("El correo electrónico ya está registrado en otro perfil.");

                if (existingProfile.IdentificationNumber == request.IdentificationNumber)
                    throw new ClientFaultException("El número de identificación ya está registrado en otro perfil.");
            }

            var entity = _mapper.Map<domain.Entity.Profiles.Profile>(request);
            var profile = await _profileRepository.GetProfileByEmailOrIdentificationAsync(request.Email, request.IdentificationNumber);
            var createdEntity = await _profileRepository.CreateProfileAsync(entity);
            var response = _mapper.Map<ProfileResponse>(createdEntity);

            return response;
        }

        //Pantalla 2 del formulario
        public async Task<ProfileResponse> CreateProfileAsync(FormationRequest request,int profileId)
        {
            var entity = await _profileRepository.GetProfileByIdAsync(profileId);

            if (entity == null)
                throw new ClientFaultException("No existe el perfil con ese ID.");

            var mapping = _mapper.Map(request, entity);
            entity.CareerList = JsonSerializer.Serialize(request.CareerIds);
            var updateEntity = await _profileRepository.UpdateProfileAsync(entity);
            var response = _mapper.Map<ProfileResponse>(updateEntity);
            return response;
        }

        // Pantalla 3 del formulario 
        public async Task UpdateProfileTechnologiesAsync(int profileId, ProfileTechnologiesRequest request)
        {
            var profile = await _profileRepository.GetProfileByIdAsync(profileId);

            if (profile == null)
                throw new ClientFaultException("No existe el perfil con ese ID.");

            profile.KnowledgeList = JsonSerializer.Serialize(request.KnowledgeIds);
            profile.ToolList = JsonSerializer.Serialize(request.ToolIds);
            profile.SkillList = JsonSerializer.Serialize(request.SkillIds);
            profile.CertificationList = JsonSerializer.Serialize(request.CertificationIds);

            await _profileRepository.UpdateProfileAsync(profile);
        }

        public async Task<ProfileTechnologiesRequest> GetProfileTechnologiesAsync(int profileId)
        {
            var profile = await _profileRepository.GetProfileByIdAsync(profileId);

            if (profile == null)
                throw new ClientFaultException("No existe el perfil con ese ID.");

            return new ProfileTechnologiesRequest
            {
                KnowledgeIds = string.IsNullOrEmpty(profile.KnowledgeList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.KnowledgeList),

                ToolIds = string.IsNullOrEmpty(profile.ToolList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.ToolList),

                SkillIds = string.IsNullOrEmpty(profile.SkillList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.SkillList),

                CertificationIds = string.IsNullOrEmpty(profile.CertificationList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.CertificationList),
            };
        }

        // Actualizar datos de la pantalla 1
        public async Task<ProfileResponse> UpdateProfile (PersonalDataRequest request, int profileId)
        {
            var entity = await _profileRepository.GetProfileByIdAsync(profileId);
            if (entity == null)
                throw new ClientFaultException("No existe el perfil con ese ID.");
            var existingProfile = await _profileRepository.GetProfileByEmailOrIdentificationAsync(request.Email, request.IdentificationNumber);

            if (existingProfile != null && existingProfile.Id != profileId)
            {
                if (existingProfile.Email == request.Email)
                    throw new ClientFaultException("El correo electrónico ya está registrado en otro perfil.");

                if (existingProfile.IdentificationNumber == request.IdentificationNumber)
                    throw new ClientFaultException("El número de identificación ya está registrado en otro perfil.");
            }

            entity.GenderId = request.GenderId;
            entity.MaritalStatusId = request.MaritalStatusId;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.IdentificationNumber = request.IdentificationNumber;
            entity.Phone = request.Phone;
            entity.Address = request.Address;
            entity.BirthDate = request.BirthDate;
            entity.Nationality = request.Nationality;
            entity.DisabilityCard = request.DisabilityCard;

            await _profileRepository.UpdateProfileAsync(entity);

            var response = _mapper.Map<ProfileResponse>(entity);
            return response;
        }

        // Actualizar datos de la pantalla 2
        public async Task<ProfileResponse> UpdateProfile(FormationRequest request, int profileId)
        {
            var entity = await _profileRepository.GetProfileByIdAsync(profileId);

            if (entity == null)
                throw new ClientFaultException("No existe el perfil con ese ID.");

            entity.EducationLevel = request.EducationLevel;
            entity.EducationStatus = request.EducationStatus;
            entity.AcademicInstitution = request.AcademicInstitution;
            entity.CountryOfStudy = request.CountryOfStudy;
            entity.EnglishLevel = request.EnglishLevel;

            await _profileRepository.UpdateProfileAsync(entity);

            var response = _mapper.Map<ProfileResponse>(entity);
            return response;
        }

        //public async Task ActivateInactiveResourceAsync(int profileId, bool active)
        //{
        //    var rowsAffected = await _profileRepository.ActiveInactiveProfileAsync(profileId, active);

        //    if (rowsAffected == 0)
        //    {
        //        throw new Exception($"El Perfil {profileId} no existe");
        //    }
        //}

        private ProfileResponse MapProfileWithLists(domain.Entity.Profiles.Profile profile)
            {
                var response = _mapper.Map<ProfileResponse>(profile);

                response.KnowledgeIds = string.IsNullOrEmpty(profile.KnowledgeList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.KnowledgeList);

                response.ToolIds = string.IsNullOrEmpty(profile.ToolList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.ToolList);

                response.SkillIds = string.IsNullOrEmpty(profile.SkillList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.SkillList);

                response.CertificationIds = string.IsNullOrEmpty(profile.CertificationList)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(profile.CertificationList);

                return response;
            }


    }
}
