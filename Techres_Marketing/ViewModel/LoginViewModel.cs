using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using Techres_Marketing.Helper;
using Techres_Marketing.Interfaces;
using Techres_Marketing.Loading;
using Techres_Marketing.Models.Response;
using Techres_Marketing.Service;
using Techres_Marketing.Views;
using Techres_Marketing.Views.UserControls;

namespace Techres_Marketing.ViewModel
{
    public class LoginViewModel : BaseViewModel, ICacheService, IDeserializer, IErrorLogger
    {
        private readonly double MAX_EXPIRE_CACHE = 1;
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand LoadWindow { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }

        public string _VersionTitle { get; set; }
        public string VersionTitle { get => _VersionTitle; set { _VersionTitle = value; OnPropertyChanged("VersionTitle"); } }

        public string _UserName { get; set; }
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged("UserName"); } }
        public string _Password { get; set; }
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged("Password"); } }
        public string _RestaurantName { get; set; }
        public string RestaurantName { get => _RestaurantName; set { _RestaurantName = value; OnPropertyChanged("RestaurantName"); } }

        private int _caseSensitive;
        public int CaseSensitive
        {
            get { return _caseSensitive; }
            set
            {
                _caseSensitive = value;
                OnPropertyChanged("CaseSensitive");
            }
        }
        private static ContentControl _MainContentControl;
        public LoginViewModel()
        {
            try
            {
                VersionTitle = string.Format("Phiên bản {0}", Properties.Settings.Default.VERSION);
                LoadWindow = new RelayCommand<LoginWindow>(p => { return true; }, p =>
                {
                    CheckRememberUser(p);
                });
                LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                    Login(p); 
                });
                CloseCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
                {
                    foreach (Process Proc in Process.GetProcesses())
                        if (Proc.ProcessName.Equals(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)) Proc.Kill();
                    System.Windows.Application.Current.Shutdown();
                });
                MinimizeWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) => { p.WindowState = WindowState.Minimized; });
                PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
                {
                    _Password = p.Password;
                });
            }
            catch (Exception expr_105)
            {
                Debug.WriteLine(expr_105.Message);
            }
        }
        public void CheckRememberUser(LoginWindow p)
        {
            string mind = Properties.Settings.Default.Mind;
            string UserNameSetting = Properties.Settings.Default.UserNameMind;
            string PasswordSetting = Properties.Settings.Default.PasswordMind;
            string restaurantName = Properties.Settings.Default.RestaurantName;
            VersionTitle = string.Format("Phiên bản {0}", Properties.Settings.Default.VERSION);
            if (!string.IsNullOrEmpty(mind) && !string.IsNullOrEmpty(restaurantName) && !string.IsNullOrEmpty(UserNameSetting) && !string.IsNullOrEmpty(PasswordSetting))
            {
                RestaurantName = restaurantName;
                int mindbl = int.Parse(mind);
                if (mindbl == 1)
                {
                    UserName = UserNameSetting;
                    Password = PasswordSetting;
                    p.txtPassword.Password = Password;
                    CaseSensitive = 1;
                }
                else
                {
                    UserName = String.Empty;
                    p.txtPassword.Password = String.Empty;
                    CaseSensitive = 0;
                }
            }
        }
        public async void Login(Window p)
        {
            if (p == null) return;
            else if (string.IsNullOrEmpty(RestaurantName))
            {
                NotificationWindow window = new NotificationWindow();
                window.ContentNotification.Text = MessageValue.MESSAGE_RESTAURANT_NAME_NOT;
                window.ShowDialog();
            }
            else if(string.IsNullOrEmpty(UserName))
            {
                NotificationWindow window = new NotificationWindow();
                window.ContentNotification.Text = MessageValue.MESSAGE_USERNAME_NOT;
                window.ShowDialog();
            }
            else if (string.IsNullOrEmpty(Password))
            {
                NotificationWindow window = new NotificationWindow();
                window.ContentNotification.Text = MessageValue.MESSAGE_PASSWORD_NOT;
                window.ShowDialog();
            }
            else if(RestaurantName.Length < 3 || RestaurantName.Length > 30)
            {
                NotificationWindow window = new NotificationWindow();
                window.ContentNotification.Text = MessageValue.MESSAGE_ERROR_RESTAURANT_NAME;
                window.ShowDialog();
            }
            else if(Password.Length < 4 || Password.Length > 50)
            {
                NotificationWindow window = new NotificationWindow();
                window.ContentNotification.Text = MessageValue.MESSAGE_ERROR_PASSWORD;
                window.ShowDialog();
            }
            else if(UserName.Length < 3 || UserName.Length > 30)
            {
                NotificationWindow window = new NotificationWindow();
                window.ContentNotification.Text = MessageValue.MESSAGE_ERROR_USERNAME;
                window.ShowDialog();
            }
            else
            {
                if (Utils.CheckInternet())
                {
                    UserClient userClient = new UserClient(this, this, this);
                    ConfigResponse configResponse = userClient.GetConfig(RestaurantName);
                    if (configResponse != null && configResponse.Status == (int)HttpStatusCode.OK)
                    {
                        UserResponse current_user = userClient.LoginSystem(UserName, Password, configResponse.Data.ApiKey);
                        Constants.ADS_DOMAIN = configResponse.Data.AdsDomain;
                        Constants.SERVER_DOMAIN = configResponse.Data.ApiDomain;
                        Constants.ADVERT_DOMAIN = configResponse.Data.ApiDomain + "/api";
                        if (current_user != null && current_user.Status == (int)HttpStatusCode.OK && current_user.Data != null)
                        {
                            Utils.AddCacheValue(Constants.CURRENT_USER, current_user.Data, DateTimeOffset.Now.AddDays(MAX_EXPIRE_CACHE));
                            current_user.Data.NodeAccessToken = GetNodeAccessToken(current_user, Password);
                            Utils.AddCacheValue(Constants.CURRENT_USER, current_user.Data, DateTimeOffset.Now.AddDays(MAX_EXPIRE_CACHE));
                            LoadingWaitDownloadAsyn loadingWait = new LoadingWaitDownloadAsyn();
                            loadingWait.DataContext = new LoadingDownloadingHomeAdsViewModel();
                            p.Hide();
                            loadingWait.Show();
                            var loading = loadingWait.DataContext as LoadingDownloadingHomeAdsViewModel;
                            if (loading.IsSussces)
                            {
                                loadingWait.Hide();
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.DataContext = await Task.Run(() => new MainViewModels());
                                mainWindow.Show();
                            }
                            if (CaseSensitive == 1)
                            {
                                Properties.Settings.Default.Mind = CaseSensitive.ToString();
                                Properties.Settings.Default.UserNameMind = UserName;
                                Properties.Settings.Default.PasswordMind = Password;
                                Properties.Settings.Default.RestaurantName = RestaurantName;
                                Properties.Settings.Default.NameMind = current_user.Data.Name;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.Mind = CaseSensitive.ToString();
                                Properties.Settings.Default.UserNameMind = "";
                                Properties.Settings.Default.PasswordMind = "";
                                Properties.Settings.Default.RestaurantName = "";
                                Properties.Settings.Default.NameMind = "";
                                Properties.Settings.Default.Save();
                            }
                            SettingClient settingClient = new SettingClient(this, this, this);
                            SettingResponse settingResponse = settingClient.GetSetting(current_user.Data.BranchId);
                            if (settingResponse != null && settingResponse.Status == (int)HttpStatusCode.OK)
                            {
                                Constants.SERVER_DOMAIN = Constants.SERVER_DOMAIN + settingResponse.Data.ApiPrefixPathForBranchType;
                                Utils.AddCacheValue(Constants.CURRENT_SETTING, settingResponse, DateTimeOffset.Now.AddDays(MAX_EXPIRE_CACHE));
                            }
                            BranchClient branchClient = new BranchClient(this, this, this);
                            BranchesResponse branch = branchClient.GetAllBranchesResponse();

                            List<string> validextentions = new List<string> { "png", "jpg", "gif" };
                            DirectoryInfo d = new DirectoryInfo(Constants.FILE_PATH);

                            List<FileInfo> myFiles = (from file in d.GetFiles("*.*", SearchOption.TopDirectoryOnly)
                                                      where validextentions.Contains(file.Extension.Replace(".", "").ToLower())
                                                      select new FileInfo(file.FullName)).ToList();
                            if (myFiles.Count == 0)
                            {
                                WebClient webClient = new WebClient();
                                string banner = "";
                                string link = "";
                                foreach (Branches branches in branch.Data)
                                {
                                    banner = Constants.FILE_PATH + string.Format("{0}{1}", @"\", branches.Banner.Substring(branches.Banner.LastIndexOf("/") + 1));
                                    link = string.Format("{0}{1}", Constants.ADS_DOMAIN, branches.Banner);
                                }
                                webClient.DownloadFileAsync(new Uri(link), banner);
                                webClient.DownloadFileCompleted += (s, e) =>
                                {
                                    MainSecondViewModel.BannerPath = banner;
                                    MainSecondViewModel.ShowMainAdsWindow();
                                };
                                webClient.DownloadFileCompleted += (s, e) =>
                                {
                                    MainSecondViewModel.BannerPath = banner;
                                    MainSecondViewModel.ShowMainAdsWindow();
                                };
                            }
                            else
                            {
                                foreach (FileInfo file in myFiles)
                                {
                                    string title = "";
                                    foreach (Branches tmp in branch.Data)
                                    {
                                        title = tmp.Banner.Substring(tmp.Banner.LastIndexOf("/") + 1);
                                    }

                                    Debug.WriteLine(title);
                                    Debug.WriteLine(Path.GetFileName(file.FullName));
                                    if (String.Compare(title, file.Name, true) != 0)
                                    {
                                        File.Delete(file.FullName);
                                        WebClient webclient = new WebClient();
                                        string banner = "";
                                        string link = "";
                                        foreach (Branches tmp in branch.Data)
                                        {
                                            banner = Constants.FILE_PATH + string.Format("{0}{1}", @"\", tmp.Banner.Substring(tmp.Banner.LastIndexOf("/") + 1));
                                            link = string.Format("{0}{1}", Constants.ADS_DOMAIN, tmp.Banner);
                                        }
                                        try
                                        {
                                            webclient.DownloadFile(new Uri(link), banner);
                                            webclient.DownloadFileCompleted += (s, e) =>
                                            {
                                                MainSecondViewModel.BannerPath = banner;
                                                MainSecondViewModel.ShowMainAdsWindow();
                                            };
                                            break;
                                        }
                                        catch
                                        {
                                            MainSecondViewModel.ShowMainAdsBannerWindow();
                                        }
                                    }
                                    else
                                    {
                                        MainSecondViewModel.BannerPath = file.FullName;
                                        MainSecondViewModel.ShowMainAdsWindow();
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            NotificationWindow window = new NotificationWindow();
                            window.ContentNotification.Text = MessageValue.MESSAGE_LOGIN_FAIL;
                            window.ShowDialog();
                        }
                    }
                }
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    //MainWindowDemo mainWindow = new MainWindowDemo();
                    mainWindow.DataContext = await Task.Run(() => new MainViewModels());
                    mainWindow.Show();
                }
            }
        }
        private string GetNodeAccessToken(UserResponse user, string password)
        {
            UserNodeClient userClient = new UserNodeClient(this, this, this);
            ConfigNodeResponse configResponse = userClient.GetConfig();
            if (configResponse != null && configResponse.Status == (int)HttpStatusCode.OK)
            {
                UserNodeResponse userNodeResponse = userClient.LoginSystemNode(user, password, configResponse.Data.ApiKey);
                if (userNodeResponse != null && userNodeResponse.Status == (int)HttpStatusCode.OK)
                {
                    return userNodeResponse.Data.NodeAccessToken;
                    //  Utils.Utils.AddCacheValue(Constants.CURRENT_USER_CHART, userNodeResponse.Data, DateTimeOffset.Now.AddDays(MAX_EXPIRE_CACHE));
                }
            }
            return string.Empty;
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
