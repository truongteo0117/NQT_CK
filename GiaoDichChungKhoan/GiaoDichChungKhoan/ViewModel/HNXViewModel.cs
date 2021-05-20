using GiaoDichChungKhoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDichChungKhoan.ViewModel
{
    class HNXViewModel
    {
        private DataSource.DataSQL _data = new DataSource.DataSQL();
        public BindingSource ContactBindingSource { get; set; }
        private ViewModel.GiaoDichViewModel _vm = new ViewModel.GiaoDichViewModel();
        public void Load_san()
        {
            ContactBindingSource.ResetBindings(false);
            ContactBindingSource.DataSource = _data.getdata_hnx();
        }
        public int ktlenh(string gia, float tran, float san, int id)
        {
            string[] user = _vm.data_user(id);
            int value;
            string[] data = new string[2];

            int kiemtra = 0;
            int tien = 0;
            //Kiểm tra tính hợp lệ của lệnh nhập vào
            if (gia == "MOK" || gia == "MAK" || gia == "MTL" || gia == "ATC")
            {
                kiemtra = 1;
            }
            else if (int.TryParse(gia, out value))
            {

                tien = int.Parse(gia);
                //MessageBox.Show("" + buocgia + "||" + tien);
                kiemtra = 2;
                //MessageBox.Show((int)(san * 1000) + "\\" + (float)(san * 1000));
                if (tien < (float)(san * 1000))
                {
                    kiemtra = 3;
                }
                else if (tien > (float)(tran * 1000))
                {
                    kiemtra = 4;
                }
                else if (tien % 100 != 0)
                {
                    kiemtra = 5;
                }
            }
            else kiemtra = 0;
            return kiemtra;
        }
        public int kt_cophieu(string cophieu, int sucban)
        {
            int kt = 0;
            if (int.Parse(cophieu) > sucban)
            {
                kt = 2;
            }
            else if (int.Parse(cophieu) % 100 != 0)
            {
                kt = 1;
            }
            else kt = 0;
            return kt;
        }
        public int kt_cophieu_ban(string cophieu, int sucmua)
        {
            int kt = 0;
            if (int.Parse(cophieu) > sucmua)
            {
                kt = 2;
            }
            else if (int.Parse(cophieu) % 100 != 0)
            {
                kt = 1;
            }
            else kt = 0;
            return kt;
        }
        public string label_sucmua(string gia, int id, float tran, float san)
        {
            string _label_sucmua = "";
            string[] phien = kt_phien(gia);
            int kiemtra = ktlenh(gia.ToString(), tran, san, id);
            string[] user = _vm.data_user(id);
            if (kiemtra == 2)
            {
                _label_sucmua = (int.Parse(user[1]) / int.Parse(gia)).ToString();
            }
            else if (kiemtra == 1)
            {
                if (phien[0] == "1") _label_sucmua = (int.Parse(user[1]) / (int)(tran * 1000)).ToString();
                else _label_sucmua = "2";
            }
            else if (kiemtra == 3) _label_sucmua = "3";
            else if (kiemtra == 4) _label_sucmua = "4";
            else if (kiemtra == 5) _label_sucmua = "5";
            else _label_sucmua = null;

            return _label_sucmua;
        }
        public string[] kt_phien(string gia)
        {
            int value;
            string phien = "";
            int kt_lenh = 0;
            string[] data = new string[2];
            DateTime now = DateTime.Now;
            int time_now = now.Hour * 60 + now.Minute;
            //MessageBox.Show("" + now.Hour + ":" + now.Minute);
            //if (gia == "ATO" || gia == "ATC" || gia == "MP" || int.TryParse(gia, out value))
            //{
            if (/*time_now >= 540 &&*/ time_now <= 690)
            {
                phien = "Phiên liên tục";
                if (gia == "MOK" || gia == "MAK" || gia == "MTL" || int.TryParse(gia, out value))
                {
                    kt_lenh = 1;
                }
            }
            else if (time_now >= 780 && time_now <= 870)
            {
                phien = "Phiên liên tục";
                if (gia == "MOK" || gia == "MAK" || gia == "MTL" || int.TryParse(gia, out value))
                {
                    kt_lenh = 1;
                }
            }
            else if (time_now > 870 /*&& time_now <=  885*/)
            {
                phien = "Phiên Đóng Cửa";
                if (gia == "ATC" || int.TryParse(gia, out value))
                {
                    kt_lenh = 1;
                }
                //MessageBox.Show("Lệnh [" + gia + "] Phù Hợp Với " + phien);
            }
            //if (kt_lenh == 0) MessageBox.Show("Lệnh [" + gia + "] Không Phù Hợp Với " + phien);
            //}
            //else kt_lenh = 0; //MessageBox.Show("Lệnh ["+gia+"] Không Hợp Lệ");

            data[0] = kt_lenh.ToString();
            data[1] = phien;

            return data;
        }
        public int kt_mck(int id, string mck, string lenh)
        {
            string[] _mck = _data.mck(id);
            int kt = 0;
            string[] mck_hnx = _data.mck_hnx();
            for (int i = 0; i < mck_hnx.Length; i++)
            {
                if (mck == mck_hnx[i].Trim())
                {
                    kt = 1;
                }
            }
            if (lenh == "Bán")
            {
                for (int i = 0; i < _mck.Length - 1; i++)
                {
                    if (mck == _mck[i].Trim() && kt == 1) kt = 1;
                    //else if (mck != _mck[i].Trim() && kt == 1)  kt = 2;
                }
            }

            return kt;
        }
        public void add_lenh(string mck, int mUser, string lenh, int cophieu, string gia, float tran, float san)
        {
            int id = mUser;
            float tien = 0;
            string[] user = _vm.data_user(id);
            string[] coPhieu = _data.getdata_coPhieu(id);
            int kt_ban = 0;
            int kt_lenh = 0;
            int value;
            string mSan = "HNX";
            string trangthai = "Đã Nhận";
            string phien = "";
            int tienadd = 0;
            int cophieu_find = 0;
            string lenh_gia = "";

            //Kiểm tra phiên làm việc và lệnh theo phiên
            DateTime now = DateTime.Now;
            int time_now = now.Hour * 60 + now.Minute;
            //MessageBox.Show("" + now.Hour + ":" + now.Minute);
            if (gia == "MOK" || gia == "MAK" || gia == "MTL" || gia == "ATC")
            {
                tien = tran * 1000;
                lenh_gia = gia;
            }
            else if (int.TryParse(gia, out value))
            {
                tien = int.Parse(gia);
                lenh_gia = "LO";
            }
            if (gia == "MOK" || gia == "MAK" || gia == "MTL" || gia == "ATC" || int.TryParse(gia, out value))
            {
                if (/*time_now >= 540 &&*/ time_now <= 690)
                {
                    phien = "Phiên liên tục";
                    if (gia == "MOK" || gia == "MAK" || gia == "MTL" || int.TryParse(gia, out value))
                    {
                        kt_lenh = 1;
                    }
                }
                else if (time_now >= 780 && time_now <= 870)
                {
                    phien = "Phiên liên tục";
                    if (gia == "MOK" || gia == "MAK" || gia == "MTL" || int.TryParse(gia, out value))
                    {
                        kt_lenh = 1;
                    }
                }
                else if (time_now > 870 /*&& time_now <=  885*/)
                {
                    phien = "Phiên Đóng Cửa";
                    if (gia == "ATC" || int.TryParse(gia, out value))
                    {
                        kt_lenh = 1;
                    }
                    //MessageBox.Show("Lệnh [" + gia + "] Phù Hợp Với " + phien);
                }
                //if (kt_lenh == 0) /*//MessageBox.Show(now.Hour + ">= 14 -"+now.Minute+">=30 || "+ now.Hour+ "<= 18-"+now.Minute+"<=45"+"||"+phien );*/ //MessageBox.Show("Lệnh [" + gia + "] Không Phù Hợp Với " + phien);
            }
            //else MessageBox.Show("Lệnh Nhập Không Hợp Lệ");


            if (kt_lenh == 1)
            {
                if (lenh == "Mua") //Kiểm tra dữ liệu nhập vào nếu Mua
                {
                    //MessageBox.Show(tien + "<=" + tran * 1000 + "||" + tien +"*"+ cophieu + "<=" + user[1]);
                    //Kiểm tra khối lượng, và tiền nhập vào
                    //if (cophieu % 100 == 0 && tien % 100 == 0 && tien >= san * 1000 && tien <= tran * 1000 && tien * cophieu <= int.Parse(user[1]))
                    //{
                    //    //MessageBox.Show("ok" + tien);
                    //    kt_mua = 1;
                    //}

                    ////else MessageBox.Show("Dữ Liệu Nhập vào Không Thỏa Mãn Điều Kiện");

                    //if (kt_mua == 1)
                    //{

                    tienadd = int.Parse(user[1]) - ((int)tien * cophieu);
                    //MessageBox.Show(mSan + "-" + mUser + "-" + mck + "-" + lenh + "-" + cophieu + "-" + trangthai + "-" + phien + "||" + tienadd);
                    _data.add_lenh(mSan, mUser.ToString(), mck, lenh, cophieu, tien.ToString(), trangthai, phien, lenh_gia);
                    _data.update_data_user(tienadd, id);
                    //}
                }
                else if (lenh == "Bán" && kt_lenh == 1) //Kiểm tra dữ liệu nhập vào nêu Bán
                {
                    //Tính tiền khi nhập lệnh
                    if (gia == "MOK" || gia == "MAK" || gia == "MTL" || gia == "ATC")
                    {
                        tien = san * 1000;
                    }
                    else tien = int.Parse(gia);

                    //Kiểm tra khối lượng, và tiền nhập vào
                    //if (cophieu % 100 == 0 && tien % 100 == 0 && tien >= san * 1000 && tien <= tran * 1000)
                    //{
                    for (int i = 0; i < coPhieu.Length; i++)
                    {
                        if (coPhieu[i].Trim() == mck && int.Parse(coPhieu[i + 1]) >= cophieu)//Kiểm tra mã chứng khoán với số cổ phiếu có bằng dữ liệu nhập vào không ? 
                        {
                            //MessageBox.Show("ok" + tien);
                            kt_ban = 1;
                        }
                        //else MessageBox.Show("Null" + "-" + coPhieu[i].Trim() + ":" + mck + "-" + coPhieu[i + 1] + "-" + cophieu);
                        i = i + 2;
                    }
                    //}
                    //else MessageBox.Show("Lệnh Nhập Không Hợp Lệ");

                    if (kt_ban == 1)
                    {
                        _data.add_lenh(mSan, mUser.ToString(), mck, lenh, cophieu, tien.ToString(), trangthai, phien, lenh_gia);
                        cophieu_find = _data.find_cophieu(id, mck);
                        //MessageBox.Show(mSan + "-" + mUser + "-" + mck + "-" + lenh + "-" + cophieu + "-" + trangthai + "-" + phien +"||"+(cophieu_find-cophieu));
                        //_data.add_lenh(mSan, mUser.ToString(), mck, lenh, cophieu, tien.ToString(), trangthai, phien);
                        _data.update_data_cp(id, mck, cophieu, cophieu_find - cophieu);
                    }
                }
            }



            //end


            //_data.add_lenh(mSan, mck, mUser, lenh, soCoPhieu, soTien, trangthai, phien);
        }
    }
}
