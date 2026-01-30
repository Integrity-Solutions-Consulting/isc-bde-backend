using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.domain.Models.Request.EmployeeCategoryRequirement
{
    public record class EmployeeCategoryRequirementRequest
    {
        public int RequirementId { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int Quantity { get; set; }
    }
}
