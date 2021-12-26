using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyThuVien.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        
        public bool Isloaded = false;
        public ICommand LoadWindowCommand { get; set; }
        public ICommand PassbookCommand { get; set; }
        public ICommand PaymentCommand { get; set; }
        public ICommand ReceiptsCommand { get; set; }
        public ICommand PassbookListViewCommand { get; set; }
        public ICommand StatisticalCommand { get; set; }
        public ICommand MonthStatisticalCommand { get; set; }
        public ICommand ProductCommand{ get; set; }
        public ICommand StorageCommand { get; set; }

        public MainViewModel()
        {
            LoadWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                Logscreen logscreen = new Logscreen();
                logscreen.ShowDialog();
                if (logscreen.DataContext == null)
                    return;
                var loginVM = logscreen.DataContext as LogInViewModel;
                if (loginVM.isLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Hide();
                }
            }
            );
            int roleid=1;
            bool confirmative;
            var LoginRole = DataProvider.Ins.DB.USERINFOes.Where(x => x.IdRole == roleid).Count();
            if (LoginRole > 0) { confirmative = true; } else { confirmative = false; };


            ProductCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Product wd = new Product(); wd.ShowDialog(); });
            StorageCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Storage wd = new Storage(); wd.ShowDialog(); });           
            PaymentCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Payment wd = new Payment(); wd.ShowDialog(); });
            ReceiptsCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { Receipts wd = new Receipts(); wd.ShowDialog(); });
            PassbookListViewCommand = new RelayCommand<Object>((p) => { return true; }, (p) => { PassbookListView wd = new PassbookListView(); wd.ShowDialog(); });
            StatisticalCommand = new RelayCommand<Object>((p) => { return confirmative; }, (p) => { Statistical wd = new Statistical(); wd.ShowDialog(); });
            MonthStatisticalCommand = new RelayCommand<Object>((p) => { return confirmative; }, (p) => { MonthStatistical wd = new MonthStatistical(); wd.ShowDialog(); });

            
        }

        
    }
}
