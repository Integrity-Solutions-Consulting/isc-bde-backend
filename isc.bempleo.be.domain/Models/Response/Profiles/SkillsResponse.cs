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
        public KnowledgeResponse Knowledges { get; set; } 
        public ToolResponse Tools { get; set; }
    }
    public class KnowledgeResponse
    {
        public int Id { get; set; }
        public List<string> KnowledgeType { get; set; }
        public List<string> KnowledgeName { get; set; }
    }

    public class ToolResponse
    {
        public int Id { get; set; }
        public List<string> ToolName { get; set; }
        public List<string> Certificate { get; set; }

    }
}
