using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techres_Marketing.Helper;
using Techres_Marketing.Interfaces;
using Techres_Marketing.Models.Request;
using Techres_Marketing.Models.Response;

namespace Techres_Marketing.Service
{
    class CustomerClient : BaseClient
    {
       public CustomerClient(ICacheService cache, IDeserializer deserializer, IErrorLogger errorLogger) 
            : base(cache, deserializer, errorLogger) { }

         
        public CustomerAlolineResponse  FindCustomerAloline(CustomerAloLineWrapper wrapper)
        {
            RestRequest request = new RestRequest(LinkCallApi.API_CUSTOMER_SEARCH_BY_PHONE, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var js = JsonConvert.SerializeObject(wrapper);
            WriteLog.logs(js);
            request.AddJsonBody(js);
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.ORDER, request);
            return Get<CustomerAlolineResponse>(request, callApiWrapper);
        }
    }
}
