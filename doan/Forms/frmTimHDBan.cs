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
    public partial class frmTimHDBan : Form
    {
        DataTable tblHDB;
        public frmTimHDBan()
        {
            InitializeComponent();
        }

        private void frmTimHDBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;


            Functions.FillCombo("select SoHDB,SoHDB from tblHoadonban", cboHDB, "SoHDB", "SoHDB");
            cboHDB.SelectedIndex = -1;
            Functions.FillCombo("select Mamay,Mamay from tblKhomay", cboMm, "Mamay", "Mamay");
            cboMm.SelectedIndex = -1;
            Functions.FillCombo("select MaNV,MaNV from tblNhanvien", cboMNV, "MaNV", "MaNV");
            cboMNV.SelectedIndex = -1;
            Functions.FillCombo("select Makhach,Makhach from tblKhachhang", cboMK, "Makhach", "Makhach");
            cboMK.SelectedIndex = -1;
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
            
                if ((cboHDB.Text.ToString() == "") && (cboMm.Text.ToString() == "")
                    && (txtThang.Text == "") && (txtNam.Text == "") && (cboMNV.Text.ToString() == "")
                    && (cboMK.Text.ToString() == "")
                   )
                {
                    MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
           
            sql = "SELECT * FROM tblHoadonban  WHERE 1=1";
            if (cboHDB.Text.ToString() != "")
                sql = sql + " AND SoHDB Like N'%" + cboHDB.SelectedValue.ToString() + "%'";
            if (cboMNV.Text.ToString() != "")
                sql = sql + " AND MaNV Like N'%" + cboMNV.SelectedValue.ToString() + "%'";
            if (cboMK.Text.ToString() != "")
                sql = sql + " AND Makhach Like N'%" + cboMK.SelectedValue.ToString() + "%'";
            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngaynhap) Like N'%" + txtThang.Text + "%'";
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngaynhap) Like N'%" + txtNam.Text + "%'";


            tblHDB = Class.Functions.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblHDB;
            ResetValues();

        }

        private void Load_DataGridView()
        {
            
            DataGridView.Columns[0].HeaderText = "Số HĐB";
            DataGridView.Columns[1].HeaderText = "Mã khách";
            DataGridView.Columns[2].HeaderText = "Mã khách";
            DataGridView.Columns[3].HeaderText = "Mã nhân viên";
            DataGridView.Columns[4].HeaderText = "Ngày nhập";
           
            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 100;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 80;
            DataGridView.Columns[5].Width = 80;
            DataGridView.Columns[6].Width = 80;

            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            cboHDB.Text = "";
            cboMm.Text = "";
            txtNam.Text = "";
            txtThang.Text = "";
            ResetValues();
            DataGridView.DataSource = null;
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
    }
}
