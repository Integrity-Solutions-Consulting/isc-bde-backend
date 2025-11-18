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
        Task<ProfileResponse> GetProfileByCedulaEmail(string cedula, string email);
        //Task<SkillsResponse> GetProfileSkillsAsync(int profileId);
        //Task<SkillsResponse> CreateProfileAsync(SkillsRequest request);
        Task<ProfileResponse> CreateProfileAsync(PersonalDataRequest request);
        Task<ProfileResponse> CreateProfileAsync(FormationRequest request, int profileId);
        Task<SkillsResponse> CreateProfileAsync(SkillsRequest request, int profileId);

        Task<ProfileResponse> UpdateProfile(PersonalDataRequest request, int profileId);
        Task<ProfileResponse> UpdateProfile(FormationRequest request, int profileId);
        Task ActivateInactiveResourceAsync(int profileId, bool active);
    }
}
