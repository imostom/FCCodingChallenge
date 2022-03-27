using FCCodingChallenge.API.Data.ViewModels;
using Newtonsoft.Json;
using System;

namespace FCCodingChallenge.API.Data.Models
{
    public class User 
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime DateUpdated { get; set; }

    }
}
