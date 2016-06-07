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
    
    public partial class frmTimHDN : Form
    {
        DataTable tblHDN;

        public frmTimHDN()
        {
            InitializeComponent();
        }

        private void frmTimHDN_Load(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;

            Functions.FillCombo("select SoHDN,SoHDN from tblHoadonnhap", cboHDN, "SoHDN", "SoHDN");
            cboHDN.SelectedIndex = -1;
            Functions.FillCombo("select Mamay,Mamay from tblKhomay", cboMm, "Mamay", "Mamay");
            cboMm.SelectedIndex = -1;
          
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

            string sql;
            if ((cboHDN.Text.ToString() == "") && (cboMm.Text.ToString() == "") 
                && (txtThang.Text == "") && (txtNam.Text == "")
               )
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoadonnhap  WHERE 1=1";
            if (cboHDN.Text.ToString() != "")
                sql = sql + " AND SoHDN Like N'%" + cboHDN.SelectedValue.ToString() + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngaynhap) Like N'%" + txtThang.Text + "%'";
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngaynhap) Like N'%" + txtNam.Text + "%'";
            

            tblHDN = Class.Functions.GetDataToTable(sql);
            if (tblHDN.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblHDN;
            ResetValues();

        }

        private void Load_DataGridView()
        {

            DataGridView.Columns[0].HeaderText = "Số HĐN";
            DataGridView.Columns[1].HeaderText = "Mã máy";
            DataGridView.Columns[2].HeaderText = "Ngày nhập";
            DataGridView.Columns[3].HeaderText = "Mã nhà cung cấp";
            DataGridView.Columns[4].HeaderText = "Tổng tiền";
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
