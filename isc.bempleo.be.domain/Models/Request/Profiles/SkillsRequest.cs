using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Profiles
{
    public class SkillsRequest
    {
        //public int ProfileId { get; set; }  

        public List<KnowledgeRequestForProfile> Knowledges { get; set; } 
        public List<ToolRequestForProfile> Tools { get; set; } 
    }
    public class KnowledgeRequestForProfile
    {
        public string KnowledgeType { get; set; }   
        public string KnowledgeName { get; set; }   
    }   

    public class ToolRequestForProfile
    {
        public string ToolName { get; set; }
        public string Certificate { get;set; }
    }
}
