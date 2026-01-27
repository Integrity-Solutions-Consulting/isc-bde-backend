using isc.bempleo.be.domain.Models.Response.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Template
{
    public record class TemplateDetailResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<KnowledgeResponse> Knowledges { get; set; } = new();
        public List<ToolResponse> Tools { get; set; } = new();
    }
}
