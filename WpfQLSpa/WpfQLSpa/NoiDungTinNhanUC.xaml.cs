using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
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

namespace WpfQLSpa
{
    /// <summary>
    /// Interaction logic for NoiDungTinNhanUC.xaml
    /// </summary>
    public partial class NoiDungTinNhanUC : UserControl
    {
        public NoiDungTinNhanUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string content = System.Configuration.ConfigurationManager.AppSettings["SMSContent"];
            txtNoiDun.Text = content;
        }

      

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["SMSContent"].Value = txtNoiDun.Text;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("Lưu thành công");
        }
    }
}
