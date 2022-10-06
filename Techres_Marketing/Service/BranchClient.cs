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
    public class BranchClient : BaseClient
    {
        public BranchClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
         : base(cache, serializer, errorLogger) { }

        public BranchesResponse GetAllBranchesResponse(int isEnableMemberShipCard = -1, int restaurantBrandId = -1)
        {
            RestRequest request = new RestRequest(LinkCallApi.API_ALL_BRANCHES, Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddQueryParameter("is_enable_membership_card", isEnableMemberShipCard.ToString());
            request.AddQueryParameter("restaurant_brand_id", restaurantBrandId.ToString());
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.ORDER, request);
            return Get<BranchesResponse>(request, callApiWrapper);
        }
    }
}
