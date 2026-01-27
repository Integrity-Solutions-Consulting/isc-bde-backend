using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Booklets
{
    public record class TemplateRequest
    {
        public string TemplateName { get; set; } 
        public List<int> KnowledgeIds { get; set; } 
        public List<int> ToolIds { get; set; }
    }
}
