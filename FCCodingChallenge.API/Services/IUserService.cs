using FCCodingChallenge.API.Data;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Services
{
    public interface IUserService
    {
        Task<GenericResponse<object>> GetUser(string email);
    }
}
