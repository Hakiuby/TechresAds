using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Techres_Marketing.Helper;
using Techres_Marketing.Interfaces;
using Techres_Marketing.Models.Request;
using Techres_Marketing.Models.Response;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System.Diagnostics;

namespace Techres_Marketing.Service
{
    public class SettingClient: BaseClient
    {
        public SettingClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger) { }
        public SettingResponse GetSetting(long branchId)
        {
            RestRequest request = new RestRequest(LinkCallApi.API_SETTING, Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddQueryParameter("branch_id", branchId.ToString());
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.OAUTH, request);
            Debug.WriteLine(request);
            return Get<SettingResponse>(request, callApiWrapper);

        }
    }
}
