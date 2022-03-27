using FCCodingChallenge.API.Data;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Services
{
    public interface IRoleService
    {
        Task<GenericResponse<object>> GetRoles();
    }
}