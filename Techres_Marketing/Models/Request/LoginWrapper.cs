using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techres_Marketing.Helper;

namespace Techres_Marketing.Models.Request
{
    public class LoginWrapper
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public LoginWrapper(string username, string password)
        {
            this.Username = username;
            this.Password = Utils.Base64Encode(password);

        }
    }
}
