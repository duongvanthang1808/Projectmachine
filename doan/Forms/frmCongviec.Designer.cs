namespace doan.Forms
{
    partial class frmCongviec
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTencv = new System.Windows.Forms.TextBox();
            this.txtMacv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vd = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 26);
            this.label1.TabIndex = 36;
            this.label1.Text = "QUẢN LÝ CÔNG VIỆC";
            // 
            // txtTencv
            // 
            this.txtTencv.Location = new System.Drawing.Point(373, 93);
            this.txtTencv.Name = "txtTencv";
            this.txtTencv.Size = new System.Drawing.Size(176, 20);
            this.txtTencv.TabIndex = 35;
            // 
            // txtMacv
            // 
            this.txtMacv.Location = new System.Drawing.Point(124, 93);
            this.txtMacv.Name = "txtMacv";
            this.txtMacv.Size = new System.Drawing.Size(165, 20);
            this.txtMacv.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Tên công việc";
            // 
            // vd
            // 
            this.vd.AutoSize = true;
            this.vd.Location = new System.Drawing.Point(46, 96);
            this.vd.Name = "vd";
            this.vd.Size = new System.Drawing.Size(72, 13);
            this.vd.TabIndex = 32;
            this.vd.Text = "Mã công việc";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(470, 275);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(79, 23);
            this.btnDong.TabIndex = 31;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(384, 275);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(79, 23);
            this.btnBoqua.TabIndex = 30;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(292, 275);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(79, 23);
            this.btnLuu.TabIndex = 29;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(205, 275);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(79, 23);
            this.btnSua.TabIndex = 28;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(120, 275);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(79, 23);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(28, 275);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(81, 23);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(28, 137);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(520, 125);
            this.DataGridView.TabIndex = 25;
            this.DataGridView.Click += new System.EventHandler(this.DataGridView_Click);
            // 
            // frmCongviec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 349);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTencv);
            this.Controls.Add(this.txtMacv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vd);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.DataGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCongviec";
            this.Text = "frmCongviec";
            this.Load += new System.EventHandler(this.frmCongViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTencv;
        private System.Windows.Forms.TextBox txtMacv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label vd;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView DataGridView;
    }
}