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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        List<HoaDon> _list;
        ObservableCollection<Product> _listProduct;
        ObservableCollection<HoaDon> _listhoadon;
        public OrderWindow()
        {
            _list = new List<HoaDon>();
            _listhoadon = new ObservableCollection<HoaDon>();
            InitializeComponent();
            this.DataContext = this;

        }
        private HoaDon _hoadonSelected;

        public List<HoaDon> List { get => _list; set => _list = value; }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listProduct = new ObservableCollection<Product>(DataProvider.Instance.DB.Products);
            _listhoadon = new ObservableCollection<HoaDon>(_list);
            lsvData.ItemsSource = _listhoadon;
            cboSanpham.ItemsSource = _listProduct;


            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }


        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _hoadonSelected = item as HoaDon;
            if (_hoadonSelected == null)
            {
                return;
            }

            txtDonGia.Text = _hoadonSelected.Price.ToString();
            txtMaHoaDon.Text = "auto";
            txtSoLuong.Text = _hoadonSelected.Amount.ToString();
            cboSanpham.SelectedValue = _hoadonSelected.IDProduct;
            btnSua.IsEnabled = true;
        }




        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtMaHoaDon.Text = "auto";
            //txtDonGia.Text = "";
            //txtSoLuong.Text = "";

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
                int idpro = int.Parse(_hoadonSelected.IDProduct.ToString());
                var product = _list.SingleOrDefault(n => n.IDProduct == idpro);
                if (product != null)
                {
                    _list.Remove(product);
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
            try
            {
                var index = _list.FindIndex(n => n.IDProduct == (int)cboSanpham.SelectedValue);
                if (index != -1)
                {
                    _list[index].Amount += int.Parse(txtSoLuong.Text);
                    return;
                }
                var hoadon = new HoaDon();
                hoadon.IDProduct = (int)cboSanpham.SelectedValue;
                hoadon.Name = cboSanpham.Text;
                hoadon.Price = txtDonGia.Text;
                hoadon.Amount = int.Parse(txtSoLuong.Text);
                var sanpham = DataProvider.Instance.DB.Products.SingleOrDefault(n => n.IDProduct == hoadon.IDProduct);
                if (sanpham == null)
                {
                    return;
                }
                hoadon.Producer = sanpham.Producer.Name;
                hoadon.Type = sanpham.Type.Name;
                _list.Add(hoadon);
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Sua()
        {
            var index = _list.FindIndex(n => n.IDProduct == (int)cboSanpham.SelectedValue);

            if (index != -1)
            {
                _list[index].Price = txtDonGia.Text;
                _list[index].Amount = int.Parse(txtSoLuong.Text);
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

        private void BtnHoanTat_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order();
            DataProvider.Instance.DB.Orders.Add(order);
            DataProvider.Instance.DB.SaveChanges();
            order.TimeOrder = DateTime.Now;
            foreach(var hoadon in _list)
            {
                var orderdetails = new OrderDetail();
                orderdetails.IDOrder = order.IDOrder;
                orderdetails.IDProduct = hoadon.IDProduct;
                orderdetails.Price = double.Parse(hoadon.Price);
                orderdetails.Amount = hoadon.Amount;
                DataProvider.Instance.DB.OrderDetails.Add(orderdetails);
            }
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thêm hóa đơn thành công");

        }

        private void CboSanpham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idproduct = (int)cboSanpham.SelectedValue;
            Product product = DataProvider.Instance.DB.Products.SingleOrDefault(n => n.IDProduct == idproduct);
            txtDonGia.Text = product.Price.ToString();
        }
    }
}
