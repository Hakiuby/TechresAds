using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Response
{
    public class AlbumCustomer : BaseResponse
    {
        [JsonProperty("data")]
        public List<AlbumCustomerData> Data { get; set; }
    }
    public class AlbumCustomerData
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
