using isc.bempleo.be.application.Interfaces.Repository;
using isc.bempleo.be.application.Interfaces.Service;
using isc.bempleo.be.domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Services
{
    public class ProjectionService : IProjectionService 
    {
        private readonly IProjectionRepository _projectionRepository;
       
        
        public ProjectionService(IProjectionRepository projectionRepository) { 
        
                _projectionRepository = projectionRepository;
        }


        public async Task<List<ProjectionHoursProjectResponse>> GetAllProjectionByProjectId(int projectId)
        {
            var result = await _projectionRepository.GetAllProjectionsAsync(projectId);

            return result;
        }
    }
}
