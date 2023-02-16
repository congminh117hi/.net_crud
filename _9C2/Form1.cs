using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace _9C2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString.ToString();
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        public void HienThi()
        {
            string sqlSelect = "Select * from tbsinhvien";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsSinhVien.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlInsert = "Insert into tbsinhvien values (@ma_sv, @ho_ten, @dia_chi, @que_quan)";
            SqlCommand cmd = new SqlCommand(sqlInsert, con);
            cmd.Parameters.AddWithValue("ma_sv", txtMa.Text);
            cmd.Parameters.AddWithValue("ho_ten", txtTen.Text);
            cmd.Parameters.AddWithValue("dia_chi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("que_quan", txtQueQuan.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlEdit = "Update tbsinhvien Set ho_ten = @ho_ten, dia_chi = @dia_chi, que_quan = @que_quan Where ma_sv = @ma_sv";
            SqlCommand cmd = new SqlCommand(sqlEdit, con);
            cmd.Parameters.AddWithValue("ma_sv", txtMa.Text);
            cmd.Parameters.AddWithValue("ho_ten", txtTen.Text);
            cmd.Parameters.AddWithValue("dia_chi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("que_quan", txtQueQuan.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlDelete = "Delete from tbsinhvien Where ma_sv = @ma_sv";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.Parameters.AddWithValue("ma_sv", txtMa.Text);
            cmd.Parameters.AddWithValue("ho_ten", txtTen.Text);
            cmd.Parameters.AddWithValue("dia_chi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("que_quan", txtQueQuan.Text);
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlTimKiem = "Select * from tbsinhvien Where ma_sv = @ma_sv";
            SqlCommand cmd = new SqlCommand(sqlTimKiem, con);
            cmd.Parameters.AddWithValue("ma_sv", txtMaCanTim.Text);
            cmd.Parameters.AddWithValue("ho_ten", txtTen.Text);
            cmd.Parameters.AddWithValue("dia_chi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("que_quan", txtQueQuan.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsSinhVien.DataSource = dt;
        }
    }
}
