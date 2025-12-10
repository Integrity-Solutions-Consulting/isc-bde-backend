using AutoMapper;
using isc.bempleo.be.domain.Entity.Genders;
using isc.bempleo.be.domain.Entity.MaritalStatus;
using isc.bempleo.be.domain.Models.Response.Genders;
using isc.bempleo.be.domain.Models.Response.MaritalStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class MaritalStatuProfile : Profile  
    {
        public MaritalStatuProfile()
        {
            CreateMap<MaritalStatu, MaritalStatuResponse>();
        }
    }
}
