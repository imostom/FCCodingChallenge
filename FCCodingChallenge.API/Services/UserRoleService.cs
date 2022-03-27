using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Enum;
using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using FCCodingChallenge.API.Repository;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace FCCodingChallenge.API.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserRoleService(ILoggerManager loggerManager, IUserRoleRepository userRoleRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _loggerManager = loggerManager;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }


        public async Task<GenericResponse<object>> AddUserRole(RemoteDetails remoteDetails, UserVM userRoleRequest)
        {
            string serviceName = "AddUserRole";
            try
            {
                _loggerManager.Information($"Request from :{JsonConvert.SerializeObject(remoteDetails)} Body:{JsonConvert.SerializeObject(userRoleRequest)}");

                if (string.IsNullOrEmpty(userRoleRequest.Email) || string.IsNullOrEmpty(userRoleRequest.Role))
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ValidationError).ToString(), ResponseMessage = $"Empty Parameters Not Allowed", Caller = serviceName };

                    //add user details
                    var userId = await _userRepository.AddUser(userRoleRequest);
                    if (userId is 0)
                        return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"User Creation Failed", Caller = serviceName };

                    //get role details
                    var role = await _roleRepository.GetRole(userRoleRequest.Role);
                    if (role is null || role.Id is 0)
                        return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"Role Not Found", Caller = serviceName };

                    //add user role
                    var userRoleId = await _userRoleRepository.AddUserRole(userId, role.Id);
                    if (userRoleId <= 0)
                        return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"User Role Creation Failed", Caller = serviceName };

                    return new GenericResponse<object> { IsSuccessful = true, ResponseCode = ((int)ResponseCode.Successful).ToString(), ResponseMessage = $"Success", Caller = serviceName, Data = null };

            }
            catch (Exception ex)
            {
                _loggerManager.Error($"Error {serviceName} - ", ex);
                return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ProcessingError).ToString(), ResponseMessage = $"Processing Error - {ex.Message}", Caller = serviceName };
            }
        }

        public async Task<GenericResponse<object>> DeleteUserRole(RemoteDetails remoteDetails, string email)
        {
            string serviceName = "DeleteUserRole";
            try
            {
                _loggerManager.Information($"Request from :{JsonConvert.SerializeObject(remoteDetails)} ");

                if (string.IsNullOrEmpty(email))
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ValidationError).ToString(), ResponseMessage = $"Empty Parameters Not Allowed", Caller = serviceName };

                //get user details
                var user = await _userRepository.GetUser(email);
                if (user is null)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"User Not Found", Caller = serviceName };

                //delete user role details
                var reponse = await _userRoleRepository.DeleteUserRole(user.Id);
                if (reponse is <= 0)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"User Role Deletion Failed", Caller = serviceName };

                //delete user
                var userResponse = await _userRepository.DeleteUser(user.Email);
                if (userResponse <= 0)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"User Deletion Failed", Caller = serviceName };

                return new GenericResponse<object> { IsSuccessful = true, ResponseCode = ((int)ResponseCode.Successful).ToString(), ResponseMessage = $"Success", Caller = serviceName, Data = null };

            }
            catch (Exception ex)
            {
                _loggerManager.Error($"Error {serviceName} - ", ex);
                return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ProcessingError).ToString(), ResponseMessage = $"Processing Error - {ex.Message}", Caller = serviceName };
            }
        }
    }
}
