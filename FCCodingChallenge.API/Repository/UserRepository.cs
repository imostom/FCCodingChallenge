using Dapper;
using FCCodingChallenge.API.Data.Models;
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

        public async Task<User> GetUser(string email)
        {
            var queryString = @"select u.Id, u.Firstname, u.Lastname, u.Email, u.Phone, u.Nationality, u.Gender, u.DateOfBirth, r.[Name] as [Role]
                from [User] AS u
                LEFT JOIN [UserRoles] as ur
                ON u.Id = ur.UserId
                LEFT JOIN [Roles] AS r
                ON ur.RoleId = r.Id
                WHERE u.Email = @Email
                AND u.IsDeleted=@IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("Email", email);
            dbPara.Add("IsDeleted", false);

            var response = await _dapperRepository.Get<User>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<List<User>> GetUserByPhone(string phone)
        {
            var queryString = @"select u.Id, u.Firstname, u.Lastname, u.Email, u.Phone, u.Nationality, u.Gender, u.DateOfBirth, r.[Name] as [Role]
                from [User] AS u
                LEFT JOIN [UserRoles] as ur
                ON u.Id = ur.UserId
                LEFT JOIN [Roles] AS r
                ON ur.RoleId = r.Id
                WHERE u.Phone = @Phone
                AND u.IsDeleted=@IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("Phone", phone);
            dbPara.Add("IsDeleted", false);

            var response = await _dapperRepository.GetAll<User>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<List<UserVM>> GetUsers()
        {
            //var queryString = @"SELECT * FROM [User] WITH(NOLOCK) WHERE IsDeleted = @IsDeleted";

            var queryString = @"select u.Id, u.Firstname, u.Lastname, u.Email, u.Phone, u.Nationality, u.Gender, u.DateOfBirth, r.[Name] as [Role]
                from [User] AS u
                LEFT JOIN [UserRoles] as ur
                ON u.Id = ur.UserId
                LEFT JOIN [Roles] AS r
                ON ur.RoleId = r.Id
                WHERE u.IsDeleted=@IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("IsDeleted", false);

            var response = await _dapperRepository.GetAll<UserVM>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }

        public async Task<long> UpdateUser(UserVM userVM, long userId)
        {
            var queryString = @"UPDATE [User]  set Firstname=@Firstname, Lastname=@Lastname, Email=@Email, Phone=@Phone, 
Gender=@Gender, DateOfBirth=@DateOfBirth, Nationality=@Nationality, DateUpdated=@DateUpdated OUTPUT inserted.Id WHERE Id=@Id AND IsDeleted = @IsDeleted";

            var dbPara = new DynamicParameters();
            dbPara.Add("Id", userId);
            dbPara.Add("Firstname", userVM.Firstname);
            dbPara.Add("Lastname", userVM.Lastname);
            dbPara.Add("Email", userVM.Email);
            dbPara.Add("Phone", userVM.Phone);
            dbPara.Add("Gender", userVM.Gender);
            dbPara.Add("DateOfBirth", userVM.DateOfBirth);
            dbPara.Add("Nationality", userVM.Nationality);
            dbPara.Add("IsDeleted", false);
            dbPara.Add("DateUpdated", DateTime.Now.AddHours(1));

            var response = await _dapperRepository.Execute<long>(queryString, dbPara, commandType: CommandType.Text);

            return response;

        }

        public async Task<long> DeleteUser(string email)
        {
            var queryString = @"UPDATE [User]  set IsDeleted = @IsDeleted, DateUpdated=@DateUpdated OUTPUT inserted.Id WHERE Email=@Email";

            var dbPara = new DynamicParameters();
            dbPara.Add("Email", email);
            dbPara.Add("IsDeleted", true);
            dbPara.Add("DateUpdated", DateTime.Now.AddHours(1));

            var response = await _dapperRepository.Execute<long>(queryString, dbPara, commandType: CommandType.Text);

            return response;
        }
    }
}
