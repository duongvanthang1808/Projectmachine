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
    public partial class frmBanphim : Form
    {
        DataTable tblBP;
        public frmBanphim()
        {
            InitializeComponent();
        }

        private void frmBanphim_Load(object sender, EventArgs e)
        {
            txtMabp.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mabp, Tenbp FROM tblBanphim";
            tblBP = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblBP;
            DataGridView.Columns[0].HeaderText = "Mã bàn phím";
            DataGridView.Columns[1].HeaderText = "Tên bàn phím";
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
                txtMabp.Focus();
                return;
            }
            if (tblBP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMabp.Text = DataGridView.CurrentRow.Cells["Mabp"].Value.ToString();
            txtTenbp.Text = DataGridView.CurrentRow.Cells["Tenbp"].Value.ToString();
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
            txtMabp.Enabled = true;
            txtMabp.Focus();
        }

        private void ResetValues()
        {
            txtMabp.Text = "";
            txtTenbp.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMabp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã bàn phím", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMabp.Focus();
                return;
            }
            if (txtTenbp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên bàn phím", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenbp.Focus();
                return;
            }

            sql = "SELECT Mabp FROM tblBanphim WHERE Mabp=N'" + txtMabp.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã bàn phím  này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMabp.Focus();
                txtMabp.Text = "";
                return;
            }
            sql = "INSERT INTO tblBanphim(Mabp,Tenbp) VALUES (N'" + txtMabp.Text.Trim() + "',N'" + txtTenbp.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMabp.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblBP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMabp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenbp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên bàn hpism", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenbp.Focus();
                return;
            }
            sql = "UPDATE tblBanphim SET  Tenbp=N'" + txtTenbp.Text.Trim().ToString() +
                    "',Mabp=N'" + txtMabp.Text.Trim().ToString() +
                    "'WHERE Mabp=N'" + txtMabp.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblBP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMabp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblBanphim WHERE Mabp=N'" + txtMabp.Text + "'";
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
            txtMabp.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
