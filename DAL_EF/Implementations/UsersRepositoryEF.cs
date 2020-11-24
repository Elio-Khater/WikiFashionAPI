using DAL_EF.Interfaces;
using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_EF.Implementations
{
    public class UsersRepositoryEF : IUsersRepositoryEF
    {
        wikifashiondbContext context;
        public UsersRepositoryEF()
        {
            context = new wikifashiondbContext();
        }

        public void DeleteUserAsync(int id)
        {
            User user = new User()
            {
                Id = id
            };

            context.Remove<User>(user);
            context.SaveChanges();
        }

        public User GetUserByIdAsync(int id)
        {
            //var users = context.User.Select(x => new { x.Id, x.Lastname }).OrderBy(x=>x.Lastname).ToList();
            var users = context.User.Where(x => x.Id == id).FirstOrDefault();
            return users;
        }
    }
}
