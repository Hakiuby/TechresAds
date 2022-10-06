using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Techres_Marketing.Helper;
using Techres_Marketing.Interfaces;
using Techres_Marketing.Loading;
using Techres_Marketing.Models.Item;
using Techres_Marketing.Models.Response;
using Techres_Marketing.Service;
using Techres_Marketing.Views;

namespace Techres_Marketing.ViewModel
{
    public class LoadingDownloadingHomeAdsViewModel: BaseViewModel, ICacheService, IDeserializer, IErrorLogger
    {
        public ICommand LoadedWindowCommand { get; set; }
        private string _NumerDownloaded { get; set; }
        public string NumerDownloaded { get => _NumerDownloaded; set { _NumerDownloaded = value; OnPropertyChanged("NumerDownloaded"); } }
        private string _PercentDownloadRealtime { get; set; }
        public string PercentDownloadRealtime { get => _PercentDownloadRealtime; set { _PercentDownloadRealtime = value; OnPropertyChanged("PercentDownloadRealtime"); } }
        private double _PercentDownloadRealtimeProgressBar { get; set; }
        public double PercentDownloadRealtimeProgressBar { get => _PercentDownloadRealtimeProgressBar; set { _PercentDownloadRealtimeProgressBar = value; OnPropertyChanged("PercentDownloadRealtimeProgressBar"); } }

        private User currentUser;

        private int countVideo = 0;

        public bool IsSussces = false;
        private List<MediaData> Datas;
        private Window Window;

        private void CheckListVideo()
        {
            if (Datas == null)
            {
                Datas = new List<MediaData>();
            }
            else
            {
                Datas.Clear();
            }
            foreach (MediaData media in Constants.MediaDataList)
            {
                string m = media.MediaUrl.Substring(media.MediaUrl.LastIndexOf("/") + 1);
                string[] name = m.Split('.');

                media.MediaUrlLocal = string.Format(Constants.FILE_PATH + @"\{0}_{1}.mp4", name[0].Replace("-", ""), media.Id);
                if (!File.Exists(media.MediaUrlLocal))
                {
                    Datas.Add(media);
                }
                else
                {
                    if (media.IsRunning == 0)
                    {
                        File.Delete(media.MediaUrlLocal);
                        Constants.MediaDataList.Remove(media);
                    }
                }
            }
        }

        private void GetData()
        {
            currentUser = (User)Utils.GetCacheValue(Constants.CURRENT_USER);
            MediaClient client = new MediaClient(this, this, this);
            MediaResponse mediaResponse = client.GetMediaUri(currentUser.BranchId);
            if (mediaResponse != null && mediaResponse.Status == (int)HttpStatusCode.OK && mediaResponse.Data.Count > 0)
            {
                //SetupData(mediaResponse.Data);
                //IsSussces = true;
                if (Constants.MediaDataList == null)
                {
                    Constants.MediaDataList = new List<MediaData>();
                }
                else
                {
                    Constants.MediaDataList.Clear();
                }
                Constants.MediaDataList = mediaResponse.Data;
            }
            else
            {
                App.Current.Dispatcher.Invoke((Action)async delegate
                {
                    NotificationWindow noti = new NotificationWindow();
                    noti.ContentNotification.Text = "Chưa đăng kí dữ liệu quảng cáo!";
                    noti.ShowDialog();
                });
            }
        }
        private void LoadingProgressBar(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            PercentDownloadRealtime = string.Format("{0} %", Math.Round(percentage));
            PercentDownloadRealtimeProgressBar = percentage;
            NumerDownloaded = string.Format("{1}/{0}", Datas.Count, countVideo);
        }
        public void SaveVideo(MediaData media)
        {
            try
            {
                string m = media.MediaUrl.Substring(media.MediaUrl.LastIndexOf("/") + 1);
                string[] name = m.Split('.');

                media.MediaUrlLocal = string.Format(Constants.FILE_PATH + @"\{0}_{1}.mp4", name[0].Replace("-", ""), media.Id);

                Uri uri = new Uri(string.Format("{1}{0}", media.MediaUrl, Constants.ADS_DOMAIN));
                WebClient client = new WebClient();
                //string path = string.Format(Constants.FILE_PATH + @"\{0}_{1}.mp4", media.Name, media.Id);
                string path = string.Format(Constants.FILE_PATH + @"\{0}_{1}.mp4", name[0].Replace("-", ""), media.Id);
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(LoadingProgressBar);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
                client.DownloadFileAsync(uri, path);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
        public LoadingDownloadingHomeAdsViewModel()
        {
            GetData();
            CheckListVideo();
            if (Datas.Count == 0)
            {
                IsSussces = true;
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.DataContext = new MainViewModels();
                //mainWindow.Show();
            }
            else
            {
                SaveVideo(Datas[countVideo]);
            }
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, p =>
            {
                if (p != null)
                {
                    Window = p;
                }
            });
        }
        public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            countVideo++;
            if (countVideo < Datas.Count)
            {
                NumerDownloaded = string.Format("{1}/{0}", Datas.Count, countVideo);
                SaveVideo(Datas[countVideo]);
            }
            if (countVideo >= Datas.Count)
            {
                Window.Close();
                IsSussces = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new MainViewModels();
                mainWindow.Show();
            }
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
