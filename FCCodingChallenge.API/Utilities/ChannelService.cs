using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Enum;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Utilities
{
    public class ChannelService
    {
        
        public static bool AuthorizeChannel(string appKey)
        {
            bool resp = false;
            string serviceName = "AuthorizeChannel";

            if (appKey != "11c7479f-3d38-4ec8-9d58-2b7f22624f1b")
                return false;

            return resp = true;
        }
    }
}
