using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ResponseDTO
{
    public class UserResponseDTO
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public List<string> image { get; set; }
        public string bio { get; set; }
        public int categoryid { get; set; }
        public string country { get; set; }
        public int countryid { get; set; }
        public string eyes { get; set; }
        public int social { get; set; }
        public string socialCount { get; set; }
        public string birthplace { get; set; }
        public string birthdate { get; set; }
        public string heightinch { get; set; }
        public int heightcm { get; set; }
        public int weight { get; set; }
        public string motheragency { get; set; }
        public string language { get; set; }
        public bool islogged { get; set; }
        public string urlinsta { get; set; }
        public string urlfacebook { get; set; }
        public string urltiktok { get; set; }
        public string urltwitter { get; set; }
        public string urlyoutube { get; set; }
        public string skin { get; set; }
        public string chestcm { get; set; }
        public string chestinch { get; set; }
        public string waistcm { get; set; }
        public string waistinch { get; set; }
        public string hipscm{ get; set; }
        public string hipsinch{ get; set; }
        public string hair { get; set; }
        public string shoeus { get; set; }
        public string shoeeu { get; set; }

    }
}
