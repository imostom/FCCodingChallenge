using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Enum;
using FCCodingChallenge.API.Repository;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IRoleRepository _roleRepository;

        public RoleService(ILoggerManager loggerManager, IRoleRepository roleRepository) 
        {
            _loggerManager = loggerManager;
            _roleRepository = roleRepository;
        }


        public async Task<GenericResponse<object>> GetRoles()
        {
            string serviceName = "GetRoles";
            try
            {
                var roles = await _roleRepository.GetRoles();
                if (roles is null)
                    return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.NotFound).ToString(), ResponseMessage = $"No Role Found", Caller = serviceName };


                return new GenericResponse<object> { IsSuccessful = true, ResponseCode = ((int)ResponseCode.Successful).ToString(), ResponseMessage = $"Success", Caller = serviceName, Data = roles };
            }
            catch (Exception ex)
            {
                _loggerManager.Error($"Error {serviceName} - ", ex);
                return new GenericResponse<object> { IsSuccessful = false, ResponseCode = ((int)ResponseCode.ProcessingError).ToString(), ResponseMessage = $"Processing Error - {ex.Message}", Caller = serviceName };
            }

        }
    }
}
