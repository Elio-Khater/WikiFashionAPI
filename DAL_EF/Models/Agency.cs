using System;
using System.Collections.Generic;

namespace DAL_EF.Models
{
    public partial class Agency
    {
        public Agency()
        {
            Useragency = new HashSet<Useragency>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public ICollection<Useragency> Useragency { get; set; }
    }
}
