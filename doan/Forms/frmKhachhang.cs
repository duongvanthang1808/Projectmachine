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
    public partial class frmKhachhang : Form
    {
        DataTable tblKH;
        public frmKhachhang()
        {
            InitializeComponent();
        }
        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            txtMakhach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Makhach, Tenkhach, Diachi, Dienthoai FROM tblKhachhang";
            tblKH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKH;
            DataGridView.Columns[0].HeaderText = "Mã khách";
            DataGridView.Columns[1].HeaderText = "Tên khách";
            DataGridView.Columns[2].HeaderText = "Địa chỉ";
            DataGridView.Columns[3].HeaderText = "Điện thoại";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 150;
            DataGridView.Columns[2].Width = 150;
            DataGridView.Columns[3].Width = 150;
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
            txtMakhach.Enabled = true;
            txtMakhach.Focus();
        }

        private void ResetValues()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMakhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhach.Focus();
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            sql = "SELECT Makhach FROM tblKhachhang WHERE Makhach=N'" + txtMakhach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMakhach.Focus();
                txtMakhach.Text = "";
                return;
            }
            sql = "INSERT INTO tblKhachhang(Makhach,Tenkhach,Diachi,Dienthoai) VALUES (N'" + txtMakhach.Text.Trim() + "',N'" + txtTenkhach.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + mskDienthoai.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMakhach.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            sql = "UPDATE tblKhachhang SET  Tenkhach=N'" + txtTenkhach.Text.Trim().ToString()
                  + "',Diachi=N'" + txtDiachi.Text.Trim().ToString() + "',Dienthoai='" +
                mskDienthoai.Text.ToString() + "' WHERE Makhach=N'" + txtMakhach.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblKhachhang WHERE Makhach=N'" + txtMakhach.Text + "'";
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
            txtMakhach.Enabled = false;
        }

        private void txtMakhach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMakhach.Text = DataGridView.CurrentRow.Cells["Makhach"].Value.ToString();
            txtTenkhach.Text = DataGridView.CurrentRow.Cells["Tenkhach"].Value.ToString();
            txtDiachi.Text = DataGridView.CurrentRow.Cells["Diachi"].Value.ToString();
            mskDienthoai.Text = DataGridView.CurrentRow.Cells["Dienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
        
    }
}
