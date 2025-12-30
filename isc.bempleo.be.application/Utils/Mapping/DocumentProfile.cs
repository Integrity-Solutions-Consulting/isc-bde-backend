using AutoMapper;
using isc.bempleo.be.domain.Entity.Documents;
using isc.bempleo.be.domain.Models.Request.Documents;
using isc.bempleo.be.domain.Models.Response.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {

            CreateMap<Document, DocumentRequest>();
            CreateMap<DocumentRequest, Document>();
        
        }
    }
}
