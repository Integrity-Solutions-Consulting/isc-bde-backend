using isc.bempleo.be.domain.Models.Request.Profiles;
using isc.bempleo.be.domain.Models.Response.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Profiles
{
    public interface IProfileService
    {
        Task<List<ProfileResponse>> GetAllProfileAsync(bool isActive);
        Task<ProfileResponse> GetProfileByCodeAsync(string cedula, string email, string code);


        // Las 3 sobrecargas del flujo de creación (pantalla 1,2 y 3)
        Task<ProfileResponse> CreateProfileAsync(PersonalDataRequest request);
        Task<ProfileResponse> CreateProfileAsync(FormationRequest request, int profileId); // Actualiza el perfil ya creado en la pantalla 1
        Task CreateProfileAsync(int profileId, ProfileTechnologiesRequest request); // Actualiza el perfil ya creado en la pantalla 1

        // Pantalla 1
        Task<ProfileResponse> UpdateProfile(PersonalDataRequest request, int profileId);
        // Pantalla 2
        //Task<ProfileResponse> UpdateProfile(FormationRequest request, int profileId);

        Task<ProfileTechnologiesRequest> GetProfileTechnologiesAsync(int profileId);
        //Task<ProfileResponse> GetProfileForGenerateCode(string cedula, string email);
    }
}
