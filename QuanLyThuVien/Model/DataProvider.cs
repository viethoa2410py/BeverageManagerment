using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Model
{
    public class DataProvider
    {
        public static DataProvider _ins;
        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }

        public BEVERAGEMANAGERMENTEntities DB { get; set; }

        private DataProvider()
        {
            DB = new BEVERAGEMANAGERMENTEntities();
        }
    }
}
