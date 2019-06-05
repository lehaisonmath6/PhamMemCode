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
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private ObservableCollection<Product> _list;
        private ObservableCollection<Type> _listTypes;
        private ObservableCollection<Producer> _listProducers;
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        public ProductWindow()
        {
            _list = new ObservableCollection<Product>(DataProvider.Instance.DB.Products);
            InitializeComponent();
            this.DataContext = this;
            txtIDProduct.IsReadOnly = true;
        }
        private Product _productSelected;

        public ObservableCollection<Product> List { get => _list; set => _list = value; }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new ObservableCollection<Product>(DataProvider.Instance.DB.Products);
            _listTypes = new ObservableCollection<Type>(DataProvider.Instance.DB.Types);
            _listProducers = new ObservableCollection<Producer>(DataProvider.Instance.DB.Producers);

            lsvData.ItemsSource = _list;
            cboLoaiSanPham.ItemsSource = _listTypes;
            cboNhaSanXuat.ItemsSource = _listProducers;

            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }


        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _productSelected = item as Product;
            if (_productSelected == null)
            {
                return;
            }
            txtIDProduct.Text = _productSelected.IDProduct.ToString();
            txtTenSanPham.Text = _productSelected.Name;
            txtDonGia.Text = _productSelected.Price.ToString();
            cboLoaiSanPham.SelectedValue = _productSelected.IDType;
            //txtLoaiSanPham.Text = _productSelected.Type.Name;
            cboNhaSanXuat.SelectedValue = _productSelected.IDProducer;
            txtDescription.Text = _productSelected.Description;
            btnSua.IsEnabled = true;
        }




        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtIDProduct.Text = "auto";
            txtTenSanPham.Text = "";
            //txtNhaSanXuat.Text = "";
            //txtLoaiSanPham.Text = "";
            txtDonGia.Text = "";
            txtDescription.Text = "";

           

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
                int idproducer = int.Parse(txtIDProduct.Text);
                var producer = DataProvider.Instance.DB.Producers.SingleOrDefault(n => n.IDProducer == idproducer);
                if (producer != null)
                {
                    DataProvider.Instance.DB.Producers.Remove(producer);
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
            try
            {
                var product = new Product();

                product.Name = txtTenSanPham.Text;
                product.IDProducer = (int)cboNhaSanXuat.SelectedValue;
                product.IDType = (int)cboLoaiSanPham.SelectedValue;
               
                product.Price = (double)int.Parse(txtDonGia.Text);
                product.Description = txtDescription.Text;

                DataProvider.Instance.DB.Products.Add(product);
                DataProvider.Instance.DB.SaveChanges();
                MessageBox.Show("Thêm thành công");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        private void Sua()
        {
            int producerid = int.Parse(txtIDProduct.Text);
            var product = DataProvider.Instance.DB.Products.SingleOrDefault(n => n.IDProduct == producerid);
            if (product != null)
            {
                product.Name = txtTenSanPham.Text;
                product.IDProducer = (int)cboNhaSanXuat.SelectedValue;
                product.IDType = (int)cboLoaiSanPham.SelectedValue;
                product.Price = double.Parse(txtDonGia.Text);
                product.Description = txtDescription.Text;

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

        private void TxtDonGia_TextChanged(object sender, TextChangedEventArgs e)
        {
            //MessageBox.Show(txtDonGia.Text);
        }

        private void BtnHuy_MouseEnter(object sender, MouseEventArgs e)
        {
          
        }

        private void TxtIDProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
