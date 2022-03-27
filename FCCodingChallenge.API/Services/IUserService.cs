using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Services
{
    public interface IUserService
    {
        //Task<GenericResponse<long>> DeleteUser(RemoteDetails remoteDetails, string email);
        Task<GenericResponse<User>> GetUser(string email);
        Task<GenericResponse<object>> GetUserByPhone(string phone);
        Task<GenericResponse<object>> UpdateUser(RemoteDetails remoteDetails, UserVM userVM);
    }
}
