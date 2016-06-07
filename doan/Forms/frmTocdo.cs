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
    public partial class frmTocdo : Form
    {
        DataTable tblTD;
        public frmTocdo()
        {
            InitializeComponent();
        }

        private void frmTocdo_Load(object sender, EventArgs e)
        {
            txtMatocdo.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Matocdo, Tentocdo FROM tblTocdo";
            tblTD = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblTD;
            DataGridView.Columns[0].HeaderText = "Mã tốc độ";
            DataGridView.Columns[1].HeaderText = "Tên tốc độ";
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
                txtMatocdo.Focus();
                return;
            }
            if (tblTD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMatocdo.Text = DataGridView.CurrentRow.Cells["Matocdo"].Value.ToString();
            txtTentocdo.Text = DataGridView.CurrentRow.Cells["Tentocdo"].Value.ToString();
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
            txtMatocdo.Enabled = true;
            txtMatocdo.Focus();
        }

        private void ResetValues()
        {
            txtMatocdo.Text = "";
            txtTentocdo.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMatocdo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tốc độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatocdo.Focus();
                return;
            }
            if (txtTentocdo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tốc độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentocdo.Focus();
                return;
            }

            sql = "SELECT Matocdo FROM tbltocdo WHERE Matocdo=N'" + txtMatocdo.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã tốc độ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatocdo.Focus();
                txtMatocdo.Text = "";
                return;
            }
            sql = "INSERT INTO tblTocdo(Matocdo,Tentocdo) VALUES (N'" + txtMatocdo.Text.Trim() + "',N'" + txtTentocdo.Text.Trim() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMatocdo.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTD.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatocdo.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTentocdo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTentocdo.Focus();
                return;
            }
            sql = "UPDATE tblTocdo SET  Tentocdo=N'" + txtTentocdo.Text.Trim().ToString() +
                    "',Matocdo=N'" + txtMatocdo.Text.Trim().ToString() +
                    "'WHERE Matocdo=N'" + txtMatocdo.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTD.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatocdo.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblTocdo WHERE Matocdo=N'" + txtMatocdo.Text + "'";
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
            txtMatocdo.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
