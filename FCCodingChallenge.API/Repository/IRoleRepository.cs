using FCCodingChallenge.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public interface IRoleRepository
    {
        Task<Role> GetRole(string name);
        Task<List<string>> GetRoles();
    }
}