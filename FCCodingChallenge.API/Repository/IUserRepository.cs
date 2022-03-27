using FCCodingChallenge.API.Data.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public interface IUserRepository
    {
        Task<long> AddUser(UserVM userVM);
        Task<long> DeleteUser(string email);
        Task<UserVM> GetUser(string email);
        Task<List<UserVM>> GetUsers();
        Task<UserVM> UpdateUser(UserVM userVM);
    }
}
