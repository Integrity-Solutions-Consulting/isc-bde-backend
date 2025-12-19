using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.ApplicationStatus;
using isc.bempleo.be.application.Interfaces.Service.ApplicationStatus;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.ApplicationStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.ApplicationStatus
{
    public class ApplicationStatuService : IApplicationStatuService
    {
        private readonly IApplicationStatuRepository _repository;
        private readonly IMapper _mapper;

        public ApplicationStatuService(IApplicationStatuRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ApplicationStatuResponse>> GetAllAsync(bool isActive)
        {
            var statuses = await _repository.GetAllApplicationStatusAsync(isActive);

            if (statuses == null)
                throw new ServerFaultException("Error al obtener los estados de aplicación (resultado null).");

            if (!statuses.Any())
                return new List<ApplicationStatuResponse>();

            return _mapper.Map<List<ApplicationStatuResponse>>(statuses);
        }


    }
}
