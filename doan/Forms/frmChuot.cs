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
    public partial class frmChuot : Form
    {
        DataTable tblC;
        public frmChuot()
        {
            InitializeComponent();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Machuot, Tenchuot FROM tblChuot";
            tblC = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblC;
            DataGridView.Columns[0].HeaderText = "Mã chuột";
            DataGridView.Columns[1].HeaderText = "Tên chuột";
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
                txtMachuot.Focus();
                return;
            }
            if (tblC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMachuot.Text = DataGridView.CurrentRow.Cells["Machuot"].Value.ToString();
            txtTenchuot.Text = DataGridView.CurrentRow.Cells["Tenchuot"].Value.ToString();
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
            txtMachuot.Enabled = true;
            txtMachuot.Focus();
        }

        private void ResetValues()
        {
            txtMachuot.Text = "";
            txtTenchuot.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMachuot.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chuột", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachuot.Focus();
                return;
            }
            if (txtTenchuot.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chuột", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenchuot.Focus();
                return;
            }

            sql = "SELECT Machuot FROM tblChuot WHERE Machuot=N'" + txtMachuot.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chuột này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMachuot.Focus();
                txtMachuot.Text = "";
                return;
            }
            sql = "INSERT INTO tblChuot(Machuot,Tenchuot) VALUES (N'" + txtMachuot.Text.Trim() + "',N'" + txtTenchuot.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMachuot.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMachuot.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenchuot.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenchuot.Focus();
                return;
            }
            sql = "UPDATE tblChuot SET  Tenchuot=N'" + txtTenchuot.Text.Trim().ToString() +
                    "',Machuot=N'" + txtMachuot.Text.Trim().ToString() +
                    "'WHERE Machuot=N'" + txtMachuot.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMachuot.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblChuot WHERE Machuot=N'" + txtMachuot.Text + "'";
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
            txtMachuot.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChuot_Load(object sender, EventArgs e)
        {
            txtMachuot.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
       
    }
}
