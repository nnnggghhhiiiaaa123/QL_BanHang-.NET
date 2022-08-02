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
namespace WindowsFormsApp1
{
    public partial class frmDanhSachPhieu : Form
    {
        SqlConnection Ketnoi = new SqlConnection();
        SqlCommand lenh = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        public frmDanhSachPhieu()
        {
            InitializeComponent();
            Ketnoi.ConnectionString = Properties.Settings.Default.ChuoiKetNoi;
            Ketnoi.Open();
            lenh.Connection = Ketnoi;
        }
        void NapDanhSachPhieu()
        {
            lenh.CommandText = "Select SoPhieuX, NgayXuat, MaKH, LyDoXuat from XUATKHO";
            lenh.Parameters.Clear();
            da.SelectCommand = lenh;
            DataTable dt = new DataTable("DS");
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmDanhSachPhieu_Load(object sender, EventArgs e)
        {
            NapDanhSachPhieu();
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //có chọn dòng
            if(dataGridView1.SelectedRows.Count > 0)
            {
                clsThuVien.SoPhieuX = dataGridView1.SelectedRows[0].Cells["SoPhieuX"].Value.ToString();
                Close();
            }
        }
    }
}
