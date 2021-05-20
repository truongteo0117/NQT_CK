using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiaoDichChungKhoan.Model;
namespace GiaoDichChungKhoan.DataSource
{
    class DataSQL
    {
        private SqlConnection conn;

        public DataTable getdata_history(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM giaodich where mUser = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;

        }

        public DataTable getdata_hose()
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM[giaodichchungkhoan].[dbo].[sanhose]", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
        public DataTable getdata_hnx()
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM[giaodichchungkhoan].[dbo].[sanhnx]", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        public DataTable coPhieu(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM cophieu where id_user = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
        public DataTable find(string mck)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM giaodich where mck = @mck", conn);
            cmd.Parameters.AddWithValue("@mck", mck.Trim());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        public string[] getdata_user(int id)
        {
            string[] user = new string[3];
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT name,tien FROM nguoidung Where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                user[0] = dr.GetValue(0).ToString();
                user[1] = dr.GetValue(1).ToString();
            }
            return user;
        }
        public string[] getdata_coPhieu(int id)
        {
            int i = 0;
            int dem = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT[mck],[coPhieu],[coPhieuLP] FROM[giaodichchungkhoan].[dbo].[cophieu] where id_user = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                dem = dem + 3;
            }
            string[] coPhieu = new string[dem];
            foreach (DataRow row in dt.Rows)
            {
                coPhieu[i] = row["mck"].ToString();
                coPhieu[i + 1] = row["coPhieu"].ToString();
                coPhieu[i + 2] = row["coPhieuLP"].ToString();
                i = i + 3;
            }

            return coPhieu;
        }
        public int find_cophieu(int id, string mck)
        {
            int find_cophieu = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT coPhieu FROM cophieu Where id_user=@id AND mck= @mck", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@mck", mck);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                find_cophieu = int.Parse(dr.GetValue(0).ToString());
            }
            return find_cophieu;
        }
        public string[] mck_hose()
        {
            int i = 0;
            int dem = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [mck] FROM[giaodichchungkhoan].[dbo].[sanhose]", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                dem++;
            }
            string[] mck = new string[dem];
            foreach (DataRow row in dt.Rows)
            {
                mck[i] = row["mck"].ToString();
                i++;
            }

            return mck;
        }
        public string[] mck_hnx()
        {
            int i = 0;
            int dem = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [mck] FROM[giaodichchungkhoan].[dbo].[sanhnx]", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                dem++;
            }
            string[] mck = new string[dem];
            foreach (DataRow row in dt.Rows)
            {
                mck[i] = row["mck"].ToString();
                i++;
            }

            return mck;
        }
        public float fin_tran_from_hose(string mck)
        {
            float giaTran = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [giaTran] FROM [giaodichchungkhoan].[dbo].[sanhose] where mck=@mck", conn);
            cmd.Parameters.AddWithValue("@mck", mck);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                giaTran = float.Parse(dr.GetValue(0).ToString());
            }
            return giaTran;
        }
        public float fin_san_from_hose(string mck)
        {
            float giaSan = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [giaSan] FROM [giaodichchungkhoan].[dbo].[sanhose] where mck=@mck", conn);
            cmd.Parameters.AddWithValue("@mck", mck);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                giaSan = float.Parse(dr.GetValue(0).ToString());
            }
            return giaSan;
        }
        public float fin_tran_from_hnx(string mck)
        {
            float giaTran = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [giaTran] FROM [giaodichchungkhoan].[dbo].[sanhnx] where mck=@mck", conn);
            cmd.Parameters.AddWithValue("@mck", mck);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                giaTran = float.Parse(dr.GetValue(0).ToString());
            }
            return giaTran;
        }
        public float fin_san_from_hnx(string mck)
        {
            float giaSan = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [giaSan] FROM [giaodichchungkhoan].[dbo].[sanhnx] where mck=@mck", conn);
            cmd.Parameters.AddWithValue("@mck", mck);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                giaSan = float.Parse(dr.GetValue(0).ToString());
            }
            return giaSan;
        }
        public string[] getdata_gd(int id)
        {
            int i = 0;
            int dem = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT[lenh],[soCoPhieu],[soTien],[trangThai] FROM[giaodichchungkhoan].[dbo].[giaodich] where mUser = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                dem = dem + 4;
            }
            string[] gd = new string[dem];
            foreach (DataRow row in dt.Rows)
            {
                gd[i] = row["lenh"].ToString();
                gd[i + 1] = row["soCoPhieu"].ToString();
                gd[i + 2] = row["soTien"].ToString();
                gd[i + 3] = row["trangThai"].ToString();
                i = i + 4;
            }

            return gd;
        }
        public string[] mck(int id)
        {
            int i = 0;
            int dem = 0;
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT [id_user],[mck] FROM [giaodichchungkhoan].[dbo].[cophieu] WHERE id_user = 1", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            foreach (DataRow row in dt.Rows)
            {
                dem++;
            }
            string[] mck = new string[dem+1];
            foreach (DataRow row in dt.Rows)
            {
                mck[i] = row["mck"].ToString();
                i++;
            }
            return mck;
        }
        public void add_lenh(string mSan, string mUser, string mck, string lenh, int soCoPhieu, string soTien, string trangthai, string phien, string lenhgia)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO giaodich VALUES(@mSan, @mck, @mUser, @lenh, @soCoPhieu, @soTien, @trangThai, @thoigian, @phien,@lenhgia,'',''); ", conn);
            cmd.Parameters.AddWithValue("mSan", mSan.Trim());
            cmd.Parameters.AddWithValue("mck", mck.Trim());
            cmd.Parameters.AddWithValue("mUser", mUser);
            cmd.Parameters.AddWithValue("lenh", lenh);
            cmd.Parameters.AddWithValue("soCoPhieu", soCoPhieu);
            cmd.Parameters.AddWithValue("soTien", int.Parse(soTien));
            cmd.Parameters.AddWithValue("trangthai", trangthai);
            cmd.Parameters.AddWithValue("thoigian", DateTime.Now);
            cmd.Parameters.AddWithValue("phien", phien);
            cmd.Parameters.AddWithValue("lenhgia", lenhgia);
            cmd.ExecuteNonQuery();
        }
        public void update_data_user(int tien, int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE nguoidung SET tien = @tien  WHERE ID = @id; ", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("tien", tien);
            cmd.ExecuteNonQuery();
        }
        public void update_data_cp(int id_user, string mck, int cophieulp, int coPhieu)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE cophieu SET coPhieuLP = @cophieulp,coPhieu = @coPhieu  WHERE id_user = @id AND mck = @mck", conn);
            cmd.Parameters.AddWithValue("id", id_user);
            cmd.Parameters.AddWithValue("mck", mck);
            cmd.Parameters.AddWithValue("cophieulp", cophieulp);
            cmd.Parameters.AddWithValue("coPhieu", coPhieu);
            cmd.ExecuteNonQuery();
        }
        public void delete_lichsu(int id)
        {
            string connString = ConfigurationManager.ConnectionStrings["gdck"].ConnectionString.ToString();
            conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM giaodich where id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
