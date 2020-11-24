using DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<CategoryResponseDTO>> GetListOfCategoriesAsync();
        Task<List<UserResponseDTO>> GetUserByCategoryAsync(int id,string eyes,int agency);
        Task<List<CategoryResponseDTO>> GetAdvancedFiltersAsync(int id,int agency, string eyes);
    }
}
