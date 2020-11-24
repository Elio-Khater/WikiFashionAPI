using System;
using System.Collections.Generic;

namespace DAL_EF.Models
{
    public partial class Useragency
    {
        public int Userid { get; set; }
        public int Agencyid { get; set; }
        public bool? IsMotherAgency { get; set; }

        public Agency Agency { get; set; }
        public User User { get; set; }
    }
}
