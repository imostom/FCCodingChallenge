using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public interface IRoleRepository
    {
        Task<List<string>> GetRoles();
    }
}