using isc.bempleo.be.domain.Entity.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Vacancies
{
    public interface IVacancyRepository
    {
        Task<List<Vacancy>> GetAllVacanciesAsync(bool isActive);
    }
}
