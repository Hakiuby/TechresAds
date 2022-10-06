using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media; 
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Techres_Marketing.Helper.Enum;
using Techres_Marketing.Models.Item;
using Techres_Marketing.Views.SecondScreen;
using Techres_Marketing.Views.UserControls;
using Unosquare.FFME.Common;
using Techres_Marketing.Views;

namespace Techres_Marketing.ViewModel
{
    public static class MainSecondViewModel
    {
        public static MainAdsWindow mainAdsWindow = new MainAdsWindow();
        private static ContentControl _MainContentControl;
        private static ShowAdsUserControl ShowAdsUserControl;
        //public static MediaElement _VideoControl;
        public static Unosquare.FFME.MediaElement _VideoControl;
        //public static MediaPlayer mediaPlayer;
        //public static List<string> ListPictures;
        private static ShowBirthDayUserControl showBirthDayUserControl;
        //private static ShowWebUserControl ShowWebUserControl;
        private static ShowRestaurantAdsUserControl ShowRestaurantAdsUserControl;
        public static MainSecondEnum MainSecondEnum = MainSecondEnum.HOME;
        public static bool IsMuteBirthDay;
        public static bool IsMuteRestaurant;
        public static bool IsMuteAdsMain;
        public static DispatcherTimer BirthDay;
        public static DispatcherTimer Restaurant;
        public static string BannerPath;
        public static void ShowWebAdsWindow(UserControl p)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                _MainContentControl.Content = p;
                mainAdsWindow.Show();
            }
        }
        public static void ShowMainAdsBannerWindow()
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                MainAdsUserControl tmp = new MainAdsUserControl();

                //if (mediaPlayer != null)
                //{
                //    mediaPlayer.Stop();
                //}                
                _MainContentControl.Content = tmp;
                mainAdsWindow.Show();
            }
        }
        public static void ShowMainAdsWindow()
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                MainAdsUserControl tmp = new MainAdsUserControl();

                //if (mediaPlayer != null)
                //{
                //    mediaPlayer.Stop();
                //}
                if (!string.IsNullOrEmpty(BannerPath) && File.Exists(BannerPath))
                {
                    tmp.Image.Source = new BitmapImage(new Uri(BannerPath));
                }
                _MainContentControl.Content = tmp;
                mainAdsWindow.Show();
            }
        }
        public static void ReShowSecondWindow()
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                if (ShowAdsUserControl == null)
                {
                    ShowAdsUserControl = new ShowAdsUserControl();
                }
                _MainContentControl.Content = ShowAdsUserControl;
            }
        }
        public static async void ShowAds(Uri src, bool IsMute)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                MainSecondEnum = MainSecondEnum.ADS;

                Debug.WriteLine(src.OriginalString); // C: \Users\HA\Favorites\1644308850699858_1.mp4

                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                if (ShowAdsUserControl == null)
                {
                    ShowAdsUserControl = new ShowAdsUserControl();
                }


                _VideoControl = ShowAdsUserControl.FindName("mePlayer") as Unosquare.FFME.MediaElement;

                //await _VideoControl.Close();
                //await _VideoControl.ChangeMedia();
                //_VideoControl = ShowAdsUserControl.mePlayer;
                _VideoControl.IsMuted = IsMute;

                await _VideoControl.Open(new Uri(Uri.UnescapeDataString(src.OriginalString)));

                await _VideoControl.Play();

                _MainContentControl.Content = ShowAdsUserControl;
            }
        }
        public static void MuteAds(bool IsMute)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                MainSecondEnum = MainSecondEnum.ADS;

                if (_VideoControl != null)
                {
                    _VideoControl.IsMuted = IsMute;
                }
            }
        }
        public static void ShowListPicture(CustomerBirthDay customer, bool IsShowName)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                MainSecondEnum = MainSecondEnum.BIRTHDAY;

                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                //mainSecondWindow.DataContext = new MainSecondViewModel();
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;

                if (showBirthDayUserControl == null)
                {
                    showBirthDayUserControl = new ShowBirthDayUserControl();
                }
                //showBirthDayUserControl.pageTransitionControl.Visibility = Visibility.Visible;
                //MainSecondViewModel.ListPictures = ListPictures;
                showBirthDayUserControl.Images = customer.ListPictures.ToList();
                showBirthDayUserControl.ImgCurrent.Source = new BitmapImage(new Uri(customer.ListPictures[0]));
                showBirthDayUserControl.PlayPictures();
                showBirthDayUserControl.Video.Visibility = Visibility.Collapsed;
                //if(mediaPlayer == null)
                //{
                //    mediaPlayer = new MediaPlayer();
                //}
                //if (!IsRepeat)
                //{
                //    mediaPlayer.Open(new Uri(Uri.UnescapeDataString(MediaUri), UriKind.Relative));
                //}               
                //showBirthDayUserControl.PlayImages(IsPresentation);                    
                if (showBirthDayUserControl.Video != null)
                {
                    showBirthDayUserControl.Video.Stop();
                }
                if (IsShowName)
                {
                    showBirthDayUserControl.ShowName = true;
                    showBirthDayUserControl.TitleBirthDay.Text = customer.TitleBirthDay;
                    showBirthDayUserControl.TitleBirthDay.FontFamily = new FontFamily(customer.FontTitle);
                    showBirthDayUserControl.TitleBirthDay.FontSize = customer.FontSizeTitle;
                    showBirthDayUserControl.CustomerName.Text = customer.CustomerName;
                    showBirthDayUserControl.CustomerName.FontFamily = new FontFamily(customer.FontCustomer);
                    showBirthDayUserControl.CustomerName.FontSize = customer.FontSizeCustomer;

                }
                else
                {
                    showBirthDayUserControl.ShowName = false;
                }
                _MainContentControl.Content = showBirthDayUserControl;
            }
        }
        
        public static void ShowVideo(CustomerBirthDay CurrentCustomer, bool IsPlay, bool IsRepeat, bool IsMute)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                MainSecondEnum = MainSecondEnum.BIRTHDAY;

                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                //mainSecondWindow.DataContext = new MainSecondViewModel();
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                if (showBirthDayUserControl == null)
                {
                    showBirthDayUserControl = new ShowBirthDayUserControl();
                }
                //if (mediaPlayer != null)
                //{
                //    mediaPlayer.Stop();
                //}
                if (showBirthDayUserControl.timerImageChange != null)
                {
                    showBirthDayUserControl.timerImageChange.Stop();
                }
                showBirthDayUserControl.Video.Visibility = Visibility.Visible;
                if (!IsRepeat)
                {
                    showBirthDayUserControl.Video.Source = new Uri(Uri.UnescapeDataString(CurrentCustomer.MediaUri));
                }
                if (IsPlay)
                {
                    showBirthDayUserControl.Video.Play();
                }
                else
                {
                    showBirthDayUserControl.Video.Pause();
                }
                showBirthDayUserControl.Video.IsMuted = IsMute;
                showBirthDayUserControl.Video.MediaEnded += new RoutedEventHandler(m_MediaEnded);
                void m_MediaEnded(object sender, RoutedEventArgs e)
                {
                    showBirthDayUserControl.Video.Position = TimeSpan.FromSeconds(0);
                    showBirthDayUserControl.Video.Play();
                }
                if (CurrentCustomer.IsShowName)
                {
                    showBirthDayUserControl.ShowName = true;
                    showBirthDayUserControl.TitleBirthDay.Text = CurrentCustomer.TitleBirthDay;
                    showBirthDayUserControl.TitleBirthDay.FontFamily = new FontFamily(CurrentCustomer.FontTitle);
                    showBirthDayUserControl.CustomerName.Text = CurrentCustomer.CustomerName;
                    showBirthDayUserControl.CustomerName.FontFamily = new FontFamily(CurrentCustomer.FontCustomer);
                }
                else
                {
                    showBirthDayUserControl.ShowName = false;
                    //howBirthDayUserControl.frontItem.Visibility = Visibility.Collapsed;
                }
                _MainContentControl.Content = showBirthDayUserControl;
            }
        }
        public static void ShowNameBirthDay(string TitleBirthDay, string FontTitle, string CustomerName, string FontCustomer, bool IsShowName)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                //mainSecondWindow.DataContext = new MainSecondViewModel();
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                if (showBirthDayUserControl != null)
                {
                    if (IsShowName)
                    {
                        showBirthDayUserControl.ShowName = true;
                        showBirthDayUserControl.TitleBirthDay.Text = TitleBirthDay;
                        showBirthDayUserControl.TitleBirthDay.FontFamily = new FontFamily(FontTitle);
                        showBirthDayUserControl.CustomerName.Text = CustomerName;
                        showBirthDayUserControl.CustomerName.FontFamily = new FontFamily(FontCustomer);
                    }
                    else
                    {
                        showBirthDayUserControl.ShowName = false;
                        //showBirthDayUserControl.frontItem.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
        public static void MuteVideoBirthDay(bool IsMute)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                //mainSecondWindow.DataContext = new MainSecondViewModel();
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                if (showBirthDayUserControl != null)
                {
                    showBirthDayUserControl.Video.IsMuted = IsMute;
                    //if (mediaPlayer != null)
                    //{
                    //    mediaPlayer.IsMuted = IsMute;
                    //}
                    IsMuteBirthDay = IsMute;
                }
            }
        }

        public static void ShowWebBrowser(string Link)
        {
            //var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            //if (secondaryScreen != null)
            //{
            //    var workingArea = secondaryScreen.Bounds;
            //    mainAdsWindow.Left = workingArea.Left;
            //    mainAdsWindow.Top = workingArea.Top;
            //    mainAdsWindow.Width = workingArea.Width;
            //    mainAdsWindow.Height = workingArea.Height;
            //    //mainSecondWindow.DataContext = new MainSecondViewModel();
            //    _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
            //    if (ShowWebUserControl == null)
            //    {
            //        ShowWebUserControl = new ShowWebUserControl();
            //    }
            //    ShowWebUserControl.ShowBrowser.Address = Link;
            //    _MainContentControl.Content = ShowWebUserControl;
            //}
        }
        public static void ShowVideoRestaurant(string Link, bool IsMute)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                MainSecondEnum = MainSecondEnum.VIDEO_RESTAURANT;

                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                //mainSecondWindow.DataContext = new MainSecondViewModel();
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                if (ShowRestaurantAdsUserControl == null)
                {
                    ShowRestaurantAdsUserControl = new ShowRestaurantAdsUserControl();
                }
                if (showBirthDayUserControl != null)
                {
                    showBirthDayUserControl.Video.Stop();
                }
                //if (mediaPlayer != null)
                //{
                //    mediaPlayer.Stop();
                //}               
                ShowRestaurantAdsUserControl.video.Source = new Uri(Link);
                ShowRestaurantAdsUserControl.video.IsMuted = IsMute;
                ShowRestaurantAdsUserControl.video.Play();

                _MainContentControl.Content = ShowRestaurantAdsUserControl;
            }
        }
        public static void MuteVideoRestaurant(bool IsMute)
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();
            if (secondaryScreen != null)
            {
                MainSecondEnum = MainSecondEnum.VIDEO_RESTAURANT;
                var workingArea = secondaryScreen.Bounds;
                mainAdsWindow.Left = workingArea.Left;
                mainAdsWindow.Top = workingArea.Top;
                mainAdsWindow.Width = workingArea.Width;
                mainAdsWindow.Height = workingArea.Height;
                //mainSecondWindow.DataContext = new MainSecondViewModel();
                _MainContentControl = mainAdsWindow.FindName("ContentMain") as ContentControl;
                if (ShowRestaurantAdsUserControl != null)
                {
                    ShowRestaurantAdsUserControl.video.IsMuted = IsMute;
                    IsMuteRestaurant = IsMute;
                }
            }
        }
        public static void DeletedWindow()
        {
            mainAdsWindow.Close();
        }
        public static void PlayAds()
        {
            _VideoControl.Play();
        }
        public static void PauseAds()
        {
            _VideoControl.Pause();
        }

    }

}
