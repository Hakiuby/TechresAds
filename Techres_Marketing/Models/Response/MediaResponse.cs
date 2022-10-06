using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Techres_Marketing.Helper;

namespace Techres_Marketing.Models.Response
{
    public class MediaResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<MediaData> Data { get; set; }
    }
    public class Media : BaseResponse
    {
        [JsonProperty("data")]
        public MediaData Data { get; set; }
    }

    public partial class MediaData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        [JsonProperty("from_hour")]
        public long FromHour { get; set; }

        [JsonProperty("to_hour")]
        public long ToHour { get; set; }
        [JsonProperty("is_running")]
        public long IsRunning { get; set; }
        [JsonIgnore]
        public string MediaUrlLocal { get; set; }
        public string TimeVideo
        {
            get
            {
                string t;
                if (FromHour == 0 && ToHour == 0)
                {
                    t = "Luôn chạy";
                }
                else
                {
                    t = String.Format("{0} đến {1}", FromHour.ToString(), ToHour == 0 ? ToHour + 24 : ToHour);
                }
                return t;
            }
            set
            {
                TimeVideo = value;
            }
        }
        public BitmapImage IsRunningString
        {
            get
            {
                if (IsRunning == 1)
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/Resources/Images/ic-running.png"));
                }
                else
                {
                    return new BitmapImage(new Uri(@"pack://application:,,,/Resources/Images/ic-stop.png"));
                }

            }
            set
            {
                IsRunningString = value;
            }
        }
        public string MediaUrlString
        {
            get
            {
                return string.Concat(Constants.ADS_DOMAIN, this.MediaUrl);
            }
            set
            {
                MediaUrlString = value;
            }
        }
    }
}
