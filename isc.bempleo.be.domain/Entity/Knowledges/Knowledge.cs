using isc.bempleo.be.domain.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Entity.Knowledges
{
    public class Knowledge : BaseEntity
    {
        public int ProfileId { get; set; }
        public string KnowledgeType { get; set; }
        public string KnowledgeName { get; set; }

    }
}
