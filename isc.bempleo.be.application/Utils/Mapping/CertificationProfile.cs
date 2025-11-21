using AutoMapper;
using isc.bempleo.be.domain.Models.Response.Certifications;
using isc.bempleo.be.domain.Entity.Certifications;
using isc.bempleo.be.domain.Models.Request.Certifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class CertificationProfile : Profile
    {
        public CertificationProfile()
        {
            CreateMap<CertificationRequest, Certification>();
            CreateMap<Certification, CertificationResponse>();
        }
    }
}
