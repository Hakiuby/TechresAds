using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Timers;

using Techres_Marketing.Helper;
using Techres_Marketing.Interfaces;
using Techres_Marketing.Models.Response;
using Techres_Marketing.Service;
using Techres_Marketing.Views.Dialogs;
using Techres_Marketing.Views;
using Techres_Marketing.Helper.Enum;

namespace Techres_Marketing.ViewModel
{
    public class AdsCustomerViewModel : BaseViewModel, ICacheService, IDeserializer, IErrorLogger
    {
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        public ICommand PreViewCommand { get; set; }
        public ICommand ShowAdsCommand { get; set; }
        public ICommand MuteCommand { get; set; }
        public ICommand UnMuteCommand { get; set; }
        private Visibility _PresentationVisibility { get; set; }
        public Visibility PresentationVisibility { get => _PresentationVisibility; set { _PresentationVisibility = value; OnPropertyChanged("PresentationVisibility"); } }
        private Visibility _PausePresentationVisibility { get; set; }
        public Visibility PausePresentationVisibility { get => _PausePresentationVisibility; set { _PausePresentationVisibility = value; OnPropertyChanged("PausePresentationVisibility"); } }
        private Visibility _PreViewEnabled { get; set; }
        public Visibility PreViewEnabled { get => _PreViewEnabled; set { _PreViewEnabled = value; OnPropertyChanged("PreViewEnabled"); } }
        private Visibility _PlayButtonVisibility { get; set; }
        public Visibility PlayButtonVisibility { get => _PlayButtonVisibility; set { _PlayButtonVisibility = value; OnPropertyChanged("PlayButtonVisibility"); } }
        private Visibility _PauseButtonVisibility { get; set; }
        public Visibility PauseButtonVisibility { get => _PauseButtonVisibility; set { _PauseButtonVisibility = value; OnPropertyChanged("PauseButtonVisibility"); } }
        private Visibility _MuteVisibility { get; set; }
        public Visibility MuteVisibility { get => _MuteVisibility; set { _MuteVisibility = value; OnPropertyChanged("MuteVisibility"); } }
        private Visibility _UnMuteVisibility { get; set; }
        public Visibility UnMuteVisibility { get => _UnMuteVisibility; set { _UnMuteVisibility = value; OnPropertyChanged("UnMuteVisibility"); } }
        private ObservableCollection<MediaData> _ListVideos { get; set; }
        public ObservableCollection<MediaData> ListVideos { get => _ListVideos; set { _ListVideos = value; OnPropertyChanged("ListVideos"); } }
        //private List<MediaData> Datas;
        //  private int index = 0;
        private MediaData currentMedia;
        //private int VideoCount = 0;
        private bool IsMute = true;
        //private MediaElement _VideoControl;
        private bool IsPlayContactAds;
        private void GetListVideoAds()
        {
            if (ListVideos == null)
            {
                ListVideos = new ObservableCollection<MediaData>();
            }
            else
            {
                ListVideos.Clear();
            }
            // danh sach video dang co
            foreach (MediaData media in Constants.MediaDataList)
            {
                ListVideos.Add(media);

            }
            if (ListVideos != null && ListVideos.Count > 0)
            {
                currentMedia = GetMediaFristRun();
                if (currentMedia == null)
                {
                    MessageNotificationWindow message = new MessageNotificationWindow();
                    message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                    message.ShowDialog();
                }
            }
        }
        private void DeleteVideoAds()
        {
            string[] filePaths = Directory.GetFiles(Constants.FILE_PATH, "*.mp4");
            List<string> MediaDelete = new List<string>();
            MediaDelete = filePaths.ToList();
            foreach (MediaData media in Constants.MediaDataList)
            {
                foreach (string mp4 in filePaths)
                {
                    if (media.MediaUrlLocal == mp4)
                    {
                        Console.WriteLine(mp4);
                        //filePaths.a
                        MediaDelete.Remove(mp4);
                    }
                }
            }
            foreach (string del in MediaDelete)
            {
                File.Delete(del);
            }
        }
        public MediaData GetMediaFristRun()
        {
            return ListVideos.Where(x => CheckVideoIsAllowPlay(x)).FirstOrDefault();
        }
        private bool CheckVideoIsAllowPlay(MediaData media)
        {

            if (media != null && media.IsRunning == 1)
            {
                bool checkTime = false;
                DateTime fromDate = DateTime.Today.AddHours(media.FromHour);
                DateTime toDate = DateTime.Today.AddHours(media.ToHour);
                DateTime currentDate = DateTime.Now;
                if (media.FromHour >= media.ToHour)
                {
                    toDate = DateTime.Today.AddDays(1).AddHours(media.ToHour);
                    //currentDate = currentDate.AddDays(1);
                }
                if (fromDate <= currentDate && currentDate <= toDate)
                {
                    checkTime = true;
                }
                if (media.IsRunning == Constants.MediaAdsCheckRunning && checkTime)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        private void PlayVideoAds(MediaData media)
        {
            if (ListVideos.Count == 0)
            {
                MessageNotificationWindow message = new MessageNotificationWindow();
                message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                message.ShowDialog();
            }
            else
            {
                //Debug.WriteLine(index);
                if (CheckVideoIsAllowPlay(media))
                {
                    MainSecondViewModel.ShowAds(new Uri(media.MediaUrlLocal, UriKind.Relative), IsMute);
                }
                else
                {
                    int index = ListVideos.IndexOf(media);
                    Debug.WriteLine(index);
                    if (index >= ListVideos.Where(x => CheckVideoIsAllowPlay(x)).Count() - 1)
                    {
                        currentMedia = GetMediaFristRun();
                        if (currentMedia == null)
                        {
                            MessageNotificationWindow message = new MessageNotificationWindow();
                            message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                            message.ShowDialog();
                        }
                    }
                    else
                    {
                        index++;
                        currentMedia = ListVideos[index];
                    }
                    PlayVideoAds(currentMedia);
                }
            }
        }
        private void MediaEnded(object sender, EventArgs e)
        {
            if (currentMedia != null)
            {
                if (currentMedia.Id != 0 && currentMedia.IsRunning == 1)
                {
                    UpdateDataAdsAfterPlay(currentMedia);
                    Debug.WriteLine(currentMedia.Id);
                }
                IsPlayContactAds = !IsPlayContactAds;
                if (!IsPlayContactAds)
                {
                    string file = System.Windows.Forms.Application.StartupPath + string.Format("{0}.mp4", @"\contactads");
                    MainSecondViewModel.ShowAds(new Uri(file, UriKind.Relative), IsMute);
                    Debug.WriteLine(file);


                }
                else
                {

                    int index = ListVideos.IndexOf(currentMedia);
                    if (index >= ListVideos.Where(x => CheckVideoIsAllowPlay(x)).Count() - 1)
                    {
                        currentMedia = GetMediaFristRun();
                        if (currentMedia == null)
                        {
                            MessageNotificationWindow message = new MessageNotificationWindow();
                            message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                            message.ShowDialog();
                        }
                    }
                    else
                    {
                        index++;
                        currentMedia = ListVideos[index];
                    }
                    PlayVideoAds(currentMedia);
                }
            }
            else
            {
                if (MainSecondViewModel._VideoControl != null)
                {
                    MainSecondViewModel._VideoControl.Stop();
                }
                MessageNotificationWindow message = new MessageNotificationWindow();
                message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                message.ShowDialog();
            }

        }
        private async void UpdateDataAdsAfterPlay(MediaData media)
        {

            MediaClient client = new MediaClient(this, this, this);
            if (IsPlayContactAds)
            {
                Media mediaResponse = await Task.Run(() => client.UpdateDataAfterPlay(media.Id));
                if (mediaResponse != null && mediaResponse.Status == (int)HttpStatusCode.OK)
                {
                    if (mediaResponse.Data.IsRunning == 0)
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            int index = ListVideos.IndexOf(media);
                            ListVideos.RemoveAt(index);
                            ListVideos.Insert(index, mediaResponse.Data);
                        });
                    }
                }
                else
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        int index = ListVideos.IndexOf(media);
                        ListVideos.RemoveAt(index);
                        ListVideos.Insert(index, mediaResponse.Data);
                    });
                }
            }

        }
        public AdsCustomerViewModel()
        {
            GetListVideoAds();
            DeleteVideoAds();
            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, p =>
            {
                if (MainSecondViewModel.MainSecondEnum != MainSecondEnum.ADS)
                {
                    PresentationVisibility = Visibility.Visible;
                    PausePresentationVisibility = Visibility.Collapsed;
                    MuteVisibility = Visibility.Collapsed;
                    UnMuteVisibility = Visibility.Visible;
                }
            });
            PreViewCommand = new RelayCommand<UserControl>((p) => { return true; }, p =>
            {
                if (ListVideos.Count == 0)  
                {
                    MessageNotificationWindow message = new MessageNotificationWindow();
                    message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                    message.ShowDialog();
                }
                else
                {
                    CustomerAdsWindow customerAds = new CustomerAdsWindow();
                    customerAds.mePlayer.Source = new Uri(currentMedia.MediaUrlLocal, UriKind.Relative);
                    customerAds.mePlayer.IsMuted = true;
                    customerAds.mePlayer.Play();
                    customerAds.ShowDialog();
                }
            });
            ShowAdsCommand = new RelayCommand<UserControl>((p) => { return true; }, p =>
            {
                if (ListVideos.Count == 0)
                {
                    MessageNotificationWindow message = new MessageNotificationWindow();
                    message.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo";
                    message.ShowDialog();
                }
                else
                {
                    if (CheckVideoIsAllowPlay(currentMedia))
                    {
                        PresentationVisibility = Visibility.Collapsed;
                        PausePresentationVisibility = Visibility.Visible;
                        MainSecondViewModel.ShowAds(new Uri(currentMedia.MediaUrlLocal, UriKind.Absolute), IsMute);
                        if (MainSecondViewModel._VideoControl != null)
                        {
                            MainSecondViewModel._VideoControl.MediaEnded += MediaEnded;
                        }
                        else
                        {
                            MessageNotificationWindow message = new MessageNotificationWindow();
                            message.ContentNotification.Text = "Vui lòng kết nối màn hình led để chạy quảng cáo";
                            message.ShowDialog();
                        }

                    }
                    else
                    {
                        MessageNotificationWindow message = new MessageNotificationWindow();
                        message.ContentNotification.Text = "Chưa được phép chạy quảng cáo";
                        message.ShowDialog();
                    }
                }
            });
            PauseCommand = new RelayCommand<UserControl>((p) => { return true; }, p =>
            {
                if (MainSecondViewModel._VideoControl != null)
                {
                    PresentationVisibility = Visibility.Visible;
                    PausePresentationVisibility = Visibility.Collapsed;
                    MainSecondViewModel._VideoControl.Pause();
                }
            });
            MuteCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                MuteVisibility = Visibility.Collapsed;
                UnMuteVisibility = Visibility.Visible;
                IsMute = true;
                MainSecondViewModel.MuteAds(IsMute);
            });
            UnMuteCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                MuteVisibility = Visibility.Visible;
                UnMuteVisibility = Visibility.Collapsed;
                IsMute = false;
                MainSecondViewModel.MuteAds(IsMute);
            });
        }
        #region Interface 
        public void LogError(Exception ex, string infoMessage)
        {
            throw new NotImplementedException();
        }
        public T Deserialize<T>(IRestResponse response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                if (jsonResponse.status == 200)
                {
                    T check = jsonResponse.ToObject<T>();
                    if (check != null)
                    {
                        return check;
                    }
                }
                else
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        //MessageNotificationWindow window = new MessageNotificationWindow();
                        //window.ContentNotification.Text = jsonResponse.message;
                        //window.ShowDialog();
                    });
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    //MessageNotificationWindow window = new MessageNotificationWindow();
                    //window.ContentNotification.Text = MessageValue.FORBIDDEN;
                    //window.ShowDialog();
                });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    //MessageNotificationWindow window = new MessageNotificationWindow();
                    //window.ContentNotification.Text = MessageValue.INTERNAL_SERVER_ERROR;
                    //window.ShowDialog();
                });
            }
            else
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    //MessageNotificationWindow window = new MessageNotificationWindow();
                    //window.ContentNotification.Text = response.ErrorMessage;
                    //window.ShowDialog();
                });
            }
            return default;
        }
        public T Get<T>(string cacheKey) where T : class
        {
            throw new NotImplementedException();
        }
        public void Set(string cacheKey, object item, int minutes)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
