using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Response
{
    public class CategoryAlbum: BaseResponse
    {
        [JsonProperty("data")]
        public CategoryAlbumData Data { get; set; }
        
    }
    public class CategoryAlbumData
    {
        [JsonProperty("total_record")]
        public long TotalRecord { get; set; }
        [JsonProperty("list")]
        public List<CategoryAlbumList> List { get; set; }
    }
    public class CategoryAlbumList
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("folder_name")]
        public string FolderName { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("is_share")]
        public long IsShare { get; set; }
    }
}
