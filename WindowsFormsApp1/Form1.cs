using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanHang f = new frmBanHang();
            f.Show();
                
        }

        private void BáoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho f = new frmBaoCaoTonKho();
            f.Show();
        }

        private void DanhSáchHàngHoáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachHH f = new frmDanhSachHH();
            f.Show();
        }

        private void BảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHanh f = new frmBaoHanh();
            f.Show();
        }
    }
}
