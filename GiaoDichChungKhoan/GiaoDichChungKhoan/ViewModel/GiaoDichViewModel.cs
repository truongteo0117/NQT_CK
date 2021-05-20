using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaoDichChungKhoan.Model;
using GiaoDichChungKhoan.DataSource;
namespace GiaoDichChungKhoan.ViewModel
{
    class GiaoDichViewModel
    {
        private List<sanchungkhoan> san;
        private DataSource.DataSQL _data = new DataSource.DataSQL();
        public BindingSource ContactBindingSource { get; set; }
        public BindingSource HistoryBindingSource { get; set; }
        public BindingSource CoPhieuBindingSource { get; set; }
        public void Load_san()
        {
            Random TC = new Random();
            float TC1 = TC.Next(10, 50);
            float TC2 = TC.Next(50, 70);
            float TC3 = TC.Next(20, 30);
            float TC4 = TC.Next(40, 80);
            //tạo datasource cho HOSE
            san = new List<sanchungkhoan>();
            //san.Add(new sanchungkhoan { mck = "ACB", maSan = "HOSE", TC = TC1, tran = TC1 + (TC1 / 100 * 7), san = TC1 - (TC1 / 100 * 7), });
            //san.Add(new sanchungkhoan { mck = "AAA", maSan = "HOSE", TC = TC2, tran = TC2 + (TC2 / 100 * 7), san = TC2 - (TC2 / 100 * 7), });
            //san.Add(new sanchungkhoan { mck = "GAS", maSan = "HOSE", TC = TC3, tran = TC3 + (TC3 / 100 * 7), san = TC3 - (TC3 / 100 * 7), });
            //san.Add(new sanchungkhoan { mck = "FPT", maSan = "HOSE", TC = TC4, tran = TC4 + (TC4 / 100 * 7), san = TC4 - (TC4 / 100 * 7), });
            //end
            ContactBindingSource.ResetBindings(false);
            ContactBindingSource.DataSource = san;
        }


        //Data bảng Lich Su
        public void load_history(int id)
        {
            HistoryBindingSource.ResetBindings(false);
            HistoryBindingSource.DataSource = _data.getdata_history(id);
        }
        public void data_find(string mck)
        {
            HistoryBindingSource.ResetBindings(true);
            HistoryBindingSource.DataSource = _data.find(mck);
        }
        //Data bảng cổ Phiếu
        public void load_coPhieu(int id)
        {
            CoPhieuBindingSource.ResetBindings(false);
            CoPhieuBindingSource.DataSource = _data.coPhieu(id);
        }

        //Lấy dữ liệu người dùng
        public string[] data_user(int id)
        {
            string[] user = new string[2];
            string[] data_user = _data.getdata_user(id);
            string[] gd = _data.getdata_gd(id);
            int tien = int.Parse(data_user[1].ToString());
            //MessageBox.Show("|"+gd[3]+"|"+ int.Parse(gd[2]) * int.Parse(gd[1]));
            for (int i = 0; i < gd.Length; i++)
            {

                if (gd[i] == "Mua")
                {
                    if (gd[i + 3].Trim() == "Đã Nhận")
                    {
                        //tien = tien - (int.Parse(gd[i + 2]));
                    }
                }
                i = i + 3;
            }
            user[0] = data_user[0];
            user[1] = data_user[1];
            return user;
        }
        
    }
}
