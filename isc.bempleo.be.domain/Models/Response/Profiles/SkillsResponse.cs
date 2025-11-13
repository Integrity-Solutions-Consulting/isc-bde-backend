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
        public List<KnowledgeResponseForProfile> Knowledges { get; set; } 
        public List<ToolResponseForProfile> Tools { get; set; }
    }
    public class KnowledgeResponseForProfile
    {
        public int Id { get; set; }
        public string KnowledgeType { get; set; }
        public string KnowledgeName { get; set; }
    }

    public class ToolResponseForProfile
    {
        public int Id { get; set; }
        public string ToolName { get; set; }
        public string Certificate { get; set; }

    }
}
