using isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes;
using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.ProfileAccessCodes
{
    public class ProfileAccessCodeRepository : IProfileAccessCodeRepository
    {

        private readonly DBContext _dbContext;

        public ProfileAccessCodeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProfileAccessCode> CreateProfileAccessCodeAsync(ProfileAccessCode entity)
        {
            await _dbContext.ProfileAccessCodes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> CodeExistsAsync(string code)
        {
            return await _dbContext.ProfileAccessCodes
                .AnyAsync(x => x.Code == code);
        }
        public async Task<ProfileAccessCode> ValidateCode(string code) 
        {
            var codeAccess = await _dbContext.ProfileAccessCodes
                 .Where(c => c.Code == code)
                 .FirstOrDefaultAsync();
            return codeAccess;
        }




    }
}
