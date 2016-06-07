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
    public partial class frmHoadonban : Form
    {
        DataTable tblCTHDB;
        public frmHoadonban()
        {
            InitializeComponent();
        }
        private void frmHoadonban_Load(object sender, EventArgs e)
        {
            btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnXoaHD.Enabled = false;
            btnInhoadon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;

            txtDongiaban.Text = "0";
            

            txtGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Functions.FillCombo("SELECT Makhach, Tenkhach FROM tblKhachhang", cboMakhach, "Makhach", "Tenkhach");
            cboMakhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNV, TenNV FROM tblNhanvien", cboManhanvien, "MaNV", "TenNV");
            cboManhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mamay, Tenmay FROM tblKhomay", cboMahang, "Mamay", "Tenmay");
            cboMahang.SelectedIndex = -1;
            Functions.FillCombo("SELECT SoHDB, SoHDB FROM tblChitietHDB", cboMaHDBan, "SoHDB", "SoHDB");
            cboMaHDBan.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm

            if (txtMaHDBan.Text != "")
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
            sql = "SELECT a.Mamay, b.Tenmay, a.Slban, b.Giaban, a.Khuyenmai, a.Thanhtien FROM tblChitietHDB AS a, tblKhomay AS b";
            tblCTHDB = Functions.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblCTHDB;
            DataGridViewChitiet.Columns[0].HeaderText = "Mã máy";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên máy";
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
            str = "SELECT Ngayban FROM tblHoadonban WHERE SoHDB = N'" + txtMaHDBan.Text + "'";
            txtNgayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT MaNV FROM tblHoadonban WHERE SoHDB = N'" + txtMaHDBan.Text + "'";
            cboManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT Makhach FROM tblHoadonban WHERE SoHDB = N'" + txtMaHDBan.Text + "'";
            cboMakhach.Text = Functions.GetFieldValues(str);
            str = "SELECT Tongtien FROM tblHoadonban WHERE SoHDB = N'" + txtMaHDBan.Text + "'";
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
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            Load_DataGridViewChitiet();
        }

        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            txtNgayban.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            cboMakhach.Text = "";
            txtTongtien.Text = "0";

            lblBangchu.Text = "Bằng chữ: ";

            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT SoHDB FROM tblHoadonban WHERE SoHDB=N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayban.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboMakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMakhach.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadonban(SoHDB, Ngayban, MaNV, Makhach, Tongtien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" + Convert.ToDateTime(txtNgayban.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" +
                        cboMakhach.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSql(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahang.Focus();
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
            sql = "SELECT Mamay FROM tblChitietHDB WHERE Mamay=N'" + cboMahang.SelectedValue + "' AND SoHDB = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                cboMahang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblKhomay WHERE Mamay = N'" + cboMahang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblChitietHDB(SoHDB,Mamay,Slban,Dongiaban, Khuyenmai, Thanhtien) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMahang.SelectedValue +
"'," + txtSoluong.Text + "," + txtDongiaban.Text + "," + txtGiamgia.Text + "," + txtThanhtien.Text + ")";
            Functions.RunSql(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblKhomay SET Soluong =" + SLcon + " WHERE Mamay= N'" + cboMahang.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHoadonban WHERE SoHDB = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblHoadonban SET Tongtien =" + Tongmoi + " WHERE SoHDB = N'" + txtMaHDBan.Text + "'";
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
            cboMahang.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtThanhtien.Text = "0";
        }

        private void DataGridViewChitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = DataGridViewChitiet.CurrentRow.Cells["Mamay"].Value.ToString();
                DelHang(txtMaHDBan.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(DataGridViewChitiet.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMaHDBan.Text, Thanhtien);
                Load_DataGridViewChitiet();
            }

        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Slban FROM tblChitietHDB WHERE SoHDB = N'" + Mahoadon + "' AND Mamay=N'" + Mahang + "'";
            s = Convert.ToDouble(Functions.GetFieldValues(sql));
            sql = "DELETE tblChitietHDB WHERE SoHDB=N'" + Mahoadon + "' AND Mamay = N'" + Mahang + "'";
            Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM tblKhomay WHERE Mamay= N'" + Mahang + "'";
            sl = Convert.ToDouble(Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblKhomay SET Soluong =" + SLcon + " WHERE Mamay= N'" + Mahang + "'";
            Functions.RunSql(sql);
        }

        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT Tongtien FROM tblHoadonban WHERE SoHDB = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblHoadonban SET Tongtien =" + Tongmoi + " WHERE SoHDB = N'" + Mahoadon + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT Mamay FROM tblChitietHDB WHERE SoHDB = N'" + txtMaHDBan.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMaHDBan.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblHoadonban WHERE SoHDB=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                btnXoaHD.Enabled = false;
                btnInhoadon.Enabled = false;
            }

        }

        private void cboManhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenNV from tblNhanvien where MaNV =N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cboMakhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select Tenkhach from tblKhachhang where Makhach = N'" + cboMakhach.SelectedValue + "'";
            txtTenkhach.Text = Functions.GetFieldValues(str);
            str = "Select Diachi from tblKhachhang where Makhach = N'" + cboMakhach.SelectedValue + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblKhachhang where Makhach= N'" + cboMakhach.SelectedValue + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);

        }

        private void cboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMahang.Text == "")
            {
                txtTenhang.Text = "";
                txtDongiaban.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT Tenmay FROM tblKhomay WHERE Mamay =N'" + cboMahang.SelectedValue + "'";
            txtTenhang.Text = Functions.GetFieldValues(str);
            str = "SELECT Giaban FROM tblKhomay WHERE Mamay =N'" + cboMahang.SelectedValue + "'";
            txtDongiaban.Text = Functions.GetFieldValues(str);
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
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
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtGiamgia_TextChanged(object sender, EventArgs e)
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
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
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
            exRange.Range["A1:B1"].Value = "Cửa hàng sách Văn Hà";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)12345678";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.SoHDB, a.Ngayban, a.Tongtien, b.Tenkhach, b.Diachi, b.Dienthoai, c.TenNV FROM tblHoadonban AS a, tblKhachhang AS b, tblNhanvien AS c WHERE a.SoHDB = N'" + txtMaHDBan.Text + "' AND a.Makhach = b.Makhach AND a.MaNV = c.MaNV";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tenmay, a.Slban, b.Dongiaban, a.Khuyenmai, a.Thanhtien " +
                  "FROM tblChitietHDB AS a , tblKhomay AS b WHERE a.SoHDB = N'" +
                  txtMaHDBan.Text + "' AND a.Mamay = b.Mamay";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
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
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            btnXoaHD.Enabled = true;
            btnLuu.Enabled = true;
            btnInhoadon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;

        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT SoHDB FROM tblHoadonban", cboMaHDBan, "SoHDB", "SoHDB");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void frmHoadonban_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
