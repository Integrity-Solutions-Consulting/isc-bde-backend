using isc.bempleo.be.application.Interfaces.Repository.ApplicationStatus;
using isc.bempleo.be.domain.Entity.ApplicationStatus;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.ApplicationStatus
{
    public class ApplicationStatuRepository : IApplicationStatuRepository
    {
        private readonly DBContext _context;

        public ApplicationStatuRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationStatu>> GetAllApplicationStatusAsync(bool isActive)
        {
            var statuses = await _context.ApplicationStatus
                .Where(a => a.Status == isActive)
                .ToListAsync();

            return statuses;
        }
    }
}
