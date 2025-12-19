using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Genders;
using isc.bempleo.be.application.Interfaces.Repository.MaritalStatus;
using isc.bempleo.be.application.Interfaces.Service.MaritalStatus;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.MaritalStatus
{
    public class MaritalStatuService : IMaritalStatuService
    {
        private readonly IMaritalStatuRepository _repo;
        private readonly IMapper _mapper;

        public MaritalStatuService(IMaritalStatuRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<MaritalStatuResponse>> GetAllMaritalStatusAsync(bool isActive)
        {
            var statuses = await _repo.GetAllMaritalStatusAsync(isActive);

            if (statuses == null)
                throw new ServerFaultException(
                    "Error al obtener los estados civiles (resultado null)."
                );

            if (!statuses.Any())
                return new List<MaritalStatuResponse>();

            return _mapper.Map<List<MaritalStatuResponse>>(statuses);
        }

    }
}
