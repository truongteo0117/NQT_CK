using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiaoDichChungKhoan.Model;
namespace GiaoDichChungKhoan.ViewModel
{
    class Context : DbContext
    {
        public Context() : base("ContactsConnectionString")
        {

        }

        public DbSet<giaodich> giaodich { get; set; }
        public DbSet<user> user { get; set; }
    }
}
