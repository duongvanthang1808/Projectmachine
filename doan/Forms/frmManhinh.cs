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
    public partial class frmManhinh : Form
    {
        DataTable tblMH;
        public frmManhinh()
        {
            InitializeComponent();
        }

        private void frmManhinh_Load(object sender, EventArgs e)
        {
            txtMamh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mamh, Tenmh FROM tblManhinh";
            tblMH = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblMH;
            DataGridView.Columns[0].HeaderText = "Mã màn hình";
            DataGridView.Columns[1].HeaderText = "Tên màn hình";
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
                txtMamh.Focus();
                return;
            }
            if (tblMH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMamh.Text = DataGridView.CurrentRow.Cells["Mamh"].Value.ToString();
            txtTenmh.Text = DataGridView.CurrentRow.Cells["Tenmh"].Value.ToString();
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
            txtMamh.Enabled = true;
            txtMamh.Focus();
        }

        private void ResetValues()
        {
            txtMamh.Text = "";
            txtTenmh.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamh.Focus();
                return;
            }
            if (txtTenmh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmh.Focus();
                return;
            }

            sql = "SELECT Mamh FROM tblManhinh WHERE Mamh=N'" + txtMamh.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamh.Focus();
                txtMamh.Text = "";
                return;
            }
            sql = "INSERT INTO tblManhinh(Mamh,Tenmh) VALUES (N'" + txtMamh.Text.Trim() + "',N'" + txtTenmh.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMamh.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenmh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmh.Focus();
                return;
            }
            sql = "UPDATE tblManhinh SET  Tenmh=N'" + txtTenmh.Text.Trim().ToString() +
                    "',Mamh=N'" + txtMamh.Text.Trim().ToString() +
                    "'WHERE Mamh=N'" + txtMamh.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblManhinh WHERE Mamh=N'" + txtMamh.Text + "'";
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
            txtMamh.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
