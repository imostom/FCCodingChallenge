using FCCodingChallenge.API.Data.ViewModels;
using Newtonsoft.Json;
using System;

namespace FCCodingChallenge.API.Data.Models
{
    public class User : UserVM
    {
        //[JsonIgnore]
        public long Id { get; set; }
       
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public DateTime DateUpdated { get; set; }

    }
}
