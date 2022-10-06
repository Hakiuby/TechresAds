using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Techres_Marketing.Views.UserControls
{
    /// <summary>
    /// Interaction logic for BirthdayUC.xaml
    /// </summary>
    public partial class BirthdayUC : UserControl
    {
        public BirthdayUC()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        string _prevText = string.Empty;
        private void cbTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var item in cbTest.Items)
            {
                if (item.ToString().StartsWith(cbTest.Text))
                {
                    _prevText = cbTest.Text;
                    return;
                }
            }
            cbTest.Text = _prevText;
        }
        private void cbFontTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var item in cbFontTitle.Items)
            {
                if (item.ToString().StartsWith(cbFontTitle.Text))
                {
                    _prevText = cbFontTitle.Text;
                    return;
                }
            }
            cbFontTitle.Text = _prevText;
        }
    }
}
