using Newtonsoft.Json;

namespace FCCodingChallenge.API.Data.Models
{
    public class Role
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
