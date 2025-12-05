using isc.bempleo.be.domain.Models.Response.Careers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Careers
{
    public interface ICareerService
    {
        Task<List<CareerResponse>> GetAllAsync(bool isActive);
    }
}
