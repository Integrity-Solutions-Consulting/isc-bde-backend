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
        //Task<List<ProfileResponse>> GetAllProfileAsync(bool isActive);
        Task<ProfileResponse> GetProfileByCodeAsync(string cedula, string email, string code);

        // Pantalla 1
        Task<ProfileResponse> CreateProfileAsync(PersonalDataRequest request);
        Task<ProfileResponse> UpdateProfile(PersonalDataRequest request, int profileId);
        // Pantalla 2
        Task<ProfileResponse> CreateProfileAsync(FormationRequest request, int profileId);
        Task<ProfileResponse> UpdateProfile(FormationRequest request, int profileId);
        // Pantalla 3
        Task UpdateProfileTechnologiesAsync(int profileId, ProfileTechnologiesRequest request);
        Task<ProfileTechnologiesRequest> GetProfileTechnologiesAsync(int profileId);

<<<<<<< HEAD
        //Task ActivateInactiveResourceAsync(int profileId, bool active);
=======
        Task ActivateInactiveResourceAsync(int profileId, bool active);
        Task<ProfileResponse> GetProfileForGenerateCode(string cedula, string email);
>>>>>>> 4560443abb3992023c12ac77f423e2b0c1a154f6
    }
}
