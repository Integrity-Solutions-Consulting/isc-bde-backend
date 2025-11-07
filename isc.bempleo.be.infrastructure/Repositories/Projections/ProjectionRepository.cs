using isc.bempleo.be.application.Interfaces.Repository;
using isc.bempleo.be.domain.Models.Response;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Projections
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly DBContext _dbContext;
        public ProjectionRepository(DBContext dBContext) {
        
            _dbContext = dBContext;        
        }

        public async Task<List<ProjectionHoursProjectResponse>> GetAllProjectionsAsync(int projectId)
        {
            var parameters = new[] {
                new SqlParameter("@ProjectId", projectId)
            };
            return await _dbContext.Set<ProjectionHoursProjectResponse>()
                .FromSqlRaw("EXEC dbo.sp_ProyeccionHorasPorProyectoGOOOD @ProjectID", parameters)
                .ToListAsync();
        }
    }
}
