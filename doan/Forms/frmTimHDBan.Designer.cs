namespace doan.Forms
{
    partial class frmTimHDBan
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
            this.label5 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMm = new System.Windows.Forms.ComboBox();
            this.cboHDB = new System.Windows.Forms.ComboBox();
            this.cboMNV = new System.Windows.Forms.ComboBox();
            this.cboMK = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Số HĐB";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(360, 343);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 92;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimlai
            // 
            this.btnTimlai.Location = new System.Drawing.Point(218, 343);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(75, 23);
            this.btnTimlai.TabIndex = 91;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(81, 343);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimkiem.TabIndex = 90;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(39, 184);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(470, 125);
            this.DataGridView.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Năm";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(218, 143);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(75, 20);
            this.txtNam.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Tháng";
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(132, 143);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(42, 20);
            this.txtThang.TabIndex = 85;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Mã máy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 26);
            this.label1.TabIndex = 82;
            this.label1.Text = "TÌM HÓA ĐƠN BÁN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Mã nhân viên";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Mã khách";
            // 
            // cboMm
            // 
            this.cboMm.FormattingEnabled = true;
            this.cboMm.Location = new System.Drawing.Point(131, 109);
            this.cboMm.Name = "cboMm";
            this.cboMm.Size = new System.Drawing.Size(182, 21);
            this.cboMm.TabIndex = 100;
            // 
            // cboHDB
            // 
            this.cboHDB.FormattingEnabled = true;
            this.cboHDB.Location = new System.Drawing.Point(132, 79);
            this.cboHDB.Name = "cboHDB";
            this.cboHDB.Size = new System.Drawing.Size(181, 21);
            this.cboHDB.TabIndex = 99;
            // 
            // cboMNV
            // 
            this.cboMNV.FormattingEnabled = true;
            this.cboMNV.Location = new System.Drawing.Point(464, 77);
            this.cboMNV.Name = "cboMNV";
            this.cboMNV.Size = new System.Drawing.Size(121, 21);
            this.cboMNV.TabIndex = 101;
            // 
            // cboMK
            // 
            this.cboMK.FormattingEnabled = true;
            this.cboMK.Location = new System.Drawing.Point(464, 106);
            this.cboMK.Name = "cboMK";
            this.cboMK.Size = new System.Drawing.Size(121, 21);
            this.cboMK.TabIndex = 102;
            // 
            // frmTimHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 401);
            this.Controls.Add(this.cboMK);
            this.Controls.Add(this.cboMNV);
            this.Controls.Add(this.cboMm);
            this.Controls.Add(this.cboHDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTimHDBan";
            this.Text = "frmTimHDBan";
            this.Load += new System.EventHandler(this.frmTimHDBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMm;
        private System.Windows.Forms.ComboBox cboHDB;
        private System.Windows.Forms.ComboBox cboMNV;
        private System.Windows.Forms.ComboBox cboMK;
    }
}