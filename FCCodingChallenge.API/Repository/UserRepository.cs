using Dapper;
using FCCodingChallenge.API.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperRepository _dapperRepository;

        public UserRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }


        public async Task<long> AddUser(UserVM userVM)
        {
            var queryString = @"INSERT INTO [User] OUTPUT inserted.Id VALUES (@Firstname, @Lastname, @Email, @Phone, @Gender, @DateOfBirth, @Nationality, @IsDeleted, @DateCreated, @DateUpdated)";


            var dbPara = new DynamicParameters();
            dbPara.Add("Firstname", userVM.Firstname);
            dbPara.Add("Lastname", userVM.Lastname);
            dbPara.Add("Email", userVM.Email);
            dbPara.Add("Phone", userVM.Phone);
            dbPara.Add("Gender", userVM.Gender);
            dbPara.Add("DateOfBirth", userVM.DateOfBirth);
            dbPara.Add("Nationality", userVM.Nationality);
            dbPara.Add("IsDeleted", false);
            dbPara.Add("DateCreated", DateTime.Now.AddHours(1));
            dbPara.Add("DateUpdated", null);

            var response = await _dapperRepository.Insert<long>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<UserVM> GetUser(string email)
        {
            var queryString = @"SELECT * FROM [User] WITH(NOLOCK) WHERE Email=@Email AND IsDeleted = @IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("Email", email);
            dbPara.Add("IsDeleted", false);

            var response = await _dapperRepository.Get<UserVM>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<List<UserVM>> GetUsers()
        {
            var queryString = @"SELECT * FROM [User] WITH(NOLOCK) WHERE IsDeleted = @IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("IsDeleted", false);

            var response = await _dapperRepository.Get<List<UserVM>>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<UserVM> UpdateUser(UserVM userVM)
        {
            var queryString = @"UPDATE [User] OUTPUT updated.Id set Firstname=@Firstname, Lastname=@Lastname, Email=@Email, Phone=@Phone 
Gender=@Gender, DateOfBirth=@DateOfBirth, Nationality=@Nationality, DateUpdated=@DateUpdated WHERE Email=@Email AND IsDeleted = @IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("Firstname", userVM.Firstname);
            dbPara.Add("Lastname", userVM.Lastname);
            dbPara.Add("Email", userVM.Email);
            dbPara.Add("Phone", userVM.Phone);
            dbPara.Add("Gender", userVM.Gender);
            dbPara.Add("DateOfBirth", userVM.DateOfBirth);
            dbPara.Add("Nationality", userVM.Nationality);
            dbPara.Add("IsDeleted", false);
            dbPara.Add("DateUpdated", DateTime.Now.AddHours(1));

            var response = await _dapperRepository.Execute<UserVM>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<long> DeleteUser(string email)
        {
            var queryString = @"UPDATE [User] OUTPUT updated.Id set IsDeleted = @IsDeleted, DateUpdated=@DateUpdated WHERE Email=@Email";

            var dbPara = new DynamicParameters();
            dbPara.Add("Email", email);
            dbPara.Add("IsDeleted", true);
            dbPara.Add("DateUpdated", DateTime.Now.AddHours(1));

            var response = await _dapperRepository.Execute<long>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }
    }
}
