using AutoMapper;
using isc.bempleo.be.domain.Entity.Careers;
using isc.bempleo.be.domain.Models.Response.Careers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class CareerProfile : Profile
    {
        public CareerProfile()
        {
            CreateMap<Career, CareerResponse>();
        }
    }
}
