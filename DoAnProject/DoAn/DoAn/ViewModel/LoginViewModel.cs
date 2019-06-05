using DoAn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAn.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        private string _Password;
        public string UserName { get => _UserName;set { _UserName = value;OnPropertyChanged(); } }
        public string Password { get => _Password; set { _Password = value;OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        void Login(Window p)
        {
            if (p == null) return;
            var b = DataProvider.Ins.DB.Users.SingleOrDefault(n => n.UserName == _UserName && n.Password == Password);
            if( b == null) {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản");
                return;
            }
            
            IsLogin = true;
            p.Close();
        }
    }
}
