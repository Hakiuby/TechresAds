using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Techres_Marketing.Helper;
using Techres_Marketing.Helper.Enum;
using Techres_Marketing.Models.Item;
using Techres_Marketing.Models.Response;
using Techres_Marketing.Views;
using Techres_Marketing.Views.Dialogs;
using Techres_Marketing.Views.SecondScreen;

namespace Techres_Marketing.ViewModel
{
    public class BirthdayCustomerViewModel : BaseViewModel
    {
       
        MediaElement _VideoControl;
        private ObservableCollection<CustomerBirthDay> _ListCustomers;
        public ObservableCollection<CustomerBirthDay> ListCustomers
        { get { return _ListCustomers; } set { _ListCustomers = value; OnPropertyChanged("ListCustomers"); } }
        private ObservableCollection<BirthDayItem> _listItem;
        public ObservableCollection<BirthDayItem> ListItem
        { get { return _listItem; } set { _listItem = value; OnPropertyChanged("ListItem"); } }
        private Uri _VideoItem;
        public Uri VideoItem
        { get { return _VideoItem; } set { _VideoItem = value; OnPropertyChanged("VideoItem"); } }
        private Uri MusicItem;
        private Uri _PictureItem;
        public Uri PictureItem
        { get { return _PictureItem; } set { _PictureItem = value; OnPropertyChanged("PictureItem"); } }
        public void GetListPicture()
        {
            if (ListItem == null)
            {
                ListItem = new ObservableCollection<BirthDayItem>();
            }
            else
            {
                ListItem.Clear();
            }
        }
        private string _FontTitle { get; set; }
        public string FontTitle { get => _FontTitle; set { _FontTitle = value; OnPropertyChanged("FontTitle"); } }
        private string _FontCustomer { get; set; }
        public string FontCustomer { get => _FontCustomer; set { _FontCustomer = value; OnPropertyChanged("FontCustomer"); } }
        private ObservableCollection<string> _FontList = new ObservableCollection<string>();
        public ObservableCollection<string> FontList { get => _FontList; set { _FontList = value; OnPropertyChanged("FontList"); } }
        private int _FontSizeTitle { get; set; }
        public int FontSizeTitle { get => _FontSizeTitle; set { _FontSizeTitle = value; OnPropertyChanged("FontSizeTitle"); } }
        private int _FontSizeCustomer { get; set; }
        public int FontSizeCustomer { get => _FontSizeCustomer; set { _FontSizeCustomer = value; OnPropertyChanged("FontSizeCustomer"); } }
        private string _TitleBirthDay { get; set; }
        public string TitleBirthDay { get => _TitleBirthDay; set { _TitleBirthDay = value; OnPropertyChanged("TitleBirthDay"); } }
        private string _CustomerName { get; set; }
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged("CustomerName"); } }
        private int _Time { get; set; }
        public int Time { get => _Time; set { _Time = value; OnPropertyChanged("Time"); } }
        private string _MediaContent { get; set; }
        public string MediaContent { get => _MediaContent; set { _MediaContent = value; OnPropertyChanged("MediaContent"); } }
        private string _MediaChoose { get; set; }
        public string MediaChoose { get => _MediaChoose; set { _MediaChoose = value; OnPropertyChanged("MediaChoose"); } }
        private List<MediaData> Datas;
        #region Icommand 
        public ICommand RemoveListPicturesCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ChoosePictureCommand { get; set; }
        public ICommand ChooseVideoCommand { get; set;  }
        public ICommand RemovePictureCommand { get; set; }
        public ICommand ShowPreviewCommand { get; set; }
        public ICommand RemoveListPictureCommand { get; set;  }
        public ICommand PresentationCommand { get; set; }
        public ICommand PausePresentationCommand { get; set; }
        public ICommand NextPresentationCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        public ICommand MuteCommand { get; set; }
        public ICommand UnMuteCommand { get; set; }
        public ICommand ShowNameCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand UpTopCommand { get; set; }
        public ICommand ImportCustomerCommand { get; set; }
        public ICommand RemoveCustomerCommand { get; set; }
        public ICommand ChoosePicturesCommand { get; set; }

        #endregion
        #region Private 
        private bool IsChooseVideo;
        private bool IsMute;
        private bool _IsShowText;
        public bool IsPresentation;
        public bool IsRepeat;
        private string VideoUri;
        private CustomerBirthDay CurrentCustomer;
        public bool IsShowText
        { get { return _IsShowText; } set { _IsShowText = value; OnPropertyChanged("IsShowText"); } }
        #endregion
        #region Visibility
        private Visibility _PicturesVisibility { get; set; }
        public Visibility PicturesVisibility { get => _PicturesVisibility; set { _PicturesVisibility = value; OnPropertyChanged("PicturesVisibility"); } }
        private Visibility _VideoVisibility { get; set; }
        public Visibility VideoVisibility { get => _VideoVisibility; set { _VideoVisibility = value; OnPropertyChanged("VideoVisibility"); } }
        private Visibility _PresentationVisibility { get; set; }
        public Visibility PresentationVisibility { get => _PresentationVisibility; set { _PresentationVisibility = value; OnPropertyChanged("PresentationVisibility"); } }
        private Visibility _PausePresentationVisibility { get; set; }
        public Visibility PausePresentationVisibility { get => _PausePresentationVisibility; set { _PausePresentationVisibility = value; OnPropertyChanged("PausePresentationVisibility"); } }
        private Visibility _MuteVisibility { get; set; }
        public Visibility MuteVisibility { get => _MuteVisibility; set { _MuteVisibility = value; OnPropertyChanged("MuteVisibility"); } }
        private Visibility _UnMuteVisibility { get; set; }
        public Visibility UnMuteVisibility { get => _UnMuteVisibility; set { _UnMuteVisibility = value; OnPropertyChanged("UnMuteVisibility"); } }
        private Visibility _UpdateVisibility { get; set; }
        public Visibility UpdateVisibility { get => _UpdateVisibility; set { _UpdateVisibility = value; OnPropertyChanged("UpdateVisibility"); } }
        #endregion
        #region Func Hepler 
        private void CloseResAds()
        {
            if (MainSecondViewModel.Restaurant != null)
            {
                MainSecondViewModel.Restaurant.Stop();
            }
            if (MainSecondViewModel._VideoControl != null)
            {
                MainSecondViewModel._VideoControl.Stop();
            }
        }

        private void StopAds()
        {
            if (MainSecondViewModel._VideoControl != null)
            {
                PresentationVisibility = Visibility.Visible;
                PausePresentationVisibility = Visibility.Collapsed;
                MainSecondViewModel._VideoControl.Pause();
            }
        }
        private void NextCustomer()
        {
            ListCustomers.Remove(ListCustomers[0]);
            if (ListCustomers.Count > 0)
            {
                if (0 < ListCustomers.Count)
                {
                    IsPresentation = true;
                    IsChooseVideo = ListCustomers[0].IsChooseVideo;
                    MainSecondViewModel.BirthDay.Interval = TimeSpan.FromMinutes(ListCustomers[0].Time);
                    if (ListCustomers[0].IsChooseVideo)
                    {
                        MediaContent = ListCustomers[0].MediaContent;

                        MainSecondViewModel.ShowVideo(ListCustomers[0], IsPresentation, IsRepeat, IsMute);
                    }
                    else
                    {
                        //PlayMusicVisibility = Visibility.Visible;
                        //PauseMusicVisibility = Visibility.Collapsed;
                        MainSecondViewModel.ShowListPicture(ListCustomers[0], IsShowText);
                    }
                    //CurrentCustomer = ListCustomers[0];
                    IsPresentation = true;
                }
                else
                {
                    MainSecondViewModel.ShowMainAdsWindow();
                    MainSecondViewModel.BirthDay.Stop();
                }
                //PlayButtonVisibility = Visibility.Collapsed;
                //PauseButtonVisibility = Visibility.Visible;
                PresentationVisibility = Visibility.Collapsed;
                PausePresentationVisibility = Visibility.Visible;
            }
            else
            {
                //SaveCommand                   
                MessageNotificationWindow window = new MessageNotificationWindow();
                window.ContentNotification.Text = "Danh sách đang trống";
                window.ShowDialog();
            }
        }
        private void SaveCustomer()
        {
            if (string.IsNullOrEmpty(TitleBirthDay))
            {
                TitleBirthDay = "Chúc Mừng Sinh Nhật";
            }
            if (!string.IsNullOrEmpty(CustomerName))
            {
                if (Time > decimal.Zero && Time <= 15)
                {
                    if (string.IsNullOrEmpty(VideoUri) && IsChooseVideo)
                    {
                        MessageNotificationWindow window = new MessageNotificationWindow();
                        window.ContentNotification.Text = "Chưa có âm nhạc/video";
                        window.ShowDialog();
                    }
                    else
                    {
                        CustomerBirthDay customer = new CustomerBirthDay();
                        customer.TitleBirthDay = TitleBirthDay;
                        customer.FontTitle = FontTitle;
                        customer.FontSizeTitle = FontSizeTitle;
                        customer.FontSizeCustomer = FontSizeCustomer;
                        customer.CustomerName = CustomerName;
                        customer.FontCustomer = FontCustomer;
                        customer.IsShowName = IsShowText;
                        customer.Number = ListCustomers.Count();
                        customer.MediaContent = MediaChoose;
                        customer.Time = Time;
                        if (IsChooseVideo)
                        {
                            customer.IsChooseVideo = true;
                            customer.MediaUri = VideoItem.AbsolutePath;
                            ListCustomers.Add(customer);
                            SaveListCustomer(ListCustomers);

                            //Properties.Settings.Default.Save();
                            if (!IsPresentation)
                            {
                                //PlayButtonVisibility = Visibility.Visible;
                            }
                        }
                        else
                        {
                            customer.IsChooseVideo = false;
                            if (ListItem.Count > 0)
                            {
                                customer.ListPictures = ListItem.Select(x => x.UriMedia.ToString()).ToList();
                                if (MusicItem == null)
                                {
                                    string file = System.Windows.Forms.Application.StartupPath + string.Format("{0}.mp3", @"\SinhNhat");
                                    MusicItem = new Uri(file, UriKind.RelativeOrAbsolute);
                                    MediaChoose = System.IO.Path.GetFileName(file);
                                }
                                customer.MediaUri = MusicItem.AbsolutePath;
                                ListCustomers.Add(customer);
                                SaveListCustomer(ListCustomers);
                            }
                            else
                            {
                                MessageNotificationWindow window = new MessageNotificationWindow();
                                window.ContentNotification.Text = "Vui lòng chọn ảnh";
                                window.ShowDialog();
                            }

                        }
                    }
                }
                else
                {
                    MessageNotificationWindow window = new MessageNotificationWindow();
                    window.ContentNotification.Text = "Vui lòng điền thời lượng lớn hơn 0 và bé hơn 15";
                    window.ShowDialog();
                }
            }
            else
            {
                MessageNotificationWindow window = new MessageNotificationWindow();
                window.ContentNotification.Text = "Chưa nhập tên khách hàng";
                window.ShowDialog();
            }
        }
        public void GetListCustomer()
        {
            if(ListCustomers != null)
            {
                ListCustomers.Clear(); 
            }
            else
            {
                ListCustomers = new ObservableCollection<CustomerBirthDay>(); 
            }
            List<CustomerBirthDay> ListCustomerSave = Utils.AsObjectList<CustomerBirthDay>(Properties.Settings.Default.ListCustomers);
            if (ListCustomerSave != null && ListCustomerSave.Count > 0)
            {
                foreach (CustomerBirthDay customer in ListCustomerSave)
                {
                    customer.FontSizeTitle = 100;
                    customer.FontSizeCustomer = 100;
                    ListCustomers.Add(customer);
                }
                //PlayButtonVisibility = Visibility.Visible;
            }
        }
        public void GetListPictire()
        {
            if(ListItem != null)
            {
                ListItem.Clear(); 
            }
            else
            {
                ListItem = new ObservableCollection<BirthDayItem>(); 
            }
        }
        public void SaveListCustomer(ObservableCollection<CustomerBirthDay> customers)
        {
            List<CustomerBirthDay> ListCustomerSave = new List<CustomerBirthDay>(); 
            foreach(CustomerBirthDay customer in customers)
            {
                ListCustomerSave.Add(customer); 
            }
            WriteLog.logs(customers.Count.ToString());
            WriteLog.logs(ListCustomerSave.Count.ToString());
            Properties.Settings.Default.ListCustomers = Utils.AsJsonList<CustomerBirthDay>(ListCustomerSave); 
        }
        public void GetListFont()
        {
            if (FontList != null)
            {
                FontList.Clear(); 
            }
            else
            {
                FontList = new ObservableCollection<string>(); 
            }
            var fontColection = new System.Drawing.Text.InstalledFontCollection(); 
            foreach(var font in fontColection.Families)
            {
                FontList.Add(font.Name); 
            }
            FontTitle = FontList.Where(x => x.Contains("Tahoma")).FirstOrDefault();
            FontCustomer = FontList.Where(x => x.Contains("Tahoma")).FirstOrDefault();
            FontSizeTitle = 100;
            FontSizeCustomer = 100;
        }

        #endregion

        public BirthdayCustomerViewModel()
        {
            GetListPictire();
            GetListCustomer();
            GetListFont(); 
            PicturesVisibility = Visibility.Visible;
            VideoVisibility = Visibility.Visible;
            MuteVisibility = Visibility.Collapsed; 
            PresentationVisibility = Visibility.Visible;
            PausePresentationVisibility = Visibility.Visible;
            UnMuteVisibility = Visibility.Visible;
            IsShowText = true;
            MainSecondViewModel.IsMuteBirthDay = true;
            UpdateVisibility = Visibility.Collapsed;
            TitleBirthDay = "Chúc Mừng Sinh Nhật";

            LoadedWindowCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
                GetListCustomer();
                GetListFont();
                _VideoControl = p.FindName("VideoPlayer") as MediaElement;
                if (MainSecondViewModel.MainSecondEnum != MainSecondEnum.BIRTHDAY)
                {
                    PresentationVisibility = Visibility.Visible;
                    PausePresentationVisibility = Visibility.Collapsed;
                    MuteVisibility = Visibility.Collapsed;
                    UnMuteVisibility = Visibility.Visible;
                    //PlayMusicVisibility = Visibility.Collapsed;
                    //PauseMusicVisibility = Visibility.Collapsed;
                    IsShowText = true;
                    MainSecondViewModel.IsMuteBirthDay = true;
                    UpdateVisibility = Visibility.Collapsed;
                    IsMute = true;        
                }
                if (MainSecondViewModel.IsMuteBirthDay)
                {
                    MuteVisibility = Visibility.Visible;
                    UnMuteVisibility = Visibility.Collapsed;
                }
                else
                {
                    MuteVisibility = Visibility.Collapsed;
                    UnMuteVisibility = Visibility.Visible;
                }
            });
            ChoosePicturesCommand = new RelayCommand<UserControl>((p) => { return true; }, p =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Image files(*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
                if (openFileDialog.ShowDialog() == true)
                {
                    if (ListItem.Count + openFileDialog.FileNames.Length <= 50 && openFileDialog.FileNames.Length > 0)
                    {
                        for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                        {
                            ListItem.Add(new BirthDayItem(openFileDialog.FileNames[i]));
                        }
                        PictureItem = new Uri(openFileDialog.FileNames[0]);
                        PicturesVisibility = Visibility.Visible;
                        VideoVisibility = Visibility.Collapsed;
                        IsChooseVideo = false;
                        MediaChoose = "";
                    }
                    else
                    {
                        NotificationWindow notificationWindow = new NotificationWindow();
                        notificationWindow.ContentNotification.Text = "Vui lòng chọn dưới 50 bức ảnh";
                        notificationWindow.ShowDialog();
                    }
                }
            });
            RemovePictureCommand = new RelayCommand<BirthDayItem>((t) => { return true; }, t =>
            {
                if (t != null)
                {
                    ListItem.Remove(t);
                }
            });
            ChooseVideoCommand = new RelayCommand<UserControl>((p) => { return true; }, p =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Video files(*.mp4;*.fly)|*.mp4;*.fly";
                if (openFileDialog.ShowDialog() == true)
                {
                    PicturesVisibility = Visibility.Collapsed;
                    VideoVisibility = Visibility.Visible;
                    IsChooseVideo = true;
                    if (!string.IsNullOrEmpty(openFileDialog.FileNames[0]))
                    {
                        VideoItem = new Uri(openFileDialog.FileNames[0], UriKind.RelativeOrAbsolute);

                        if (VideoItem != null)
                        {
                            //_VideoControl = p.FindName("VideoPlayer") as MediaElement;
                            _VideoControl.Source = VideoItem;
                            _VideoControl.IsMuted = true;
                            _VideoControl.Play();
                            Thread.Sleep(1000);
                            _VideoControl.Pause();

                            IsChooseVideo = true;
                            MediaChoose = System.IO.Path.GetFileName(openFileDialog.FileNames[0]);
                            VideoUri = MediaChoose;
                        }
                    }
                }
            });
            PauseCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                IsPresentation = false;
                IsRepeat = true;
                if (MainSecondViewModel.BirthDay != null)
                {
                    MainSecondViewModel.BirthDay.Stop();
                    if (ListCustomers[0].IsChooseVideo)
                    {
                        MainSecondViewModel.ShowVideo(ListCustomers[0], IsPresentation, IsRepeat, IsMute);
                    }
                    else
                    {
                        MainSecondViewModel.ShowListPicture(ListCustomers[0], IsShowText);
                    }
                }
            });
            MuteCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                MuteVisibility = Visibility.Visible;
                UnMuteVisibility = Visibility.Collapsed;
                IsMute = true;
                MainSecondViewModel.MuteVideoBirthDay(IsMute);
            });
            UnMuteCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                MuteVisibility = Visibility.Collapsed;
                UnMuteVisibility = Visibility.Visible;
                IsMute = false;
                MainSecondViewModel.MuteVideoBirthDay(IsMute);
            });
            ShowNameCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                if (ListCustomers.Count > 0)
                {
                    MainSecondViewModel.ShowNameBirthDay(ListCustomers[0].TitleBirthDay, ListCustomers[0].FontTitle, ListCustomers[0].CustomerName, ListCustomers[0].FontCustomer, IsShowText);
                }
            });
            SaveCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                SaveCustomer();
                UpdateVisibility = Visibility.Collapsed;
            });
            UpTopCommand = new RelayCommand<CustomerBirthDay>((t) => { return true; }, t =>
            {
                if (t != null)
                {
                    if (!IsPresentation)
                    {
                        ListCustomers.Remove(t);
                        ListCustomers.Insert(0, t);
                        MediaContent = t.MediaContent;
                    }
                    else
                    {
                        ListCustomers.Remove(t);
                        ListCustomers.Insert(1, t);
                    }
                    SaveListCustomer(ListCustomers);
                }
            });
            RemoveCustomerCommand = new RelayCommand<CustomerBirthDay>((t) => { return true; }, t =>
            {
                if (t != null)
                {
                    if (ListCustomers.Count == 1 && IsPresentation)
                    {
                        MessageNotificationWindow window = new MessageNotificationWindow();
                        window.ContentNotification.Text = "Đang trình chiếu vui lòng chờ";
                        window.ShowDialog();
                    }
                    else
                    {
                        ListCustomers.Remove(t);
                        SaveListCustomer(ListCustomers);
                    }
                }
            });
            ImportCustomerCommand = new RelayCommand<CustomerBirthDay>((t) => { return true; }, t =>
            {
                if (t != null)
                {
                    if (!IsPresentation)
                    {
                        //PlayButtonVisibility = Visibility.Visible;
                    }
                    TitleBirthDay = t.TitleBirthDay;
                    CustomerName = t.CustomerName;
                    Time = t.Time;
                    IsShowText = t.IsShowName;
                    MediaChoose = t.MediaContent;
                    IsChooseVideo = t.IsChooseVideo;
                    if (IsChooseVideo)
                    {
                        VideoUri = MediaChoose;
                    }
                    if (t.IsChooseVideo)
                    {
                        PicturesVisibility = Visibility.Collapsed;
                        VideoVisibility = Visibility.Visible;

                        VideoItem = new Uri(t.MediaUri);
                        _VideoControl.Source = new Uri(t.MediaUri);
                        _VideoControl.IsMuted = true;
                        _VideoControl.Play();
                        Thread.Sleep(1000);
                        _VideoControl.Pause();
                    }
                    else
                    {
                        PicturesVisibility = Visibility.Visible;
                        VideoVisibility = Visibility.Collapsed;
                        ListItem.Clear();
                        PictureItem = new Uri(t.ListPictures[0]);
                        for (int i = 0; i < t.ListPictures.Count; i++)
                        {
                            ListItem.Add(new BirthDayItem(t.ListPictures[i]));
                        }
                    }
                    CurrentCustomer = t;
                    UpdateVisibility = Visibility.Visible;
                }
            });
            UpdateCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                if (CurrentCustomer != null)
                {
                    SaveCustomer();
                    int i = ListCustomers.IndexOf(CurrentCustomer);
                    if (i < ListCustomers.Count)
                    {
                        ListCustomers.Remove(ListCustomers[i]);
                        UpdateVisibility = Visibility.Collapsed;
                        ListCustomers.Move(ListCustomers.Count - 1, i);
                        SaveListCustomer(ListCustomers);
                    }
                }
                else
                {
                    UpdateVisibility = Visibility.Collapsed;
                }
            });
            ShowPreviewCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                if (IsChooseVideo)
                {
                    ShowBirthDayWindow showBirthDay = new ShowBirthDayWindow();
                    showBirthDay.textItem.TitleBirthDay.Text = TitleBirthDay;
                    showBirthDay.textItem.CustomerName.Text = CustomerName;
                    //showBirthDay.pageTransitionControl.Visibility = Visibility.Collapsed;
                    showBirthDay.Video.Source = VideoItem;
                    showBirthDay.Video.Visibility = Visibility.Visible;
                    showBirthDay.Video.IsMuted = true;
                    showBirthDay.Video.Play();
                    showBirthDay.Video.MediaEnded += new RoutedEventHandler(m_MediaEnded);
                    void m_MediaEnded(object sender, RoutedEventArgs e)
                    {
                        showBirthDay.Video.Position = TimeSpan.FromSeconds(0);
                        showBirthDay.Video.Play();
                    }
                    showBirthDay.ShowDialog();
                }
                else
                {
                    ShowBirthDayWindow showBirthDay = new ShowBirthDayWindow();
                    showBirthDay.ImgCurrent.Source = ListItem[0].UriMedia;
                    showBirthDay.textItem.TitleBirthDay.Text = TitleBirthDay;
                    showBirthDay.textItem.CustomerName.Text = CustomerName;
                    showBirthDay.Video.Visibility = Visibility.Collapsed;
                    showBirthDay.Images = ListItem.Select(x => x.UriMedia.ToString()).ToArray();
                    showBirthDay.PlayPictures();
                    showBirthDay.ShowDialog();
                }
                if (IsShowText)
                {
                    //showBirthDay.ShowName.Visibility = Visibility.Visible;
                }
                else
                {
                    //showBirthDay.ShowName.Visibility = Visibility.Collapsed;
                }
            });
            RemoveListPicturesCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                ListItem.Clear();
            });
            PresentationCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                if (ListCustomers.Count > 0)
                {
                    StopAds();
                    //ResetADS(); 
                    CloseResAds();
                    if (MainSecondViewModel.BirthDay == null)
                    {
                        MainSecondViewModel.BirthDay = new DispatcherTimer();
                    }
                    MainSecondViewModel.BirthDay.Interval = TimeSpan.FromMinutes(ListCustomers[0].Time);
                    MainSecondViewModel.BirthDay.Tick += Timer_Show;
                    MainSecondViewModel.BirthDay.Start();
                    void Timer_Show(object sender, EventArgs e)
                    {
                        if (ListCustomers.Count == 0)
                        {
                            MainSecondViewModel.ShowMainAdsWindow();
                            MainSecondViewModel.BirthDay.Stop();
                        }
                        else
                        {
                            UpdateVisibility = Visibility.Collapsed;
                            IsRepeat = false;
                            ListCustomers.Remove(ListCustomers[0]);
                            SaveListCustomer(ListCustomers);
                            if (ListCustomers.Count > 0)
                            {
                                MainSecondViewModel.BirthDay.Interval = TimeSpan.FromMinutes(ListCustomers[0].Time);
                                IsChooseVideo = ListCustomers[0].IsChooseVideo;
                                if (ListCustomers[0].IsChooseVideo)
                                {
                                    //PlayMusicVisibility = Visibility.Collapsed;
                                    //PauseMusicVisibility = Visibility.Collapsed;
                                    MediaContent = ListCustomers[0].MediaContent;
                                    MainSecondViewModel.ShowVideo(ListCustomers[0], IsPresentation, IsRepeat, IsMute);
                                }
                                else
                                {
                                    //PlayMusicVisibility = Visibility.Visible;
                                    //PauseMusicVisibility = Visibility.Collapsed;
                                    MainSecondViewModel.ShowListPicture(ListCustomers[0], IsShowText);
                                }
                                //CurrentCustomer = ListCustomers[0];
                            }
                            else
                            {
                                PicturesVisibility = Visibility.Collapsed;
                                VideoVisibility = Visibility.Collapsed;
                                MediaChoose = "";
                                CustomerName = "";
                                Time = 0;
                                PausePresentationVisibility = Visibility.Collapsed;
                                PresentationVisibility = Visibility.Visible;
                                ListItem.Clear();
                                MainSecondViewModel.ShowMainAdsWindow();
                                MainSecondViewModel.BirthDay.Stop();
                            }
                        }
                    }
                    if (0 < ListCustomers.Count)
                    {
                        IsPresentation = true;
                        IsChooseVideo = ListCustomers[0].IsChooseVideo;
                        MainSecondViewModel.BirthDay.Interval = TimeSpan.FromMinutes(ListCustomers[0].Time);
                        if (ListCustomers[0].IsChooseVideo)
                        {
                            MediaContent = ListCustomers[0].MediaContent;
                            //PlayMusicVisibility = Visibility.Collapsed;
                            //PauseMusicVisibility = Visibility.Collapsed;
                            MainSecondViewModel.ShowVideo(ListCustomers[0], IsPresentation, IsRepeat, IsMute);
                        }
                        else
                        {
                            //PlayMusicVisibility = Visibility.Visible;
                            //PauseMusicVisibility = Visibility.Collapsed;
                            MainSecondViewModel.ShowListPicture(ListCustomers[0], IsShowText);
                        }
                        //CurrentCustomer = ListCustomers[0];
                        IsPresentation = true;
                    }
                    else
                    {
                        ListItem.Clear();
                        MainSecondViewModel.ShowMainAdsWindow();
                        MainSecondViewModel.BirthDay.Stop();
                    }
                    //PlayButtonVisibility = Visibility.Collapsed;
                    //PauseButtonVisibility = Visibility.Visible;
                    PresentationVisibility = Visibility.Collapsed;
                    PausePresentationVisibility = Visibility.Visible;
                }
                else
                {
                    //SaveCommand                   
                    MessageNotificationWindow window = new MessageNotificationWindow();
                    window.ContentNotification.Text = "Danh sách đang trống";
                    window.ShowDialog();
                }
            });
            NextPresentationCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                NextCustomer();
                SaveListCustomer(ListCustomers);
            });
            PausePresentationCommand = new RelayCommand<UserControl>((t) => { return true; }, t =>
            {
                IsPresentation = false;
                IsRepeat = true;
                if (MainSecondViewModel.BirthDay != null)
                {
                    MainSecondViewModel.BirthDay.Stop();
                    if (ListCustomers[0].IsChooseVideo)
                    {
                        MainSecondViewModel.ShowVideo(ListCustomers[0], IsPresentation, IsRepeat, IsMute);
                    }
                    else
                    {
                        MainSecondViewModel.ShowListPicture(ListCustomers[0], IsShowText);
                    }
                }
                PresentationVisibility = Visibility.Visible;
                PausePresentationVisibility = Visibility.Collapsed;
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
