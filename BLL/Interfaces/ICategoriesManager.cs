using DTO.ResponseDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoriesManager
    {
        Task<List<CategoryResponseDTO>> GetListOfCategoriesAsync();
        Task<List<UserResponseDTO>> GetUserByCategoryAsync(int id, List<string> filtersArr,int section,string eyes,int agency);
        Task<List<CategoryResponseDTO>> GetAdvancedFiltersAsync(int id,int agency, string eyes);
    }
}
