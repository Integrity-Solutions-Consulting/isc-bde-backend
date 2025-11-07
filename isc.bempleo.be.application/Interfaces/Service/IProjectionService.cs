using isc.bempleo.be.domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service
{
    public interface IProjectionService
    {
        Task<List<ProjectionHoursProjectResponse>> GetAllProjectionByProjectId(int projectId);
    }
}
