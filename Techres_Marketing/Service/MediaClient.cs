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
    public class MediaClient: BaseClient
    {
        public MediaClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
        : base(cache, serializer, errorLogger) { }
        public MediaResponse GetMediaUri(long branchId)
        {
            RestRequest request = new RestRequest(LinkCallApi.API_GET_LIST_MEDIA_URI, Method.GET);
            request.AddQueryParameter("branch_id", branchId.ToString());
            request.AddHeader("Content-Type", "application/json");
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.ORDER, request);
            callApiWrapper.RequestUrl = LinkCallApi.API_GET_LIST_MEDIA_URI;
            return Get<MediaResponse>(request, callApiWrapper);
        }
        public Media UpdateDataAfterPlay(long id)
        {
            Console.WriteLine("Cap nhat ID Ads : " + id);
            RestRequest request = new RestRequest(string.Format(LinkCallApi.API_UPDATE_DATA_AFTER_PLAY, id), Method.POST);
            request.AddHeader("Content-Type", "application/json");
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.UPLOAD, request);
            return Get<Media>(request, callApiWrapper);
        }
    }
}
