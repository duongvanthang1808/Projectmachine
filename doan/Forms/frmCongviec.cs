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

    public partial class frmCongviec : Form
    {
        DataTable tblCV;
        public frmCongviec()
        {
            InitializeComponent();
        }
        private void frmCongViec_Load(object sender, EventArgs e)
        {
            txtMacv.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaCV, TenCV FROM tblCongviec";
            tblCV = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblCV;
            DataGridView.Columns[0].HeaderText = "Mã công việc";
            DataGridView.Columns[1].HeaderText = "Tên công việc";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 150;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMacv.Focus();
                return;
            }
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMacv.Text = DataGridView.CurrentRow.Cells["MaCV"].Value.ToString();
            txtTencv.Text = DataGridView.CurrentRow.Cells["TenCV"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMacv.Enabled = true;
            txtMacv.Focus();
        }

        private void ResetValues()
        {
            txtMacv.Text = "";
            txtTencv.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMacv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacv.Focus();
                return;
            }
            if (txtTencv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencv.Focus();
                return;
            }

            sql = "SELECT MaCV FROM tblCV WHERE MaCV=N'" + txtMacv.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacv.Focus();
                txtMacv.Text = "";
                return;
            }
            sql = "INSERT INTO tblDungluong(MaCV,TenCV) VALUES (N'" + txtMacv.Text.Trim() + "',N'" + txtTencv.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMacv.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMacv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTencv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencv.Focus();
                return;
            }
            sql = "UPDATE tblCongviec SET  TenCV=N'" + txtTencv.Text.Trim().ToString() +
                    "',MaCV=N'" + txtMacv.Text.Trim().ToString() +
                    "'WHERE MaCV=N'" + txtMacv.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMacv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblCongviec WHERE MaCV=N'" + txtMacv.Text + "'";
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
            txtMacv.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
