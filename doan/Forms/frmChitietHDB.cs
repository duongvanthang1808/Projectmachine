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
    public partial class frmChitietHDB : Form
    {
        DataTable tblHDN;
        public frmChitietHDB()
        {
            InitializeComponent();
        }

        private void frmChitietHDB_Load(object sender, EventArgs e)
        {
            cboSoHDB.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Class.Functions.FillCombo("SELECT SoHDB, SoHDB FROM tblHoadonban", cboSoHDB, "SoHDB", "SoHDB");
            cboSoHDB.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT Mamay, Tenmay FROM tblKhomay", cboMamay, "Mamay", "Tenmay");
            cboMamay.SelectedIndex = -1;
            txtThanhtien.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT SoHDB, Mamay, Slban, Dongiaban, Khuyenmai, Thanhtien FROM tblChitietHDB";
            tblHDN = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblHDN;
            DataGridView.Columns[0].HeaderText = "Số hóa đơn bán";
            DataGridView.Columns[1].HeaderText = "Mã máy";
            DataGridView.Columns[2].HeaderText = "Số lượng bán";
            DataGridView.Columns[3].HeaderText = "Đơn giá bán";
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
            cboSoHDB.Enabled = true;
            cboSoHDB.Focus();
        }

        private void ResetValues()
        {
            cboSoHDB.Text = "";
            cboMamay.Text = "";
            txtSLban.Text = "";
            txtKhuyenmai.Text = "";
            txtDongiaban.Text = "";
            txtThanhtien.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int a;
            string sql;
            if (cboSoHDB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số hóa đơn bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDB.Focus();
                return;
            }

            if (cboMamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamay.Focus();
                return;
            }

            if (txtSLban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLban.Focus();
                return;
            }

            if (txtDongiaban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
                return;
            }
            if (txtKhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tiền khuyến mại cho khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuyenmai.Focus();
                return;
            }

            a = Convert.ToInt32(txtSLban.Text) * Convert.ToInt32(txtDongiaban.Text) - Convert.ToInt32(txtKhuyenmai.Text);
            txtThanhtien.Text = Convert.ToString(a);

            /*sql = "SELECT SoHDN, Masach FROM tblHoadonnhap WHERE SoHDN=N'" + cboSoHDN.SelectedValue.ToString() + "', Masach=N'" + cboMasach.SelectedValue.ToString() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Số hóa đơn và mã sách đã có, bạn phải nhập số HĐ khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDN.Focus();
                cboSoHDN.Text = "";
                return;
            }*/
            sql = "INSERT INTO tblChitietHDB(SoHDB, Mamay, Slban, Dongiaban, Khuyenmai, Thanhtien) VALUES (N'" + cboSoHDB.SelectedValue.ToString() + "',N'" + cboMamay.SelectedValue.ToString() + "',N'" + txtSLban.Text.Trim() + "',N'" + txtDongiaban.Text.Trim() + "',N'" + txtKhuyenmai.Text.Trim() + "',N'" + txtThanhtien.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            cboSoHDB.Enabled = false;
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
            if (cboSoHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboSoHDB.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDB.Focus();
                return;
            }
            if (cboMamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamay.Focus();
                return;
            }

            if (txtSLban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSLban.Focus();
                return;
            }
            if (txtKhuyenmai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tiền khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuyenmai.Focus();
                return;
            }
            a = Convert.ToInt32(txtSLban.Text) * Convert.ToInt32(txtDongiaban.Text) - Convert.ToInt32(txtKhuyenmai.Text);
            txtThanhtien.Text = Convert.ToString(a);

            sql = "UPDATE tblChitietHDB SET  Mamay=N'" + cboMamay.SelectedValue.ToString() +
                    "',Slban=N'" + txtSLban.Text.Trim().ToString() +
                    "',Dongiaban=N'" + txtDongiaban.Text.Trim().ToString() +
                    "',Khuyenmai=N'" + txtKhuyenmai.Text.Trim().ToString() +
                    "',Thanhtien=N'" + txtThanhtien.Text.Trim().ToString() +
                    "' WHERE SoHDB=N'" + cboSoHDB.Text + "'";
            Class.Functions.RunSql(sql);
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
                cboSoHDB.Focus();
                return;
            }
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ma = DataGridView.CurrentRow.Cells["SoHDB"].Value.ToString();
            cboSoHDB.Text = Class.Functions.GetFieldValues("SELECT SoHDB FROM tblHoadonban WHERE SoHDB = N'" + ma + "'");

            ma = DataGridView.CurrentRow.Cells["Mamay"].Value.ToString();
            cboMamay.Text = Class.Functions.GetFieldValues("SELECT Tenmay FROM tblKhomay WHERE Mamay = N'" + ma + "'");
            txtSLban.Text = DataGridView.CurrentRow.Cells["Slban"].Value.ToString();
            txtDongiaban.Text = DataGridView.CurrentRow.Cells["Dongiaban"].Value.ToString();
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
            if (cboSoHDB.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChitietHDB WHERE SoHDB=N'" + cboSoHDB.Text + "' or Mamay = N'" + cboMamay.Text + "'";
                Class.Functions.RunSqlDel(sql);
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
            cboSoHDB.Enabled = false;
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
