using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.Documents
{
    public class DocumentData : BaseEntity
    {
        public int Id { get; set; }                    
        public int? ProcessId { get; set; }             
        public string ProcessName { get; set; }         
        public string FileName { get; set; }            
        public string FilePath { get; set; }           
        public byte[] FileData { get; set; }            
        public string FileExtension { get; set; }       
    }
}
