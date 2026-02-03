using isc.bempleo.be.application.Interfaces.Repository.Requirements;
using isc.bempleo.be.domain.Models.Request.Requirements;
using isc.bempleo.be.domain.Models.Response.Requirements;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Repositories.Requirements
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly DBContext _dbContext;

        public RequirementRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequirementResponse> CreateRequirementAsync(RequirementRequest request)
        {
            var pContactId = new MySqlParameter("@p_contact_id", request.ContactId);
            var pWorkModeId = new MySqlParameter("@p_work_mode_id", request.WorkModeId);
            var pCareerId = new MySqlParameter("@p_career_id", request.CareerId);
            var pVacancyId = new MySqlParameter("@p_vacancy_id", request.VacancyId);
            var pWorkCityId = new MySqlParameter("@p_work_city_id", request.WorkCityId);

            var pTemplateId = new MySqlParameter("@p_template_id", request.TemplateId ?? (object)DBNull.Value);

            var pEducationStatusId = new MySqlParameter("@p_education_status_id", request.EducationStatusId);


            var pContractPeriod = new MySqlParameter("@p_contract_period", request.ContractPeriod ?? (object)DBNull.Value);
            var pBudget = new MySqlParameter("@p_budget", request.Budget);
            var pWorkingHours = new MySqlParameter("@p_working_hours", request.WorkingHours ?? (object)DBNull.Value);
            var pYearsExp = new MySqlParameter("@p_years_experience", request.YearsExperience);
            var pOthercertification = new MySqlParameter("@p_other_certification", request.OtherCertification ?? (object)DBNull.Value);
            var pOtherKnowledge = new MySqlParameter("@p_other_knowledge", request.OtherKnowledge ?? (object)DBNull.Value);
            var pComments = new MySqlParameter("@p_additional_comments", request.AdditionalComments ?? (object)DBNull.Value);

            var result = await _dbContext.Set<RequirementResponse>()
                    .FromSqlRaw(@"CALL SP_CreateRequirement(
                                @p_contact_id,
                                @p_work_mode_id,
                                @p_career_id,
                                @p_vacancy_id,
                                @p_work_city_id,
                                @p_template_id,
                                @p_education_status_id,
                                @p_contract_period,
                                @p_budget,
                                @p_working_hours,
                                @p_years_experience,
                                @p_other_certification,
                                @p_other_knowledge,
                                @p_additional_comments)",
                            pContactId, pWorkModeId, pCareerId,
                            pVacancyId, pWorkCityId, pTemplateId,pEducationStatusId,
                            pContractPeriod, pBudget, pWorkingHours, pYearsExp, pOthercertification,
                            pOtherKnowledge, pComments).ToListAsync();

            return result.FirstOrDefault();
        }



    }
}
