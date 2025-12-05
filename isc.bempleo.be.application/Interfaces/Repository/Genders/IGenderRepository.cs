using isc.bempleo.be.domain.Entity.Genders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Interfaces.Repository.Genders
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAllGendersAsync(bool isActive);

    }
}
