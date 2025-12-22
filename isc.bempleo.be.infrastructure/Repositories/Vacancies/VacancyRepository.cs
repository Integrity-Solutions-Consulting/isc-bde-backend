using isc.bempleo.be.application.Interfaces.Repository.Vacancies;
using isc.bempleo.be.domain.Entity.Careers;
using isc.bempleo.be.domain.Entity.Vacancies;
using isc.bempleo.be.domain.Exceptions;
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
            try
            {
                return await _context.Vacancies
                    .Where(v => v.Status == isActive)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Vacancies.",
                    500,
                    ex
                );
            }
        } 



    }
}
