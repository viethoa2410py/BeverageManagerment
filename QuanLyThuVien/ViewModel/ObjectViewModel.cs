using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace QuanLyThuVien.ViewModel
{
    public class ObjectViewModel : BaseViewModel
    {
        private ObservableCollection<Remain> _Remainlist;
        public ObservableCollection<Remain> Remainlist { get => _Remainlist; set { _Remainlist = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.OBJECT> _List;
        public ObservableCollection<Model.OBJECT> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.UNIT> _Unit;
        public ObservableCollection<Model.UNIT> Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.SUPLIER> _Suplier;
        public ObservableCollection<Model.SUPLIER> Suplier { get => _Suplier; set { _Suplier = value; OnPropertyChanged(); } }

        private Remain _SelectedItem;
        public Remain SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (_SelectedItem != null && _SelectedItem.Object != null)
                {
                    DisplayName = _SelectedItem.Object.Displayname;
                    QRCode = _SelectedItem.Object.QRCode;
                    BarCode = _SelectedItem.Object.BarCode;
                    SelectedUnit = _SelectedItem.Object.UNIT;
                    SelectedSuplier = _SelectedItem.Object.SUPLIER;
                }
            }
        }

        private Model.UNIT _SelectedUnit;
        public Model.UNIT SelectedUnit
        {
            get => _SelectedUnit;
            set
            {
                _SelectedUnit = value;
                OnPropertyChanged();
            }
        }

        private Model.SUPLIER _SelectedSuplier;
        public Model.SUPLIER SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        private string _QRCode;
        public string QRCode { get => _QRCode; set { _QRCode = value; OnPropertyChanged(); } }


        private string _BarCode;
        public string BarCode { get => _BarCode; set { _BarCode = value; OnPropertyChanged(); } }


        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }

        private int _Counts;
        public int Counts { get => _Counts; set { _Counts = value; OnPropertyChanged(); } }


        private DateTime? _ContractDate;
        public DateTime? ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ObjectViewModel()
        {
            
            Remainlist = new ObservableCollection<Remain>();
            SelectedItem = new Remain();
            Unit = new ObservableCollection<Model.UNIT>(DataProvider.Ins.DB.UNITs);
            Suplier = new ObservableCollection<Model.SUPLIER>(DataProvider.Ins.DB.SUPLIERs);
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(DisplayName) || SelectedUnit == null )
                    return false;
                return true;

            }, (p) =>
            {
                Addobject();
            }
            );

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null || SelectedSuplier == null || SelectedUnit == null)
                    return false;

                var displayList = DataProvider.Ins.DB.OBJECTS.Where(x => x.Id == SelectedItem.Object.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Object = DataProvider.Ins.DB.OBJECTS.Where(x => x.Id == SelectedItem.Object.Id).SingleOrDefault();
                Object.Displayname = DisplayName;
                Object.BarCode = BarCode;
                Object.QRCode = QRCode;
                Object.IdSuplier = SelectedSuplier.Id;
                Object.IdUnit = SelectedUnit.Id;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.Object.Displayname = DisplayName;
            });
            LoadRemainData();
        }
        
        void LoadRemainData()
        {
            if (Remainlist.Count > 0) Remainlist.Clear();

            var objectList = DataProvider.Ins.DB.OBJECTS;

            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OutputIntoes.Where(p => p.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;

                if (inputList.Count() != 0)
                {
                    sumInput = (int)inputList.Sum(p => p.Counts);
                }
                if (outputList.Count() != 0)
                {
                    sumOutput = (int)outputList.Sum(p => p.Counts);
                }

                Remain remain = new Remain();
                remain.STT = i;
                remain.Count = sumInput - sumOutput;
                remain.Object = item;
                remain.Unit = item.UNIT;

                Remainlist.Add(remain);

                i++;

                Console.WriteLine(item.Id);
            }
        }
        void Addobject()
        {
            var product = DataProvider.Ins.DB.OBJECTS.Where(o => o.Displayname == DisplayName).FirstOrDefault();

            if (product == null)
            {
                var Object = new Model.OBJECT()
                {
                    Displayname = DisplayName,
                    IdSuplier = 1,
                    IdUnit = SelectedUnit.Id,
                    Id = Guid.NewGuid().ToString(),
                };

                product = Object;

                DataProvider.Ins.DB.OBJECTS.Add(Object);
                DataProvider.Ins.DB.SaveChanges();
            }

            var input = new Model.Input()
            {
                Id = Guid.NewGuid().ToString(),
                DateInput = DateTime.Today
            };
            DataProvider.Ins.DB.Inputs.Add(input);

            var inputinfo = new Model.InputInfo()
            {
                Id = Guid.NewGuid().ToString(),
                IdObject = product.Id,
                Counts = Counts,
                Input = input
            };

            DataProvider.Ins.DB.InputInfoes.Add(inputinfo);
            DataProvider.Ins.DB.SaveChanges();

            LoadRemainData();
        }


    }
}

