using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using doan.Class;  

namespace doan.Forms
{
    public partial class frmHoadonnhap : Form
    {
        DataTable tblHDN;
        public frmHoadonnhap()
        {
            InitializeComponent();
        }
        private void frmHoadonnhap_Load(object sender, EventArgs e)
        {
            btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnXoaHD.Enabled = false;
            btnInhoadon.Enabled = false;
            //txtMaHDNhap.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;


            txtDongianhap.Text = "0";


            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Functions.FillCombo("SELECT Mancc, Tenncc FROM tblNhacungcap", cboMaNCC, "Mancc", "Tenncc");
            cboMaNCC.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNV, TenNV FROM tblNhanvien", cboManhanvien, "MaNV", "TenNV");
            cboManhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mamay, Tenmay FROM tblKhomay", cboMamay, "Mamay", "Tenmay");
            cboMamay.SelectedIndex = -1;
            Functions.FillCombo("SELECT SoHDN, SoHDN FROM tblChitietHDN", cboMaHDNhap, "SoHDN", "SoHDN");
            cboMaHDNhap.SelectedIndex = -1;

            if (txtMaHDNhap.Text != "")
            {
                Load_ThongtinHD();
                btnXoaHD.Enabled = true;
                btnInhoadon.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "SELECT a.Mamay, b.Tenmay, a.Slnhap, b.Gianhap, a.Khuyenmai, a.Thanhtien FROM tblChitietHDN AS a, tblKhomay AS b WHERE a.SoHDN = N'" + txtMaHDNhap.Text + "' AND a.Mamay=b.Mamay";
            tblHDN = Functions.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblHDN;
            DataGridViewChitiet.Columns[0].HeaderText = "Mã sách";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên hàng";
            DataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            DataGridViewChitiet.Columns[3].HeaderText = "Đơn giá";
            DataGridViewChitiet.Columns[4].HeaderText = "Giảm giá %";
            DataGridViewChitiet.Columns[5].HeaderText = "Thành tiền";
            DataGridViewChitiet.Columns[0].Width = 80;
            DataGridViewChitiet.Columns[1].Width = 100;
            DataGridViewChitiet.Columns[2].Width = 80;
            DataGridViewChitiet.Columns[3].Width = 90;
            DataGridViewChitiet.Columns[4].Width = 90;
            DataGridViewChitiet.Columns[5].Width = 90;
            DataGridViewChitiet.AllowUserToAddRows = false;
            DataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT Ngaynhap FROM tblHoadonnhap WHERE SoHDN = N'" + txtMaHDNhap.Text + "'";
            txtNgaynhap.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaNV FROM tblHoadonnhap WHERE SoHDN = N'" + txtMaHDNhap.Text + "'";
            cboManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT Mancc FROM tblHoadonnhap WHERE SoHDN = N'" + txtMaHDNhap.Text + "'";
            cboMaNCC.Text = Functions.GetFieldValues(str);
            str = "SELECT Tongtien FROM tblHoadonnhap WHERE SoHDN = N'" + txtMaHDNhap.Text + "'";
            txtTongtien.Text = Functions.GetFieldValues(str);
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            btnXoaHD.Enabled = false;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = false;
            btnThemmoi.Enabled = false;
            ResetValues();
            //  txtMaHDNhap.Text = Functions.CreateKey ("HDN");
            Load_DataGridViewChitiet();
        }

        private void ResetValues()
        {
            txtMaHDNhap.Text = "";
            txtNgaynhap.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            cboMaNCC.Text = "";
            txtTongtien.Text = "0";

            txtDongianhap.Text = "0";

            lblBangchu.Text = "Bằng chữ: ";
            cboMamay.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLmoi, tong, Tongmoi;

            sql = "SELECT SoHDN FROM tblHoadonnhap WHERE SoHDN=N'" + txtMaHDNhap.Text + "'";

            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgaynhap.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboMaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaNCC.Focus();
                    return;
                }

                sql = "INSERT INTO tblHoadonnhap (SoHDN, Ngaynhap, MaNV, Mancc, Tongtien) VALUES (N'" + txtMaHDNhap.Text.Trim() + "','" + Convert.ToDateTime(txtNgaynhap.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" + cboMaNCC.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng

            if (cboMamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamay.Focus();
                return;
            }

            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamgia.Focus();
                return;
            }
            // sql = "SELECT SoHDN FROM tblChitietHDN WHERE SoHDN=N'" + cboMasach.SelectedValue + "' AND SoHDN = N'" + txtMaHDNhap.Text.Trim() + "'";

            /*            if (Functions.CheckKey(sql))
                        {
                            MessageBox.Show("Mã sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ResetValuesHang(); 
                            cboMasach.Focus();
                            return;
                        }
             */
            sql = "INSERT INTO tblChitietHDN(SoHDN,Mamay,Slnhap,Dongianhap,Khuyenmai, Thanhtien) VALUES(N'" + txtMaHDNhap.Text.Trim() + "',N'" + cboMamay.SelectedValue + "'," + txtSoluong.Text + "," + txtDongianhap.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            Functions.RunSql(sql);
            Load_DataGridViewChitiet();

            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblKhomay WHERE Mamay = N'" + cboMamay.SelectedValue + "'"));

            // Cập nhật lại số lượng của sách vào bảng tblKhosach
            SLmoi = sl + Convert.ToDouble(txtSoluong.Text);

            double dgn;
            dgn = Convert.ToDouble(Functions.GetFieldValues("SELECT Gianhap FROM tblKhomay WHERE Mamay =N'" + cboMamay.SelectedValue + "'"));

            double dgnmoi = (Convert.ToDouble(txtDongianhap.Text) * Convert.ToDouble(txtSoluong.Text) + dgn * sl) / SLmoi;


            sql = "UPDATE tblKhomay SET Soluong =" + SLmoi + ",Gianhap=" + dgnmoi + ",Giaban=" + 1.1 * dgnmoi + " WHERE Mamay= N'" + cboMamay.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn nhập
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHoadonnhap WHERE SoHDN = N'" + txtMaHDNhap.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblHoadonnhap SET Tongtien =" + Tongmoi + " WHERE SoHDN = N'" + txtMaHDNhap.Text + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            ResetValuesHang();
            btnXoaHD.Enabled = true;
            btnThemmoi.Enabled = true;
            btnInhoadon.Enabled = true;
        }

