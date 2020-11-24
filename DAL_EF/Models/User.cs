using System;
using System.Collections.Generic;

namespace DAL_EF.Models
{
    public partial class User
    {
        public User()
        {
            Useragency = new HashSet<Useragency>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Categoryid { get; set; }
        public int? Countryid { get; set; }
        public string Eyes { get; set; }
        public int? Weight { get; set; }
        public int? Heightcm { get; set; }
        public string Heightinch { get; set; }
        public int? Social { get; set; }
        public string Bio { get; set; }
        public string Birthplace { get; set; }
        public string Language { get; set; }
        public string Birthdate { get; set; }
        public bool? Islogged { get; set; }
        public string Urlinsta { get; set; }
        public string Urlfb { get; set; }
        public string Urltwitter { get; set; }
        public string Urltiktok { get; set; }
        public string Urlyoutube { get; set; }
        public string Skin { get; set; }
        public string Chestcm { get; set; }
        public string Chestinch { get; set; }
        public string Waistcm { get; set; }
        public string Waistinch { get; set; }
        public string Hipscm { get; set; }
        public string Hipsinch { get; set; }
        public string Hair { get; set; }
        public string Shoeus { get; set; }
        public string Shoeeu { get; set; }

        public Category Category { get; set; }
        public Country Country { get; set; }
        public ICollection<Useragency> Useragency { get; set; }
    }
}
