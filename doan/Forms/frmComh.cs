using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace doan.Forms
{
    public partial class frmComh : Form
    {
        DataTable tblcoMH;
        public frmComh()
        {
            InitializeComponent();
        }

        private void frmComh_Load(object sender, EventArgs e)
        {
            txtMacomh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Macomh, Tencomh FROM tblCoMH";
            tblcoMH = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblcoMH;
            DataGridView.Columns[0].HeaderText = "Mã cỡ màn hình";
            DataGridView.Columns[1].HeaderText = "Tên cỡ màn hình";
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
                txtMacomh.Focus();
                return;
            }
            if (tblcoMH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMacomh.Text = DataGridView.CurrentRow.Cells["Macomh"].Value.ToString();
            txtTencomh.Text = DataGridView.CurrentRow.Cells["Tencomh"].Value.ToString();
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
            txtMacomh.Enabled = true;
            txtMacomh.Focus();
        }

        private void ResetValues()
        {
            txtMacomh.Text = "";
            txtTencomh.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMacomh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã cỡ màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacomh.Focus();
                return;
            }
            if (txtTencomh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên cỡ màn hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencomh.Focus();
                return;
            }

            sql = "SELECT Macomh FROM tblCoMH WHERE Macomh=N'" + txtMacomh.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã cỡ màn hình này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacomh.Focus();
                txtMacomh.Text = "";
                return;
            }
            sql = "INSERT INTO tblCoMH(Macomh,Tencomh) VALUES (N'" + txtMacomh.Text.Trim() + "',N'" + txtTencomh.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMacomh.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcoMH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMacomh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTencomh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTencomh.Focus();
                return;
            }
            sql = "UPDATE tblCoMH SET  Tencomh=N'" + txtTencomh.Text.Trim().ToString() +
                    "',Macomh=N'" + txtMacomh.Text.Trim().ToString() +
                    "'WHERE Macomh=N'" + txtMacomh.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblcoMH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMacomh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblCoMH WHERE Macomh=N'" + txtMacomh.Text + "'";
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
            txtMacomh.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
