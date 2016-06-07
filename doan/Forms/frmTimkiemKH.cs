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
    public partial class frmTimkiemKH : Form
    {
        DataTable tblTKKH;
        public frmTimkiemKH()
        {
            InitializeComponent();
        }
        private void frmTimkiemKH_Load(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
            Functions.FillCombo("SELECT Makhach, Makhach FROM tblKhachhang", cboMaKH, "Makhach", "Makhach");
            cboMaKH.SelectedIndex = -1;
        }



        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaKH.Text == "") && (txtTenKH.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblKhachhang WHERE 1=1";
            if (txtTenKH.Text != "")
                sql = sql + " AND Tenkhach Like N'%" + txtTenKH.Text + "%'";
            if (cboMaKH.Text != "")
                sql = sql + " AND Makhach Like N'%" + cboMaKH.SelectedValue + "%'";


            tblTKKH = Functions.GetDataToTable(sql);
            if (tblTKKH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblTKKH.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblTKKH;
            ResetValues();

        }
        private void ResetValues()
        {
            txtTenKH.Text = "";
            cboMaKH.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
        }

      
    }
}
