using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Experiences
{
    public class ExperienceResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } 
        public string PositionHeld { get; set; } 
        public int? ExperienceTime { get; set; }

        public int ProfileId { get; set; }
    }
}
