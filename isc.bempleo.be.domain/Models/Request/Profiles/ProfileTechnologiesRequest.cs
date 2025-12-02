using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Profiles
{
    public class ProfileTechnologiesRequest
    {
        public List<int> KnowledgeIds { get; set; } = new();
        public List<int> ToolIds { get; set; } = new();
        public List<int> SkillIds { get; set; } = new();
        public List<int> CertificationIds { get; set; } = new();
    }
}
