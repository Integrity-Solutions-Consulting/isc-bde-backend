using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Profiles
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAllProfilesAsync(bool isActive);
        Task<Profile> GetProfileByIdAsync(int profileId);
        Task<Profile> CreateProfileAsync(Profile profile);
        Task<Profile> UpdateProfileAsync(Profile profile);
        Task<int> ActiveInactiveProfileAsync(int profileId, bool status);
        Task<Profile> GetProfileByEmailOrIdentificationAsync(string email, string identificationNumber);

    }
}
