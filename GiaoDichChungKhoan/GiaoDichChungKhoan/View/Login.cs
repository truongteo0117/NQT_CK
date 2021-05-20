using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaoDichChungKhoan.View;
namespace GiaoDichChungKhoan
{
    public partial class Login : Form
    {
        private DataSource.DataSQL _data = new DataSource.DataSQL();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            decimal id = numericUpDown1.Value;
            mainForms truyen = new mainForms(id.ToString());
            truyen.FormClosed += new FormClosedEventHandler(truyen_FormClosed);
            truyen.Show();
            this.Hide();

        }
        private void truyen_FormClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
