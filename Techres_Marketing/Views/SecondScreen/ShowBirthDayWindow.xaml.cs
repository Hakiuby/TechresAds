using ImageView.Shaders;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Techres_Marketing.Views.UserControls;
using WpfPageTransitions;

namespace Techres_Marketing.Views.SecondScreen
{
    /// <summary>
    /// Interaction logic for ShowBirthDayWindow.xaml
    /// </summary>
    public partial class ShowBirthDayWindow : Window
    {
        public DispatcherTimer timerImageChange;
        //private List<ImageSource> Images = new List<ImageSource>();
        private static string[] TransitionEffects = new[] { "Slide", "SlideAndFade", "Grow", "GrowAndFade", "LFade", "Flip", "FlipAndFade", "Spin", "SpinAndFade" };
        public TextItemUserControl textItem = new TextItemUserControl();
        private int IntervalTimer = 6;
        private int i = 0;

        private EffectManager _em;
        private BitmapSource _current;
        private BitmapSource _next;
        private string[] _images;
        public ShowBirthDayWindow()
        {
            InitializeComponent();
            textItem.TitleBirthDay.FontSize = 50;
            textItem.CustomerName.FontSize = 50;
            pageTransitionControl.ShowPage(textItem); 
        }
        private void timerImageChange_Tick(object sender, EventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                int next = i + 1;
                if (i + 1 > Images.Length - 1) next = 0;

                _current = getImg(Images[i], true);
                _next = getImg(Images[next], true);
                AplyEffect();
                ImgCurrent.Source = _next;
                ++i;
                if (i > Images.Length - 1) i = 0;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public string[] Images
        {
            get { return _images; }
            set
            {
                _images = value;
            }
        }
        private void da_Completed(object sender, EventArgs e)
        {
            if (i % 2 == 0)
            {
                pageTransitionControl.TransitionType = (WpfPageTransitions.PageTransitionType)Enum.Parse(typeof(PageTransitionType), TransitionEffects[i % 9], true);
                pageTransitionControl.ShowPage(textItem);
            }
        }
        private void AplyEffect()
        {
            TransitionEffect fx = _em.GetEffect();
            fx.Progress = 0;
            fx.OldImage = new ImageBrush(_current);
            fx.OldImage.Freeze();
            ImgCurrent.Effect = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            ImgCurrent.Effect = fx;

            DoubleAnimation da = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(3)), FillBehavior.HoldEnd);
            da.AccelerationRatio = 0.5;
            da.DecelerationRatio = 0.5;
            da.Completed += new EventHandler(da_Completed);
            fx.BeginAnimation(TransitionEffect.ProgressProperty, da);
        }
        private BitmapSource getImg(string path, bool small)
        {
            BitmapImage ret = new BitmapImage();
            ret.BeginInit();
            ret.UriSource = new Uri(path);
            if (small)
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
            if (Images.Length > 1)
            {
                _em = new EffectManager();
                timerImageChange = new DispatcherTimer();
                timerImageChange.Interval = new TimeSpan(0, 0, 5);
                timerImageChange.Tick += new EventHandler(timerImageChange_Tick);
                timerImageChange.Start();
            }
        }
    }
}
