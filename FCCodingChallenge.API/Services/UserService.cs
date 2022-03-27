using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Enum;
using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using FCCodingChallenge.API.Repository;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Services
{
    public class UserService : IUserService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IUserRepository _userRepository;

        public UserService(ILoggerManager loggerManager, IUserRepository userRepository) 
        {
            _loggerManager = loggerManager;
            _userRepository = userRepository;
        }


        public async Task<GenericResponse<object>> GetUser(string email)
        {
            string serviceName = "GetUser";
            try
            {
                if (string.IsNullOrEmpty(email))
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ValidationError).ToString(), ResponseMessage = $"Empty Parameter Not Allowed", Caller = serviceName };

                var user = await _userRepository.GetUser(email);
                if (user is null)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"No User Found", Caller = serviceName };


                return new GenericResponse<object> { IsSuccessful = true, ResponseCode = ((int)ResponseCode.Successful).ToString(), ResponseMessage = $"Success", Caller = serviceName, Data = user };
            }
            catch (Exception ex)
            {
                _loggerManager.Error($"Error {serviceName} - ", ex);
                return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ProcessingError).ToString(), ResponseMessage = $"Processing Error - {ex.Message}", Caller = serviceName };
            }

        }

        public async Task<GenericResponse<object>> AddUser(RemoteDetails remoteDetails, UserVM userVM)
        {
            string serviceName = "AddUser";
            try
            {
                _loggerManager.Information($"Request from :{JsonConvert.SerializeObject(remoteDetails)} Body:{JsonConvert.SerializeObject(userVM)}");

                if (string.IsNullOrEmpty(userVM.Firstname) || string.IsNullOrEmpty(userVM.Lastname) || string.IsNullOrEmpty(userVM.Email))
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ValidationError).ToString(), ResponseMessage = $"Empty Parameters Not Allowed", Caller = serviceName };

                var userId = await _userRepository.AddUser(userVM);
                if (userId <= 0)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"User Creation Failed", Caller = serviceName };


                return new GenericResponse<object> { IsSuccessful = true, ResponseCode = ((int)ResponseCode.Successful).ToString(), ResponseMessage = $"Success", Caller = serviceName, Data = null };
            }
            catch (Exception ex)
            {
                _loggerManager.Error($"Error {serviceName} - ", ex);
                return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ProcessingError).ToString(), ResponseMessage = $"Processing Error - {ex.Message}", Caller = serviceName };
            }
        }

        public async Task<GenericResponse<object>> DeleteUser(string email)
        {
            string serviceName = "DeleteUser";
            try
            {
                if (string.IsNullOrEmpty(email))
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ValidationError).ToString(), ResponseMessage = $"Empty Parameter Not Allowed", Caller = serviceName };

                var user = await GetUser(email);
                if (user.Data is null)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"No User Found", Caller = serviceName };

                var response = await _userRepository.DeleteUser(email);
                if (response <= 0)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"No User Found", Caller = serviceName };


                return new GenericResponse<object> { IsSuccessful = true, ResponseCode = ((int)ResponseCode.Successful).ToString(), ResponseMessage = $"Success", Caller = serviceName, Data = user };
            }
            catch (Exception ex)
            {
                _loggerManager.Error($"Error {serviceName} - ", ex);
                return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ProcessingError).ToString(), ResponseMessage = $"Processing Error - {ex.Message}", Caller = serviceName };
            }

        }
    }
}
