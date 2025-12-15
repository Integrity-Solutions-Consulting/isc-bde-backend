using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.Experiences
{
    public class Experience : BaseEntity
    {
        public string CompanyName { get; set; } = null!;
        public string PositionHeld { get; set; } = null!;
        public int? ExperienceTime { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;

    }
}
