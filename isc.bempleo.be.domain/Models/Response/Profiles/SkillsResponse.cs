using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Profiles
{
    public class SkillsResponse
    {
        public int ProfileId { get; set; }
        public List<KnowledgeResponse> Knowledges { get; set; } 
        public List<ToolResponse> Tools { get; set; }
    }
    public class KnowledgeResponse
    {
        public int Id { get; set; }
        public string KnowledgeType { get; set; }
        public string KnowledgeName { get; set; }
    }

    public class ToolResponse
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public string Certificate { get; set; }

    }
}
