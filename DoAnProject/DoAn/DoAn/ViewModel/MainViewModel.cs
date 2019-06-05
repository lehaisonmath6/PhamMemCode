using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DoAn.Model;

namespace DoAn.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public string TongLuongNhap { get; set; }
        public string TongLuongXuat { get; set; }
        public string TongTonKho ;
        private ObservableCollection<TonKho> _TonKhoList;
        public ObservableCollection<TonKho> TonKhoList { get => _TonKhoList; set { _TonKhoList = value;OnPropertyChanged(); } }
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if(p==null)
                {
                    return;
                }
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if(loginWindow.DataContext == null)
                {
                    return;
                }
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if(loginVM.IsLogin)
                {
                    p.Show();
                    LoadTonKhoData();
                }
                else
                {
                    p.Close();
                }
            
            });
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
              {
                  UnitWindow unit = new UnitWindow();
                  unit.ShowDialog();
              });
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SuplierWindow unit = new SuplierWindow();
                unit.ShowDialog();
            });
            
        }
        int i = 1;
        void LoadTonKhoData()
        {
            TonKhoList = new ObservableCollection<TonKho>();
            var objectList = DataProvider.Ins.DB.Objects;
            int tongLuongNhap = 0;
            int tongLuongXuat = 0;
            int tongTonKho = 0;
            foreach(var item in objectList)
            {

                var inputList = DataProvider.Ins.DB.InputInfoes.Where(n => n.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputInfoes.Where(n => n.IdObject == item.Id);
                int sumInput = 0;
                int sumOutput = 0;
                if (inputList != null)
                {
                    sumInput = (int)inputList.Sum(p => p.Count);
                }
                if (outputList != null)
                {
                    sumOutput = (int)outputList.Sum(p => p.Count);
                }
                tongLuongNhap += sumInput;
                tongLuongXuat += sumOutput;
                TonKho tonKho = new TonKho();
                tonKho.STT = i;
                tonKho.Count = sumInput - sumOutput;
                tonKho.Object = item;
                TonKhoList.Add(tonKho);
                i++;
            }
            tongTonKho = tongLuongNhap - tongLuongXuat;
            TongLuongNhap = tongLuongNhap.ToString();
            TongLuongXuat = tongLuongXuat.ToString();
            TongTonKho = tongTonKho.ToString();
        }

    }
}
