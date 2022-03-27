using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Services
{
    public interface IUserRoleService
    {
        Task<GenericResponse<object>> AddUserRole(RemoteDetails remoteDetails, UserVM userRoleRequest);
        Task<GenericResponse<object>> DeleteUserRole(RemoteDetails remoteDetails, string email);
    }
}