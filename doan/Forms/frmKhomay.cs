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
    public partial class frmKhomay : Form
    {
        DataTable tblKS;
        public frmKhomay()
        {
            InitializeComponent();
        }

        private void frmKhomay_Load(object sender, EventArgs e)
        {
            txtMamay.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Functions.FillCombo("SELECT Maloai, Tenloai FROM tblLoaimay", cboMaloai, "Maloai", "Tenloai");
            cboMaloai.SelectedIndex = -1;
            Functions.FillCombo("SELECT Machip, Tenchip FROM tblChip", cboMachip, "Machip", "Tenchip");
            cboMachip.SelectedIndex = -1;
            Functions.FillCombo("SELECT Maocung, Tenocung FROM tblOcung", cboMaocung, "Maocung", "Tenocung");
            cboMaocung.SelectedIndex = -1;
            Functions.FillCombo("SELECT Madungluong, Tendungluong  FROM tblDungluong", cboMadungluong, "Madungluong", "Tendungluong");
            cboMadungluong.SelectedIndex = -1;
            Functions.FillCombo("SELECT Matocdo, Tentocdo  FROM tblTocdo", cboMatocdo, "Matocdo", "Tentocdo");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Maocung, Tenocung  FROM tblOcung", cboMaocung, "Maocung", "Tenocung");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Maloa, Tenloa  FROM tblLoa", cboMaloa, "Maloa", "Tenloa");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Macd, Tencd  FROM tblCD", cboMacd, "Macd", "Tencd");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mamh, Tenmh  FROM tblManhinh", cboMamh, "Mamh", "Tenmh");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Machuot, Tenchuot  FROM tblChuot", cboMachuot, "Machuot", "Tenchuot");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mabp, Tenbp  FROM tblBanphim", cboMabp, "Mabp", "Tenbp");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mausb, Tenusb  FROM tblUSB", cboMausb, "Mausb", "Tenusb");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Mahsx, Tenhsx  FROM tblHSX", cboMahsx, "Mahsx", "Tenhsx");
            cboMatocdo.SelectedIndex = -1;
            Functions.FillCombo("SELECT Maram, Tenram  FROM tblRam", cboMaram, "Maram", "Tenram");
            cboMatocdo.SelectedIndex = -1;

            ResetValues();

        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mamay, Tenmay, Maloai, Machip, Soluong, Gianhap, Giaban, Maocung, Madungluong, Matocdo, Macd, Mamh, Machuot, Mabp, Mausb, Maram, Maloa, Mahsx FROM tblKhomay";
            tblKS = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKS;
            DataGridView.Columns[0].HeaderText = "Mã máy";
            DataGridView.Columns[1].HeaderText = "Tên máy";
            DataGridView.Columns[2].HeaderText = "Mã loại máy";
            DataGridView.Columns[3].HeaderText = "Mã chip";
            DataGridView.Columns[4].HeaderText = "Số lượng";
            DataGridView.Columns[5].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[6].HeaderText = "Đơn giá bán";
            DataGridView.Columns[7].HeaderText = "Mã ổ cứng";
            DataGridView.Columns[8].HeaderText = "Mã dung lượng";
            DataGridView.Columns[9].HeaderText = "Mã tốc độ";
            DataGridView.Columns[10].HeaderText = "Mã CD";
            DataGridView.Columns[11].HeaderText = "Mã màn hình";
            DataGridView.Columns[12].HeaderText = "Mã chuột";
            DataGridView.Columns[13].HeaderText = "Mã bàn phím";
            DataGridView.Columns[14].HeaderText = "Mã USB";
            DataGridView.Columns[15].HeaderText = "Mã RAM";
            DataGridView.Columns[16].HeaderText = "Mã loa";
            DataGridView.Columns[17].HeaderText = "Mã hãng sản xuất";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 140;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 40;
            DataGridView.Columns[5].Width = 80;
            DataGridView.Columns[6].Width = 80;
            DataGridView.Columns[7].Width = 80;
            DataGridView.Columns[8].Width = 80;
            DataGridView.Columns[9].Width = 80;
            DataGridView.Columns[10].Width = 30;
            DataGridView.Columns[11].Width = 80;
            DataGridView.Columns[12].Width = 80;
            DataGridView.Columns[13].Width = 80;
            DataGridView.Columns[14].Width = 80;
            DataGridView.Columns[15].Width = 80;
            DataGridView.Columns[16].Width = 80;
            DataGridView.Columns[17].Width = 80;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMamay.Text = "";
            txtTenmay.Text = "";
            cboMaloai.Text = "";
            cboMachip.Text = "";
            cboMaocung.Text = "";
            cboMadungluong.Text = "";
            cboMatocdo.Text = "";
            cboMacd.Text = "";
            cboMamh.Text = "";
            cboMachuot.Text = "";
            cboMabp.Text = "";
            cboMausb.Text = "";
            cboMaram.Text = "";
            cboMaloa.Text = "";
            cboMahsx.Text = "";

            txtSoluong.Text = "0";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";

            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;

            
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string ma, ma2, ma3, ma4, ma5, ma6, ma7, ma8, ma9, ma10, ma11,ma12,ma13;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMamay.Focus();
                return;
            }
            if (tblKS.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMamay.Text = DataGridView.CurrentRow.Cells["Mamay"].Value.ToString();
            txtTenmay.Text = DataGridView.CurrentRow.Cells["Tenmay"].Value.ToString();

            ma = DataGridView.CurrentRow.Cells["Maloai"].Value.ToString();
            cboMaloai.Text = Functions.GetFieldValues("SELECT Tenloai FROM tblLoaimay WHERE Maloai = N'" + ma + "'");

            ma2 = DataGridView.CurrentRow.Cells["Machip"].Value.ToString();
            cboMachip.Text = Functions.GetFieldValues("SELECT Tenchip FROM tblChip WHERE Machip = N'" + ma2 + "'");

            ma3 = DataGridView.CurrentRow.Cells["Maocung"].Value.ToString();
            cboMaocung.Text = Functions.GetFieldValues("SELECT Tenocung FROM tblOcung WHERE Maocung = N'" + ma3 + "'");

            ma4 = DataGridView.CurrentRow.Cells["Madungluong"].Value.ToString();
            cboMadungluong.Text = Functions.GetFieldValues("SELECT Tendungluong FROM tblDungluong WHERE Madungluong = N'" + ma4 + "'");

            ma5 = DataGridView.CurrentRow.Cells["Matocdo"].Value.ToString();
            cboMatocdo.Text = Functions.GetFieldValues("SELECT Tentocdo FROM tblTocdo WHERE Matocdo = N'" + ma5 + "'");

            ma6 = DataGridView.CurrentRow.Cells["Macd"].Value.ToString();
            cboMacd.Text = Functions.GetFieldValues("SELECT Tencd FROM tblTocdo WHERE Macd = N'" + ma6 + "'");

            ma7 = DataGridView.CurrentRow.Cells["Mamh"].Value.ToString();
            cboMamh.Text = Functions.GetFieldValues("SELECT Tenmh FROM tblManhinh WHERE Mamh = N'" + ma7 + "'");

            ma8 = DataGridView.CurrentRow.Cells["Machuot"].Value.ToString();
            cboMachuot.Text = Functions.GetFieldValues("SELECT Tenchuot FROM tblChuot WHERE Machuot = N'" + ma8 + "'");

            ma9 = DataGridView.CurrentRow.Cells["Mabp"].Value.ToString();
            cboMabp.Text = Functions.GetFieldValues("SELECT Tenbp FROM tblBanphim WHERE Mabp = N'" + ma9 + "'");

            ma10 = DataGridView.CurrentRow.Cells["Mausb"].Value.ToString();
            cboMausb.Text = Functions.GetFieldValues("SELECT Tenusb FROM tblUSB WHERE Mausb = N'" + ma10 + "'");
            
            ma11 = DataGridView.CurrentRow.Cells["Maram"].Value.ToString();
            cboMaram.Text = Functions.GetFieldValues("SELECT Tenram FROM tblRam WHERE Maram = N'" + ma11 + "'");

            ma12 = DataGridView.CurrentRow.Cells["Maloa"].Value.ToString();
            cboMaloa.Text = Functions.GetFieldValues("SELECT Tenloa FROM tblLoa WHERE Maloa = N'" + ma12 + "'");

            ma13 = DataGridView.CurrentRow.Cells["Mahsx"].Value.ToString();
            cboMahsx.Text = Functions.GetFieldValues("SELECT Tenhsx FROM tblHSX WHERE Mahsx = N'" + ma13 + "'");
            txtTenmay.Text = DataGridView.CurrentRow.Cells["Tenmay"].Value.ToString();
            txtSoluong.Text = DataGridView.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDongianhap.Text = DataGridView.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtDongiaban.Text = DataGridView.CurrentRow.Cells["Dongiaban"].Value.ToString();
            //      txtAnh.Text = Functions.GetFieldValues("SELECT Anh FROM tblKhosach WHERE Masach = N'" + txtMasach.Text + "'");
            //      picAnh.Image = Image.FromFile(txtAnh.Text);
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
            txtMamay.Enabled = true;
            cboMaloai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMamay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamay.Focus();
                return;
            }
            if (txtTenmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmay.Focus();
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloai.Focus();
                return;
            }
            /* if (txtAnh.Text.Trim().Length == 0 )
             {
                 MessageBox.Show("Bạn phải chọn ảnh minh họa cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 txtAnh.Focus();
                 return;
             } */

            sql = "SELECT Mamay FROM tblKhomay WHERE Mamay=N'" + txtMamay.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã máy này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMamay.Focus();
                txtMamay.Text = "";
                return;
            }
            sql = "INSERT INTO tblKhomay(Mamay, Tenmay, Soluong, Gianhap, Giaban, Maloai, Machip, Maocung, Madungluong, Matocdo, Macd, Mamh, Machuot, Mabp, Mausb, Maram, Maloa, Mahsx, Anh) VALUES(N'" + txtMamay.Text.Trim() +
                    "',N'" + txtTenmay.Text.Trim() + "',N'" + txtSoluong.Text.Trim() + "',N'" + txtDongianhap.Text.Trim() + "',N'" + txtDongiaban.Text.Trim() + "',N'" + cboMaloai.SelectedValue.ToString() + "',N'" + cboMachip.SelectedValue.ToString() + "',N'" + cboMaocung.SelectedValue.ToString() + "',N'" + cboMadungluong.SelectedValue.ToString() +
                    "',N'" + cboMatocdo.SelectedValue.ToString() + "',N'" + cboMacd.SelectedValue.ToString() + "',N'" + cboMamh.SelectedValue.ToString() + "',N'" + cboMachuot.SelectedValue.ToString() + "',N'" + cboMabp.SelectedValue.ToString() + "',N'" + cboMausb.SelectedValue.ToString() + "',N'" + cboMaram.SelectedValue.ToString() + "',N'" + cboMaloa.SelectedValue.ToString() + "',N'" + cboMahsx.SelectedValue.ToString() + "','" + txtAnh.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMamay.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKS.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenmay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenmay.Focus();
                return;
            }
            if (cboMaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloai.Focus();
                return;
            }

            if (cboMachip.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachip.Focus();
                return;
            }

            if (cboMaocung.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaocung.Focus();
                return;
            }
            if (cboMadungluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lĩnh vực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMadungluong.Focus();
                return;
            }
            if (cboMatocdo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMatocdo.Focus();
                return;
            }
            if (cboMacd.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamh.Focus();
                return;
            }
            if (cboMamh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMamh.Focus();
                return;
            }
            if (cboMachuot.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMachuot.Focus();
                return;
            }
            if (cboMabp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMabp.Focus();
                return;
            }
            if (cboMausb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMausb.Focus();
                return;
            }
            if (cboMaram.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaram.Focus();
                return;
            }
            if (cboMaloa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloa.Focus();
                return;
            }
            if (cboMahsx.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngôn ngữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMahsx.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }

     

            sql = "UPDATE tblKhosach SET  Tensach=N'" + txtTenmay.Text.Trim().ToString() +
                "',Maloai=N'" + cboMaloai.SelectedValue.ToString() +
                "',Machip=N'" + cboMachip.SelectedValue.ToString() +
                "',Maocung=N'" + cboMaocung.SelectedValue.ToString() +
                "',Madungluong=N'" + cboMadungluong.SelectedValue.ToString() +
                "',Matocdo=N'" + cboMatocdo.SelectedValue.ToString() +
                "',Macd=N'" + cboMacd.SelectedValue.ToString() +
                "',Mamh=N'" + cboMamh.SelectedValue.ToString() +
                "',Machuot=N'" + cboMachuot.SelectedValue.ToString() +
                "',Mabp=N'" + cboMabp.SelectedValue.ToString() +
                "',Mausb=N'" + cboMausb.SelectedValue.ToString() +
                "',Maram=N'" + cboMaram.SelectedValue.ToString() +
                "',Maloa=N'" + cboMaloa.SelectedValue.ToString() +
                "',Mahsx=N'" + cboMahsx.SelectedValue.ToString() +
                "',Anh='" + txtAnh.Text + "' WHERE Masach=N'" + txtMamay.Text + "'";

               
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }



        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKS.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMamay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblKhomay WHERE Mamay=N'" + txtMamay.Text + "'";
                Functions.RunSqlDel(sql);
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
            txtMamay.Enabled = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaocung.Text == "") && (txtTenmay.Text == "") && (cboMaloai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblKhomay WHERE 1=1";
            if (txtTenmay.Text != "")
                sql = sql + " AND Tenmay Like N'%" + txtTenmay.Text + "%'";
            if (cboMaocung.Text != "")
                sql = sql + " AND Maocung Like N'%" + cboMaocung.SelectedValue + "%'";
            if (cboMaloai.Text != "")
                sql = sql + " AND Maloai Like N'%" + cboMaloai.SelectedValue + "%'";

            tblKS = Functions.GetDataToTable(sql);
            if (tblKS.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKS.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblKS;
            ResetValues();

        }

        private void txtDongianhap_TextChanged(object sender, EventArgs e)
        {
            float Lai = 110 / 100;
            float DGN;
            float DGB;

            if (txtDongianhap.Text.Trim().Length == 0)
                return;
            //Lai = 110%;
            //txtDongia đã được đảm bảo luôn là số
            DGN = Convert.ToInt32(txtDongianhap.Text.Trim());
            DGB = Lai * DGN;

            txtDongiaban.Text = DGB.ToString();
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit((char)e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mamay, Tenmay, Soluong, Dongianhap, Dongiaban, Maloai, Machip, Maocung, Madungluong, Matocdo, Macd, Mamh, Machuot, Mabp, Mausb, Maram, Maloa, Mahsx FROM tblKhosach";
            tblKS = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblKS;

        }
    }
}
