using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techres_Marketing.Models.Item
{
    public class CustomerBirthDay
    {
        public string TitleBirthDay { get; set; }
        public string FontTitle { get; set; }
        public int FontSizeTitle { get; set; }
        public string CustomerName { get; set; }
        public string FontCustomer { get; set; }
        public int FontSizeCustomer { get; set; }
        public int Number { get; set; }
        public int Time { get; set; }
        public string MediaContent { get; set; }
        public bool IsShowName { get; set; }
        public bool IsChooseVideo { get; set; }
        public string MediaUri { get; set; }
        public List<string> ListPictures { get; set; }
        public string CustomerNameString
        {
            get
            {
                return String.Format("Tên KH : {0}", CustomerName);
            }
        }
        public string TimeString
        {
            get
            {
                return String.Format("Thời gian : {0}(phút)", Time);
            }
        }
    }
}
