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
    public partial class frmDungluong : Form
    {
        DataTable tblDL;
        public frmDungluong()
        {
            InitializeComponent();
        }

        private void frmDungluong_Load(object sender, EventArgs e)
        {
            txtMadungluong.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Madungluong, Tendungluong FROM tblDungluong";
            tblDL = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblDL;
            DataGridView.Columns[0].HeaderText = "Mã dung lượng";
            DataGridView.Columns[1].HeaderText = "Tên dung lượng";
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
                txtMadungluong.Focus();
                return;
            }
            if (tblDL.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMadungluong.Text = DataGridView.CurrentRow.Cells["Madungluong"].Value.ToString();
            txtTendungluong.Text = DataGridView.CurrentRow.Cells["Tendungluong"].Value.ToString();
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
            txtMadungluong.Enabled = true;
            txtMadungluong.Focus();
        }

        private void ResetValues()
        {
            txtMadungluong.Text = "";
            txtTendungluong.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMadungluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMadungluong.Focus();
                return;
            }
            if (txtTendungluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendungluong.Focus();
                return;
            }

            sql = "SELECT Madungluong FROM tblDungluong WHERE Madungluong=N'" + txtMadungluong.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMadungluong.Focus();
                txtMadungluong.Text = "";
                return;
            }
            sql = "INSERT INTO tblDungluong(Madungluong,Tendungluong) VALUES (N'" + txtMadungluong.Text.Trim() + "',N'" + txtTendungluong.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMadungluong.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMadungluong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTendungluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTendungluong.Focus();
                return;
            }
            sql = "UPDATE tblDungluong SET  Tendungluong=N'" + txtTendungluong.Text.Trim().ToString() +
                    "',Maloai=N'" + txtMadungluong.Text.Trim().ToString() +
                    "'WHERE Madungluong=N'" + txtMadungluong.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMadungluong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblDungluong WHERE Madungluong=N'" + txtMadungluong.Text + "'";
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
            txtMadungluong.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
