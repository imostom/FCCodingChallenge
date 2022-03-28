using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCCodingChallenge.Web.Models
{
    public class GenericResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
        [JsonIgnore]
        public string Caller { get; set; }
    }
}