using DAL_EF.Models;
using DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.Interfaces
{
    public interface ICategoriesRepositoryEF
    {
        List<Category> GetListOfCategoriesAsync();
        List<User> GetUserByCategoryAsync(int id, string eyes, int agency);

    }
}
