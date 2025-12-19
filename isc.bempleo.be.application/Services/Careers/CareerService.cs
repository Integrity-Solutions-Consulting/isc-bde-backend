using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Careers;
using isc.bempleo.be.application.Interfaces.Service.Careers;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.Careers;
using isc.bempleo.be.domain.Models.Response.Genders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Careers
{
    public class CareerService : ICareerService
    {

        private readonly ICareerRepository _repository;
        private readonly IMapper _mapper;

        public CareerService(ICareerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CareerResponse>> GetAllAsync(bool isActive)
        {
            var careers = await _repository.GetAllCareeraAsync(isActive);

            if (careers == null)
                throw new ServerFaultException("Error al obtener las carreras (resultado null).");

            if (!careers.Any())
                return new List<CareerResponse>();

            return _mapper.Map<List<CareerResponse>>(careers);
        }



    }
}
