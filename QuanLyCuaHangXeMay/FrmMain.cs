using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangXeMay.Class;

namespace QuanLyCuaHangXeMay
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect(); // Kết nối CSDL

            // 1. Mở full màn hình
            this.WindowState = FormWindowState.Maximized;

            
            this.IsMdiContainer = true;//Đặt làm cha 

        }

        private void mnuXeMay_Click(object sender, EventArgs e)
        {
            FrmXeMay f = new FrmXeMay();
            f.MdiParent = this; //  Khai báo đây là con của Form Main
            f.StartPosition = FormStartPosition.CenterScreen; // Hiện giữa màn hình
            f.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FrmKhachHang f = new FrmKhachHang();
            f.MdiParent = this; 
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon f = new FrmHoaDon();
            f.MdiParent = this; 
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTonKho_Click(object sender, EventArgs e)
        {
            FrmTonKho f = new FrmTonKho();
            f.MdiParent = this; 
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            Application.Exit();
        }
    }
}