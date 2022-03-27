using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public RoleRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<List<string>> GetRoles()
        {
            var queryString = @"SELECT Name FROM [Roles] WITH(NOLOCK) WHERE IsDeleted = @IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("IsDeleted", false);

            var response = await _dapperRepository.Get<List<string>>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }
    }
}
