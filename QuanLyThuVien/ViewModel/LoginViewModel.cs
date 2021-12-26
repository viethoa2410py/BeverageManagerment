using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyThuVien.ViewModel
{
    public class LogInViewModel : BaseViewModel
    {
        public bool isLogin { get; set; }
        private string _username;
        public string username { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _password;
        public string password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand PasswordCommand { get; set; }

       
        public LogInViewModel()
        {
            isLogin = false;
            password = "";
            username = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { password = p.Password; });
        }

        void Login(Window p)
        {
            if (p == null)
                return;
            string passEncode = MD5Hash(Base64Encode(password));
            var accCounts = DataProvider.Ins.DB.USERINFOes.Where(x => x.Username == username && x.Userpassword == passEncode).Count();
            if (accCounts>0)
            {
                isLogin = true;
                p.Close();
            }
            else
            {
                isLogin = false;
                System.Windows.MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}

