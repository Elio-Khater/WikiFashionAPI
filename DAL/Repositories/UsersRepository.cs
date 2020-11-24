using DAL.Interfaces;
using Dapper;
using DTO.RequestDTO;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _Configuration;
        private readonly IHostingEnvironment _HostingEnvironment;

        public UsersRepository(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _Configuration = configuration;
            _HostingEnvironment = hostingEnvironment;
        }

        public async Task<int> AddUserAsync(UserRequestDTO objRequest)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("eyes", objRequest.eyes);
                    param.Add("categoryid", objRequest.categoryid);
                    param.Add("birthdate", objRequest.birthdate);
                    param.Add("birthplace", objRequest.birthplace);
                    param.Add("firstname", objRequest.firstname);
                    param.Add("heightcm", objRequest.heightcm);
                    param.Add("heightinch", objRequest.heightinch);
                    param.Add("lastname", objRequest.lastname);
                    param.Add("countryid", objRequest.countryid);
                    param.Add("weight", objRequest.weight);
                    param.Add("social", objRequest.social);
                    param.Add("bio", objRequest.bio);
                    param.Add("hipscm", objRequest.hipscm);
                    param.Add("hipsinch", objRequest.hipsinch);
                    param.Add("waistcm", objRequest.waistcm);
                    param.Add("waistinch", objRequest.waistinch);
                    param.Add("chestcm", objRequest.chestcm);
                    param.Add("chestinch", objRequest.chestinch);
                    param.Add("shoeus", objRequest.shoeus);
                    param.Add("shoeeu", objRequest.shoeeu);
                    param.Add("skin", objRequest.skin);
                    param.Add("hair", objRequest.hair);
                    param.Add("id", direction: ParameterDirection.Output, dbType: DbType.Int32);
                    await conn.ExecuteAsync(sql: "AddUser", param: param, commandType: CommandType.StoredProcedure);
                    return param.Get<Int32>("id");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  void DeleteImage(int id, string image)
        {
            
            try
            {
                var path = Path.Combine(_HostingEnvironment.WebRootPath, "Pictures", id.ToString());

                var part2 = Path.GetFileName(image);
                if (Directory.Exists(path))
                {
                    string[] fileEntries = Directory.GetFiles(path);

                    foreach (string fileName in fileEntries)
                    {
                        var part1 = fileName.Split('\\').Last();
                        if (part1 == part2)
                        {
                            File.Delete(fileName);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<UserResponseDTO> DeleteUserAsync(int id)
        {
            UserResponseDTO objResponse = new UserResponseDTO();
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("id", id);
                    objResponse = await conn.QueryFirstOrDefaultAsync<UserResponseDTO>(sql: "DeleteUser", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objResponse;
        }

        public async Task EditUserAsync(int id,UserRequestDTO objRequest)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("id", id);
                    param.Add("eyes", objRequest.eyes);
                    param.Add("categoryid", objRequest.categoryid);
                    param.Add("birthdate", objRequest.birthdate);
                    param.Add("birthplace", objRequest.birthplace);
                    param.Add("firstname", objRequest.firstname);
                    param.Add("heightcm", objRequest.heightcm);
                    param.Add("heightinch", objRequest.heightinch);
                    param.Add("lastname", objRequest.lastname);
                    param.Add("countryid", objRequest.countryid);
                    param.Add("weight", objRequest.weight);
                    param.Add("social", objRequest.social);
                    param.Add("bio", objRequest.bio);

                    await conn.ExecuteAsync(sql: "EditUser", param: param, commandType: CommandType.StoredProcedure);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            UserResponseDTO objResponse = new UserResponseDTO();
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("userid", id);
                    objResponse = await conn.QueryFirstOrDefaultAsync<UserResponseDTO>(sql: "GetUserById", param: param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objResponse;
        }

        public async Task<List<UserResponseDTO>> GetUsersAsync()
        {
            List<UserResponseDTO> objResponse = new List<UserResponseDTO>();
            try
            {

                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    
                    var response = await conn.QueryAsync<UserResponseDTO>(sql: "GetUsers", param: param, commandType: CommandType.StoredProcedure);
                    objResponse = response.AsList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objResponse;
        }

        public async Task loginAsync(int id, bool log)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("id", id);
                    param.Add("log", log);
                    await conn.ExecuteAsync(sql: "Login", param: param, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<List<AgencyResponseDTO>> IUsersRepository.GetAgenciesByIdAsync(int id)
        {
            List<AgencyResponseDTO> objResponse = new List<AgencyResponseDTO>();
            try
            {

                using (IDbConnection conn = new SqlConnection(_Configuration.GetSection("Database").Value))
                {
                    var param = new DynamicParameters();
                    param.Add("userId", id);
                    var response = await conn.QueryAsync<AgencyResponseDTO>(sql: "GetAgenciesByUser", param: param, commandType: CommandType.StoredProcedure);
                    objResponse = response.AsList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return objResponse;
        }
    }
}
