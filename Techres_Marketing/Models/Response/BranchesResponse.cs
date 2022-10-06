using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Response
{
    public class BranchesResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<Branches> Data { get; set; }
    }
    public class Branches
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("is_use_fingerprint")]
        public long IsUseFingerprint { get; set; }

        [JsonProperty("enable_checkin")]
        public long EnableCheckin { get; set; }

        [JsonProperty("qr_code_checkin")]
        public string QrCodeCheckin { get; set; }
        [JsonProperty("image_logo")]
        public string ImageLogo { get; set; }
        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonIgnore]
        public bool IsCheck { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
