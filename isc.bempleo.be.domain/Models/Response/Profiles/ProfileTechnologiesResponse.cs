using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Profiles
{
    public class ProfileTechnologiesResponse
    {
        public List<int> KnowledgeIds { get; set; }
        public List<int> ToolIds { get; set; }
        public List<int> SkillIds { get; set; }
        public List<int> CertificationIds { get; set; }
    }
}
