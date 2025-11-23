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
using QuanLyCuaHangXeMay.Class; 

namespace QuanLyCuaHangXeMay
{
    public partial class FrmXeMay : Form
    {
        DataTable tblXM;
        private bool themMoi = false;
        private string maXeDangChon = "";

        public FrmXeMay()
        {
            InitializeComponent();
        }

        private void FrmXeMay_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadCombos();
            LoadDataGridView();
            ResetValues();
            SetControlStatus(false);

        }

        
        private void LoadDataGridView()
        {
            // SỬA: TblXeMay -> XeMay
            string sql = "SELECT MaXe, TenXe, HangXe, MauXe, GiaXe, SoLuong FROM XeMay ORDER BY MaXe DESC";
            tblXM = Functions.GetDataToTable(sql);
            dgvXeMay.DataSource = tblXM;
            dgvXeMay.AllowUserToAddRows = false;
            dgvXeMay.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvXeMay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvXeMay.MultiSelect = false;

            if (dgvXeMay.Columns.Count > 5) // Kiểm tra để tránh lỗi index
            {
                dgvXeMay.Columns[0].HeaderText = "Mã Xe";
                dgvXeMay.Columns[1].HeaderText = "Tên Xe";
                dgvXeMay.Columns[2].HeaderText = "Hãng Xe";
                dgvXeMay.Columns[3].HeaderText = "Màu Xe";
                dgvXeMay.Columns[4].HeaderText = "Giá Xe";
                dgvXeMay.Columns[5].HeaderText = "Số Lượng";
            }
        }

        private void LoadCombos()
        {
            cboHangXe.DataSource = null;
            cboHangXe.Items.Clear();

            // Thêm thủ công 3 hãng xe vào ComboBox
            cboHangXe.Items.Add("Honda");
            cboHangXe.Items.Add("Yamaha");
            cboHangXe.Items.Add("Suzuki");

            // Mặc định chưa chọn gì
            cboHangXe.SelectedIndex = -1;

            // Xóa trắng ComboBox Tên Xe
            cboTenXe.DataSource = null;
            cboTenXe.Items.Clear();
        }

        private void LoadTenXeCombo(string hangXe)
        {
            // SỬA: TblXeMay -> XeMay
            string sqlTen = "SELECT DISTINCT TenXe FROM XeMay";
            if (!string.IsNullOrEmpty(hangXe))
            {
                sqlTen += $" WHERE HangXe = N'{hangXe.Replace("'", "''")}'";
            }

            DataTable tblTen = Functions.GetDataToTable(sqlTen);
            cboTenXe.DataSource = tblTen;
            cboTenXe.DisplayMember = "TenXe";
            cboTenXe.ValueMember = "TenXe";
            cboTenXe.SelectedIndex = -1;
        }

        // --- 2. CÁC HÀM HỖ TRỢ ---
        private void SetControlStatus(bool enabled)
        {
            cboHangXe.Enabled = enabled;
            cboTenXe.Enabled = enabled;
            txtMauXe.Enabled = enabled;
            txtGiaXe.Enabled = enabled;
            txtSoLuong.Enabled = enabled;

            btnThem.Enabled = !enabled;
            btnXoa.Enabled = !enabled;
            btnSua.Enabled = !enabled;

            // Nút Lưu chỉ sáng khi đang nhập liệu
            btnLuuLai.Enabled = enabled;

            // Nút Quay lại luôn sáng để có thể hủy thao tác
            btnQuayLai.Enabled = true;
        }

        private void ResetValues()
        {
            maXeDangChon = "";
            cboHangXe.Text = "";
            cboTenXe.Text = "";
            txtMauXe.Text = "";
            txtGiaXe.Text = "";
            txtSoLuong.Text = "";
        }

        

        private void cboHangXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mỗi khi chọn lại hãng, ta xóa danh sách tên xe cũ đi
            cboTenXe.DataSource = null;
            cboTenXe.Items.Clear();
            cboTenXe.Text = "";

            // Lấy hãng xe đang được chọn
            string hangChon = cboHangXe.Text.Trim();

