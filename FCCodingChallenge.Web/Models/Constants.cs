using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FCCodingChallenge.Web.Models
{
    public class Constants
    {
        public static string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        public static string GetUserByEmail = ConfigurationManager.AppSettings["GetUserByEmail"];
        public static string GetUserByPhone = ConfigurationManager.AppSettings["GetUserByPhone"];
        public static string CreateUser = ConfigurationManager.AppSettings["CreateUser"];
        public static string DeleteUser = ConfigurationManager.AppSettings["DeleteUser"];
        public static string UpdateUser = ConfigurationManager.AppSettings["UpdateUser"];
    }
}