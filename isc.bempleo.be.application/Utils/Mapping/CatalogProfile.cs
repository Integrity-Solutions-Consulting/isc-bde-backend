using AutoMapper;
using isc.bempleo.be.domain.Entity.Catalogs;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Models.Response.Catalogs;
using isc.bempleo.be.domain.Models.Response.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<ApplicationStatu, ApplicationStatuResponse>();

            CreateMap<Career, CareerResponse>();

            CreateMap<Certification, CertificationResponse>();

            CreateMap<Document, DocumentResponse>();
            CreateMap<DocumentResponse, Document>();

            CreateMap<Knowledge, KnowledgeResponse>();

            CreateMap<MaritalStatu, MaritalStatuResponse>();

            CreateMap<Skill, SkillResponse>();

            CreateMap<Tool, ToolResponse>();

            CreateMap<Vacancy, VacancyResponse>();

        }
    }
}
