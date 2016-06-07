namespace doan.Forms
{
    partial class frmBCNhapmay
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboQuy = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.dvgBanHang = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgBanHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(464, 26);
            this.label3.TabIndex = 34;
            this.label3.Text = "BÁO CÁO DANH SÁCH HÓA ĐƠN NHẬP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Chọn năm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Chọn quý :";
            // 
            // cboQuy
            // 
            this.cboQuy.FormattingEnabled = true;
            this.cboQuy.Location = new System.Drawing.Point(332, 101);
            this.cboQuy.Name = "cboQuy";
            this.cboQuy.Size = new System.Drawing.Size(101, 21);
            this.cboQuy.TabIndex = 31;
            this.cboQuy.SelectedIndexChanged += new System.EventHandler(this.cboQuy_SelectedIndexChanged);
            // 
            // cboNam
            // 
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(545, 101);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(101, 21);
            this.cboNam.TabIndex = 30;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(243, 289);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 31);
            this.btnIn.TabIndex = 29;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // dvgBanHang
            // 
            this.dvgBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgBanHang.Location = new System.Drawing.Point(62, 156);
            this.dvgBanHang.Name = "dvgBanHang";
            this.dvgBanHang.Size = new System.Drawing.Size(570, 125);
            this.dvgBanHang.TabIndex = 28;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(517, 289);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 31);
            this.btnDong.TabIndex = 27;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(379, 289);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(75, 31);
            this.btnBoqua.TabIndex = 26;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(109, 289);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(75, 31);
            this.btnBaocao.TabIndex = 25;
            this.btnBaocao.Text = "Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Chọn tháng :";
            // 
            // cboThang
            // 
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(139, 101);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(101, 21);
            this.cboThang.TabIndex = 35;
            //this.cboThang.SelectedIndexChanged += new System.EventHandler(this.cboThang_SelectedIndexChanged);
            // 
            // frmBCNhapmay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 332);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboQuy);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dvgBanHang);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnBaocao);
            this.Name = "frmBCNhapmay";
            this.Text = "frmNhapmay";
            this.Load += new System.EventHandler(this.frmBCNhapmay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgBanHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboQuy;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridView dvgBanHang;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnBaocao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboThang;
    }
}