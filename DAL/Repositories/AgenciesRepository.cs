using DAL.Interfaces;
using Dapper;
using DTO.ResponseDTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AgenciesRepository : IAgenciesRepository
    {
        private readonly IConfiguration _Configuration;
        public AgenciesRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public async Task<bool> AddAgenciesToUserAsync(int id, List<int> agencies)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    foreach (int agency in agencies) {
                        var param = new DynamicParameters();
                        param.Add("agency", agency);
                        param.Add("id", id);
                        await conn.ExecuteAsync(sql: "AddAgenciesToUser", param: param, commandType: CommandType.StoredProcedure);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public async Task<bool> AddAgencyAsync(string agency,string link)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("agency", agency);
                    param.Add("link", link);
                    await conn.ExecuteAsync(sql: "AddAgency", param: param, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public async Task EditAgenciesToUserAsync(int id, List<int> agencies)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("id", id);
                    await conn.ExecuteAsync(sql: "DeleteAgenciesToUser", param: param, commandType: CommandType.StoredProcedure);
                    foreach (int agency in agencies)
                    {
                        param = new DynamicParameters();
                        param.Add("agency", agency);
                        param.Add("id", id);
                        await conn.ExecuteAsync(sql: "AddAgenciesToUser", param: param, commandType: CommandType.StoredProcedure);
                    }
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        public async Task<List<AgencyResponseDTO>> GetAgenciesAsync()
        {
            List<AgencyResponseDTO> objResponse = new List<AgencyResponseDTO>();
            try
            {

                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    var response = await conn.QueryAsync<AgencyResponseDTO>(sql: "GetAgencies", param: param, commandType: CommandType.StoredProcedure);
                    objResponse = response.AsList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objResponse;
        }
    }
}
