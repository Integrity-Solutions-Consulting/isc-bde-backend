using isc.bempleo.be.domain.Entity.ProfileVacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.ProfileVacancies
{
    public interface IProfileVacancyRepository
    {
        Task<List<ProfileVacancy>> GetAllAsync(bool isActive);
        Task<ProfileVacancy> CreateAsync(ProfileVacancy entity);

    }
}
