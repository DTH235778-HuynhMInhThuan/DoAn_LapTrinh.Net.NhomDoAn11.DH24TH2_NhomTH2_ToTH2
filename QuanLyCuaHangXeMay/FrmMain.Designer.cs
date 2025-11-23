namespace QuanLyCuaHangXeMay
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuTrangChu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXeMay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrangChu,
            this.mnuXeMay,
            this.mnuKhachHang,
            this.mnuHoaDon,
            this.mnuTonKho,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTrangChu
            // 
            this.mnuTrangChu.Name = "mnuTrangChu";
            this.mnuTrangChu.Size = new System.Drawing.Size(93, 24);
            this.mnuTrangChu.Text = "Trang Chủ ";
            // 
            // mnuXeMay
            // 
            this.mnuXeMay.Name = "mnuXeMay";
            this.mnuXeMay.Size = new System.Drawing.Size(72, 24);
            this.mnuXeMay.Text = "Xe Máy";
            this.mnuXeMay.Click += new System.EventHandler(this.mnuXeMay_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(107, 24);
            this.mnuKhachHang.Text = "Khách Hàng ";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Size = new System.Drawing.Size(83, 24);
            this.mnuHoaDon.Text = "Hóa Đơn";
            this.mnuHoaDon.Click += new System.EventHandler(this.mnuHoaDon_Click);
            // 
            // mnuTonKho
            // 
            this.mnuTonKho.Name = "mnuTonKho";
            this.mnuTonKho.Size = new System.Drawing.Size(78, 24);
            this.mnuTonKho.Text = "Tồn Kho";
            this.mnuTonKho.Click += new System.EventHandler(this.mnuTonKho_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(61, 24);
            this.mnuThoat.Text = "&Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.ShowInTaskbar = false;
            this.Text = "Quản Lý Cửa Hàng Xe Máy ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrangChu;
        private System.Windows.Forms.ToolStripMenuItem mnuXeMay;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuTonKho;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
    }
}