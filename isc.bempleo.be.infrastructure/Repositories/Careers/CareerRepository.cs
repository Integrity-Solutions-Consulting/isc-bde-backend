using isc.bempleo.be.application.Interfaces.Repository.Careers;
using isc.bempleo.be.domain.Entity.Careers;
using isc.bempleo.be.domain.Exceptions;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Careers
{
    public class CareerRepository : ICareerRepository
    {

        private readonly DBContext _context;

        public CareerRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<List<Career>> GetAllCareeraAsync(bool isActive)
        {
            try
            {
                var careers = await _context.Careers.Where(c => c.Status == isActive).ToListAsync();
                return careers;
            }
            catch (Exception ex)
            {
                throw new ServerFaultException(
                    "Error en base de datos al consultar Careers.",
                    500,
                    ex
                );
            }
        }

    }
}
