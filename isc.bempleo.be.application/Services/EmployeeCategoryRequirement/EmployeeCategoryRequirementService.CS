using isc.bempleo.be.application.Interfaces.Repository.Contacts;
using isc.bempleo.be.application.Interfaces.Repository.EmployeeCategoryRequirement;
using isc.bempleo.be.application.Interfaces.Service.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Request.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Response.EmployeeCategoryRequirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.EmployeeCategoryRequirement
{
    public class EmployeeCategoryRequirementService : IEmployeeCategoryRequirementService
    {
        private readonly IEmployeeCategoryRequirementRepository _requirementRepository;

        public EmployeeCategoryRequirementService(IEmployeeCategoryRequirementRepository employeeRepository)
        {
            _requirementRepository = employeeRepository;
        }

        public async Task<List<EmployeeCategoryRequirementResponse>> AddEmployeeCategoryRequirements(List<EmployeeCategoryRequirementRequest> requestList)
        {
            var responses = new List<EmployeeCategoryRequirementResponse>();

            if (requestList == null || requestList.Count == 0)
            {
                return responses;
            }

            foreach (var item in requestList)
            {
                if (item.Quantity > 0)
                {
                    var result = await _requirementRepository.CreateEmployeeCategoryRequirementAsync(item);

                    if (result != null)
                    {
                        responses.Add(result);
                    }
                }
            }

            return responses;
        }

    }
}
