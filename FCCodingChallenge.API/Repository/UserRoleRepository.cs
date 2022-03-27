using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public UserRoleRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }


        public async Task<long> AddUserRole(long userId, int roleId)
        {
            var queryString = @"INSERT INTO [UserRoles] OUTPUT inserted.Id VALUES (@UserId, @RoleId, @IsDeleted, @DateCreated, @DateUpdated)";


            var dbPara = new DynamicParameters();
            dbPara.Add("UserId", userId);
            dbPara.Add("RoleId", roleId);
            dbPara.Add("IsDeleted", false);
            dbPara.Add("DateCreated", DateTime.Now.AddHours(1));
            dbPara.Add("DateUpdated", null);

            var response = await _dapperRepository.Insert<long>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<long> DeleteUserRole(long userId)
        {
            var queryString = @"UPDATE [UserRoles]  set IsDeleted = @IsDeleted, DateUpdated=@DateUpdated OUTPUT inserted.Id WHERE UserId=@UserId";

            var dbPara = new DynamicParameters();
            dbPara.Add("UserId", userId);
            dbPara.Add("IsDeleted", true);
            dbPara.Add("DateUpdated", DateTime.Now.AddHours(1));

            var response = await _dapperRepository.Execute<long>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }
    }
}
