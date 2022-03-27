using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public interface IUserRepository
    {
        Task<long> AddUser(UserVM userVM);
        Task<long> DeleteUser(string email);
        Task<User> GetUser(string email);
        Task<List<User>> GetUserByPhone(string phone);
        Task<List<UserVM>> GetUsers();
        Task<long> UpdateUser(UserVM userVM, long userId);
    }
}
