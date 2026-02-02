using isc.bempleo.be.domain.Models.Request.Requirements;
using isc.bempleo.be.domain.Models.Response.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Requirements
{
    public interface IRequirementService
    {
        Task<RequirementResponse> CreateRequirement(RequirementRequest request);
    }
}
