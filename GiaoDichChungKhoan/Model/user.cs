using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    class user
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tien { get; set; }
        public string cophieu { get; set; }
    }
}
