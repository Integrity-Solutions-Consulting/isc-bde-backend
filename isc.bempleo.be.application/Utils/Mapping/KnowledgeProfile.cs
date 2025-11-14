using AutoMapper;
using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.domain.Models.Request.Knowledges;
using isc.bempleo.be.domain.Models.Response.Knowledges;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class KnowledgeProfile : Profile
    {
        public KnowledgeProfile()
        {
            CreateMap<KnowledgeRequest, Knowledge>();
            CreateMap<Knowledge, KnowledgeResponse>();

            CreateMap<KnowledgeRequest, KnowledgeResponse>();

        }
    }
}
