using isc.bempleo.be.domain.Entity.Tools;
using isc.bempleo.be.domain.Models.Request.Tools;
using isc.bempleo.be.domain.Models.Response.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.application.Utils.Mapping
{
    public class ToolProfile : AutoMapper.Profile
    {
        public ToolProfile()
        {

            CreateMap<Tool, ToolResponse>();
            CreateMap<ToolResponse, Tool>();

            CreateMap<Tool, ToolRequest>();
            CreateMap<ToolRequest, Tool>();

            CreateMap<ToolRequest, ToolResponse>();
        }
    }
}
