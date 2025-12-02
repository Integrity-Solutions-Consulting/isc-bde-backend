using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.ProfileAccessCode
{
    public class ProfileAccessCodeResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public bool Status { get; set; }

    }
}
