using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using doan.Class; 

namespace doan.Forms
{
    public partial class frmChitietHDN : Form
    {
        DataTable tblHDN;
        public frmChitietHDN()
        {
            InitializeComponent();
        }
        
        private void frmChitietHDN_Load(object sender, EventArgs e)
        {
            cboSoHDN.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Functions.FillCombo("SELECT SoHDN, SoHDN FROM tblHoadonnhap", cboSoHDN, "SoHDN", "SoHDN");
            cboSoHDN.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mamay, Tenmay FROM tblKhomay", cboMamay, "Mamay", "Tenmay");
            cboMamay.SelectedIndex = -1;
            txtThanhtien.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT SoHDN, Mamay, Slnhap, Dongianhap, Khuyenmai, Thanhtien FROM tblChitietHDN";
            tblHDN = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblHDN;
            DataGridView.Columns[0].HeaderText = "Số hóa đơn nhập";
            DataGridView.Columns[1].HeaderText = "Mã máy";
            DataGridView.Columns[2].HeaderText = "Số lượng nhập";
            DataGridView.Columns[3].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[4].HeaderText = "Khuyến mại";
            DataGridView.Columns[5].HeaderText = "Thành tiền";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 100;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            cboSoHDN.Enabled = true;
            cboSoHDN.Focus();
        }

        private void ResetValues()
        {
            cboSoHDN.Text = "";
            cboMamay.Text = "";
            txtSLnhap.Text = "";
            txtDongianhap.Text = "";
            txtThanhtien.Text = "";
            txtKhuyenmai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int a;
            string sql;
            if (cboSoHDN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số hóa đơn nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDN.Focus();
                return;
            }

            if (cboMamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamay.Focus();
                return;
            }

            if (txtSLnhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLnhap.Focus();
                return;
            }

            if (txtDongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
                return;
            }
            if (txtKhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tiền được khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuyenmai.Focus();
                return;
            }

            a = Convert.ToInt32(txtSLnhap.Text) * Convert.ToInt32(txtDongianhap.Text) - Convert.ToInt32(txtKhuyenmai.Text);
            txtThanhtien.Text = Convert.ToString(a);

            /*sql = "SELECT SoHDN, Masach FROM tblHoadonnhap WHERE SoHDN=N'" + cboSoHDN.SelectedValue.ToString() + "', Masach=N'" + cboMasach.SelectedValue.ToString() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Số hóa đơn và mã sách đã có, bạn phải nhập số HĐ khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDN.Focus();
                cboSoHDN.Text = "";
                return;
            }*/
            sql = "INSERT INTO tblChitietHDN(SoHDN, Mamay, Slnhap, Dongianhap, Khuyenmai, Thanhtien) VALUES (N'" + cboSoHDN.SelectedValue.ToString() + "',N'" + cboMamay.SelectedValue.ToString() + "',N'" + txtSLnhap.Text.Trim() + "',N'" + txtDongianhap.Text.Trim() + "',N'" + txtKhuyenmai.Text.Trim() + "',N'" + txtThanhtien.Text.Trim() + "')";
            Functions.RunSql(sql);

            //sql = "INSERT INTO tblKhosach (Dongianhap) VALUES (N'" + txtDongianhap.Text.Trim() + "') WHERE (tblKhosach.Masach = tblChitietHDN.Masach)";
            sql = "INSERT INTO tblKhomay (Dongianhap) SELECT Dongianhap FROM tblChitietHDN WHERE (tblKhomay.Mamay = tblChitietHDN.Mamay)";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            cboSoHDN.Enabled = false;
            cboMamay.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            int a;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboSoHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboSoHDN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDN.Focus();
                return;
            }
            if (cboMamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamay.Focus();
                return;
            }

            if (txtSLnhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLnhap.Focus();
                return;
            }
            if (txtKhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tiền khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuyenmai.Focus();
                return;
            }
            a = Convert.ToInt32(txtSLnhap.Text) * Convert.ToInt32(txtDongianhap.Text) - Convert.ToInt32(txtKhuyenmai.Text);
            txtThanhtien.Text = Convert.ToString(a);

            sql = "UPDATE tblChitietHDN SET  Mamay=N'" + cboMamay.SelectedValue.ToString() +
                    "',Slnhap=N'" + txtSLnhap.Text.Trim().ToString() +
                    "',Dongianhap=N'" + txtDongianhap.Text.Trim().ToString() +
                    "',Khuyenmai=N'" + txtKhuyenmai.Text.Trim().ToString() +
                    "',Thanhtien=N'" + txtThanhtien.Text.Trim().ToString() +
                    "' WHERE SoHDN=N'" + cboSoHDN.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSoHDN.Focus();
                return;
            }
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ma = DataGridView.CurrentRow.Cells["SoHDN"].Value.ToString();
            cboSoHDN.Text = Functions.GetFieldValues("SELECT SoHDN FROM tblHoadonnhap WHERE SoHDN = N'" + ma + "'");
            ma = DataGridView.CurrentRow.Cells["Mamay"].Value.ToString();
            cboMamay.Text = Functions.GetFieldValues("SELECT Tenmay FROM tblKhomay WHERE Mamay= N'" + ma + "'");
            txtSLnhap.Text = DataGridView.CurrentRow.Cells["Slnhap"].Value.ToString();
            txtDongianhap.Text = DataGridView.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtKhuyenmai.Text = DataGridView.CurrentRow.Cells["Khuyenmai"].Value.ToString();
            txtThanhtien.Text = DataGridView.CurrentRow.Cells["Thanhtien"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboSoHDN.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChitietHDN WHERE SoHDN=N'" + cboSoHDN.Text + "' or Mamay = N'" + cboMamay.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            cboSoHDN.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        

       
    }
}
