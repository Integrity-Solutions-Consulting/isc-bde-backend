using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.Genders
{
    public class Gender : BaseEntity
    {
        public string GenderCode { get; set; }
        public string GenderName { get; set; }
    }
}
