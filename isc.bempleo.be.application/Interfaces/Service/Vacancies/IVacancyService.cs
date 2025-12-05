using isc.bempleo.be.domain.Models.Response.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Vacancies
{
    public interface IVacancyService
    {
        Task<List<VacancyResponse>> GetAllAsync(bool isActive);
    }
}
