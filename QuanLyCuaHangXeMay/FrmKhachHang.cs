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
    public partial class FrmKhachHang : Form
    {
        DataTable tblKH;
        private bool themMoi = false;
        private string maKHDangChon = "";
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            Functions.Connect(); // Kết nối CSDL
            LoadDataGridView();  // Tải dữ liệu lên lưới
            ResetValues();       // Xóa trắng các ô nhập
            SetControlStatus(false);
        }
        private void LoadDataGridView()
        {
            string sql = "SELECT MaKH, HoTen, SDT, DiaChi FROM KhachHang ORDER BY MaKH DESC";
            tblKH = Functions.GetDataToTable(sql);
            dgvKhachHang.DataSource = tblKH;

            // Cấu hình giao diện lưới
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Cài đặt chế độ chọn dòng (Sửa lỗi khó click)
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;

            // Đặt tên cột hiển thị (tránh lỗi nếu bảng chưa có dữ liệu)
            if (dgvKhachHang.Columns.Count >= 4)
            {
                dgvKhachHang.Columns[0].HeaderText = "Mã KH";
                dgvKhachHang.Columns[1].HeaderText = "Họ Tên";
                dgvKhachHang.Columns[2].HeaderText = "SĐT";
                dgvKhachHang.Columns[3].HeaderText = "Địa Chỉ";

                // Chỉnh độ rộng cột nếu cần
                dgvKhachHang.Columns[0].Width = 80;
                dgvKhachHang.Columns[1].Width = 150;
                dgvKhachHang.Columns[2].Width = 100;
                dgvKhachHang.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void ResetValues()
        {
            maKHDangChon = "";
            txtHoTen.Text = "";
            txtSdt.Text = "";
            txtDiaChi.Text = "";
        }
        private void SetControlStatus(bool enabled)
        {
            // Bật/Tắt các ô nhập liệu
            txtHoTen.Enabled = enabled;
            txtSdt.Enabled = enabled;
            txtDiaChi.Enabled = enabled;

            // Bật/Tắt các nút chức năng
            btnThem.Enabled = !enabled;
            btnSua.Enabled = !enabled;
            btnXoa.Enabled = !enabled;

            // Nút Lưu và Quay Lại sáng khi đang nhập liệu
            btnLuuLai.Enabled = enabled;
            btnQuayLai.Enabled = true;


        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvKhachHang.CurrentRow == null) return;

            // Nếu đang nhập liệu (Thêm/Sửa) thì chặn click
            if (btnThem.Enabled == false && btnSua.Enabled == false && btnLuuLai.Enabled == true) return;

            try
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                // Lấy Mã KH (dùng tên cột cho chính xác)
                // Nếu code báo lỗi dòng này, hãy kiểm tra xem trong SQL tên cột có phải là MaKH không
                maKHDangChon = row.Cells["MaKH"].Value.ToString();

                // Đổ dữ liệu lên các ô textbox
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSdt.Text = row.Cells["SDT"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();

                // Bật nút Sửa và Xóa
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn dòng: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themMoi = true;
            ResetValues();
            SetControlStatus(true); // Bật nhập liệu
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maKHDangChon))
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng mã " + maKHDangChon + " không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM KhachHang WHERE MaKH = {maKHDangChon}";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maKHDangChon))
            {
                MessageBox.Show("Bạn chưa chọn khách hàng nào để sửa!");
                return;
            }
            themMoi = false;
            SetControlStatus(true); // Bật nhập liệu
            txtHoTen.Focus();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                MessageBox.Show("Bạn phải nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }

            string sql;

            // 2. Xử lý Thêm Mới
            if (themMoi)
            {
                // Câu lệnh INSERT (Giả định MaKH là IDENTITY tự tăng nên không cần insert)
                sql = "INSERT INTO KhachHang (HoTen, SDT, DiaChi) " +
                      $"VALUES (N'{txtHoTen.Text}', '{txtSdt.Text}', N'{txtDiaChi.Text}')";
            }
            // 3. Xử lý Sửa
            else
            {
                // Câu lệnh UPDATE
                sql = "UPDATE KhachHang SET " +
                      $"HoTen = N'{txtHoTen.Text}', " +
                      $"SDT = '{txtSdt.Text}', " +
                      $"DiaChi = N'{txtDiaChi.Text}' " +
                      $"WHERE MaKH = {maKHDangChon}";
            }

            // 4. Thực thi
            Functions.RunSQL(sql); // Gọi hàm từ Class Functions

            LoadDataGridView();    // Tải lại lưới
            ResetValues();         // Xóa trắng
            SetControlStatus(false); // Khóa nhập liệu
            themMoi = false;
            MessageBox.Show("Đã lưu thành công!");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (btnLuuLai.Enabled == true)
            {
                ResetValues();
                SetControlStatus(false);
                themMoi = false;
            }
            // Nếu đang xem bình thường thì nút này là THOÁT
            else
            {
                this.Close();
            }
        }
    }
}