        private void ResetValuesHang()
        {
            cboMamay.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void DataGridViewChitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mamay;
            Double Thanhtien;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mamay = DataGridViewChitiet.CurrentRow.Cells["Mamay"].Value.ToString();
                Delmay(txtMaHDNhap.Text, mamay);
                // Cập nhật lại tổng tiền cho hóa đơn nhập
                Thanhtien = Convert.ToDouble(DataGridViewChitiet.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMaHDNhap.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void Delmay(string Mahoadon, string Mamay)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Slnhap FROM tblChitietHDN WHERE SoHDN = N'" + Mahoadon + "' AND Mamay=N'" + Mamay + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE tblChitietHDN WHERE SoHDN=N'" + Mahoadon + "' AND Mamay = N'" + Mamay + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM tblKhomay WHERE Mamay = N'" + Mamay + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblKhomay SET Soluong =" + SLcon + " WHERE Mamay= N'" + Mamay + "'";
            Functions.RunSql(sql);
        }


        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT Tongtien FROM tblHoadonnhap WHERE SoHDN = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblHoadonnhap SET Tongtien =" + Tongmoi + " WHERE SoHDN = N'" + Mahoadon + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mamay = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT SoHDN FROM tblChitietHDN WHERE SoHDN = N'" + txtMaHDNhap.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mamay[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    Delmay(txtMaHDNhap.Text, Mamay[i]);
                //Xóa hóa đơn
                sql = "DELETE tblHoadonnhap WHERE SoHDN=N'" + txtMaHDNhap.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnXoaHD.Enabled = false;
                btnInhoadon.Enabled = false;
            }
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDNhap.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDNhap.Focus();
                return;
            }
            txtMaHDNhap.Text = cboMaHDNhap.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnXoaHD.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cboMaHDNhap.SelectedIndex = -1;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtGiamgia_TextChanged_1(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtDongianhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtSoluong_TextChanged_1(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamgia.Text);
            if (txtDongianhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongianhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void cboMamay_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMamay.Text == "")
            {
                txtTenhang.Text = "";
                txtDongianhap.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT Tenmay FROM tblKhomay WHERE Mamay =N'" + cboMamay.SelectedValue + "'";
            txtTenhang.Text = Functions.GetFieldValues(str);
            str = "SELECT Gianhap FROM tblKhomay WHERE Mamay =N'" + cboMamay.SelectedValue + "'";
            txtDongianhap.Text = Functions.GetFieldValues(str);

            string s1, s2;
            s1 = "Select Tenmay from tblKhomay where Tenmay =N'" + cboMamay.Text.Trim() + "'";
            s2 = "Select Gianhap from tblKhomay where Tenmay =N'" + cboMamay.Text.Trim() + "'";


            if (cboMamay.Text.Trim() == Functions.GetFieldValues(s1))
            {
                txtTenhang.Text = Functions.GetFieldValues(s1);
                txtDongianhap.Text = Functions.GetFieldValues(s2);
            }
        }

        private void cboManhanvien_TextChanged_1(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenNV from tblNhanvien where MaNV =N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);

            string str1;
            //Khi thay đổi Tên nhân viên thì txtNhanvien.Text bị thay đổi
            //Nhập lại đúng Tên nhân viên thì txtNhanvien.Text lại hiện ra
            str1 = "Select TenNV from tblNhanvien where TenNV =N'" + cboManhanvien.Text.Trim() + "'";
            if (cboManhanvien.Text.Trim() == Functions.GetFieldValues(str1))
            {
                txtTennhanvien.Text = Functions.GetFieldValues(str1);
            }
        }

