using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Profiles
{
    public class SkillsRequest
    {
        public int ProfileId { get; set; }  

        public KnowledgeRequest Knowledges { get; set; } 
        public ToolRequest Tools { get; set; } 
    }
    public class KnowledgeRequest
    {
        public List<string> KnowledgeType { get; set; }   
        public List<string> KnowledgeName { get; set; }   
    }

    public class ToolRequest
    {
        public List<string> ToolName { get; set; }
        public List<string> Certificate { get;set; }
    }
}
