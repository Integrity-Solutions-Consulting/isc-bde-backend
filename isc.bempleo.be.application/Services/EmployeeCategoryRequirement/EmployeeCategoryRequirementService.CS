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

        public async Task<EmployeeCategoryRequirementResponse> AddEmployeeCategoryToRequirement(EmployeeCategoryRequirementRequest request)
        {
            var response = await _requirementRepository.CreateEmployeeCategoryRequirementAsync(request);


            if (response == null)
            {
                throw new ServerFaultException("Error interno: La base de datos no devolvió respuesta al intentar guardar la categoría.");
            }

            return response;
        }





    }
}
