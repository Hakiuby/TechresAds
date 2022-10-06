using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using FFmpeg.AutoGen;
using Unosquare.FFME;
using System.Diagnostics;
using Techres_Marketing.Views;
using Techres_Marketing.Views.Dialogs;
using Techres_Marketing.Helper;
using Techres_Marketing.Views.UserControls;

namespace Techres_Marketing.ViewModel
{
    public class MainViewModels: BaseViewModel
    {
        // Command 
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AdsCustomerCommand {get; set; }
        public ICommand AdsRestaurantCommand { get; set; }
        public ICommand BirthdayCommand { get; set; }
        public ICommand ImageShareAloLineCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        // Brush 
        private Brush _AdsRestaurantBackground;
        public Brush AdsRestaurantBackground { get => _AdsRestaurantBackground; set { _AdsRestaurantBackground = value; OnPropertyChanged("AdsRestaurantBackground"); } }
        private Brush _WebBackground;
        public Brush WebBackground { get => _WebBackground; set { _WebBackground = value; OnPropertyChanged("WebBackground"); } }

        private Brush _HomeBackground;
        public Brush HomeBackground { get => _HomeBackground; set { _HomeBackground = value; OnPropertyChanged("HomeBackground"); } }
        private Brush _BirthDayBackground;
        public Brush BirthDayBackground { get => _BirthDayBackground; set { _BirthDayBackground = value; OnPropertyChanged("BirthDayBackground"); } }
        private string _VersionTitle;
        public string VersionTitle { get => _VersionTitle; set { _VersionTitle = value; OnPropertyChanged("VersionTitle"); } }
        private Brush _ForegroundSelected;
        public Brush ForegroundSelected { get => _ForegroundSelected;set { _ForegroundSelected = value; OnPropertyChanged("ForegroundSelected");}}

        public string _CharFirstOfName;
        public string CharFirstOfName { get => _CharFirstOfName; set { _CharFirstOfName = value; OnPropertyChanged("CharFirstOfName"); } }
        public string _FullName;
        public string FullName { get => _FullName; set { _FullName = value; OnPropertyChanged("FullName"); } }
        private static ContentControl _MainContentControl;
        //private HomeUserControl customerAdsUC;
        //private BirthDayUserControl birthDayUC;
        //private RestaurantAdsUserControl RestaurantAdsUC;
        public MainViewModels()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => 
            {
                HandleTryCheckSysDSCData();
                VersionTitle = string.Format("Phiên bản {0}", Properties.Settings.Default.VERSION);
                HomeBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0080FF"));
                BirthDayBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA233"));
                AdsRestaurantBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA233"));
                WebBackground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA233"));

                Library.FFmpegDirectory = System.Windows.Forms.Application.StartupPath + @"\FFMPEG" + (Environment.Is64BitProcess ? @"\X64" : @"\X86");
                Library.FFmpegLoadModeFlags = FFmpegLoadMode.FullFeatures;
                Library.EnableWpfMultiThreadedVideo = !Debugger.IsAttached;

                _MainContentControl = p.FindName("ContentCt") as ContentControl;
                AdsCustomerUC adsCustomer = new AdsCustomerUC();
                _MainContentControl.Content = adsCustomer;


                FullName = Properties.Settings.Default.NameMind;
                CharFirstOfName = Utils.HandleCharFistOfString(Properties.Settings.Default.NameMind);
            });
            AdsCustomerCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
                _MainContentControl = p.FindName("ContentCt") as ContentControl;
                AdsCustomerUC adsCustomer = new AdsCustomerUC();
                _MainContentControl.Content = adsCustomer;
            });
            
            AdsRestaurantCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) => {
                _MainContentControl = p.FindName("ContentCt") as ContentControl;
                AdsRestaurantUC adsRestaurant = new AdsRestaurantUC();
                _MainContentControl.Content = adsRestaurant; 
            });
            BirthdayCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) => {
                _MainContentControl = p.FindName("ContentCt") as ContentControl;
                BirthdayUC birthdayUC = new BirthdayUC();
                _MainContentControl.Content = birthdayUC; 
                
            });
            ImageShareAloLineCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) => {
                _MainContentControl = p.FindName("ContentCt") as ContentControl; 
                ImageShareAloLineWindow imageShareAloLine = new ImageShareAloLineWindow();
                _MainContentControl.Content = imageShareAloLine; 

            }); 
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                ConfirmExitWindow notification = new ConfirmExitWindow();
                string contentConfirm = MessageValue.MESSAGE_CONTENT_LOGOUT;
                string Title = MessageValue.MESSAGE_TITILE_LOGOUT;
                string YesContent = MessageValue.MESSAGE_FROM_CONFIRM;
                string NoContent = MessageValue.MESSAGE_NO_CONTENT;
                notification.DataContext = new ConfirmViewModel(contentConfirm, Title, NoContent, YesContent);
                notification.ShowDialog();
                var confirm = notification.DataContext as ConfirmViewModel; 
                if (confirm.isConfirm)
                {
                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Equals(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)) process.Kill();
                    }
                    System.Windows.Application.Current.Shutdown();
                }
                
            }); 
        }
        // Func Help 
        private static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (MainSecondViewModel._VideoControl != null && MainSecondViewModel._VideoControl.Source != null)
            {
                var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
                if (secondaryScreen != null)
                {
                    //MainSecondViewModel.PlayAds();
                    MainSecondViewModel.ReShowSecondWindow();
                }
                else
                {
                    MainSecondViewModel.PauseAds();
                }
            }
        }
        public static void SystemEvents_DisplaySettingsChanging(object sender, EventArgs e)
        {
            if (MainSecondViewModel._VideoControl != null && MainSecondViewModel._VideoControl.Source != null)
            {
                var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
                if (secondaryScreen != null)
                {
                    MainSecondViewModel.ReShowSecondWindow();
                }
            }
        }
        public void HandleTryCheckSysDSCData()
        {
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanging += SystemEvents_DisplaySettingsChanging;
            //Control.LostStylusCaptureEvent += SystemEvents_DisplayLocationChanging;
        }
    }
}
