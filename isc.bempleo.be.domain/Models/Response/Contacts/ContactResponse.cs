using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Contacts
{
    public record class ContactResponse
    {
        public int ContactID { get; set; } 
        public int ClientID { get; set; }  
        public string first_name { get; set; } 
        public string last_name { get; set; }  
        public string email { get; set; }      
    }
}
