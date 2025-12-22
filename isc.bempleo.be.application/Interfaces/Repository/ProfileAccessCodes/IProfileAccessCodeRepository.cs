using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Response.ProfileAccessCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.ProfileAccessCodes
{
    public interface IProfileAccessCodeRepository
    {
        Task InactiveCode(DateTime expirationLimit, CancellationToken cancellationToken);
        Task<ProfileAccessCode> ValidateCode(string code);
        Task<ProfileAccessCode> CreateProfileAccessCodeAsync(ProfileAccessCode entity);
    }
}
