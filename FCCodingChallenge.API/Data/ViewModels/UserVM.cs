using FCCodingChallenge.API.Data.Models;

namespace FCCodingChallenge.API.Data.ViewModels
{
    public class UserVM 
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }
    }
}
