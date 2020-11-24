using DAL_EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_EF.Interfaces
{
    public interface IUsersRepositoryEF
    {
        User GetUserByIdAsync(int id);
        void DeleteUserAsync(int id);


    }
}
