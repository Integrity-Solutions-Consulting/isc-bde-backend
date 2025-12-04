using isc.bempleo.be.application.Interfaces.Repository.Genders;
using isc.bempleo.be.domain.Entity.Genders;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Genders
{
    public class GenderRepository : IGenderRepository
    {
        private readonly DBContext _dbContext;
        public GenderRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Gender>> GetAllGendersAsync(bool isActive)
        {
            return await _dbContext.Genders
                .Where(g => g.Status == isActive)
                .ToListAsync();
        }
    }
}
