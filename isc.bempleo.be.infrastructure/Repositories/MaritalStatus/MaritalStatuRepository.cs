using isc.bempleo.be.application.Interfaces.Repository.MaritalStatus;
using isc.bempleo.be.domain.Entity.MaritalStatus;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.MaritalStatus
{
    public class MaritalStatuRepository : IMaritalStatuRepository
    {
        private readonly DBContext _dbContext;
        public MaritalStatuRepository(DBContext context)
        {
            _dbContext = context;
        }

        public async Task<List<MaritalStatu>> GetAllMaritalStatusAsync(bool isActive)
        {
            try
            {
                return await _dbContext.MaritalStatus
                    .Where(m => m.Status == isActive)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar MaritalStatus.",
                    500,
                    ex
                );
            }
        }

    }
}
