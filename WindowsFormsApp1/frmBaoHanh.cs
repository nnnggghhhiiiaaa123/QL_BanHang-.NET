using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class frmBaoHanh : Form
    {
        SqlConnection Ketnoi = new SqlConnection();
        SqlCommand lenh2 = new SqlCommand();
        SqlDataAdapter da2 = new SqlDataAdapter();
        DataTable dtChiTiet = new DataTable("BaoHanh");
        public frmBaoHanh()
        {
            InitializeComponent();
            Ketnoi.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            Ketnoi.Open();
            lenh2.Connection = Ketnoi;
        }
        void NapMaKH()
        {
            lenh2.CommandText = "select MaKH, TenKH from KHACHHANG";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            DataTable dt = new DataTable("KH");
            da2.Fill(dt);
            cboTenKH.DataSource = dt;
            cboTenKH.ValueMember = "MaKH";
            cboTenKH.DisplayMember = "TenKH";
        }
        void NapMaHang()
        {
            lenh2.CommandText = "select MaHang, TenHang from HANGHOA";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            DataTable dt = new DataTable("HH");
            da2.Fill(dt);
            cboTenHH.DataSource = dt;
            TenHH.ValueMember = "MaHang";
            TenHH.DisplayMember = "TenHang";
        }
        void NapLoaiSCBH()
        {
            lenh2.CommandText = "select SoPhieuBH, LoaiSuaChua from BAOHANH";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            DataTable dt = new DataTable("BH");
            da2.Fill(dt);
            cboLoaiSuaChua.DataSource = dt;
            LoaiSuaChua.ValueMember = "SoPhieuBH";
            LoaiSuaChua.DisplayMember = "LoaiSuaChua";
        }
        void NapChiTietBH(string spbh)
        {
            NapMaKH();
            NapMaHang();
            NapLoaiSCBH();
            lenh2.CommandText = " select *, SL*Phi as ThanhTien from BAOHANH where SoPhieuBH= @SPBH";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@SPBH", spbh);
            da2.SelectCommand = lenh2;
            dtChiTiet.Clear();
            da2.Fill(dtChiTiet);
            dataGridView1.DataSource = dtChiTiet;
            //Tính tổng tiền phiếu xuất
            double tongtien = 0;
            for (int i = 0; i < dtChiTiet.Rows.Count; i++)
            {
                double sl = Convert.ToDouble(dtChiTiet.Rows[i]["SL"]);
                double phi = Convert.ToDouble(dtChiTiet.Rows[i]["Phi"]);
                tongtien += sl * phi;
            }
            txtBaoGia.Text = tongtien.ToString();
        }

        private void FrmBaoHanh_Load(object sender, EventArgs e)
        {
            NapMaKH();
            NapMaHang();
            NapLoaiSCBH();
            NapChiTietBH(txtSoPhieuBH.Text);
        }
    }
}
