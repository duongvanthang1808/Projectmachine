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
    public partial class frmRam : Form
    {
        DataTable tblR;
        public frmRam()
        {
            InitializeComponent();
        }

        private void frmRam_Load(object sender, EventArgs e)
        {
            txtMaram.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Maram, Tenram FROM tblRam";
            tblR = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblR;
            DataGridView.Columns[0].HeaderText = "Mã RAM";
            DataGridView.Columns[1].HeaderText = "Tên RAM";
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
                txtMaram.Focus();
                return;
            }
            if (tblR.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaram.Text = DataGridView.CurrentRow.Cells["Maram"].Value.ToString();
            txtTenram.Text = DataGridView.CurrentRow.Cells["Tenram"].Value.ToString();
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
            txtMaram.Enabled = true;
            txtMaram.Focus();
        }

        private void ResetValues()
        {
            txtMaram.Text = "";
            txtTenram.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaram.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaram.Focus();
                return;
            }
            if (txtTenram.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenram.Focus();
                return;
            }

            sql = "SELECT Maram FROM tblRam WHERE Maram=N'" + txtMaram.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại ram này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaram.Focus();
                txtMaram.Text = "";
                return;
            }
            sql = "INSERT INTO tblRam(Maram,Tenram) VALUES (N'" + txtMaram.Text.Trim() + "',N'" + txtTenram.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaram.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblR.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaram.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenram.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenram.Focus();
                return;
            }
            sql = "UPDATE tblRam SET  Tenram=N'" + txtTenram.Text.Trim().ToString() +
                    "',Maram=N'" + txtMaram.Text.Trim().ToString() +
                    "'WHERE Maram=N'" + txtMaram.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblR.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaram.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblRam WHERE Madungluong=N'" + txtMaram.Text + "'";
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
            txtMaram.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
