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
using Techres_Marketing.Interfaces;
using Techres_Marketing.Models.Request;
using Techres_Marketing.Models.Response;
using Techres_Marketing.Service;

namespace Techres_Marketing.ViewModel
{
    public class AdsAloLineViewModel : BaseViewModel , ICacheService, IDeserializer, IErrorLogger
    {
        private string _CustomerName; 
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged("CustomerName");  } }
        private string _CustomerPhone; 
        public string CustomerPhone { get => _CustomerPhone; set { _CustomerPhone = value; OnPropertyChanged("CustomerPhone");  } }

        // ICommand 

        public ICommand SearchCustomerCommnad { get; set;  }
        public ICommand ChooseFolderCommand { get; set;  }

        // Func Help 
        public void FindCusByPhone()
        {
            CustomerClient client = new CustomerClient(this, this, this);
            CustomerAloLineWrapper wrapper = new CustomerAloLineWrapper(string.IsNullOrEmpty(CustomerName) ? "" : CustomerName, string.IsNullOrEmpty(CustomerPhone) ? "" : CustomerPhone);
            CustomerAlolineResponse respons = client.FindCustomerAloline(wrapper); 
        }
        public AdsAloLineViewModel()
        {

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
