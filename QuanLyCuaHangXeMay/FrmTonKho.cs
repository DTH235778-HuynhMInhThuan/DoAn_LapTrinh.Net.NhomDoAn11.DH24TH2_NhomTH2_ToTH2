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
    public partial class FrmTonKho : Form
    {
        DataTable tblTonKho;

        public FrmTonKho()
        {
            InitializeComponent();
        }

        private void FrmTonKho_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadComboBoxHang();
            LoadDataGridView();
        }

        private void LoadComboBoxHang()
        {
            string sql = "SELECT DISTINCT HangXe FROM XeMay";
            DataTable dt = Functions.GetDataToTable(sql);

            cboHangXe.DataSource = dt;
            cboHangXe.DisplayMember = "HangXe";
            cboHangXe.ValueMember = "HangXe";
            cboHangXe.SelectedIndex = -1;
            cboHangXe.Text = "--- Chọn hãng ---";
        }

        private void LoadDataGridView()
        {
            // --- CÂU LỆNH SQL ĐÃ ĐƯỢC SỬA ---
            // Logic: Lấy Số lượng gốc (x.SoLuong) TRỪ ĐI Tổng số lượng đã bán (SUM(h.SoLuong))
            string sql = "SELECT " +
                         "x.MaXe, " +
                         "x.TenXe, " +
                         "x.HangXe, " +
                         "x.GiaXe, " +
                         "ISNULL(SUM(h.SoLuong), 0) AS DaBan, " +
                         "(x.SoLuong - ISNULL(SUM(h.SoLuong), 0)) AS TonKho " + //  Phép trừ để ra tồn kho thực tế
                         "FROM XeMay x " +
                         "LEFT JOIN HoaDon h ON x.MaXe = h.MaXe ";

            // Xử lý lọc theo hãng
            if (cboHangXe.SelectedIndex != -1 && !string.IsNullOrEmpty(cboHangXe.Text) && cboHangXe.Text != "--- Chọn hãng ---")
            {
                sql += $"WHERE x.HangXe = N'{cboHangXe.Text}' ";
            }

            sql += "GROUP BY x.MaXe, x.TenXe, x.HangXe, x.GiaXe, x.SoLuong " +
                   "ORDER BY TonKho DESC"; // Sắp xếp theo Tồn kho thực tế

            tblTonKho = Functions.GetDataToTable(sql);
            dgvTonKho.DataSource = tblTonKho;

            FormatLuoi();

            // --- TÍNH TỔNG VÀ TÔ MÀU CẢNH BÁO ---
            // (Bạn nhớ thêm Label tên lblThongBao vào form để hiển thị tổng nhé)
            int tongTonKho = 0;

            foreach (DataGridViewRow row in dgvTonKho.Rows)
            {
                // Cột Tồn Kho thực tế nằm ở vị trí Index 5
                if (row.Cells[5].Value != null)
                {
                    int tonKho = 0;
                    if (int.TryParse(row.Cells[5].Value.ToString(), out tonKho))
                    {
                        tongTonKho += tonKho;

                        // Tô màu cảnh báo
                        if (tonKho <= 0) // Hết hàng hoặc Âm (nếu bán quá tay)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                        else if (tonKho <= 2) // Sắp hết
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }

            // Hiển thị ra Label (Nếu bạn đã thêm Label vào form)
            if (this.Controls.Find("lblThongBao", true).Length > 0)
            {
                this.Controls["lblThongBao"].Text = "Tổng số lượng xe thực tế còn trong kho: " + tongTonKho.ToString("N0") + " chiếc";
            }
        }

        private void FormatLuoi()
        {
            dgvTonKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTonKho.MultiSelect = false;
            dgvTonKho.AllowUserToAddRows = false;
            dgvTonKho.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvTonKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvTonKho.Columns.Count >= 6)
            {
                dgvTonKho.Columns[0].HeaderText = "Mã Xe";
                dgvTonKho.Columns[1].HeaderText = "Tên Xe";
                dgvTonKho.Columns[2].HeaderText = "Hãng Xe";
                dgvTonKho.Columns[3].HeaderText = "Giá Bán";
                dgvTonKho.Columns[4].HeaderText = "Đã Bán";
                dgvTonKho.Columns[5].HeaderText = "Tồn Thực Tế"; // Đổi tên cột cho rõ nghĩa

                dgvTonKho.Columns[3].DefaultCellStyle.Format = "N0";
                dgvTonKho.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvTonKho.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTonKho.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // Các sự kiện nút bấm giữ nguyên
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboHangXe_SelectedIndexChanged(object sender, EventArgs e) // Kiểm tra tên hàm bên Events
        {
            LoadDataGridView();
        }

        // Nếu tên hàm bên Events là cboLocTheoHang_SelectedIndexChanged thì dùng cái này:
        private void cboLocTheoHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboHangXe.SelectedIndex = -1;
            cboHangXe.Text = "--- Chọn hãng ---";
            LoadDataGridView();
        }

        // Không dùng sự kiện này nữa vì đã xử lý màu trong LoadData
        private void dgvTonKho_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}