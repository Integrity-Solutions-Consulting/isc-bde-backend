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
            return await _context.ProfileVacancies
                .AsNoTracking()
                .Where(pv => pv.Status == isActive)
                .ToListAsync();
        }

        public async Task<ProfileVacancy> CreateAsync(ProfileVacancy entity)
        {
            await _context.ProfileVacancies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
