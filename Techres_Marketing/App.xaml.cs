using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Techres_Marketing.ViewModel;
using Application = System.Windows.Application;

namespace Techres_Marketing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            
            var secondaryScreen = Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                //showMainSecondDefault();
                MainSecondViewModel.ShowMainAdsBannerWindow();
            }
        }
    }
}
