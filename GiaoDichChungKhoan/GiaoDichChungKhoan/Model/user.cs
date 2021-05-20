using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaoDichChungKhoan.Model
{
    [Serializable]
    class user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tien { get; set; }
    }
}
