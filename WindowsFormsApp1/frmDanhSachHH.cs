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
    public partial class frmDanhSachHH : Form
    {
        
        SqlConnection Ketnoi = new SqlConnection();
        SqlCommand lenh2 = new SqlCommand();
        SqlDataAdapter da2 = new SqlDataAdapter();
        DataTable dtDanhSachHH = new DataTable("HH");
        
        public frmDanhSachHH()
        {
            InitializeComponent();
            Ketnoi.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            Ketnoi.Open();
            lenh2.Connection = Ketnoi;
        }
        void NapHangHoa(string mh)
        {
            lenh2.CommandText = " select * from HANGHOA where MaHang = @MaHang";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@MaHang", mh);
            da2.SelectCommand = lenh2;
            dtDanhSachHH.Clear();
            da2.Fill(dtDanhSachHH);
            dataGridView1.DataSource = dtDanhSachHH;

        }
        void HienThi()
        {
            lenh2.CommandText = " select * from HANGHOA ";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            dtDanhSachHH.Clear();
            da2.Fill(dtDanhSachHH);
            dataGridView1.DataSource = dtDanhSachHH;

        }
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            lenh2.CommandText = " select * from HANGHOA where MaHang = @MaHang";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@MaHang", txtTimKiem.Text);
            lenh2.ExecuteNonQuery();
            NapHangHoa(txtTimKiem.Text);

        }

        private void FrmDanhSachHH_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
             lenh2.CommandText = " Insert into HANGHOA values(@MaHang, @TenHang, @MoTa, @SoLuong, @DonGia)";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@MaHang", txtMaHang.Text);
            lenh2.Parameters.AddWithValue("@TenHang", txtTenHang.Text);
            lenh2.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
            lenh2.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
            lenh2.Parameters.AddWithValue("@DonGia", txtDonGia.Text);
            lenh2.ExecuteNonQuery();
            MessageBox.Show("Bạn vừa thêm một hàng hoá mới");
            NapHangHoa(txtMaHang.Text);
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHang.Text = string.Empty;
            txtTenHang.Text = string.Empty;
            txtMoTa.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtDonGia.Text = string.Empty;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da2);
            da2.Update(dtDanhSachHH);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            lenh2.CommandText = "Update HANGHOA set MaHang=@MaHang,TenHang= @TenHang,MoTa = @MoTa,SL= @SL,DG = @DG  where MaHang = @MaHang";

            //lenh2.CommandText = " Update XUATKHO set SoPhieuX = @SoPhieuX, NgayXuat = @NgayXuat,MaKH= @MaKH,LyDoXuat = @LyDoXuat where)";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@MaHang", txtMaHang.Text.Trim());
            lenh2.Parameters.AddWithValue("@TenHang", txtTenHang.Text);
            lenh2.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
            lenh2.Parameters.AddWithValue("@SL", txtSoLuong.Text);
            lenh2.Parameters.AddWithValue("@DG", txtDonGia.Text);
            lenh2.ExecuteNonQuery();
            MessageBox.Show("Bạn vừa sửa danh sách hàng hoá");
            HienThi();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            lenh2.CommandText = " delete from HANGHOA where MaHang = @MaHang";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@MaHang", txtMaHang.Text.Trim());
            lenh2.ExecuteNonQuery();
            MessageBox.Show("Bạn có chắc muốn xoá hàng hoá này không?");
            HienThi();
        }
    }
}
