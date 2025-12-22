using isc.bempleo.be.application.Interfaces.Repository.ProfileVacancies;
using isc.bempleo.be.domain.Entity.ProfileVacancies;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.ProfileVacancies
{
    public class ProfileVacancyRepository : IProfileVacancyRepository
    {
        private readonly DBContext _context;

        public ProfileVacancyRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<ProfileVacancy>> GetAllAsync(bool isActive)
        {
            try
            {
                var result = await _context.ProfileVacancies
                    .Where(pv => pv.Status == isActive)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar ProfileVacancies.",
                    500,
                    ex
                );
            }
        }

        public async Task<ProfileVacancy> CreateAsync(ProfileVacancy entity)
        {
            try
            {
                await _context.ProfileVacancies.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al crear ProfileVacancy.",
                    500,
                    ex
                );
            }
        }

    }
}
