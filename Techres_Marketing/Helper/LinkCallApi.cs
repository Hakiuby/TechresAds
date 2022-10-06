using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Helper
{
    public static class LinkCallApi
    {
        // user
        public static readonly string API_LOGIN = "/api/employees/login";

        public static readonly string API_LOGIN_CHART = "/api/login";

        public static readonly string API_CONFIG = "api/configs";

        public static readonly string CURRENT_USER = "CURRENT_USER";

        public static readonly string API_RESTAURANT_INFO = "/application/restaurants/{0}";

        public static readonly string API_BRANCH_INFO = "/application/branches/{0}";

        public static readonly string API_ALL_BRANCHES = "/application/branches";

        public static readonly string API_SETTING = "/api/employees/settings";

        public static readonly string API_GET_LIST_MEDIA_URI = "api/adverts";

        public static readonly string API_UPDATE_DATA_AFTER_PLAY = "/adverts/{0}/update-data-after-play";

        public static readonly string API_UPDATE_VERSION = "/api/check-version?os_name=windows_ads";

        public static readonly string API_LOGIN_CHAT = "/api/oauth-login-nodejs/login";

        // Node log 
        public static readonly string API_CREATE_ALBUM = "/api-upload/create-album";
        public static readonly string API_UPLOAD_ALBUM = "/api-upload/upload-file";
        public static readonly string API_GET_ALBUM = "/api-upload/get-album";
        public static readonly string API_GET_LIST_RESTAUREANT_PRIVAE_ADVERTS = "api/large/application/restaurant-private-adverts";
        public static readonly string API_NODE_CONFIG = "/api/oauth-configs-nodejs/get-configs";
        public static readonly string API_NODE_LOGIN = "/api/oauth-login-nodejs/login";

        // Aloline 
        public static readonly string API_GET_ALBUM_CUSTOMER = "/api-upload/get-category-album/{0}";
        public static readonly string API_GET_CATEGORY_ALBUM = "/api-upload/get-album";

        // Customer 
        public static readonly string API_CUSTOMER_SEARCH_BY_PHONE = "/application/customers/search"; 
    }
}
