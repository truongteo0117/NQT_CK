using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GiaoDichChungKhoan.ViewModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;
using GiaoDichChungKhoan.Model;
namespace GiaoDichChungKhoan.View
{
    public partial class mainForms : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private ViewModel.GiaoDichViewModel _vm = new ViewModel.GiaoDichViewModel();
        private ViewModel.HOSEViewModel _hose = new ViewModel.HOSEViewModel();
        private ViewModel.HNXViewModel _hnx = new ViewModel.HNXViewModel();
        private ViewModel.UPCOM _upcom = new ViewModel.UPCOM();
        private DataSource.DataSQL _data = new DataSource.DataSQL();
        int id;
        string mckhose = "";
        string mckhnx = "";
        float tranhose = 0;
        float sanhose = 0;
        float tranhnx = 0;
        float sanhnx = 0;
        int id_vb = 0;
        public mainForms(string giatri)
        {
            id = int.Parse(giatri);
            InitializeComponent();
            _hose.ContactBindingSource = sanchungkhoanBindingSource;
            _vm.CoPhieuBindingSource = cophieuBindingSource;
            _vm.HistoryBindingSource = giaodichBindingSource;  
            Load += delegate { _hose.Load_san(); };
            Load += delegate { _vm.load_coPhieu(id); };
            tabControl.TabPages.Remove(sanHNX);
            tabControl.TabPages.Remove(sanUPCOM);
            tabControl.TabPages.Remove(tabCoPhieu);
            tabControl.TabPages.Remove(tabHistory);
            gridViewSanHOSE.RowClick += delegate
            {
                mckhose = gridViewSanHOSE.GetFocusedRowCellValue("mck").ToString(); //lấy giá trị cột mck tại dòng đã chọn
                tranhose = float.Parse(gridViewSanHOSE.GetFocusedRowCellValue("giaTran").ToString()); //lấy giá trị cột mck tại dòng đã chọn
                sanhose = float.Parse(gridViewSanHOSE.GetFocusedRowCellValue("giaSan").ToString()); //lấy giá trị cột mck tại dòng đã chọn };
            };
            gridViewSanHNX.RowClick += delegate
            {
                mckhnx = gridViewSanHNX.GetFocusedRowCellValue("mck").ToString(); //lấy giá trị cột mck tại dòng đã chọn
                tranhnx = float.Parse(gridViewSanHNX.GetFocusedRowCellValue("giaTran").ToString()); //lấy giá trị cột mck tại dòng đã chọn
                sanhnx = float.Parse(gridViewSanHNX.GetFocusedRowCellValue("giaSan").ToString()); //lấy giá trị cột mck tại dòng đã chọn };
            };
            gridView1.RowClick += delegate
            {
                id_vb = int.Parse(gridView1.GetFocusedRowCellValue("id").ToString());
            };
            gridView1.Columns[9].DisplayFormat.FormatString = "HH:mm:ss MMM dd yyyy ";
            user();
        }


        private void gridViewSanHOSE_DoubleClick(object sender, EventArgs e)
        {
            string lenh = "";
            string mck = gridViewSanHOSE.GetFocusedRowCellValue("mck").ToString(); //lấy giá trị cột mck tại dòng đã chọn
            float tran = float.Parse(gridViewSanHOSE.GetFocusedRowCellValue("giaTran").ToString()); //lấy giá trị cột mck tại dòng đã chọn
            float san = float.Parse(gridViewSanHOSE.GetFocusedRowCellValue("giaSan").ToString()); //lấy giá trị cột mck tại dòng đã chọn
            //string[] user = _data.getdata_user(id);
            //MessageBox.Show("time" + tran * 1000 + "||" + (int)(tran * 1000)+"||"+ int.Parse(user[1]) / (tran * 1000));
            HOSE sanhose = new HOSE(mck, id, tran, san, lenh);
            sanhose.Show();
            sanhose.FormClosed += new FormClosedEventHandler(button1_Click);
        }

