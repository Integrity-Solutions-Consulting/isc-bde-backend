using isc.bempleo.be.application.Interfaces.Repository.Vacancies;
using isc.bempleo.be.domain.Entity.Careers;
using isc.bempleo.be.domain.Entity.Vacancies;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Vacancies
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly DBContext _context;

        public VacancyRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Vacancy>> GetAllVacanciesAsync(bool isActive)
        {
            var vacancies = await _context.Vacancies
                .Where(v => v.Status == isActive)
                .ToListAsync();

            return vacancies;
        }



    }
}
