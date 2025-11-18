using isc.bempleo.be.domain.Models.Request.ProfileAccessCodes;
using isc.bempleo.be.domain.Models.Response.ProfileAccessCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.ProfileAccessCodes
{
    public interface IProfileAccessCodeService
    {


        Task<ProfileAccessCodeResponse> CreateProfileAccessCodeAsync(ProfileAccessCodeRequest request);

    }
}
