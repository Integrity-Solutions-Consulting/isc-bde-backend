using isc.bempleo.be.application.Interfaces.Repository.Requirements;
using isc.bempleo.be.application.Interfaces.Service.Requirements;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.Requirements;
using isc.bempleo.be.domain.Models.Response.Requirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Requirements
{
    public class RequirementService :IRequirementService
    {

        private readonly IRequirementRepository _requirementRepository;

        public RequirementService(IRequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }

        public async Task<RequirementResponse> CreateRequirement(RequirementRequest request)
        {
            var newRequirement = await _requirementRepository.CreateRequirementAsync(request);

            if (newRequirement == null)
            {
                throw new ServerFaultException("Error interno: La creación del requerimiento retornó un valor nulo.");
            }

            return newRequirement;
        }

    }
}
