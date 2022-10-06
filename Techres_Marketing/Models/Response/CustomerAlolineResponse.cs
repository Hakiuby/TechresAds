using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Response
{
    public class CustomerAlolineResponse : BaseResponse
    {
        [JsonProperty("data")]
        public CustomerAloLine Data { get; set;  }

    }
    public class CustomerAloLine
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set;  }
        [JsonProperty("phone")]
        public string Phone { get; set;  }
        [JsonProperty("avatar")] 
        public string Avatar { get; set;  }
        [JsonProperty("birthday")]    
        public DateTime Birthday { get; set;  }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("address_full_text")]
        public string AddressFullText { get; set; }
    }
}
