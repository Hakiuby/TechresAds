using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Response
{
    public class UserNodeResponse : BaseResponse
    {
        [JsonProperty("data")]
        public UserNode Data { get; set; }
    }
    public class UserNode
    {
        [JsonProperty("node_access_token")]
        public string NodeAccessToken { get; set; }
    }
}
