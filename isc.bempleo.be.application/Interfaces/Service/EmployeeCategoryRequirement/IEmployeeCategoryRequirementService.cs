using isc.bempleo.be.domain.Models.Request.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Response.EmployeeCategoryRequirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.EmployeeCategoryRequirement
{
    public interface IEmployeeCategoryRequirementService
    {
        Task<List<EmployeeCategoryRequirementResponse>> AddEmployeeCategoryRequirements(List<EmployeeCategoryRequirementRequest> requestList);
    }
}
