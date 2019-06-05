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
    /// Interaction logic for ProducerWindow.xaml
    /// </summary>
    public partial class ProducerWindow : Window
    {
        private ObservableCollection<Producer> _list;
        enum UserAction
        {
            Them,
            Sua,
            Xoa,
            Huy,
            Luu
        }
        UserAction userAction;
        public ProducerWindow()
        {
            _list = new ObservableCollection<Producer>(DataProvider.Instance.DB.Producers);
            InitializeComponent();
            this.DataContext = this;
            txtIDProducer.IsReadOnly = true;
        }
        private Producer _producerSelected;

        public ObservableCollection<Producer> List { get => _list; set => _list = value; }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new ObservableCollection<Producer>(DataProvider.Instance.DB.Producers);
            lsvData.ItemsSource = _list;
            btnHuy.Visibility = Visibility.Hidden;
            btnLuu.Visibility = Visibility.Hidden;
            btnThem.IsEnabled = true;
            btnXoa.IsEnabled = true;
            btnSua.IsEnabled = false;
        }


        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            _producerSelected = item as Producer;
            if (_producerSelected == null)
            {
                return;
            }
            txtIDProducer.Text = _producerSelected.IDProducer.ToString();
            txtTenNhaSanXuat.Text = _producerSelected.Name;
            txtEmail.Text = _producerSelected.Email;
            txtDienThoai.Text = _producerSelected.Phone;
            txtAddress.Text = _producerSelected.Address;
            txtDescription.Text = _producerSelected.Description;
            btnSua.IsEnabled = true;
        }




        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            txtTenNhaSanXuat.Text = "";
            txtEmail.Text = "";
            txtDienThoai.Text = "";
            txtDescription.Text = "";
            txtAddress.Text = "";
            txtIDProducer.Text = "auto";
            
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
                int idproducer = int.Parse(txtIDProducer.Text);
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
            var producer = new Producer();

            producer.Name = txtTenNhaSanXuat.Text;
            producer.Phone = txtDienThoai.Text;
            producer.Email = txtEmail.Text;
            producer.Description = txtDescription.Text;
            producer.Address = txtAddress.Text;
            
            DataProvider.Instance.DB.Producers.Add(producer);
            DataProvider.Instance.DB.SaveChanges();
            MessageBox.Show("Thêm thành công");
        }

        private void Sua()
        {
            int producerid = int.Parse(txtIDProducer.Text);
            var producer = DataProvider.Instance.DB.Producers.SingleOrDefault(n => n.IDProducer == producerid);
            if (producer != null)
            {
                producer.Name = txtTenNhaSanXuat.Text;
                producer.Phone = txtDienThoai.Text;
                producer.Description = txtDescription.Text;
                producer.Email = txtEmail.Text;
                producer.Address = txtAddress.Text;
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
