using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.Vacancies;
using isc.bempleo.be.application.Interfaces.Service.Vacancies;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.domain.Models.Response.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.Vacancies
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyRepository _repository;
        private readonly IMapper _mapper;

        public VacancyService(IVacancyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VacancyResponse>> GetAllAsync(bool isActive)
        {
            var vacancies = await _repository.GetAllVacanciesAsync(isActive);

            if (vacancies == null)
                throw new ServerFaultException(
                    "Error al obtener las vacantes (resultado null)."
                );

            if (!vacancies.Any())
                return new List<VacancyResponse>();

            return _mapper.Map<List<VacancyResponse>>(vacancies);
        }

    }
}
