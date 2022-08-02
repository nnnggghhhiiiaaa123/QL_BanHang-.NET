using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class frmBaoCaoTonKho : Form
    {
        SqlConnection Ketnoi = new SqlConnection();
        SqlCommand lenh = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        public frmBaoCaoTonKho()
        {
            InitializeComponent();
            Ketnoi.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            Ketnoi.Open();
            lenh.Connection = Ketnoi;
        }

        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            //Kết nối nguồn dữ liệu cho Report
            lenh.CommandText = "select HANGHOA.MaHang,TenHang,SL from HANGHOA";
            lenh.Parameters.Clear();
            da.SelectCommand = lenh;
            DataTable dt = new DataTable("PhieuBCTonKho");
            da.Fill(dt);
            //Gán nguồn dữ liệu cho Crystal Report
            rptBaoCaoTonKho baocao = new rptBaoCaoTonKho();
            baocao.SetDataSource(dt);
            // Hiển thị báo cáo
            frmInBaoCaoTonKho f = new frmInBaoCaoTonKho();
            f.crystalReportViewer2.ReportSource = baocao;
            f.ShowDialog();
        }
    }
}
