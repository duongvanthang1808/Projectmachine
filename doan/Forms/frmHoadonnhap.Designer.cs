namespace doan.Forms
{
    partial class frmHoadonnhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDienthoai = new System.Windows.Forms.TextBox();
            this.txtDiachi = new System.Windows.Forms.TextBox();
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTennhanvien = new System.Windows.Forms.TextBox();
            this.txtNgaynhap = new System.Windows.Forms.TextBox();
            this.cboManhanvien = new System.Windows.Forms.ComboBox();
            this.txtMaHDNhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDongianhap = new System.Windows.Forms.TextBox();
            this.txtThanhtien = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtGiamgia = new System.Windows.Forms.TextBox();
            this.txtTenhang = new System.Windows.Forms.TextBox();
            this.cboMaHDNhap = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMamay = new System.Windows.Forms.ComboBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.DataGridViewChitiet = new System.Windows.Forms.DataGridView();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblBangchu = new System.Windows.Forms.Label();
            this.btnThemmoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoaHD = new System.Windows.Forms.Button();
            this.btnInhoadon = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewChitiet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDienthoai
            // 
            this.txtDienthoai.Location = new System.Drawing.Point(446, 119);
            this.txtDienthoai.Margin = new System.Windows.Forms.Padding(4);
            this.txtDienthoai.Name = "txtDienthoai";
            this.txtDienthoai.Size = new System.Drawing.Size(160, 20);
            this.txtDienthoai.TabIndex = 9;
            // 
            // txtDiachi
            // 
            this.txtDiachi.Location = new System.Drawing.Point(446, 87);
            this.txtDiachi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiachi.Name = "txtDiachi";
            this.txtDiachi.Size = new System.Drawing.Size(160, 20);
            this.txtDiachi.TabIndex = 8;
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Location = new System.Drawing.Point(446, 29);
            this.cboMaNCC.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(160, 21);
            this.cboMaNCC.TabIndex = 2;
            this.cboMaNCC.SelectedIndexChanged += new System.EventHandler(this.cboMaNCC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(300, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "HÓA ĐƠN NHẬP HÀNG";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(446, 58);
            this.txtTenNCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(160, 20);
            this.txtTenNCC.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mã NCC:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDienthoai);
            this.groupBox1.Controls.Add(this.txtDiachi);
            this.groupBox1.Controls.Add(this.txtTenNCC);
            this.groupBox1.Controls.Add(this.cboMaNCC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTennhanvien);
            this.groupBox1.Controls.Add(this.txtNgaynhap);
            this.groupBox1.Controls.Add(this.cboManhanvien);
            this.groupBox1.Controls.Add(this.txtMaHDNhap);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(45, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(691, 154);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tên NCC:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Địa chỉ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Điện thoại";
            // 
            // txtTennhanvien
            // 
            this.txtTennhanvien.Location = new System.Drawing.Point(137, 120);
            this.txtTennhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.txtTennhanvien.Name = "txtTennhanvien";
            this.txtTennhanvien.Size = new System.Drawing.Size(165, 20);
            this.txtTennhanvien.TabIndex = 2;
            // 
            // txtNgaynhap
            // 
            this.txtNgaynhap.Location = new System.Drawing.Point(137, 58);
            this.txtNgaynhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgaynhap.Name = "txtNgaynhap";
            this.txtNgaynhap.Size = new System.Drawing.Size(165, 20);
            this.txtNgaynhap.TabIndex = 4;
            // 
            // cboManhanvien
            // 
            this.cboManhanvien.FormattingEnabled = true;
            this.cboManhanvien.Location = new System.Drawing.Point(137, 91);
            this.cboManhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.cboManhanvien.Name = "cboManhanvien";
            this.cboManhanvien.Size = new System.Drawing.Size(165, 21);
            this.cboManhanvien.TabIndex = 3;
            this.cboManhanvien.SelectedIndexChanged += new System.EventHandler(this.cboManhanvien_TextChanged_1);
            // 
            // txtMaHDNhap
            // 
            this.txtMaHDNhap.Location = new System.Drawing.Point(137, 28);
            this.txtMaHDNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHDNhap.Name = "txtMaHDNhap";
            this.txtMaHDNhap.Size = new System.Drawing.Size(165, 20);
            this.txtMaHDNhap.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số hóa đơn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã nhân viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tên nhân viên:";
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimkiem.Location = new System.Drawing.Point(341, 578);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimkiem.TabIndex = 54;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(451, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Đơn giá";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(451, 69);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Thành tiền";
            // 
            // txtDongianhap
            // 
            this.txtDongianhap.Location = new System.Drawing.Point(536, 28);
            this.txtDongianhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtDongianhap.Name = "txtDongianhap";
            this.txtDongianhap.Size = new System.Drawing.Size(132, 20);
            this.txtDongianhap.TabIndex = 3;
            // 
            // txtThanhtien
            // 
            this.txtThanhtien.Location = new System.Drawing.Point(536, 65);
            this.txtThanhtien.Margin = new System.Windows.Forms.Padding(4);
            this.txtThanhtien.Name = "txtThanhtien";
            this.txtThanhtien.Size = new System.Drawing.Size(132, 20);
            this.txtThanhtien.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 69);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Giảm giá %";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(506, 476);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 48;
            this.label18.Text = "Tổng tiền:";
            // 
            // txtGiamgia
            // 
            this.txtGiamgia.Location = new System.Drawing.Point(317, 65);
            this.txtGiamgia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiamgia.Name = "txtGiamgia";
            this.txtGiamgia.Size = new System.Drawing.Size(124, 20);
            this.txtGiamgia.TabIndex = 3;
            this.txtGiamgia.TextChanged += new System.EventHandler(this.txtGiamgia_TextChanged_1);
            // 
            // txtTenhang
            // 
            this.txtTenhang.Location = new System.Drawing.Point(317, 28);
            this.txtTenhang.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenhang.Name = "txtTenhang";
            this.txtTenhang.Size = new System.Drawing.Size(124, 20);
            this.txtTenhang.TabIndex = 4;
            // 
            // cboMaHDNhap
            // 
            this.cboMaHDNhap.FormattingEnabled = true;
            this.cboMaHDNhap.Location = new System.Drawing.Point(129, 582);
            this.cboMaHDNhap.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaHDNhap.Name = "cboMaHDNhap";
            this.cboMaHDNhap.Size = new System.Drawing.Size(200, 21);
            this.cboMaHDNhap.TabIndex = 53;
            //this.cboMaHDNhap.SelectedIndexChanged += new System.EventHandler(this.cboMaHDNhap_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Mã máy:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(30, 584);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 13);
            this.label19.TabIndex = 52;
            this.label19.Text = "Mã hóa đơn:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtDongianhap);
            this.groupBox2.Controls.Add(this.txtThanhtien);
            this.groupBox2.Controls.Add(this.txtGiamgia);
            this.groupBox2.Controls.Add(this.txtTenhang);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboMamay);
            this.groupBox2.Controls.Add(this.txtSoluong);
            this.groupBox2.Location = new System.Drawing.Point(45, 186);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(691, 102);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin các mặt hàng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 32);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tên hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 69);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Số lượng:";
            // 
            // cboMamay
            // 
            this.cboMamay.FormattingEnabled = true;
            this.cboMamay.Location = new System.Drawing.Point(103, 28);
            this.cboMamay.Margin = new System.Windows.Forms.Padding(4);
            this.cboMamay.Name = "cboMamay";
            this.cboMamay.Size = new System.Drawing.Size(113, 21);
            this.cboMamay.TabIndex = 5;
            this.cboMamay.SelectedIndexChanged += new System.EventHandler(this.cboMamay_TextChanged);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(103, 65);
            this.txtSoluong.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(113, 20);
            this.txtSoluong.TabIndex = 6;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged_1);
            // 
            // DataGridViewChitiet
            // 
            this.DataGridViewChitiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewChitiet.Location = new System.Drawing.Point(45, 297);
            this.DataGridViewChitiet.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewChitiet.Name = "DataGridViewChitiet";
            this.DataGridViewChitiet.Size = new System.Drawing.Size(691, 156);
            this.DataGridViewChitiet.TabIndex = 50;
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(604, 474);
            this.txtTongtien.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(132, 20);
            this.txtTongtien.TabIndex = 49;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(42, 474);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 13);
            this.label16.TabIndex = 47;
            this.label16.Text = "Kích đúp một dòng hàng để xóa";
            // 
            // lblBangchu
            // 
            this.lblBangchu.AutoSize = true;
            this.lblBangchu.Location = new System.Drawing.Point(42, 509);
            this.lblBangchu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBangchu.Name = "lblBangchu";
            this.lblBangchu.Size = new System.Drawing.Size(56, 13);
            this.lblBangchu.TabIndex = 46;
            this.lblBangchu.Text = "Bằng chữ:";
            // 
            // btnThemmoi
            // 
            this.btnThemmoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemmoi.Location = new System.Drawing.Point(28, 540);
            this.btnThemmoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemmoi.Name = "btnThemmoi";
            this.btnThemmoi.Size = new System.Drawing.Size(131, 28);
            this.btnThemmoi.TabIndex = 45;
            this.btnThemmoi.Text = "Thêm hóa đơn";
            this.btnThemmoi.UseVisualStyleBackColor = true;
            this.btnThemmoi.Click += new System.EventHandler(this.btnThemmoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(192, 540);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 28);
            this.btnLuu.TabIndex = 44;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoaHD
            // 
            this.btnXoaHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaHD.Location = new System.Drawing.Point(304, 540);
            this.btnXoaHD.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaHD.Name = "btnXoaHD";
            this.btnXoaHD.Size = new System.Drawing.Size(120, 28);
            this.btnXoaHD.TabIndex = 43;
            this.btnXoaHD.Text = "Hủy hóa đơn";
            this.btnXoaHD.UseVisualStyleBackColor = true;
            this.btnXoaHD.Click += new System.EventHandler(this.btnXoaHD_Click);
            // 
            // btnInhoadon
            // 
            this.btnInhoadon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInhoadon.Location = new System.Drawing.Point(479, 540);
            this.btnInhoadon.Margin = new System.Windows.Forms.Padding(4);
            this.btnInhoadon.Name = "btnInhoadon";
            this.btnInhoadon.Size = new System.Drawing.Size(100, 28);
            this.btnInhoadon.TabIndex = 42;
            this.btnInhoadon.Text = "In hóa đơn";
            this.btnInhoadon.UseVisualStyleBackColor = true;
            this.btnInhoadon.Click += new System.EventHandler(this.btnInhoadon_Click);
            // 
            // btnDong
            // 
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(636, 540);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.TabIndex = 41;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmHoadonnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 602);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cboMaHDNhap);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DataGridViewChitiet);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblBangchu);
            this.Controls.Add(this.btnThemmoi);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoaHD);
            this.Controls.Add(this.btnInhoadon);
            this.Controls.Add(this.btnDong);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHoadonnhap";
            this.Text = "Hoadonnhap";
            this.Load += new System.EventHandler(this.frmHoadonnhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewChitiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDienthoai;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTennhanvien;
        private System.Windows.Forms.TextBox txtNgaynhap;
        private System.Windows.Forms.ComboBox cboManhanvien;
        public System.Windows.Forms.TextBox txtMaHDNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDongianhap;
        private System.Windows.Forms.TextBox txtThanhtien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGiamgia;
        private System.Windows.Forms.TextBox txtTenhang;
        private System.Windows.Forms.ComboBox cboMaHDNhap;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboMamay;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.DataGridView DataGridViewChitiet;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblBangchu;
        private System.Windows.Forms.Button btnThemmoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoaHD;
        private System.Windows.Forms.Button btnInhoadon;
        private System.Windows.Forms.Button btnDong;
    }
}