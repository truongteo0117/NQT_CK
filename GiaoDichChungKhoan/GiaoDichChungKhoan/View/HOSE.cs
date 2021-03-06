using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDichChungKhoan.View
{


    public partial class HOSE : Form
    {
        string Mck;
        float tran;
        float san;
        int kt = 0;
        int id_user;
        float sucmua = 0;
        int sucban = 0;
        int kt_gia = 0;
        int kt_cp = 0;
        int kt_mck = 0;
        private ViewModel.HOSEViewModel _vm = new ViewModel.HOSEViewModel();
        private DataSource.DataSQL _data = new DataSource.DataSQL();
        public HOSE()
        {
            InitializeComponent();
            //add item combobox
            comboBox1.Items.Add("Mua");
            comboBox1.Items.Add("Bán");
            label5.Hide();
            label6.Hide();
            label7.Hide();

            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Hide();

            button3.TabStop = false;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Hide();

            button4.TabStop = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.Hide();

            //end
        }
        public HOSE(string mck, int id, float sotran, float sosan, string lenh) : this()
        {
            textBox1.Text = mck.Trim();
            Mck = textBox1.Text;
            id_user = id;
            tran = sotran;
            san = sosan;
            string[] user = _data.getdata_user(id_user);
            sucmua = int.Parse(user[1]) / (tran * 1000);
            sucban = _data.find_cophieu(id_user, textBox1.Text);
            button1.Enabled = false;
            button4.Show();
            kt_mck = 1;
            //label7.Text = (sotran * 1000).ToString();
            if (lenh == "Mua" || lenh == "")
            {
                comboBox1.SelectedItem = "Mua";
            }
            else if (lenh == "Bán")
            {
                comboBox1.SelectedItem = "Bán";
                if (comboBox1.Text == "Bán" && sucban == 0)
                {
                    button2.Hide();
                    label6.Hide();
                    label5.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Không Thể Bán. Bạn Không Có Cổ Phiếu Trong Công Ty Này !!";
                    kt = 1;
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label8.Show();
                button2.Hide();
                label8.ForeColor = Color.Red;
                label8.Text = "Vui Lòng Không Để Trống MCK!!!";
            }
            else if (textBox2.Text == "")
            {
                label8.Show();
                button2.Hide();
                label8.ForeColor = Color.Red;
                label8.Text = "Vui Lòng Không Để Trống Khối Lượng !!!";
            }
            else if (textBox3.Text == "")
            {
                label8.Show();
                button2.Hide();
                label8.ForeColor = Color.Red;
                label8.Text = "Vui Lòng Không Để Trống Giá!!!";
            }
            else
            {
                if (kt == 0)
                {

                    int value;
                    string mck = textBox1.Text;
                    int mUser = id_user;
                    string lenh = comboBox1.Text;
                    int khoiluong = int.Parse(textBox2.Text);
                    string gia = textBox3.Text;
                    if (comboBox1.Text == "Mua")
                    {
                        if (int.TryParse(gia, out value))
                        {
                            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                            decimal formattien = decimal.Parse(gia.ToString(), System.Globalization.NumberStyles.AllowThousands);
                            _vm.add_lenh(mck, mUser, lenh, khoiluong, gia, tran, san, (int)sucmua);
                            MessageBox.Show("Đặt Lệnh Mua Thành Công", "Thông Báo");
                            MessageBox.Show("[Mua]: Mã Sàn:" + mck.Trim() + ", Khối Lượng:" + khoiluong + ", Giá: " + String.Format(culture, "{0:N0}", formattien) + " VND !!", "Thông Báo");
                            comboBox1_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            _vm.add_lenh(mck, mUser, lenh, khoiluong, gia, tran, san, (int)sucban);
                            MessageBox.Show("Đặt Lệnh Mua Thành Công", "Thông Báo");
                            MessageBox.Show("[Mua]: Mã Sàn:" + mck.Trim() + ", Khối Lượng:" + khoiluong + ", Lệnh: " + gia, "Thông Báo");
                            comboBox1_SelectedIndexChanged(sender, e);
                        }

                    }
                    else
                    {
                        if (int.TryParse(gia, out value))
                        {
                            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                            decimal formattien = decimal.Parse(gia.ToString(), System.Globalization.NumberStyles.AllowThousands);
                            _vm.add_lenh(mck, mUser, lenh, khoiluong, gia, tran, san, (int)sucban);
                            MessageBox.Show("Đặt Lệnh Mua Thành Công", "Thông Báo");
                            MessageBox.Show("[Bán]: Mã Sàn:" + mck.Trim() + ", Khối Lượng:" + khoiluong + ", Giá: " + String.Format(culture, "{0:N0}", formattien) + " VND !!", "Thông Báo");
                            comboBox1_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            _vm.add_lenh(mck, mUser, lenh, khoiluong, gia, tran, san, (int)sucban);
                            MessageBox.Show("Đặt Lệnh Bán Thành Công");
                            MessageBox.Show("[Bán]: Mã Sàn:" + mck.Trim() + ", Khối Lượng:" + khoiluong + ", Lệnh: " + gia, "Thông Báo");
                            comboBox1_SelectedIndexChanged(sender, e);
                        }

                    }
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kt_cp = 0;
            kt_gia = 0;
            kt_mck = 0;
            string[] user = _data.getdata_user(id_user);
            if (comboBox1.Text == "Mua")
            {
                textBox2.Text = "";
                textBox3.Text = "";
                button3.Hide();
                button2.Hide();
                //MessageBox.Show("" + _data.find_cophieu(id_user, Mck));
                //MessageBox.Show(""+(int)sucmua);
                if (sucmua == 0 || int.Parse(user[1]) < tran * 1000 || int.Parse(user[1]) < san * 1000)
                {
                    label6.Hide();
                    label5.Hide();
                    label8.Show();
                    button2.Hide();
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox1.Enabled = false;
                    label8.ForeColor = Color.Red;
                    label8.Text = "Bạn Không Có Tiền Để Thực Hiện Mua, Vui Lòng Nạp Tiền !!";
                    kt = 1;

                }
                else
                {
                    kt = 0;
                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                    decimal formattien = decimal.Parse(((int)sucmua).ToString(), System.Globalization.NumberStyles.AllowThousands);
                    label5.Show();
                    label6.Show();
                    label8.Hide();
                    button2.Hide();
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    label6.Text = String.Format(culture, "{0:N0}", formattien) + " Cổ Phiếu";
                    label5.Text = "Sức Mua";
                }

            }
            else if (comboBox1.Text == "Bán")
            {
                //MessageBox.Show("" + _data.find_cophieu(id_user, Mck));
                //MessageBox.Show(""+(int)sucban);
                textBox2.Text = "";
                textBox3.Text = "";
                button3.Hide();
                button2.Hide();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal formattien = decimal.Parse(((int)sucban).ToString(), System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ
                if (sucban == 0)
                {
                    button2.Hide();
                    label6.Hide();
                    label5.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    label8.Text = "Không Thể Bán. Bạn Không Có Cổ Phiếu Trong Công Ty Này !!";
                    button4.Hide();
                    kt = 1;
                }
                else
                {
                    kt = 0;
                    button2.Hide();
                    label5.Show();
                    label6.Show();
                    label8.Hide();
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    label6.Text = String.Format(culture, "{0:N0}", formattien) + " Cổ Phiếu";
                    label5.Text = "Sức Bán:";
                }
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string[] user = _data.getdata_user(id_user);
            if (comboBox1.Text == "Mua" && textBox3.Text != "")
            {
                textBox1_TextChanged(sender, e);
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal formattiensan = decimal.Parse((san * 1000).ToString(), System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ
                decimal formattientran = decimal.Parse((tran * 1000).ToString(), System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ
                string[] phien = _vm.kt_phien(textBox3.Text);
                string data = _vm.label_sucmua(textBox3.Text, id_user, tran, san);
                if (data == null)
                {
                    button2.Hide();
                    label5.Hide();
                    label6.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Giá [" + textBox3.Text + "] Không Hợp Lệ !!";
                    kt_gia = 0;
                }
                else if (data == "3")
                {
                    button2.Hide();
                    label5.Hide();
                    label6.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Giá Nhập Vào Nhỏ Hơn Giá Sàn [" + String.Format(culture, "{0:N0}", formattiensan) + " VND] !!!";
                    kt_gia = 0;
                }
                else if (data == "4")
                {
                    button2.Hide();
                    label5.Hide();
                    label6.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Giá Nhập Vào Lớn Hơn Giá Trần [" + String.Format(culture, "{0:N0}", formattientran) + " VND] !!!";
                    kt_gia = 0;
                }
                else if (data != "4" && data != "3" && data == "5")
                {
                    button2.Hide();
                    label5.Hide();
                    label6.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Bước Giá Không Hợp Lệ !!!";
                    kt_gia = 0;
                }
                else if (data == "2")
                {
                    button2.Hide();
                    label5.Hide();
                    label6.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Lệnh [" + textBox3.Text + "] Không Hợp Lệ Tại " + phien[1] + " !!!";
                    kt_gia = 0;
                }
                else
                {
                    label5.Show();
                    label6.Show();
                    label8.Hide();
                    button2.Show();
                    kt_gia = 1;
                    sucmua = int.Parse(data);
                    textBox2_TextChanged(sender, e);
                    decimal formattien = decimal.Parse(data, System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ
                    label5.Text = "Sức Mua:";
                    label6.Text = String.Format(culture, "{0:N0}", formattien) + " Cổ Phiếu";
                }

            }
            else if (comboBox1.Text == "Bán" && textBox3.Text != "")
            {
                textBox1_TextChanged(sender, e);
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal formattiensan = decimal.Parse((san * 1000).ToString(), System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ

                decimal formattientran = decimal.Parse((tran * 1000).ToString(), System.Globalization.NumberStyles.AllowThousands);//Chuyển đổi chuỗi sang tiền tệ
                string[] phien = _vm.kt_phien(textBox3.Text);
                string data = _vm.label_sucmua(textBox3.Text, id_user, tran, san);
                if (data == null)
                {
                    button2.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Giá [" + textBox3.Text + "] Không Hợp Lệ !!";
                    kt_gia = 0;
                }
                else if (data == "3")
                {
                    button2.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Giá Nhập Vào Nhỏ Hơn Giá Sàn [" + String.Format(culture, "{0:N0}", formattiensan) + " VND] !!!";
                    kt_gia = 0;
                }
                else if (data == "4")
                {
                    button2.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Giá Nhập Vào Lớn Hơn Giá Trần [" + String.Format(culture, "{0:N0}", formattientran) + " VND] !!!";
                    kt_gia = 0;
                }
                else if (data != "4" && data != "3" && data == "5")
                {
                    button2.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Bước Giá Không Hợp Lệ !!!";
                    kt_gia = 0;
                }
                else if (data == "2")
                {
                    button2.Hide();
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Lệnh [" + textBox3.Text + "] Không Hợp Lệ Tại " + phien[1] + " !!!";
                    kt_gia = 0;
                }
                else
                {
                    kt_gia = 1;
                    button2.Show();
                    label8.Hide();
                }
                decimal formattien = decimal.Parse(((int)sucban).ToString(), System.Globalization.NumberStyles.AllowThousands);
                label6.Text = String.Format(culture, "{0:N0}", formattien) + " Cổ Phiếu";
                label5.Text = "Sức Bán:";


            }
            else if (textBox3.Text == "" && comboBox1.Text == "Mua")
            {
                //textBox1_TextChanged(sender, e);
                label8.Hide();
                label5.Show();
                label6.Show();
                button2.Hide();
                kt_gia = 0;
                textBox2_TextChanged(sender, e);
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal formattien = decimal.Parse(((int)sucmua).ToString(), System.Globalization.NumberStyles.AllowThousands);
                label6.Text = String.Format(culture, "{0:N0}", formattien) + " Cổ Phiếu";
                label5.Text = "Sức Mua:";
            }
            else if (textBox3.Text == "" && comboBox1.Text == "Bán")
            {
                //textBox1_TextChanged(sender, e);
                label8.Hide();
                label5.Show();
                label6.Show();
                button2.Hide();
                kt_gia = 0;
                textBox2_TextChanged(sender, e);
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal formattien = decimal.Parse(((int)sucban).ToString(), System.Globalization.NumberStyles.AllowThousands);
                label6.Text = String.Format(culture, "{0:N0}", formattien) + " Cổ Phiếu";
                label5.Text = "Sức Bán:";
            }
            else kt_gia = 1;

            //if (kt == 0) kt_gia = 1;
            //else kt_gia = 0;
            HOSE_Load(sender, e);

        }

        private void HOSE_Load(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mua")
            {
                if (kt_cp == 1 && kt_gia == 1 && kt_mck == 1)
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
            }
            else if (comboBox1.Text == "Bán")
            {
                if (kt_cp == 1 && kt_gia == 1 && kt_mck == 1)
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
            }


            if (textBox2.Text == "")
            {
                kt = 1;
                button3.Hide();
            }
            else if (textBox3.Text == "")
            {
                kt = 1;
                button2.Hide();
            }
            else kt = 0;


            //string[] user = _data.getdata_user(id_user);
            //if (kt_mck==1 && user[1] !=null) sucmua = int.Parse(user[1]) / (_tran * 1000);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] user = _data.getdata_user(id_user);
            if (textBox1.Text != "")
            {
                int check = _vm.kt_mck(id_user, textBox1.Text, comboBox1.Text);
                if (check == 1)
                {
                    kt_mck = 1;
                    label8.Hide();
                    label5.Show();
                    label6.Show();
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    button4.Show();
                    tran = _data.fin_tran_from_hose(textBox1.Text);
                    san = _data.fin_san_from_hose(textBox1.Text);
                    if (user[1] != null && textBox3.Text == "")
                    {
                        sucmua = int.Parse(user[1]) / (tran * 1000);
                        sucban = _data.find_cophieu(id_user, textBox1.Text);
                        comboBox1_SelectedIndexChanged(sender, e);

                    }
                }
                else if (check == 0)
                {
                    kt_mck = 0;
                    button4.Hide();
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Mã Sàn Không Tồn Tại !!!";
                }
            }
            else
            {
                label5.Hide();
                label6.Hide();
                label8.Text = "Vui Lòng Nhập Mã Chứng Khoán !!";
            }
            HOSE_Load(sender, e);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int cp_sucmua = 0;
            if (comboBox1.Text == "Bán" && textBox2.Text != "")
            {
                int kt_cophieu = _vm.kt_cophieu(textBox2.Text, sucban);
                if (kt_cophieu == 1)
                {
                    kt = 1;
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    button2.Hide();
                    label8.Text = "Số Cổ Nhập Vào Không Hợp Lệ (Bội của 10) !!";
                    button3.Hide();
                }
                else if (kt_cophieu == 2)
                {
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    button2.Hide();
                    label8.Text = "Số Cổ Phiếu Lớn Hơn Cổ Phiếu Hiện Có !!!";
                    kt = 1;
                    button3.Hide();
                }
                else if (kt_cophieu == 0)
                {
                    label8.Hide();
                    kt = 0;
                    button3.Show();
                    //textBox2_TextChanged(sender, e);

                }
            }

            if (comboBox1.Text == "Mua" && textBox2.Text != "")
            {
                /*if (textBox3.Text == "")*/
                cp_sucmua = (int)sucmua;
                //else
                //{
                //    string data = _vm.label_sucmua(textBox3.Text, id_user, tran, san);
                //    cp_sucmua = int.Parse(data);
                //}
                int kt_cophieu = _vm.kt_cophieu_ban(textBox2.Text, cp_sucmua);
                if (kt_cophieu == 1)
                {
                    kt = 1;
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Số Cổ Nhập Vào Không Hợp Lệ (Bội của 10) !!";
                    button3.Hide();
                }
                else if (kt_cophieu == 2)
                {
                    label8.Show();
                    label8.ForeColor = Color.Red;
                    label8.Text = "Khối Lượng Vượt Quá Sức Mua, Hãy Thay Đổi Giá !!";
                    kt = 1;
                    button3.Hide();
                }
                else if (kt_cophieu == 0)
                {
                    label8.Hide();
                    button3.Show();
                    kt = 0;
                }

                //label7.Text = "Cổ Phiếu: " + (tran * 1000) + "||" + cp_sucmua + "||" + textBox3.Text + ">" + (int)(tran * 1000);

            }
            if (textBox2.Text == "") label8.Hide();
            if (kt == 0) kt_cp = 1;
            else kt_cp = 0;
            HOSE_Load(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
