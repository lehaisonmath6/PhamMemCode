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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLBHwpf
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtTenDangNhap.Text;
            var o = DataProvider.Instance.DB.Users.SingleOrDefault(n => n.Username == username);
            if(o != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại");
                return;
            }
            User user = new User { Username = txtTenDangNhap.Text, Password = FloatingPasswordBox.Password, Email = txtEmail.Text };
            DataProvider.Instance.DB.Users.Add(user);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Đăng ký thành công ");
            this.Close();
        }
    }
}
