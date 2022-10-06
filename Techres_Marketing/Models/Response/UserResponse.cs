using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techres_Marketing.Models.Item;

namespace Techres_Marketing.Models.Response
{
    public class UserResponse:BaseResponse
    {
        [JsonProperty("data")]
        public User Data { get; set; }
    }
}
