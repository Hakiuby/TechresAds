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
    public class ImageShareAlolineClient : BaseClient 
    {
        public ImageShareAlolineClient(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
       : base(cache, serializer, errorLogger) { }

        public CategoryAlbum GetCategoryAlbum(long limit, long page, long userId)
        {
            RestRequest request = new RestRequest(LinkCallApi.API_GET_CATEGORY_ALBUM, Method.GET);
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("page", page.ToString());
            request.AddQueryParameter("user_id", userId.ToString());
            request.AddHeader("Content-Type", "application/json");
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.UPLOAD, request);
            return Get<CategoryAlbum>(request, callApiWrapper); 
        }

        public AlbumCustomer GetAlbumCustomer(long categoryId)
        {
            string url = LinkCallApi.API_GET_ALBUM_CUSTOMER;
            url = string.Format(LinkCallApi.API_GET_ALBUM_CUSTOMER, categoryId); 
            RestRequest request = new RestRequest(url,Method.GET);
            request.AddHeader("Content-Type", "application/json");
            CallApiWrapper callApiWrapper = new CallApiWrapper((long)ProjectIdEnum.UPLOAD, request);
            //callApiWrapper.RequestUrl = LinkCallApi.API_GET_LIST_MEDIA_URI;
            return Get<AlbumCustomer>(request, callApiWrapper);
        }
    }
}
