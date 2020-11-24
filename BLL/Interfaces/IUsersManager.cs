using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO.RequestDTO;
using DTO.ResponseDTO;

namespace BLL.Interfaces
{
    public interface IUsersManager
    {
         Task<UserResponseDTO> GetUserByIdAsync(int id);
        Task<List<AgencyResponseDTO>> GetAgenciesByIdAsync(int id);
        Task<int> AddUserAsync(UserRequestDTO objRequest);
        Task<List<UserResponseDTO>> GetUsersAsync();
        Task<UserResponseDTO> DeleteUserAsync(int id);
        Task EditUserAsync(int id,UserRequestDTO objRequest);
        void DeleteImage(int id, string image);
        Task loginAsync(int id, bool log);
    }
}
