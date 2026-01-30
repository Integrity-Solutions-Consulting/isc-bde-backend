using isc.bempleo.be.application.Interfaces.Repository.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Request.EmployeeCategoryRequirement;
using isc.bempleo.be.domain.Models.Response.EmployeeCategoryRequirement;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.EmployeeCategoryRequirement
{
    public class EmployeeCategoryRequirementRepository : IEmployeeCategoryRequirementRepository
    {
        private readonly DBContext _dbContext;

        public EmployeeCategoryRequirementRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeCategoryRequirementResponse> CreateEmployeeCategoryRequirementAsync(EmployeeCategoryRequirementRequest request)
        {
            var pRequirementId = new MySqlParameter("@p_requirement_id", request.RequirementId);
            var pCategoryId = new MySqlParameter("@p_employee_category_id", request.EmployeeCategoryId);
            var pQuantity = new MySqlParameter("@p_quantity", request.Quantity);

            var result = await _dbContext.Database
                .SqlQueryRaw<EmployeeCategoryRequirementResponse>(
                    "CALL SP_CreateEmployeeCategoryRequirement(@p_requirement_id, @p_employee_category_id, @p_quantity)",
                    pRequirementId, pCategoryId, pQuantity
                )
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }





}