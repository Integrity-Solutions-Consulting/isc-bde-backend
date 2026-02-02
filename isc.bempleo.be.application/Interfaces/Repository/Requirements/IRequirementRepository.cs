using isc.bempleo.be.domain.Models.Request.Requirements;
using isc.bempleo.be.domain.Models.Response.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Requirements
{
    public interface IRequirementRepository
    {
        Task<RequirementResponse> CreateRequirementAsync(RequirementRequest request);
    }
}
