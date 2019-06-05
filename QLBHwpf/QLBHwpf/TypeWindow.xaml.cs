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
    /// Interaction logic for TypeWindow.xaml
    /// </summary>
    public partial class TypeWindow : Window
    {
        private ObservableCollection<Type> _list;
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        public TypeWindow()
        {
            _list = new ObservableCollection<Type>(DataProvider.Instance.DB.Types);
            InitializeComponent();
            this.DataContext = this;
            txtIDType.IsReadOnly = true;
        }
        private Type _typeSelected;

        public ObservableCollection<Type> List { get => _list; set => _list = value; }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new ObservableCollection<Type>(DataProvider.Instance.DB.Types);
            lsvType.ItemsSource = _list;
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }


        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _typeSelected = item as Type;
            if (_typeSelected == null)
            {
                return;
            }
            txtIDType.Text = _typeSelected.IDType.ToString();
            txtTenLoaiSanPham.Text = _typeSelected.Name;
            txtMoTa.Text = _typeSelected.Description;
            btnSua.IsEnabled = true;
        }




        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtMoTa.Text = "";
            txtTenLoaiSanPham.Text = "";
            txtIDType.Text = "auto";
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
            btnXoa.IsEnabled = false;
            userAction = UserAction.Sua;
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            userAction = UserAction.Xoa;
            if (MessageBox.Show("Xóa", "Bạn có chắc sẽ xóa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int idtype = int.Parse(txtIDType.Text);
                var types = DataProvider.Instance.DB.Types.SingleOrDefault(n => n.IDType == idtype);
                if (types != null)
                {
                    DataProvider.Instance.DB.Types.Remove(types);
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
            var types = new Type();
            types.Name = txtTenLoaiSanPham.Text;
            types.Description = txtMoTa.Text;
            DataProvider.Instance.DB.Types.Add(types);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thêm thành công");
        }

        private void Sua()
        {
            int typeid = int.Parse(txtIDType.Text);
            Type types = DataProvider.Instance.DB.Types.SingleOrDefault(n => n.IDType == typeid);
            if (types != null)
            {
                types.Name = txtTenLoaiSanPham.Text;
                types.Description = txtTenLoaiSanPham.Text;
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Sửa thành công");
            }

        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            switch (userAction)
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
            userAction = UserAction.Huy;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
