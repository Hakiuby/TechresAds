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
    public class UserNodeClient: BaseClient
    {
        public UserNodeClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
     : base(cache, serializer, errorLogger) { }
        public ConfigNodeResponse GetConfig()
        {
            RestRequest request = new RestRequest(LinkCallApi.API_NODE_CONFIG, Method.GET);
            request.AddQueryParameter("secret_key", "cHJvamVjdC51c2VyLmtleSZhYmMkXiYl");
            request.AddHeader("Content-Type", "application/json");
            CallApiWrapper wrapper = new CallApiWrapper((long)ProjectIdEnum.OAUTH_NODE, request);
            return Get<ConfigNodeResponse>(request, wrapper);
        }
        public UserNodeResponse LoginSystemNode(UserResponse user, string password, string ApiKey)
        {
            RestRequest request = new RestRequest(LinkCallApi.API_NODE_LOGIN, Method.POST);
            request.AddHeader("Content-Type", "application/json");
            LoginNodeWrapper wrapper = new LoginNodeWrapper(user, password);
            var js = JsonConvert.SerializeObject(wrapper);
            WriteLog.logs(js);
            request.AddJsonBody(js);
            CallApiWrapper call = new CallApiWrapper((long)ProjectIdEnum.OAUTH_NODE, request);

            return Get<UserNodeResponse>(request, ApiKey, call);
        }
    }
}
