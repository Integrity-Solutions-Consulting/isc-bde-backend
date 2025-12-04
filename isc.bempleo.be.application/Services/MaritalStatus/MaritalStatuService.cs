using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Genders;
using isc.bempleo.be.application.Interfaces.Repository.MaritalStatus;
using isc.bempleo.be.application.Interfaces.Service.MaritalStatus;
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
            var allStatuses = await _repo.GetAllMaritalStatusAsync(isActive);

            if (allStatuses == null || !allStatuses.Any())
            {
                return new List<MaritalStatuResponse>();
            }

            var mapping = _mapper.Map<List<MaritalStatuResponse>>(allStatuses);
            return mapping;
        }



    }
}
