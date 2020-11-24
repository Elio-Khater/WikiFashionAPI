using DAL_EF.Interfaces;
using DAL_EF.Models;
using DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_EF.Implementations
{
    public class CategoriesRepositoryEF : ICategoriesRepositoryEF
    {
        wikifashiondbContext context;
        public CategoriesRepositoryEF()
        {
            context = new wikifashiondbContext();
        }
        public List<Category> GetListOfCategoriesAsync()
        {
            var categories = context.Category.ToList();
            return categories;
        }

        public List<User> GetUserByCategoryAsync(int id, string eyes, int agency)
        {
            var users = context.User.Where(x => x.Categoryid == id && x.Eyes==eyes).Include(x=>x.Useragency).ToList();
            return users;
        }
    }
}
