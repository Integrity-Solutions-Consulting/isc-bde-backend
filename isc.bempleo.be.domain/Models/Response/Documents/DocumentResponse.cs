using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Response.Documents
{
    public class DocumentResponse
    {
        public int Id { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
    }
}
