using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Techres_Marketing.Models.Item
{
    public class BirthDayItem
    {
        public BitmapImage UriMedia { get; set; }
        public BirthDayItem(string filename)
        {
            this.UriMedia = new BitmapImage(new Uri(filename, UriKind.RelativeOrAbsolute));
        }
    }
}
