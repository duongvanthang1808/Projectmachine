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
    public partial class frmHangsanxuat : Form
    {
        DataTable tblHSX;
        public frmHangsanxuat()
        {
            InitializeComponent();
        }

        private void frmHangsanxuat_Load(object sender, EventArgs e)
        {
            txtMahsx.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }


        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mahsx, Tenhsx, Diachi, Dienthoai FROM tblHSX";
            tblHSX = Class.Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblHSX;
            DataGridView.Columns[0].HeaderText = "Mã HSX";
            DataGridView.Columns[1].HeaderText = "Tên HSX";
            DataGridView.Columns[2].HeaderText = "Địa chỉ";
            DataGridView.Columns[3].HeaderText = "Điện thoại";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 150;
            DataGridView.Columns[3].Width = 100;
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
            txtMahsx.Enabled = true;
            txtMahsx.Focus();
        }

        private void ResetValues()
        {
            txtMahsx.Text = "";
            txtTenhsx.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahsx.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahsx.Focus();
                return;
            }
            if (txtTenhsx.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhsx.Focus();
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
            sql = "SELECT MaHSX FROM tblHSX WHERE MaHSX=N'" + txtMahsx.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahsx.Focus();
                txtMahsx.Text = "";
                return;
            }
            sql = "INSERT INTO tblHSX(MaHSX,TenHSX,Diachi,Dienthoai) VALUES (N'" + txtMahsx.Text.Trim() + "',N'" + txtTenhsx.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + mskDienthoai.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahsx.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahsx.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenhsx.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhsx.Focus();
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
            sql = "UPDATE tblHSX SET  TenHSX=N'" + txtTenhsx.Text.Trim().ToString()
                  + "',Diachi=N'" + txtDiachi.Text.Trim().ToString() + "',Dienthoai='" +
                mskDienthoai.Text.ToString() + "' WHERE MaHSX=N'" + txtMahsx.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahsx.Focus();
                return;
            }
            if (tblHSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMahsx.Text = DataGridView.CurrentRow.Cells["MaHSX"].Value.ToString();
            txtTenhsx.Text = DataGridView.CurrentRow.Cells["TenHSX"].Value.ToString();
            txtDiachi.Text = DataGridView.CurrentRow.Cells["Diachi"].Value.ToString();
            mskDienthoai.Text = DataGridView.CurrentRow.Cells["Dienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahsx.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblHSX WHERE MaHSX=N'" + txtMahsx.Text + "'";
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
            txtMahsx.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
