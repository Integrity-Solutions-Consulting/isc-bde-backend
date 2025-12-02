using isc.bempleo.be.domain.Models.Response.Genders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Service.Genders
{
    public interface IGenderService
    {
        Task<List<GenderResponse>> GetAllGenderAsync(bool isActive);

    }
}
