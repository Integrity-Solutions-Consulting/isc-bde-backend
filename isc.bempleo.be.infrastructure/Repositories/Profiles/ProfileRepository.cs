using isc.bempleo.be.application.Interfaces.Repository.Profiles;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Profiles
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DBContext _dbContext;

        public ProfileRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Profile>> GetAllProfilesAsync(bool isActive)
        {
            List<Profile> allProfiles = await _dbContext.Profiles
                .Where(p => p.Status == isActive)
                .ToListAsync();

            return allProfiles;
        }

        public async Task<Profile> GetProfileByIdAsync(int profileId)
        {
            var profile = await _dbContext.Profiles
                .Where(p => p.Id == profileId)
                .FirstOrDefaultAsync();

            return profile;
        }

        public async Task<Profile> CreateProfileAsync(Profile profile)
        {
            await _dbContext.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<Profile> UpdateProfileAsync(Profile profile)
        {
            _dbContext.Entry(profile).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<int> ActiveInactiveProfileAsync(int profileId, bool status)
        {
            return await _dbContext.Profiles
                .Where(p => p.Id == profileId)
                .ExecuteUpdateAsync(update => update.SetProperty(p => p.Status, status));
        }

        public async Task<Profile> GetProfileByEmailOrIdentificationAsync(string email, string identificationNumber)
        {
            var validation = await _dbContext.Profiles
                .FirstOrDefaultAsync(p =>
                    p.Email == email &&
                    p.IdentificationNumber == identificationNumber);
            return validation;
        }


    }
}
