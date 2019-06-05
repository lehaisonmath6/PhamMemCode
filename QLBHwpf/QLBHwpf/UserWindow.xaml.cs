using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window 
    {
        private ObservableCollection<User> _list;
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        public UserWindow()
        {
            _list = new ObservableCollection<User>(DataProvider.Instance.DB.Users);
            InitializeComponent();
            this.DataContext = this;
            txtIDUser.IsReadOnly = true;
        }
        private User _userSelected;
     
        public ObservableCollection<User> List { get => _list; set => _list = value; }
       
     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new ObservableCollection<User>(DataProvider.Instance.DB.Users);
            lsvUser.ItemsSource = _list;
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;           
        }

        
        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _userSelected = item as User;
            if(_userSelected == null)
            {
                return;
            }
            txtMatKhau.Text = _userSelected.Password;
            txtEmail.Text = _userSelected.Email;
            txtTenDangNhap.Text = _userSelected.Username;
            txtIDUser.Text = _userSelected.IDUser.ToString();
            btnSua.IsEnabled = true;
        }

       
    

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            txtTenDangNhap.Text = "";
            btnHuy.Visibility = Visibility.Visible;
            btnLuu.Visibility = Visibility.Visible;
            btnSua.IsEnabled = false;
            btnThem.IsEnabled = false;
            btnXoa.IsEnabled = false;
            userAction = UserAction.Them;
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            btnHuy.Visibility = Visibility.Visible;
            btnLuu.Visibility = Visibility.Visible;
            btnSua.IsEnabled = false;
            btnThem.IsEnabled = false;
            txtTenDangNhap.IsReadOnly = true;
            btnXoa.IsEnabled = false;
            userAction = UserAction.Sua;
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            userAction = UserAction.Xoa;
            if ( MessageBox.Show("Xóa","Bạn có chắc sẽ xóa",MessageBoxButton.YesNo) ==  MessageBoxResult.Yes)
            {
                int iduser = int.Parse(txtIDUser.Text);
                User user = DataProvider.Instance.DB.Users.SingleOrDefault(n => n.IDUser == iduser);
                if(user != null)
                {
                    DataProvider.Instance.DB.Users.Remove(user);
                    DataProvider.Instance.DB.SaveChanges();
                    Window_Loaded(null, null);
                    MessageBox.Show("Xóa thành công");
                    return;
                }
                MessageBox.Show("Xóa không thành công");
                return;
            }
        }

        private void Them()
        {
            txtIDUser.Text = "auto";
            User user = DataProvider.Instance.DB.Users.SingleOrDefault(n => n.Username == txtTenDangNhap.Text);
            if (user != null)
            {
                MessageBox.Show("Người dùng đã tồn tại");
                return;
            }
            user = new User();
            user.Username = txtTenDangNhap.Text;
            user.Password = txtMatKhau.Text;
            user.Email = txtEmail.Text;
            DataProvider.Instance.DB.Users.Add(user);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thêm thành công");
        }

        private void Sua()
        {
            int userid = int.Parse(txtIDUser.Text);
            User user = DataProvider.Instance.DB.Users.SingleOrDefault(n => n.IDUser == userid);
            if(user != null)
            {
                user.Password = txtMatKhau.Text;
                user.Email = txtEmail.Text;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }
            
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            switch(userAction)
            {
                case UserAction.Them:
                    Them();
                    break;
                case UserAction.Sua:
                    Sua();
                    break;
            }
            userAction = UserAction.Luu;
            Window_Loaded(null, null);
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
            txtTenDangNhap.IsReadOnly = false;
            userAction = UserAction.Huy;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
