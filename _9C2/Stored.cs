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
    public partial class Stored : Form
    {
        public Stored()
        {
            InitializeComponent();
        }
        SqlConnection conec = null;
        string stronic = @"Server = DESKTOP-EJJERSN\SQLEXPRESS;Initial Catalog=QLBanHang;Integrated Security=True";

        private void Stored_Load(object sender, EventArgs e)
        {
            HienThitoanbosanpham();
        }
        public void HienThitoanbosanpham()
        {
            if (conec == null)
            {
                conec = new SqlConnection(stronic);
            }
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "LayToanBoSanPham";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            lvSanPham.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader.GetInt32(0) + "");
                lvi.SubItems.Add(reader.GetString(1) + "");
                lvi.SubItems.Add(reader.GetDateTime(2) + "");
                lvi.SubItems.Add(reader.GetDateTime(3) + "");
                lvi.SubItems.Add(reader.GetString(4) + "");
                lvi.SubItems.Add(reader.GetInt32(5) + "");
                lvi.SubItems.Add(reader.GetString(6) + "");
                lvSanPham.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvSanPham_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem liv = lvSanPham.SelectedItems[0];
            int ma = int.Parse(liv.SubItems[0].Text);
            HienThiTheoMaSanPham(ma);
        }
        private void HienThiTheoMaSanPham(int ma)
        {
            if (conec == null)
            {
                conec = new SqlConnection(stronic);
            }
            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Hienchitietsanpham";
            command.Connection = conec;
            SqlParameter parama = new SqlParameter("@ma", SqlDbType.Int);
            parama.Value = ma;
            command.Parameters.Add(parama);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtMaSP.Text = reader.GetInt32(0) + "";
                txtTenSP.Text = reader.GetString(1) + "";
                dtpNgaySX.Text = reader.GetDateTime(2) + "";
                dtpNgayHH.Text = reader.GetDateTime(3) + "";
                txtDonVi.Text = reader.GetString(4) + "";
                txtDonGia.Text = reader.GetInt32(5) + "";
                txtGhiChu.Text = reader.GetString(6) + "";
            }
            reader.Close();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (conec == null)
            {
                conec = new SqlConnection(stronic);
            }

            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ThemSanPham";
            command.Connection = conec;
            command.Parameters.Add("@ma", SqlDbType.Int).Value = txtMaSP.Text;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTenSP.Text;
            command.Parameters.Add("@ngaysx", SqlDbType.Date).Value = dtpNgaySX.Text;
            command.Parameters.Add("@ngayhh", SqlDbType.Date).Value = dtpNgayHH.Text;
            command.Parameters.Add("@donvi", SqlDbType.NVarChar).Value = txtDonVi.Text;
            command.Parameters.Add("@dongia", SqlDbType.Int).Value = txtDonGia.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = txtGhiChu.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                HienThitoanbosanpham();
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them that bai");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (conec == null)
            {
                conec = new SqlConnection(stronic);
            }

            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SuaSanPham";
            command.Connection = conec;
            command.Parameters.Add("@ma", SqlDbType.Int).Value = txtMaSP.Text;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = txtTenSP.Text;
            command.Parameters.Add("@ngaysx", SqlDbType.Date).Value = dtpNgaySX.Text;
            command.Parameters.Add("@ngayhh", SqlDbType.Date).Value = dtpNgayHH.Text;
            command.Parameters.Add("@donvi", SqlDbType.NVarChar).Value = txtDonVi.Text;
            command.Parameters.Add("@dongia", SqlDbType.Int).Value = txtDonGia.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = txtGhiChu.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                HienThitoanbosanpham();
                MessageBox.Show("Sua Thanh Cong");
            }
            else
            {
                MessageBox.Show("Sua that bai");
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (conec == null)
            {
                conec = new SqlConnection(stronic);
            }

            if (conec.State == ConnectionState.Closed)
            {
                conec.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "XoaSanPham";
            command.Connection = conec;
            command.Parameters.Add("@ma", SqlDbType.Int).Value = txtMaSP.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                HienThitoanbosanpham();
                MessageBox.Show("Xoa Thanh Cong");
            }
        }
    }
}