        public void user()
        {
            string[] user = _vm.data_user(id);
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal formattien = decimal.Parse(user[1], System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ

            label1.Text = user[0];
            label2.Text = String.Format(culture, "{0:N0}", formattien) + "VND";

        }
        private void HNX_Click(object sender, EventArgs e)
        {
            _hnx.ContactBindingSource = hNXBindingSource;
            _hnx.Load_san();
            tabControl.TabPages.Add(sanHNX);
            tabControl.SelectedTabPage = sanHNX;
        }

        private void HOSE_Click(object sender, EventArgs e)
        {
            _hose.ContactBindingSource = sanchungkhoanBindingSource;
            _hose.Load_san();
            tabControl.TabPages.Add(sanHOSE);
            tabControl.SelectedTabPage = sanHOSE;
        }

        private void UPCOM_Click(object sender, EventArgs e)
        {
            _hnx.ContactBindingSource = hNXBindingSource;
            _hnx.Load_san();
            tabControl.TabPages.Add(sanHNX);
            tabControl.SelectedTabPage = sanHNX;
        }

        private void gridViewSanHNX_DoubleClick(object sender, EventArgs e)
        {
            string lenh = "";
            string mck = gridViewSanHNX.GetFocusedRowCellValue("mck").ToString(); //lấy giá trị cột mck tại dòng đã chọn
            float tran = float.Parse(gridViewSanHNX.GetFocusedRowCellValue("giaTran").ToString()); //lấy giá trị cột mck tại dòng đã chọn
            float san = float.Parse(gridViewSanHNX.GetFocusedRowCellValue("giaSan").ToString()); //lấy giá trị cột mck tại dòng đã chọn
            HNX sanhose = new HNX(mck, id, tran, san,lenh);
            sanhose.FormClosed += new FormClosedEventHandler(button1_Click);
            sanhose.Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            _vm.HistoryBindingSource = giaodichBindingSource;
            _vm.load_history(id);
            tabControl.TabPages.Add(tabHistory);
            tabControl.SelectedTabPage = tabHistory;
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            _vm.HistoryBindingSource = cophieuBindingSource;
            _vm.load_coPhieu(id);
            tabControl.TabPages.Add(tabCoPhieu);
            tabControl.SelectedTabPage = tabCoPhieu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user();
            
        }

        private void gridControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.Control && (int)e.KeyChar == 2) //2 là chữ cái b 19 là s
            {
                string lenh = "Mua";
                HOSE _sanhose = new HOSE(mckhose, id, tranhose, sanhose, lenh);
                _sanhose.Show();
                _sanhose.FormClosed += new FormClosedEventHandler(button1_Click);
            }
            else if (ModifierKeys == Keys.Control && (int)e.KeyChar == 19) //2 là chữ cái b 19 là s
            {
                string lenh = "Bán";
                HOSE _sanhose = new HOSE(mckhose, id, tranhose, sanhose, lenh);
                _sanhose.Show();
                _sanhose.FormClosed += new FormClosedEventHandler(button1_Click);
            }
        }

        private void sanHOSE_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void sanHNXGridControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.Control && (int)e.KeyChar == 2) //2 là chữ cái b 19 là s
            {
                string lenh = "Mua";
                HNX _sanhose = new HNX(mckhnx.Trim(), id, tranhnx, sanhnx, lenh);
                _sanhose.Show();
                _sanhose.FormClosed += new FormClosedEventHandler(button1_Click);
            }
            else if (ModifierKeys == Keys.Control && (int)e.KeyChar == 19) //2 là chữ cái b 19 là s
            {
                string lenh = "Bán";
                HNX _sanhose = new HNX(mckhnx.Trim(), id, tranhnx, sanhnx, lenh);
                _sanhose.Show();
                _sanhose.FormClosed += new FormClosedEventHandler(button1_Click);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //_vm.data_find(textBox1.Text);
        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void mainForms_Load(object sender, EventArgs e)
        {
            button2.Click += delegate {
                _vm.load_history(id);
                textBox1.Text = null;
            };
            gridViewSanHOSE.MouseDown += delegate {
                var lb = new Label();
                Random rd = new Random();
                lb.Location = new Point(rd.Next(0, 500), rd.Next(100, 200));
                lb.Text = string.Format("Label");
                Controls.Add(lb);
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") _vm.data_find(textBox1.Text);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Delete && id_vb !=0)
            {
                DialogResult dlr = MessageBox.Show("Bạn Muốn Xóa Thông Tin Giao Dịch Này?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    _data.delete_lichsu(id_vb);
                    MessageBox.Show("Bạn Đã Xóa Thành Công !!","Thông Báo");
                    _vm.load_history(id);
                }
                else id_vb = 0;
            }
        }
    }
}
