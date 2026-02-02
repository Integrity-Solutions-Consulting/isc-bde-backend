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
                // Opción: Retornar lista vacía o lanzar error. 
                return responses;
            }

            // Recorremos la lista que viene del JSON
            foreach (var item in requestList)
            {
                // LOGICA DE NEGOCIO: Solo guardamos si la cantidad es mayor a 0
                if (item.Quantity > 0)
                {
                    var result = await _requirementRepository.CreateEmployeeCategoryRequirementAsync(item);

                    if (result != null)
                    {
                        responses.Add(result);
                    }
                    // Si result es null, podrías loguear el error, pero continuamos con el siguiente
                }
            }

            return responses;
        }

    }
}
