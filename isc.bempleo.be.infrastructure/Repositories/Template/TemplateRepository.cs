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

            // 1. Obtener conexión (Asumimos que viene cerrada o gestionada por el DI)
            var connection = _dbContext.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SP_GetTemplateDetailById";
            command.CommandType = CommandType.StoredProcedure;

            var param = command.CreateParameter();
            param.ParameterName = "p_template_id"; // Ajusta si tu DB usa @p_template_id
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

        public async Task<int> CreateTemplateAsync(string name, string knowledgeIdsJson, string toolIdsJson, string user, string ip)
        {
            var connection = _dbContext.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "SP_SaveTemplate_JSON";
            command.CommandType = CommandType.StoredProcedure;

            // 1. Nombre
            var pName = command.CreateParameter();
            pName.ParameterName = "p_template_name";
            pName.Value = name;
            command.Parameters.Add(pName);

            // 2. Knowledge IDs (Recibe el JSON string ya listo)
            var pKnowledge = command.CreateParameter();
            pKnowledge.ParameterName = "p_knowledge_ids";
            pKnowledge.Value = knowledgeIdsJson;
            command.Parameters.Add(pKnowledge);

            // 3. Tool IDs (Recibe el JSON string ya listo)
            var pTools = command.CreateParameter();
            pTools.ParameterName = "p_tool_ids";
            pTools.Value = toolIdsJson;
            command.Parameters.Add(pTools);

            // 4. Auditoría
            var pUser = command.CreateParameter();
            pUser.ParameterName = "p_user";
            pUser.Value = user;
            command.Parameters.Add(pUser);

            var pIp = command.CreateParameter();
            pIp.ParameterName = "p_ip";
            pIp.Value = ip;
            command.Parameters.Add(pIp);

            // Ejecución
            var result = await command.ExecuteScalarAsync();
            return result != null ? Convert.ToInt32(result) : 0;
        }



    }
}