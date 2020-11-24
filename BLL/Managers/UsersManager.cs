using BLL.Interfaces;
using DAL.Interfaces;
using DTO.RequestDTO;
using DTO.ResponseDTO;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Utils;

namespace BLL.Managers
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepository _UsersRepository;
        private readonly IHostingEnvironment _HostingEnvironment;
        public UsersManager(IUsersRepository usersRepository, IHostingEnvironment hostingEnvironment)
        {
            _UsersRepository = usersRepository;
            _HostingEnvironment = hostingEnvironment;
        }

        public async Task<int> AddUserAsync(UserRequestDTO objRequest)
        {
            int objResponse = 0;
            try
            {
                objRequest.heightinch = CMTOINCH.Conversion(objRequest.heightcm);
                 objResponse = await _UsersRepository.AddUserAsync(objRequest);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objResponse;
        }

        public async Task<UserResponseDTO> DeleteUserAsync(int id)
        {
            UserResponseDTO objResponse = new UserResponseDTO();

            try
            {
               objResponse = await _UsersRepository.DeleteUserAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            return objResponse;
        }

       

        public async Task<List<AgencyResponseDTO>> GetAgenciesByIdAsync(int id)
        {
            List<AgencyResponseDTO> objResponse = new List<AgencyResponseDTO>();
            try
            {
                objResponse = await _UsersRepository.GetAgenciesByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            return objResponse;
        }

        public async Task<UserResponseDTO> GetUserByIdAsync(int id)
        {
            UserResponseDTO objResponse = new UserResponseDTO();

            try
            {
                objResponse = await _UsersRepository.GetUserByIdAsync(id);
                objResponse.image = new List<string>();
                var path = Path.Combine(_HostingEnvironment.WebRootPath, "Pictures", id.ToString());
                if (Directory.Exists(path))
                {
                    string[] fileEntries = Directory.GetFiles(path);
                    foreach (string fileName in fileEntries)
                    {
                        objResponse.image.Add("Pictures/" + id + "/" + Path.GetFileName(fileName));
                    }
                }
                else
                {
                    objResponse.image = new List<string>();
                }

                if (objResponse.social < 1)
                {
                    objResponse.socialCount = (objResponse.social * 1000).ToString();
                }
                else if (objResponse.social < 1000)
                {
                    objResponse.socialCount = objResponse.social + "K";
                }
                else if (objResponse.social >= 1000)
                {
                    objResponse.socialCount = (objResponse.social / 1000) + "M";
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
                objResponse = await _UsersRepository.GetUsersAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return objResponse;
        }

        public async Task EditUserAsync(int id, UserRequestDTO objRequest) { 
            
            try
            {
                objRequest.heightinch = CMTOINCH.Conversion(objRequest.heightcm);

                await _UsersRepository.EditUserAsync(id,objRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public  void DeleteImage(int id, string image)
        {
            UserResponseDTO objResponse = new UserResponseDTO();

            try
            {
                  _UsersRepository.DeleteImage(id,image);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task loginAsync(int id, bool log)
        {
            try
            {
                await _UsersRepository.loginAsync(id, log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

