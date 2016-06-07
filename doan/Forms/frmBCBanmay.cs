using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using doan.Class;

namespace doan.Forms
{
    public partial class frmBCBanmay : Form
    {
        DataTable tblBanHang;
        public frmBCBanmay()
        {
            InitializeComponent();
        }
        string str;
        private void frmBCBanmay_Load(object sender, EventArgs e)
        {
            int i;
            for (i = 1; i <= 12; i++)
                cboThang.Items.Add(i);
            for (i = 1; i <= 4; i++)
                cboQuy.Items.Add(i);
            for (i = 2010; i <= 2017; i++)
                cboNam.Items.Add(i);
            cboQuy.SelectedIndex = -1;
            cboNam.SelectedIndex = -1;
            btnBaocao.Enabled = false;
            btnIn.Enabled = false;
            btnBoqua.Enabled = false;
        }

        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNam.Text != "") btnBaocao.Enabled = true;
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQuy.Text != "") btnBaocao.Enabled = true;
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnBaocao.Enabled = false;
            cboNam.Enabled = false;
            cboQuy.Enabled = false;
            cboThang.Enabled = false;
            Load_dvgBanHang();

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            cboThang.Enabled = true;
            cboNam.Enabled = true;
            cboQuy.Enabled = true;
            btnIn.Enabled = false;
            btnBaocao.Enabled = false;
            btnBoqua.Enabled = false;
            cboNam.Text = "";
            cboQuy.Text = "";
            cboThang.Text = "";
            dvgBanHang.DataSource = null;
        }

        private void Load_dvgBanHang()
        {
            string sql = "SELECT a.SoHDB, b.Mamay, a.MaNV, a.Makhach, a.Ngayban, b.Slban, b.Dongiaban, b.Khuyenmai, b.Thanhtien FROM tblHoadonban AS a, tblChiTietHDB AS b WHERE a.SoHDB = b.SoHDB AND (MONTH(a.Ngayban)-1)/3 + 1 = " + cboQuy.Text + "AND YEAR(a.Ngayban)= " + cboNam.Text + "AND MONTH(a.Ngayban)= " + cboThang.Text;
            tblBanHang = Functions.GetDataToTable(sql);
            dvgBanHang.DataSource = tblBanHang;
            dvgBanHang.Columns[0].HeaderText = "Số hóa đơn";
            dvgBanHang.Columns[1].HeaderText = "Mã máy";
            dvgBanHang.Columns[2].HeaderText = "Mã nhân viên";
            dvgBanHang.Columns[3].HeaderText = "Mã khách";
            dvgBanHang.Columns[4].HeaderText = "Ngày bán";
            dvgBanHang.Columns[5].HeaderText = "Số lượng";
            dvgBanHang.Columns[6].HeaderText = "Đơn giá";
            dvgBanHang.Columns[7].HeaderText = "Giảm giá(%)";
            dvgBanHang.Columns[8].HeaderText = "Thành tiền(đv:đồng)";

            dvgBanHang.Columns[0].Width = 150;
            dvgBanHang.Columns[1].Width = 120;
            dvgBanHang.Columns[2].Width = 130;
            dvgBanHang.Columns[3].Width = 120;
            dvgBanHang.Columns[4].Width = 120;
            dvgBanHang.Columns[5].Width = 130;
            dvgBanHang.Columns[6].Width = 120;
            dvgBanHang.Columns[7].Width = 130;
            dvgBanHang.Columns[8].Width = 220;

            dvgBanHang.AllowUserToAddRows = false;
            dvgBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;

            if (dvgBanHang.Rows.Count > 0)
            {
                str = "SELECT SUM(TongTien) FROM tblHoadonban WHERE (MONTH(Ngayban)-1)/3 + 1 = " + cboQuy.Text + "AND YEAR(Ngayban)= " + cboNam.Text;

                btnIn.Enabled = true;
            }
            else
            {
                dvgBanHang.DataSource = null;
                MessageBox.Show("Không có dữ liệu bán hàng về thời gian này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQuy.Text = "";
                cboNam.Text = "";
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            // Khoi dong chuong trinh Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            //Dinh dang chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 12;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; // Mau xanh da troi
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng sách Thái Thịnh";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = " Điện thoại: (04) 56789999";
            exRange.Range["C2:F2"].Font.Size = 16;
            exRange.Range["C2:F2"].Font.Name = "Times new roman";
            exRange.Range["C2:F2"].Font.Bold = true;
            exRange.Range["C2:F2"].Font.ColorIndex = 3; // Mau do
            exRange.Range["C2:F2"].MergeCells = true;
            exRange.Range["C2:F2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:F2"].Value = "BÁO CÁO THỐNG KÊ BÁN HÀNG ";
            exRange.Range["C3:F3"].Font.Size = 16;
            exRange.Range["C3:F3"].Font.Name = "Times new roman";
            exRange.Range["C3:F3"].Font.Bold = true;
            exRange.Range["C3:F3"].Font.ColorIndex = 3; // Mau do
            exRange.Range["C3:F3"].MergeCells = true;
            exRange.Range["C3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C3:F3"].Value = "QUÝ " + cboQuy.Text + " NĂM " + cboNam.Text;

            exRange.Range["A8:J8"].Font.Size = 12;
            exRange.Range["A8:A8"].ColumnWidth = 10;
            exRange.Range["B8:B8"].ColumnWidth = 10;
            exRange.Range["C8:C8"].ColumnWidth = 10;
            exRange.Range["D8:D8"].ColumnWidth = 15;
            exRange.Range["E8:E8"].ColumnWidth = 12;
            exRange.Range["F8:F8"].ColumnWidth = 15;
            exRange.Range["G8:G8"].ColumnWidth = 12;
            exRange.Range["H8:H8"].ColumnWidth = 12;
            exRange.Range["I8:I8"].ColumnWidth = 15;
            exRange.Range["J8:J8"].ColumnWidth = 22;
            exRange.Range["A8:J8"].Font.Name = "Times new roman";
            exRange.Range["A8:J8"].Font.Bold = true;
            exRange.Range["A8:J8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Số hóa đơn bán";
            exRange.Range["C8:C8"].Value = "Mã sách";
            exRange.Range["D8:D8"].Value = "Mã nhân viên";
            exRange.Range["E8:E8"].Value = "Mã khách";
            exRange.Range["F8:F8"].Value = "Ngày bán";
            exRange.Range["G8:G8"].Value = "Số lượng";
            exRange.Range["H8:H8"].Value = "Đơn giá";
            exRange.Range["I8:I8"].Value = "Giảm giá(%)";
            exRange.Range["J8:J8"].Value = "Thành tiền(đv:đồng)";
            exRange.Range["A8:J8"].Borders.Color = Color.Black;

            for (hang = 0; hang <= tblBanHang.Rows.Count - 1; hang++)
            {
                // Dien so thu tu vao cot 1 tu dong 9
                exSheet.Cells[1][hang + 9] = hang + 1;
                exRange.Range["A" + (hang + 9).ToString() + ":J" + (hang + 9).ToString()].Borders.Color = Color.Black;
                for (cot = 0; cot <= tblBanHang.Columns.Count - 1; cot++)
                    // Dien thong tin tu cot thu 2, dong 9
                    exSheet.Cells[cot + 2][hang + 9] = tblBanHang.Rows[hang][cot].ToString();
            }

            exRange = exSheet.Cells[cot][hang + 11];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 11];
            exRange.Font.Bold = true;
            exRange.Value2 = Functions.GetFieldValues(str);
            exRange = exSheet.Cells[1][hang + 12]; //Ô A1 
            exRange.Range["A1:J1"].MergeCells = true;
            exRange.Range["A1:J1"].Font.Bold = true;
            exRange.Range["A1:J1"].Font.Italic = true;
            exRange.Range["A1:J1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:J1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(Functions.GetFieldValues(str));

            exRange = exSheet.Cells[8][hang + 14];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + day + " tháng " + month + " năm " + year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Người lập báo cáo";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = "Phạm Thanh TÙng";
            exSheet.Name = "Báo cáo bán hàng";
            exApp.Visible = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
