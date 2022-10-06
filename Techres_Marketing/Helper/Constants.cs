using System;
using System.Collections.Generic;
using Techres_Marketing.Models.Response;

namespace Techres_Marketing.Helper
{
    public static class Constants
    {
        // PATH DOWNLOAD 
        public static string FILE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Favorites); // ADS Customer 

        public static string SERVER_DOMAIN = "https://api.order.techres.vn";
        public static string ADVERT_DOMAIN = "https://api.order.techres.vn";
        public static string ADS_DOMAIN = "https://api.order.techres.vn";

        #region Live 
        public static string SERVER_OAUTH_DOMAIN = "https://api.gateway.techres.vn/api/queues";
        public static string SERVER_REALTIME = "http://realtime.techres.vn:1483";
        public static long IS_MODE_SERVER = 1;
        #endregion

        #region  Beta 
        //public static string SERVER_REALTIME = "http://beta.api.realtime.techres.vn:1483";
        //public static long IS_MODE_SERVER = 0;
        //public static string SERVER_OAUTH_DOMAIN = "http://172.16.2.243:8092/api/queues";
        #endregion

        #region Key Cache 

        public static readonly string CURRENT_USER = "CURRENT_USER";
        public static readonly string CURRENT_USER_CHART = "CURRENT_USER_CHART";
        public static readonly string CURRENT_SETTING = "CURRENT_SETTING";

        #endregion

        public static string KEY_CALL_API = "api/large";
        public static string SERVER_OFFLINE_DOMAIN = "https://api.upload.techres.vn";

        // ads 
        public static List<MediaData> MediaDataList = new List<MediaData>();
        public static int MediaAdsCheckRunning = 1;
    }
}