        private void cboMaNCC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNCC.Text == "")
            {
                txtTenNCC.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon Ma nha cung cap thi ten nha cung cap, dia chi, dien thoai se tu dong hien ra
            str = "Select Tenncc from tblNhacungcap where Mancc = N'" + cboMaNCC.SelectedValue + "'";
            txtTenNCC.Text = Functions.GetFieldValues(str);
            str = "Select Diachi from tblNhacungcap where Mancc = N'" + cboMaNCC.SelectedValue + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblNhacungcap where Mancc= N'" + cboMaNCC.SelectedValue + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);

            string s1, s2, s3;
            s1 = "Select Tenncc from tblNhacungcap where Tenncc =N'" + cboMaNCC.Text.Trim() + "'";
            s2 = "Select Diachi from tblNhacungcap where Tenncc =N'" + cboMaNCC.Text.Trim() + "'";
            s3 = "Select Dienthoai from tblNhacungcap where Tenncc =N'" + cboMaNCC.Text.Trim() + "'";


            if (cboMaNCC.Text.Trim() == Functions.GetFieldValues(s1))
            {
                txtTenNCC.Text = Functions.GetFieldValues(s1);
                txtDiachi.Text = Functions.GetFieldValues(s2);
                txtDienthoai.Text = Functions.GetFieldValues(s3);
            }
        }

        private void cboMaHDNhap_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT SoHDN FROM tblHDN", cboMaHDNhap, "SoHDN", "SoHDN");
            cboMaHDNhap.SelectedIndex = -1;
        }

        private void frmHoadonnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng bán sách";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa- Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (097)3488322";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn nhập
            sql = "SELECT a.SoHDN, a.Ngaynhap, a.Tongtien, b.Tenncc, b.Diachi, b.Dienthoai, c.TenNV FROM tblHoadonnhap AS a, tblNhacungcap AS b, tblNhanvien AS c WHERE a.SoHDN = N'" + txtMaHDNhap.Text + "' AND a.Mancc = b.Mancc AND a.MaNV = c.MaNV";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tenmay, a.Slnhap, b.Dongianhap, a.Khuyenmai, a.Thanhtien FROM tblChitietHDN AS a , tblKhomay AS b WHERE a.SoHDN = N'" + txtMaHDNhap.Text + "' AND a.Mamay = b.Mamay";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sách";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";

            exRange = exSheet.Cells[1][hang + 11]; //Ô A1 
            exRange.Range["A1:F" + (tblThongtinHang.Rows.Count + 1) + ""].Borders.Color = Color.Black;
            exRange.Range["A2:F" + (tblThongtinHang.Rows.Count + 1) + ""].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            //Để lại Cells[1,1] ô đầu tiên như cũ
            exRange = exSheet.Cells[1, 1];

            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu
            (tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter; DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập sách";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void txtDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
