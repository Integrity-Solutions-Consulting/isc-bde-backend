using isc.bempleo.be.domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository
{
    public interface IProjectionRepository
    {
        Task<List<ProjectionHoursProjectResponse>> GetAllProjectionsAsync(int projectId);
    }
}
