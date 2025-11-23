namespace QuanLyCuaHangXeMay
{
    partial class FrmXeMay
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
            this.dgvXeMay = new System.Windows.Forms.DataGridView();
            this.txtMauXe = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHangXe = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGiaXe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTenXe = new System.Windows.Forms.ComboBox();
            this.btnLuuLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXeMay)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvXeMay
            // 
            this.dgvXeMay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXeMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXeMay.Location = new System.Drawing.Point(0, 100);
            this.dgvXeMay.Name = "dgvXeMay";
            this.dgvXeMay.RowHeadersWidth = 51;
            this.dgvXeMay.RowTemplate.Height = 24;
            this.dgvXeMay.Size = new System.Drawing.Size(1050, 309);
            this.dgvXeMay.TabIndex = 6;
            this.dgvXeMay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXeMay_CellContentClick);
            this.dgvXeMay.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXeMay_CellContentClick_1);
            // 
            // txtMauXe
            // 
            this.txtMauXe.Location = new System.Drawing.Point(440, 67);
            this.txtMauXe.Name = "txtMauXe";
            this.txtMauXe.Size = new System.Drawing.Size(158, 22);
            this.txtMauXe.TabIndex = 13;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(830, 32);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuong.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(757, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Số Lượng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Màu Xe:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên Xe:";
            // 
            // cboHangXe
            // 
            this.cboHangXe.FormattingEnabled = true;
            this.cboHangXe.Location = new System.Drawing.Point(109, 38);
            this.cboHangXe.Name = "cboHangXe";
            this.cboHangXe.Size = new System.Drawing.Size(191, 24);
            this.cboHangXe.TabIndex = 5;
            this.cboHangXe.SelectedIndexChanged += new System.EventHandler(this.cboHangXe_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLuuLai);
            this.panel1.Controls.Add(this.btnQuayLai);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1050, 100);
            this.panel1.TabIndex = 5;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(823, 21);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(108, 53);
            this.btnQuayLai.TabIndex = 3;
            this.btnQuayLai.Text = "Quay Lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Blue;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(440, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 53);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(221, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 53);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(32, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 53);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hãng Xe ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Xe Máy ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtGiaXe);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cboTenXe);
            this.panel2.Controls.Add(this.txtMauXe);
            this.panel2.Controls.Add(this.txtSoLuong);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboHangXe);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 100);
            this.panel2.TabIndex = 7;
            // 
            // txtGiaXe
            // 
            this.txtGiaXe.Location = new System.Drawing.Point(830, 64);
            this.txtGiaXe.Name = "txtGiaXe";
            this.txtGiaXe.Size = new System.Drawing.Size(100, 22);
            this.txtGiaXe.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(765, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Giá Xe:";
            // 
            // cboTenXe
            // 
            this.cboTenXe.FormattingEnabled = true;
            this.cboTenXe.Location = new System.Drawing.Point(435, 32);
            this.cboTenXe.Name = "cboTenXe";
            this.cboTenXe.Size = new System.Drawing.Size(191, 24);
            this.cboTenXe.TabIndex = 15;
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.BackColor = System.Drawing.Color.Magenta;
            this.btnLuuLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuLai.ForeColor = System.Drawing.Color.White;
            this.btnLuuLai.Location = new System.Drawing.Point(627, 21);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(100, 53);
            this.btnLuuLai.TabIndex = 4;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = false;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // FrmXeMay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 509);
            this.Controls.Add(this.dgvXeMay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmXeMay";
            this.Text = "Quản Lý Xe Máy";
            this.Load += new System.EventHandler(this.FrmXeMay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXeMay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvXeMay;
        private System.Windows.Forms.TextBox txtMauXe;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHangXe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboTenXe;
        private System.Windows.Forms.TextBox txtGiaXe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLuuLai;
    }
}