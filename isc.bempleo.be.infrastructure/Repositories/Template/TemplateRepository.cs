using isc.bempleo.be.application.Interfaces.Repository.Booklets;
using isc.bempleo.be.domain.Models.Request.Booklets;
using isc.bempleo.be.domain.Models.Response.Booklets;
using isc.bempleo.be.domain.Models.Response.Catalogs;
using isc.bempleo.be.domain.Models.Response.Template;
using isc.bempleo.be.infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace isc.bempleo.be.infrastructure.Repositories.Booklets
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly DBContext _dbContext;

        public TemplateRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TemplateResponse>> GetBookletAsync()
        {
            return await _dbContext
                .Set<TemplateResponse>()
                .FromSqlRaw("CALL SP_GetTemplates()")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TemplateDetailResponse?> GetTemplateByIdAsync(int id)
        {
            var response = new TemplateDetailResponse();

            var connection = _dbContext.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SP_GetTemplateDetailById";
            command.CommandType = CommandType.StoredProcedure;

            var param = command.CreateParameter();
            param.ParameterName = "p_template_id";
            param.Value = id;
            command.Parameters.Add(param);

            // 2. Ejecutar
            using var reader = await command.ExecuteReaderAsync();

            // --- TABLA 1: DATOS DE LA PLANTILLA ---
            if (await reader.ReadAsync())
            {
                response.Id = reader.GetInt32(reader.GetOrdinal("TemplateID"));
                response.Name = reader.GetString(reader.GetOrdinal("template_name"));
            }
            else
            {
                // Si no hay datos en la primera tabla, no existe la plantilla.
                return null;
            }

            // --- TABLA 2: CONOCIMIENTOS ---
            // NextResultAsync() salta al segundo SELECT del SP
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Knowledges.Add(new KnowledgeResponse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("KnowledgeID")),
                        KnowledgeName = reader.GetString(reader.GetOrdinal("knowledge_name"))
                    });
                }
            }

            // --- TABLA 3: HERRAMIENTAS ---
            // NextResultAsync() salta al tercer SELECT del SP
            if (await reader.NextResultAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Tools.Add(new ToolResponse
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ToolID")),
                        ToolName = reader.GetString(reader.GetOrdinal("tool_name"))
                    });
                }
            }

            return response;
        }

        public async Task<TemplateResponse> CreateTemplateAsync(
            string name,
            string knowledgeIdsJson,
            string toolIdsJson)
        {
            var connection = _dbContext.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SP_CreateTemplate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new MySqlParameter("p_template_name", name));
            command.Parameters.Add(new MySqlParameter("p_knowledge_ids", knowledgeIdsJson));
            command.Parameters.Add(new MySqlParameter("p_tool_ids", toolIdsJson));

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new TemplateResponse
                {
                    TemplateID = reader.GetInt32("TemplateID"),
                    
                };
            }

            return null!;
        }




    }
}