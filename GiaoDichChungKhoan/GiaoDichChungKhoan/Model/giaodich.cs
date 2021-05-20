using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoDichChungKhoan.Model
{
    [Serializable]
    class giaodich
    {
        public int id { get; set; }
        public string mSan { get; set; }
        public string mck { get; set; }
        public int mUser { get; set; }
        public string lenh { get; set; }
        public string soCoPhieu { get; set; }
        public string khoiLuongKhop { get; set; }
        public string soTien { get; set; }
        public string giaKhop { get; set; }
        public string trangThai { get; set; }
        public DateTime thoiGian { get; set; }
        public string phien { get; set; }
        public string lenhGia { get; set; }
        public List<user> Users { get; set; } = new List<user>();
    }
}
