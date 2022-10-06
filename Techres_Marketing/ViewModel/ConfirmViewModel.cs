using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Techres_Marketing.Helper;
using Techres_Marketing.Interfaces;
using Techres_Marketing.Views.Dialogs;

namespace Techres_Marketing.ViewModel
{
    public class ConfirmViewModel : BaseViewModel, ICacheService, IDeserializer, IErrorLogger
    {
        public ICommand CloseCommand { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand YesCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public string _ContentConfirm;
        public string ContentConfirm
        {
            get
            {
                return _ContentConfirm;
            }
            set
            {
                _ContentConfirm = value;
                OnPropertyChanged("ContentConfirm");
            }
        }

        public string _TitleContent;
        public string TitleContent
        {
            get
            {
                return _TitleContent;
            }
            set
            {
                _TitleContent = value;
                OnPropertyChanged("TitleContent");
            }
        }

        public string _NoContent;
        public string NoContent
        {
            get
            {
                return _NoContent;
            }
            set
            {
                _NoContent = value;
                OnPropertyChanged("NoContent");
            }
        }

        public string _YesContent;
        public string YesContent
        {
            get
            {
                return _YesContent;
            }
            set
            {
                _YesContent = value;
                OnPropertyChanged("YesContent");
            }
        }
        public bool isConfirm;
        public bool isNoConfirm;
        public bool isStock;
        public ConfirmViewModel(string contentConfirm = "", string title = "", string noContent = "", string yesContent = "")
        {
            ContentConfirm = contentConfirm;
            TitleContent = title;
            NoContent = noContent;
            YesContent = yesContent;
            YesCommand = new RelayCommand<ConfirmExitWindow>((t) => { return true; }, t =>
            {
                isConfirm = true;
                t.Close();
            });
            NoCommand = new RelayCommand<ConfirmExitWindow>((t) => { return true; }, t =>
            {
                isConfirm = false;
                isStock = true;
                t.Close();
            });
            CloseCommand = new RelayCommand<ConfirmExitWindow>((t) => { return true; }, t =>
            {
                isConfirm = false;
                isNoConfirm = true;
                t.Close();
            });
            NewCommand = new RelayCommand<ConfirmExitWindow>((t) => { return true; }, t => {
                isConfirm = true;

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
                        //NotificationWindow window = new NotificationWindow();
                        //window.ContentNotification.Text = jsonResponse.message;
                        //window.ShowDialog();
                    });
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    //NotificationWindow window = new NotificationWindow();
                    //window.ContentNotification.Text = MessageValue.FORBIDDEN;
                    //window.ShowDialog();
                });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    //NotificationWindow window = new NotificationWindow();
                    //window.ContentNotification.Text = MessageValue.INTERNAL_SERVER_ERROR;
                    //window.ShowDialog();
                });

            }
            else
            {
                Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    //NotificationWindow window = new NotificationWindow();
                    //window.ContentNotification.Text = response.ErrorMessage;
                    //window.ShowDialog();
                });
            }
            return default(T);
        }
        public void Set(string cacheKey, object item, int minutes)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string cacheKey) where T : class
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
