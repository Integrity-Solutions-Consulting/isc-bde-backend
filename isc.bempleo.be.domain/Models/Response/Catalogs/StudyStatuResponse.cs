using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Catalogs
{
    public record StudyStatuResponse
    {
        public int Id { get; set; }
        public string StudyName { get; set; }

    }
}
