using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Request
{
    public class CustomerAloLineWrapper
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
        public CustomerAloLineWrapper(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }
    }
}
