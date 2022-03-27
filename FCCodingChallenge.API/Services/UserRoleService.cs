using FCCodingChallenge.API.Repository;

namespace FCCodingChallenge.API.Services
{
    public class UserRoleService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(ILoggerManager loggerManager, IUserRoleRepository userRoleRepository)
        {
            _loggerManager = loggerManager;
            _userRoleRepository = userRoleRepository;
        }


    }
}
