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


    public class CountryRepository : ICountryRepository
    {
        private readonly IConfiguration _Configuration;
        public CountryRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public async Task<List<CountryResponseDTO>> GetCountriesAsync()
        {
            List<CountryResponseDTO> objResponse = new List<CountryResponseDTO>();
            try
            {

                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    
                    var response = await conn.QueryAsync<CountryResponseDTO>(sql: "GetCountries", param: param, commandType: CommandType.StoredProcedure);
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
