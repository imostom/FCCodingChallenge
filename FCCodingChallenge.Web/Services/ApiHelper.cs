using FCCodingChallenge.Web.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FCCodingChallenge.Web.Services
{
    public class ApiHelper
    {
        static HttpClient client;

        public static string GetAsync(string param, string paramType)
        {
            string response = null;
            var endpoint = (paramType == "Email") ? Constants.GetUserByEmail.Replace("{email}", param) : Constants.GetUserByPhone.Replace("{phone}", param);
            
            var url = Constants.BaseUrl + endpoint;
            var client = new RestClient();
            var request = new RestRequest(url);
            var result = client.GetAsync(request).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(result.Content))
                    return result.Content;
            }
            else
                return response;

            return null;
        }

        public static async Task<object> PostAsync(UserVM userVM)
        {
            object response = null;
            var endpoint = Constants.CreateUser;
            var url = Constants.BaseUrl + endpoint;
            var client = new RestClient();
            var request = new RestRequest(url, Method.Post).AddJsonBody(userVM);
            var result = client.PostAsync(request).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(result.Content))
                    return response = JsonConvert.DeserializeObject<GenericResponse<UserVM>>(result.Content);
            }
            else
                return response;

            return null;
        }

        public static async Task<T> GetAsync<T>(string url, string param)
        {
            var json = string.Empty;
            client = new HttpClient();

            try
            {
                url = Constants.BaseUrl + url;
                url = url.Replace("{email}", param).Replace("{phone}", param);
                json = await client.GetStringAsync(url);

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to get information from server {ex}");
                throw ex;
            }
        }

        //public static async Task<T> PostAsync<T>(string url, object body)
        //{
        //    client = new HttpClient();

        //    try
        //    {
        //        StringContent httpContent = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

        //        url = Constants.BaseUrl + url;
        //        var result  = await client.PostAsync(url, httpContent);

        //        return JsonConvert.DeserializeObject<T>(result.Content.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        //Debug.WriteLine($"Unable to get information from server {ex}");
        //        throw ex;
        //    }
        //}

        public static async Task<T> UpdateAsync<T>(string url, object body)
        {
            client = new HttpClient();

            try
            {
                StringContent httpContent = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

                var result = await client.PutAsync(url, httpContent);

                return JsonConvert.DeserializeObject<T>(result.Content.ToString());
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to get information from server {ex}");
                throw ex;
            }
        }

        public static async Task<T> DeleteAsync<T>(string url)
        {
            client = new HttpClient();

            try
            {
                var response = await client.DeleteAsync(url);

                return JsonConvert.DeserializeObject<T>(response.Content.ToString());
            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to get information from server {ex}");
                throw ex;
            }
        }
    }
}