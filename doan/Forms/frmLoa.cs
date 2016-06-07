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
    
    public partial class frmLoa : Form
    {
        DataTable tblL;
        public frmLoa()
        {
            InitializeComponent();
        }

        private void frmLoa_Load(object sender, EventArgs e)
        {
            txtMaloa.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Maloa, Tenloa FROM tblLoa";
            tblL = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblL;
            DataGridView.Columns[0].HeaderText = "Mã loa";
            DataGridView.Columns[1].HeaderText = "Tên loa";
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
                txtMaloa.Focus();
                return;
            }
            if (tblL.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaloa.Text = DataGridView.CurrentRow.Cells["Maloa"].Value.ToString();
            txtTenloa.Text = DataGridView.CurrentRow.Cells["Tenloa"].Value.ToString();
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
            txtMaloa.Enabled = true;
            txtMaloa.Focus();
        }

        private void ResetValues()
        {
            txtMaloa.Text = "";
            txtTenloa.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaloa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloa.Focus();
                return;
            }
            if (txtTenloa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloa.Focus();
                return;
            }

            sql = "SELECT Maloa FROM tblLoa WHERE Maloa=N'" + txtMaloa.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloa.Focus();
                txtMaloa.Text = "";
                return;
            }
            sql = "INSERT INTO tblLoa(Maloa,Tenloa) VALUES (N'" + txtMaloa.Text.Trim() + "',N'" + txtTenloa.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaloa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaloa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenloa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenloa.Focus();
                return;
            }
            sql = "UPDATE tblLoa SET  Tenbp=N'" + txtTenloa.Text.Trim().ToString() +
                    "',Maloa=N'" + txtMaloa.Text.Trim().ToString() +
                    "'WHERE Maloa=N'" + txtMaloa.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaloa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblLoa WHERE Maloa=N'" + txtMaloa.Text + "'";
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
            txtMaloa.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
