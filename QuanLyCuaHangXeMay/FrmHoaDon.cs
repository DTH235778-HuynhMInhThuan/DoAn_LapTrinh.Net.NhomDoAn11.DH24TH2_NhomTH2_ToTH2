using QuanLyCuaHangXeMay.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangXeMay
{
    public partial class FrmHoaDon : Form
    {
        DataTable tblHD;
        private bool themMoi = false;
        private string maHDDangChon = "";
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            LoadComboBoxKhachHang();
            LoadComboBoxXeMay();
            LoadDataGridView();
            ResetValues();
            SetControlStatus(false);
        }

        private void LoadDataGridView()
        {
            string sql = "SELECT a.MaHD, a.NgayLap, b.HoTen, c.TenXe, a.SoLuong, a.TongTien, a.MaKH, a.MaXe " +
                         "FROM HoaDon a " +
                         "JOIN KhachHang b ON a.MaKH = b.MaKH " +
                         "JOIN XeMay c ON a.MaXe = c.MaXe " +
                         "ORDER BY a.MaHD DESC";

            tblHD = Functions.GetDataToTable(sql);
            dgvHoaDon.DataSource = tblHD;

            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvHoaDon.Columns.Count >= 6)
            {
                dgvHoaDon.Columns[0].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns[1].HeaderText = "Ngày Lập";
                dgvHoaDon.Columns[2].HeaderText = "Khách Hàng";
                dgvHoaDon.Columns[3].HeaderText = "Tên Xe";
                dgvHoaDon.Columns[4].HeaderText = "Số Lượng";
                dgvHoaDon.Columns[5].HeaderText = "Tổng Tiền";

                dgvHoaDon.Columns[6].Visible = false;
                dgvHoaDon.Columns[7].Visible = false;

                dgvHoaDon.Columns[5].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHoaDon.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void LoadComboBoxKhachHang()
        {
            string sql = "SELECT MaKH, HoTen FROM KhachHang";
            DataTable dt = Functions.GetDataToTable(sql);
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.SelectedIndex = -1;
        }

        private void LoadComboBoxXeMay()
        {
            string sql = "SELECT MaXe, TenXe FROM XeMay";
            DataTable dt = Functions.GetDataToTable(sql);
            cboXeMay.DataSource = dt;
            cboXeMay.DisplayMember = "TenXe";
            cboXeMay.ValueMember = "MaXe";
            cboXeMay.SelectedIndex = -1;
        }
        private void CapNhatTongTien()
        {
            if (cboXeMay.SelectedValue == null || string.IsNullOrEmpty(txtSoLuong.Text))
            {
                txtTongTien.Text = "0";
                return;
            }
            try
            {
                int soLuong = 0;
                if (!int.TryParse(txtSoLuong.Text, out soLuong)) return;

                string maXe = cboXeMay.SelectedValue.ToString();
                string sqlGia = "SELECT GiaXe FROM XeMay WHERE MaXe = " + maXe;
                string strGia = Functions.GetFieldValues(sqlGia);

                if (!string.IsNullOrEmpty(strGia))
                {
                    double giaXe = Convert.ToDouble(strGia);
                    double tongTien = giaXe * soLuong;
                    txtTongTien.Text = tongTien.ToString("N0");
                }
            }
            catch { }

        }

        private void cboXeMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvHoaDon.CurrentRow == null) return;
            if (btnThem.Enabled == false && btnSua.Enabled == false && btnLuuLai.Enabled == true) return;

            try
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                maHDDangChon = row.Cells[0].Value.ToString();

                if (row.Cells[1].Value != DBNull.Value)
                {
                    DateTime dt = Convert.ToDateTime(row.Cells[1].Value);
                    txtNgayLap.Text = dt.ToString("dd/MM/yyyy");
                }
                else txtNgayLap.Text = "";

                cboKhachHang.SelectedValue = row.Cells[6].Value;
                cboXeMay.SelectedValue = row.Cells[7].Value;
                txtSoLuong.Text = row.Cells[4].Value.ToString();
                txtTongTien.Text = row.Cells[5].Value.ToString();

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi chọn dòng: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themMoi = true;
            ResetValues();
            SetControlStatus(true);
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboKhachHang.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maHDDangChon)) { MessageBox.Show("Chưa chọn hóa đơn!"); return; }
            themMoi = false;
            SetControlStatus(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maHDDangChon)) { MessageBox.Show("Chưa chọn hóa đơn!"); return; }

            if (MessageBox.Show("Bạn có chắc chắn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Lưu ý: Khi xóa hóa đơn, đúng ra nên cộng lại số lượng vào kho (bài toán nâng cao)
                string sql = $"DELETE FROM HoaDon WHERE MaHD = {maHDDangChon}";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu cơ bản
            if (cboKhachHang.SelectedIndex == -1) { MessageBox.Show("Chưa chọn Khách hàng"); return; }
            if (cboXeMay.SelectedIndex == -1) { MessageBox.Show("Chưa chọn Xe máy"); return; }
            if (string.IsNullOrEmpty(txtSoLuong.Text)) { MessageBox.Show("Chưa nhập số lượng"); return; }
            if (string.IsNullOrWhiteSpace(txtNgayLap.Text)) { MessageBox.Show("Chưa nhập ngày lập"); return; }

            DateTime dtNgayLap;
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "d-M-yyyy" };
            if (!DateTime.TryParseExact(txtNgayLap.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dtNgayLap))
            {
                MessageBox.Show("Ngày tháng không hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgayLap.Focus();
                return;
            }
            string ngayLapSQL = dtNgayLap.ToString("yyyy-MM-dd");
            string tongTien = txtTongTien.Text.Replace(".", "").Replace(",", "");
            if (string.IsNullOrEmpty(tongTien)) tongTien = "0";


            // --- 2. LOGIC KIỂM TRA TỒN KHO BẮT ĐẦU TỪ ĐÂY ---

            // Lấy số lượng khách muốn mua
            int soLuongMua = 0;
            if (!int.TryParse(txtSoLuong.Text, out soLuongMua) || soLuongMua <= 0)
            {
                MessageBox.Show("Số lượng mua phải lớn hơn 0.");
                return;
            }

            // Lấy mã xe đang chọn
            string maXe = cboXeMay.SelectedValue.ToString();

            // Truy vấn CSDL để lấy Tồn kho hiện tại của xe đó
            string sqlKiemTraTon = "SELECT SoLuong FROM XeMay WHERE MaXe = " + maXe;
            string sTon = Functions.GetFieldValues(sqlKiemTraTon); // Hàm này trả về chuỗi
            int tonKhoHienTai = 0;
            if (!string.IsNullOrEmpty(sTon)) tonKhoHienTai = Convert.ToInt32(sTon);

            // Kiểm tra điều kiện
            if (themMoi)
            {
                // Trường hợp Thêm Mới: Nếu mua nhiều hơn tồn -> Báo lỗi
                if (soLuongMua > tonKhoHienTai)
                {
                    MessageBox.Show($"Trong kho chỉ còn {tonKhoHienTai} chiếc. Không đủ để bán {soLuongMua} chiếc!\nVui lòng kiểm tra lại.",
                                    "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return; // Dừng lại, không lưu
                }
            }
            else // Trường hợp Sửa
            {
                // Nếu đang sửa, ta phải tính toán phức tạp hơn chút:
                // Tồn kho khả dụng = Tồn kho hiện tại + Số lượng của hóa đơn cũ (trả lại kho)
                string sqlLaySoLuongCu = "SELECT SoLuong FROM HoaDon WHERE MaHD = " + maHDDangChon;
                int soLuongCu = Convert.ToInt32(Functions.GetFieldValues(sqlLaySoLuongCu));

                if (soLuongMua > (tonKhoHienTai + soLuongCu))
                {
                    MessageBox.Show($"Kho không đủ hàng (Kể cả khi trả lại đơn cũ)! Tổng khả dụng: {tonKhoHienTai + soLuongCu}",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return;
                }
            }
            // --- KẾT THÚC KIỂM TRA TỒN KHO ---


            // 3. Thực hiện Lưu
            string sql;
            if (themMoi)
            {
                sql = "INSERT INTO HoaDon (NgayLap, MaKH, MaXe, SoLuong, TongTien) " +
                      $"VALUES ('{ngayLapSQL}', {cboKhachHang.SelectedValue}, " +
                      $"{cboXeMay.SelectedValue}, {txtSoLuong.Text}, {tongTien})";

                // MỞ RỘNG: Nếu bạn muốn tự động trừ kho khi bán, hãy thêm lệnh này:
                // Functions.RunSQL($"UPDATE XeMay SET SoLuong = SoLuong - {soLuongMua} WHERE MaXe = {maXe}");
            }
            else // Sửa
            {
                if (string.IsNullOrEmpty(maHDDangChon)) return;

                sql = "UPDATE HoaDon SET " +
                      $"NgayLap = '{ngayLapSQL}', " +
                      $"MaKH = {cboKhachHang.SelectedValue}, " +
                      $"MaXe = {cboXeMay.SelectedValue}, " +
                      $"SoLuong = {txtSoLuong.Text}, " +
                      $"TongTien = {tongTien} " +
                      $"WHERE MaHD = {maHDDangChon}";
            }

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            SetControlStatus(false);
            themMoi = false;
            MessageBox.Show("Đã lưu hóa đơn thành công!");
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (btnLuuLai.Enabled)
            {
                ResetValues();
                SetControlStatus(false);
                themMoi = false;
            }
            else this.Close();
        }
        private void ResetValues()
        {
            maHDDangChon = "";
            cboKhachHang.SelectedIndex = -1;
            cboXeMay.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtTongTien.Text = "0";
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void SetControlStatus(bool enabled)
        {
            cboKhachHang.Enabled = enabled;
            cboXeMay.Enabled = enabled;
            txtSoLuong.Enabled = enabled;
            txtNgayLap.Enabled = enabled;
            txtTongTien.Enabled = false;
            btnThem.Enabled = !enabled;
            btnSua.Enabled = !enabled;
            btnXoa.Enabled = !enabled;
            btnLuuLai.Enabled = enabled;
            btnQuayLai.Enabled = true;
        }
    }
    
}
