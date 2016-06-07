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
    public partial class frmBCTop5HDB : Form
    {
        DataTable tblNhaphang;
        public frmBCTop5HDB()
        {
            InitializeComponent();
        }
        private void frmBCTop5HDN_Load(object sender, EventArgs e)
        {
            btnBaocao.Enabled = true;
            btnBoqua.Enabled = false;
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            btnBaocao.Enabled = false;
            Load_dvgBanHang();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {


            btnBaocao.Enabled = true;
            btnBoqua.Enabled = false;
            dvgBanHang.DataSource = null;
        }

        private void Load_dvgBanHang()
        {
            string sql = "SELECT TOP 5 a.SoHDB, b.Mamay, a.MaNV, a.Ngayban, b.Slban, b.Dongiaban, b.Khuyenmai, b.Thanhtien FROM tblHoadonban AS a, tblChiTietHDB AS b WHERE a.SoHDB = b.SoHDB ORDER BY b.Thanhtien DESC";
            tblNhaphang = Functions.GetDataToTable(sql);
            dvgBanHang.DataSource = tblNhaphang;
            dvgBanHang.Columns[0].HeaderText = "Số hóa đơn";
            dvgBanHang.Columns[1].HeaderText = "Mã máy";
            dvgBanHang.Columns[2].HeaderText = "Mã nhân viên";
           
            dvgBanHang.Columns[3].HeaderText = "Ngày bán";
            dvgBanHang.Columns[4].HeaderText = "Số lượng";
            dvgBanHang.Columns[5].HeaderText = "Đơn giá";
            dvgBanHang.Columns[6].HeaderText = "Giảm giá(%)";
            dvgBanHang.Columns[7].HeaderText = "Thành tiền(đv:đồng)";

            dvgBanHang.Columns[0].Width = 150;
            dvgBanHang.Columns[1].Width = 120;
            dvgBanHang.Columns[2].Width = 130;
            dvgBanHang.Columns[3].Width = 120;
            dvgBanHang.Columns[4].Width = 120;
            dvgBanHang.Columns[5].Width = 130;
            dvgBanHang.Columns[6].Width = 120;
            dvgBanHang.Columns[7].Width = 130;
   

            dvgBanHang.AllowUserToAddRows = false;
            dvgBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;

            if (dvgBanHang.Rows.Count > 0)
            {
                //str = "SELECT SUM(TongTien) FROM tblHoadonban WHERE (MONTH(Ngayban)-1)/3 + 1 = " + cboQuy.Text + "AND YEAR(Ngayban)= " + cboNam.Text;
                sql = "SELECT  TOP 5 c.SoHDB, a.Mamay, b.Tenmay,c.MaNV, c.Ngayban, a.Slnhap, a.KhuyenMai FROM tblChiTietHDB AS a, tblKhomay AS b, tblHoadonban AS c  WHERE a.SoHDB = c.SoHDB and b.Mamay = a.Mamay ORDER BY c.Tongtien DESC";

            }
        }
        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
