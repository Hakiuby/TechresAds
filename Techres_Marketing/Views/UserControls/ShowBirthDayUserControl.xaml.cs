using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using FluidKit.Controls;
using ImageView.Shaders;


namespace Techres_Marketing.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ShowBirthDayUserControl.xaml
    /// </summary>
    public partial class ShowBirthDayUserControl : UserControl
    {
        public DispatcherTimer timerImageChange;
        //private List<ImageSource> Images = new List<ImageSource>();
        private int i = 1;

        private EffectManager _em = new EffectManager();
        private BitmapSource _current;
        private BitmapSource _next;

        public bool ShowName;
        private bool swap;
        public ShowBirthDayUserControl()
        {
            InitializeComponent();
            timerImageChange = new DispatcherTimer();
            timerImageChange.Interval = TimeSpan.FromSeconds(8);
            timerImageChange.Tick += new EventHandler(timerImageChange_Tick);
        }
        private void TextChange_Loaded(object sender, EventArgs e)
        {
            if (!swap)
            {
                TitleBirthDay.Visibility = Visibility.Collapsed;
                CustomerName.Visibility = Visibility.Collapsed;
                swap = !swap;
            }
            else
            {
                TitleBirthDay.Visibility = Visibility.Visible;
                CustomerName.Visibility = Visibility.Visible;
                swap = !swap;
            }
        }
        private void timerImageChange_Tick(object sender, EventArgs e)
        {
            if (Images.Count <= 1)
            {
                _current = getImg(Images[0], true);
                _next = getImg(Images[0], true);
                AplyEffect();
                ImgCurrent.Source = _next;
            }
            else
            {
                int next = i + 1;
                if (i + 1 > Images.Count - 1) next = 0;
                _current = getImg(Images[i], true);
                _next = getImg(Images[next], true);
                AplyEffect();
                ImgCurrent.Source = _next;
                ++i;
                if (i > Images.Count - 1) i = 0;
            }

            if (ShowName)
            {
                if (!swap)
                {
                    TitleBirthDay.Visibility = Visibility.Collapsed;
                    CustomerName.Visibility = Visibility.Collapsed;
                    swap = !swap;
                }
                else
                {
                    TitleBirthDay.Visibility = Visibility.Visible;
                    CustomerName.Visibility = Visibility.Visible;
                    swap = !swap;
                }
            }
        }
        public List<string> Images;
        private void AplyEffect()
        {
            TransitionEffect fx = _em.GetEffect();
            Console.WriteLine(fx.ToString());
            fx.Progress = 0;
            fx.OldImage = new ImageBrush(_current);
            fx.OldImage.Freeze();
            ImgCurrent.Effect = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            ImgCurrent.Effect = fx;

            DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(2)), FillBehavior.HoldEnd);
            //da.AccelerationRatio = 0.5;
            //da.DecelerationRatio = 0.5;
            //da.Completed += new EventHandler(da_Completed);
            fx.BeginAnimation(TransitionEffect.ProgressProperty, da);
        }
        private BitmapSource getImg(string path, bool small)
        {
            BitmapImage ret = new BitmapImage();
            ret.BeginInit();
            ret.UriSource = new Uri(path);
            if (!small)
            {
                ret.DecodePixelWidth = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.8);
            }
            ret.CacheOption = BitmapCacheOption.OnLoad;
            ret.EndInit();
            ret.Freeze();
            return ret;
        }
        public void PlayPictures()
        {
            if (Images.Count > 1)
            {
                timerImageChange.Start();

                if (Images.Count <= 1)
                {
                    _current = getImg(Images[0], true);
                    _next = getImg(Images[0], true);
                    AplyEffect();
                    ImgCurrent.Source = _next;
                }
                else
                {
                    int next = i + 1;
                    if (i + 1 > Images.Count - 1) next = 0;
                    _current = getImg(Images[i], true);
                    _next = getImg(Images[next], true);
                    AplyEffect();
                    ImgCurrent.Source = _next;
                    ++i;
                    if (i > Images.Count - 1) i = 0;
                }

                if (ShowName)
                {
                    if (!swap)
                    {
                        TitleBirthDay.Visibility = Visibility.Collapsed;
                        CustomerName.Visibility = Visibility.Collapsed;
                        swap = !swap;
                    }
                    else
                    {
                        TitleBirthDay.Visibility = Visibility.Visible;
                        CustomerName.Visibility = Visibility.Visible;
                        swap = !swap;
                    }
                }
            }
        }
    }
}
