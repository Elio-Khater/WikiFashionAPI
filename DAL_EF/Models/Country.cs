using System;
using System.Collections.Generic;

namespace DAL_EF.Models
{
    public partial class Country
    {
        public Country()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
