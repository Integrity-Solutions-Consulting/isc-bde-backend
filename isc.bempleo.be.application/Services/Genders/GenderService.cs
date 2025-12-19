using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Genders;
using isc.bempleo.be.application.Interfaces.Repository.Knowledges;
using isc.bempleo.be.application.Interfaces.Service.Genders;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.Genders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Genders
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repo;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GenderResponse>> GetAllGenderAsync(bool isActive)
        {
            var allGenders = await _repo.GetAllGendersAsync(isActive);

            if (allGenders == null)
                throw new ServerFaultException("Error al obtener los géneros (resultado null).");

            if (!allGenders.Any())
                return new List<GenderResponse>();

            return _mapper.Map<List<GenderResponse>>(allGenders);
        }



    }
}
