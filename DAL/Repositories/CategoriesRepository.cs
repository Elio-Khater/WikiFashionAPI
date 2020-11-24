using DAL.Interfaces;
using Dapper;
using DTO.ResponseDTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IConfiguration _Configuration;
        public CategoriesRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public async Task<List<CategoryResponseDTO>> GetAdvancedFiltersAsync(int id,int agency, string eyes)
        {
            List<CategoryResponseDTO> objResponse = new List<CategoryResponseDTO>();
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("id", id);
                    param.Add("agency", agency);
                    param.Add("eyes", eyes);
                    //param.Add("skin", skin);
                    var Response = await conn.QueryAsync<CategoryResponseDTO>(sql: "GetAdFilters", param: param, commandType: CommandType.StoredProcedure);
                    objResponse = Response.AsList();
                }
            }
            catch (Exception ex)    
            {

                throw ex;
            }
            return objResponse;
        }

        public async Task<List<CategoryResponseDTO>> GetListOfCategoriesAsync()
        {
            List<CategoryResponseDTO> objResponse = new List<CategoryResponseDTO>();
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    //param.Add("user", "elio");
                    var Response = await conn.QueryAsync<CategoryResponseDTO>(sql: "GetCategories", param: param, commandType: CommandType.StoredProcedure);
                    objResponse = Response.AsList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objResponse;
        }

        public async Task<List<UserResponseDTO>> GetUserByCategoryAsync(int id,string eyes,int agency)
        {
            List<UserResponseDTO> objResponse = new List<UserResponseDTO>();
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    
                    var param = new DynamicParameters();
                    param.Add("id", id);
                    param.Add("eyes", eyes);
                    param.Add("agency", agency);

                    var Response = await conn.QueryAsync<UserResponseDTO>(sql: "GetUsersByCategory", param: param, commandType: CommandType.StoredProcedure);
                    objResponse = Response.AsList();
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
