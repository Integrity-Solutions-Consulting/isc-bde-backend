using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Profiles
{
    public class ProfileRepository
    {
        private readonly DBContext _dbContext;
        public ProfileRepository (DBContext context)
        {
            _dbContext = context ;
        }

        public async Task<List<Profile>> GetAllProfilesAsync (bool isActive)
        {
            List<Profile> allProfiles = await _dbContext.Profiles
                .Where(p =>p.Status == isActive)
                .ToListAsync();
            return allProfiles;
        }
    }
}
