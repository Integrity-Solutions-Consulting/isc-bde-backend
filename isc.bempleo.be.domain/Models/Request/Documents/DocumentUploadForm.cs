using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.Documents
{
    public class DocumentUploadForm
    {
        public int? ProcessId { get; set; }      
        public string? ProcessName { get; set; } 
        public IFormFile File { get; set; }    
    }
}
    