            // Kiểm tra và nạp danh sách xe tương ứng
            if (hangChon == "Honda")
            {
                string[] xeHonda = { "Vision", "Air Blade 125/160", "Lead 125", "SH Mode", "SH 125/150i", "Winner X", "Wave Alpha", "Future 125" };
                cboTenXe.Items.AddRange(xeHonda);
            }
            else if (hangChon == "Yamaha")
            {
                string[] xeYamaha = { "Exciter 155 VVA", "Grande", "Janus", "NVX 155", "Sirius", "Jupiter Finn", "Latte" };
                cboTenXe.Items.AddRange(xeYamaha);
            }
            else if (hangChon == "Suzuki")
            {
                string[] xeSuzuki = { "Raider R150", "Satria F150", "Burgman Street", "Impulse 125", "GSX-R150" };
                cboTenXe.Items.AddRange(xeSuzuki);
            }
        }

        // Sự kiện click vào lưới dữ liệu
        private void dgvXeMay_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false && btnSua.Enabled == false && btnLuuLai.Enabled == true) return;

            if (dgvXeMay.CurrentRow == null || dgvXeMay.CurrentRow.Index == -1)
            {
                ResetValues();
                return;
            }

            try
            {
                // Cách an toàn nhất: Lấy theo tên cột trong Database
                // Vì DataSource = tblXM nên tên cột trong Grid sẽ trùng tên cột trong SQL
                if (dgvXeMay.CurrentRow.Cells["MaXe"].Value != null)
                {
                    maXeDangChon = dgvXeMay.CurrentRow.Cells["MaXe"].Value.ToString();

                    // Lấy các giá trị khác theo tên cột (An toàn hơn dùng số 0,1,2)
                    cboTenXe.Text = dgvXeMay.CurrentRow.Cells["TenXe"].Value.ToString();
                    cboHangXe.Text = dgvXeMay.CurrentRow.Cells["HangXe"].Value.ToString();
                    txtMauXe.Text = dgvXeMay.CurrentRow.Cells["MauXe"].Value.ToString();
                    txtGiaXe.Text = dgvXeMay.CurrentRow.Cells["GiaXe"].Value.ToString();
                    txtSoLuong.Text = dgvXeMay.CurrentRow.Cells["SoLuong"].Value.ToString();
                }
                else
                {
                    // Dự phòng nếu cách trên lỗi thì dùng chỉ số
                    maXeDangChon = dgvXeMay.CurrentRow.Cells[0].Value.ToString();
                }

                // Bật nút Sửa và Xóa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }
       
        private void dgvXeMay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvXeMay_Click(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themMoi = true;
            ResetValues();
            SetControlStatus(true); // Bật các ô nhập liệu, Sáng nút Lưu
            cboHangXe.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maXeDangChon))
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để sửa.", "Thông báo");
                return;
            }
            themMoi = false;
            SetControlStatus(true); // Bật các ô nhập liệu, Sáng nút Lưu
            cboHangXe.Focus();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string sql;

            if (string.IsNullOrWhiteSpace(cboHangXe.Text) || string.IsNullOrWhiteSpace(cboTenXe.Text) ||
                string.IsNullOrWhiteSpace(txtMauXe.Text) || string.IsNullOrWhiteSpace(txtGiaXe.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtGiaXe.Text, out _) || !int.TryParse(txtSoLuong.Text, out _))
            {
                MessageBox.Show("Giá Xe và Số Lượng phải là số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (themMoi)
            {
               
                sql = "INSERT INTO XeMay (TenXe, HangXe, MauXe, GiaXe, SoLuong) " +
                      $"VALUES (N'{cboTenXe.Text}', N'{cboHangXe.Text}', N'{txtMauXe.Text}', " +
                      $"{txtGiaXe.Text.Replace(",", ".")}, {txtSoLuong.Text})";
            }
           
            else
            {
                if (string.IsNullOrEmpty(maXeDangChon)) return;

                
                sql = "UPDATE XeMay SET " +
                      $"TenXe = N'{cboTenXe.Text}', " +
                      $"HangXe = N'{cboHangXe.Text}', " +
                      $"MauXe = N'{txtMauXe.Text}', " +
                      $"GiaXe = {txtGiaXe.Text.Replace(",", ".")}, " +
                      $"SoLuong = {txtSoLuong.Text} " +
                      $"WHERE MaXe = {maXeDangChon}";
            }

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            SetControlStatus(false);
            themMoi = false;
            MessageBox.Show("Đã lưu dữ liệu thành công!");
        }

      
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maXeDangChon))
            {
                MessageBox.Show("Bạn chưa chọn xe để xóa!");
                return;
            }

            

            if (MessageBox.Show("Bạn có chắc muốn xóa xe mã " + maXeDangChon + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM XeMay WHERE MaXe = {maXeDangChon}";
                Functions.RunSQL(sql);

                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvXeMay_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvXeMay.CurrentRow == null) return;

            
            if (btnThem.Enabled == false && btnSua.Enabled == false && btnLuuLai.Enabled == true) return;

            try
            {
                // Lấy dòng hiện tại đang click
                DataGridViewRow row = dgvXeMay.Rows[e.RowIndex];

                // 1. Lấy Mã Xe (Dùng tên cột "MaXe" cho chính xác)
                maXeDangChon = row.Cells["MaXe"].Value.ToString();

                // 2. Đổ dữ liệu lên các ô nhập
                cboTenXe.Text = row.Cells["TenXe"].Value.ToString();
                cboHangXe.Text = row.Cells["HangXe"].Value.ToString();
                txtMauXe.Text = row.Cells["MauXe"].Value.ToString();

                // Xử lý giá tiền (đôi khi bị lỗi null)
                if (row.Cells["GiaXe"].Value != DBNull.Value)
                    txtGiaXe.Text = row.Cells["GiaXe"].Value.ToString();
                else
                    txtGiaXe.Text = "0";

                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();

                // 3. Bật nút Sửa và Xóa lên
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dòng: " + ex.Message);
            }
        }
    }
}

        