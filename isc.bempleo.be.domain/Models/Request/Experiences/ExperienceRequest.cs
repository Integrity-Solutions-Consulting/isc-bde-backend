using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Experiences
{
    public class ExperienceRequest
    {
        public string CompanyName { get; set; } = null!;
        public string PositionHeld { get; set; } = null!;
        public int? ExperienceTime { get; set; }

        public int ProfileId { get; set; }
    }
}
