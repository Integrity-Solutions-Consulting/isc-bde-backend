using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Experiences
{
    public class ExperienceUpdateRequest
    {
        public string CompanyName { get; set; } = null!;
        public string PositionHeld { get; set; } = null!;
        public string? ExperienceTime { get; set; }

    }
}
