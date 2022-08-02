using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class frmBanHang : Form
    {
        SqlConnection Ketnoi = new SqlConnection();
        SqlCommand lenh = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dtChiTiet = new DataTable("XuatKho_CT");
        DataTable dtPhieuXuat = new DataTable("XuatKho");
        int ViTri = -1;
        SqlCommand lenh2 = new SqlCommand();
        SqlDataAdapter da2 = new SqlDataAdapter();
        public frmBanHang()
        {
            InitializeComponent();
            Ketnoi.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            Ketnoi.Open();
            lenh.Connection = Ketnoi;
            lenh2.Connection = Ketnoi;
        }

        void NapMaKH()
        {
            lenh2.CommandText = "select MaKH, TenKH from KHACHHANG";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            DataTable dt = new DataTable("KH");
            da2.Fill(dt);
            cboMaKH.DataSource = dt;
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.DisplayMember = "TenKH";
        }
        void NapMaHang()
        {
            lenh2.CommandText = "select MaHang, TenHang from HANGHOA";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            DataTable dt = new DataTable("HH");
            da2.Fill(dt);
            MaHang.DataSource = dt;
            MaHang.ValueMember = "MaHang";
            MaHang.DisplayMember = "TenHang";
        }
        void NapChiTietPhieuXuat(string spx)
        {
            NapMaHang();
            lenh.CommandText = " select *, SLXuat*DGXuat as ThanhTien from XUATKHO_CT where SoPhieuX= @SPX";
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@SPX", spx);
            da.SelectCommand = lenh;
            dtChiTiet.Clear();
            da.Fill(dtChiTiet);
            dataGridView1.DataSource = dtChiTiet;
            //Tính tổng tiền phiếu xuất
            double tongtien = 0;
            for( int i=0;i< dtChiTiet.Rows.Count;i++)
            {
                double sl = Convert.ToDouble(dtChiTiet.Rows[i]["SLXuat"]);
                double dg = Convert.ToDouble(dtChiTiet.Rows[i]["DGXuat"]);
                tongtien += sl * dg;
            }
            txtTongTien.Text = tongtien.ToString();
        }
        void NapMotPhieuXuat(string spx)
        {
            lenh2.CommandText = " select * from XUATKHO where SoPhieuX = @SPX";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@SPX", spx);
            da2.SelectCommand = lenh2;
            DataTable dt = new DataTable("MOTPHIEUXUAT");
            da2.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtSoPhieuX.Text = dt.Rows[0]["SoPhieuX"].ToString();
                txtNgayXuat.Value = Convert.ToDateTime(dt.Rows[0]["NgayXuat"]);
                cboMaKH.SelectedValue = dt.Rows[0]["MaKH"].ToString();
                txtLyDoXuat.Text = dt.Rows[0]["LyDoXuat"].ToString();
            }
        }

        void NapDanhSachPhieuXuat()
        {
            lenh2.CommandText = "select * from XUATKHO";
            lenh2.Parameters.Clear();
            da2.SelectCommand = lenh2;
            dtPhieuXuat.Clear();
            da2.Fill(dtPhieuXuat);
        }

        void DiChuyenDenPhieu(int i)
        {
            txtSoPhieuX.Text = dtPhieuXuat.Rows[i]["SoPhieuX"].ToString();
            txtNgayXuat.Value = Convert.ToDateTime(dtPhieuXuat.Rows[i]["NgayXuat"]);
            cboMaKH.SelectedValue = dtPhieuXuat.Rows[i]["MaKH"].ToString();
            txtLyDoXuat.Text = dtPhieuXuat.Rows[i]["LyDoXuat"].ToString();
        }
        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            NapMaKH();
            NapDanhSachPhieuXuat();
            if(dtPhieuXuat.Rows.Count > 0)
            {
                ViTri = 0;
                DiChuyenDenPhieu(ViTri);
                NapChiTietPhieuXuat(txtSoPhieuX.Text);
            }
        }

        private void BtnDauTien_Click(object sender, EventArgs e)
        {
            if(dtPhieuXuat.Rows.Count > 0)
            {
                ViTri = 0;
                DiChuyenDenPhieu(ViTri);
                NapChiTietPhieuXuat(txtSoPhieuX.Text);
            }
        }

        private void BtnCuoiCung_Click(object sender, EventArgs e)
        {
            if(ViTri < dtPhieuXuat.Rows.Count-1)
            {
                ViTri = dtPhieuXuat.Rows.Count - 1;
                DiChuyenDenPhieu(ViTri);
                NapChiTietPhieuXuat(txtSoPhieuX.Text);
            }
        }

        private void BtnTruoc_Click(object sender, EventArgs e)
        {
            if(ViTri > 0)
            {
                ViTri -= 1;
                DiChuyenDenPhieu(ViTri);
                NapChiTietPhieuXuat(txtSoPhieuX.Text);
            }
        }

        private void BtnSau_Click(object sender, EventArgs e)
        {
            if(ViTri < dtPhieuXuat.Rows.Count -1 )
            {
                ViTri += 1;
                DiChuyenDenPhieu(ViTri);
                NapChiTietPhieuXuat(txtSoPhieuX.Text);
            }
        }
        //In phiếu bán hàng X
        private void BtnIn_Click(object sender, EventArgs e)
        {
            //Kết nối nguồn dữ liệu cho Report
            lenh.CommandText = "select HANGHOA.MaHang, TenHang, KHACHHANG.MaKH,TenKH,DiaChi, XUATKHO_CT.STT,SLXuat,DGXuat,SLXuat*DGXuat as ThanhTien"
                + " from HANGHOA, KHACHHANG, XUATKHO,XUATKHO_CT"
            + " where XUATKHO_CT.MaHang = HANGHOA.MaHang and XUATKHO_CT.SoPhieuX = XUATKHO.SoPhieuX and KHACHHANG.MaKH = XUATKHO.MaKH"
            + " and KHACHHANG.MaKH=@MaKH";
            lenh.Parameters.Clear();
            lenh.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue.ToString());
            da.SelectCommand = lenh;
            DataTable dt = new DataTable("PhieuBH");
            da.Fill(dt);
            //Gán nguồn dữ liệu cho Crystal Report
            rptPhieuBH baocao = new rptPhieuBH();
            baocao.SetDataSource(dt);
            // Hiển thị báo cáo
            frmInBaoCaoPhieuBH f = new frmInBaoCaoPhieuBH();
            f.crystalReportViewer1.ReportSource = baocao;
            f.ShowDialog();
            
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            frmDanhSachPhieu f = new frmDanhSachPhieu();
            f.ShowDialog();
            if(clsThuVien.SoPhieuX != "")
            {
                NapMotPhieuXuat(clsThuVien.SoPhieuX);
                NapChiTietPhieuXuat(clsThuVien.SoPhieuX);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            lenh2.CommandText = " Insert into XUATKHO(SoPhieuX, NgayXuat, MaKH,LyDoXuat)" + "values(@SoPhieuX, @NgayXuat, @MaKH,@LyDoXuat)";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@SoPhieuX", txtSoPhieuX.Text);
            lenh2.Parameters.AddWithValue("@NgayXuat", txtNgayXuat.Value);
            lenh2.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue);
            lenh2.Parameters.AddWithValue("@LyDoXuat", txtLyDoXuat.Text);
            lenh2.ExecuteNonQuery();
            MessageBox.Show("Bạn vừa thêm mới một phiếu xuất");
            NapDanhSachPhieuXuat();
            NapChiTietPhieuXuat(txtSoPhieuX.Text);
        }
        // nút sửa X
        private void BtnSua_Click(object sender, EventArgs e)
        {
            lenh2.CommandText = "Update XUATKHO set NgayXuat = @NgayXuat,MaKH= @MaKH,LyDoXuat = @LyDoXuat where SoPhieuX = @SoPhieuX";

            //lenh2.CommandText = " Update XUATKHO set SoPhieuX = @SoPhieuX, NgayXuat = @NgayXuat,MaKH= @MaKH,LyDoXuat = @LyDoXuat where)";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@SoPhieuX", txtSoPhieuX.Text.Trim());
            lenh2.Parameters.AddWithValue("@NgayXuat", txtNgayXuat.Value);
            lenh2.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue.ToString().Trim());
            lenh2.Parameters.AddWithValue("@LyDoXuat", txtLyDoXuat.Text);
            lenh2.ExecuteNonQuery();
            MessageBox.Show("Bạn vừa sửa một phiếu xuất");
            NapDanhSachPhieuXuat();
            NapChiTietPhieuXuat(txtSoPhieuX.Text);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            lenh2.CommandText = " delete from XUATKHO where SoPhieuX = @SoPhieuX";
            lenh2.Parameters.Clear();
            lenh2.Parameters.AddWithValue("@SoPhieuX", txtSoPhieuX.Text);
            lenh2.Parameters.AddWithValue("@NgayXuat", txtNgayXuat.Value);
            lenh2.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue);
            lenh2.Parameters.AddWithValue("@LyDoXuat", txtLyDoXuat.Text);
            lenh2.ExecuteNonQuery();
            MessageBox.Show("Bạn có chắc muốn xoá phiếu xuất không?");
            NapDanhSachPhieuXuat();
            NapChiTietPhieuXuat(txtSoPhieuX.Text);
        }
        // Nút tìm kiếm X
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView1.Rows[e.Row.Index - 1].Cells["SoPhieuX"].Value = txtSoPhieuX.Text;
        }

        private void DataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Tính thành tiền
                double sl = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["SLXuat"].Value);
                double dg = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["DGXuat"].Value);
                double tt = sl * dg;
                dataGridView1.Rows[e.RowIndex].Cells["ThanhTien"].Value = tt;
                //Cập nhật dữ liệu bảng XUATKHO_CT

                lenh2.CommandText = " Insert into XUATKHO(SoPhieuX, NgayXuat, MaKH,LyDoXuat)" + "values(@SoPhieuX, @NgayXuat, @MaKH,@LyDoXuat)";
                lenh2.Parameters.Clear();
                lenh2.Parameters.AddWithValue("@SoPhieuX", txtSoPhieuX.Text);
                lenh2.Parameters.AddWithValue("@NgayXuat", txtNgayXuat.Value);
                lenh2.Parameters.AddWithValue("@MaKH", cboMaKH.SelectedValue);
                lenh2.Parameters.AddWithValue("@LyDoXuat", txtLyDoXuat.Text);
                lenh2.ExecuteNonQuery();
                MessageBox.Show("Bạn vừa thêm mới một phiếu xuất");
                NapDanhSachPhieuXuat();
                NapChiTietPhieuXuat(txtSoPhieuX.Text);

                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dtChiTiet);
            }
            catch { }


        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnLuuHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.Show();
        }
    }
}
