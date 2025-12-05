using AutoMapper;
using isc.bempleo.be.application.Interfaces.Repository.ProfileVacancies;
using isc.bempleo.be.application.Interfaces.Service.ProfileVacancies;
using isc.bempleo.be.domain.Entity.ProfileVacancies;
using isc.bempleo.be.domain.Models.Request.ProfileVacancies;
using isc.bempleo.be.domain.Models.Response.ProfileVacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services.ProfileVacancies
{
    public class ProfileVacancyService : IProfileVacancyService
    {
        private readonly IProfileVacancyRepository _repository;
        private readonly IMapper _mapper;

        public ProfileVacancyService(IProfileVacancyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProfileVacancyResponse>> GetAllAsync(bool isActive)
        {
            var profileVacancies = await _repository.GetAllAsync(isActive);

            if (profileVacancies == null || !profileVacancies.Any())
            {
                return new List<ProfileVacancyResponse>();
            }

            var mapping = _mapper.Map<List<ProfileVacancyResponse>>(profileVacancies);
            return mapping;
        }


        public async Task<ProfileVacancyResponse> CreateAsync(ProfileVacancyRequest request)
        {
            var entity = new ProfileVacancy
            {
                ProfileId = request.ProfileId,
                VacancyId = request.VacancyId,
                ApplicationStatusId = request.ApplicationStatusId ?? 1, 
                ApplicationDate = DateTime.Now,
                Status = true
            };

            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<ProfileVacancyResponse>(created);
        }


    }
}
