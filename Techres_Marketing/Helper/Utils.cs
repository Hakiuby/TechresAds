using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Helper
{
    internal struct Utils
    {
        public static string convertFormListString(List<string> tmp)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string t in tmp) // Loop through all strings
            {
                builder.Append(t).Append(","); // Append string to StringBuilder
            }
            return builder.ToString().TrimEnd(',');
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static object GetCacheValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }
        public static bool AddCacheValue(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }
        public static void SetCacheValue(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(key, value, absExpiration);
        }

        public static void DeleteCacheValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }
        public static DateTime GetStringFormatDateTime(string dateInString)
        {
            //DateTime tempDate;

            if (!string.IsNullOrEmpty(dateInString))
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                return DateTime.ParseExact(dateInString, "dd/MM/yyyy HH:mm", culture);
            }
            else
            {
                return DateTime.Now;
            }
        }
        //k.khánh
        public static string HandleCharFistOfString(string str)
        {
            string res = "";
            string[] tu = str.Split(' ');

            for(int i = 0; i < tu.Length; i++)
            {
                res += tu[i].Substring(0, 1);
            }

            char[] arr = res.ToCharArray();
            Array.Reverse(arr);
            string end = new string(arr);

            string result = string.Concat(res.Substring(0, 1), end.Substring(0, 1));
            return result;
        }
        public static int GetOnlyDate(DateTime dateTime)
        {
            //DateTime tempDate;
            string dateInString = dateTime.ToString();
            IFormatProvider culture = new CultureInfo("en-US", true);
            if (!string.IsNullOrEmpty(dateInString))
            {
                return int.Parse(DateTime.ParseExact(dateInString, "dd", culture).ToString());
            }
            else
            {
                return int.Parse(DateTime.ParseExact(DateTime.Now.ToString(), "dd", culture).ToString());
            }
        }
        public static string AsJsonList<T>(List<T> tt)
        {
            if (tt != null)
            {
                return JsonConvert.SerializeObject(tt);
            }
            else
            {
                return string.Empty;
            }
        }
        public static List<T> AsObjectList<T>(string tt)
        {
            if (string.IsNullOrEmpty(tt))
            {
                return new List<T>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<T>>(tt);
            }

        }
        public static T AsObject<T>(string t)
        {
            return JsonConvert.DeserializeObject<T>(t);

        }
        public static long GetOnlyHour(DateTime date)
        {
            if (date == null)
            {
                date = new DateTime();
                return int.Parse(date.ToString("HH", CultureInfo.InvariantCulture));
            }
            else
            {
                return int.Parse(date.ToString("HH", CultureInfo.InvariantCulture));

            }
        }
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private class WebClient : System.Net.WebClient
        {
            public int Timeout { get; set; }

            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest lWebRequest = base.GetWebRequest(uri);
                lWebRequest.Timeout = Timeout;
                ((HttpWebRequest)lWebRequest).ReadWriteTimeout = Timeout;
                return lWebRequest;
            }
        }
        public static bool CheckInternet()
        {
            try
            {
                using (var lWebClient = new WebClient())
                {
                    lWebClient.Timeout = 10 * 1000;
                    using (var r = lWebClient.OpenRead("https://www.google.com.vn"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
