using isc.bempleo.be.domain.Models.Response.MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.MaritalStatus
{
    public interface IMaritalStatuService
    {
        Task<List<MaritalStatuResponse>> GetAllMaritalStatusAsync(bool isActive);
    }
}
