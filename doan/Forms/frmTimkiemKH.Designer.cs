namespace doan.Forms
{
    partial class frmTimkiemKH
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
            this.btnTimlai = new System.Windows.Forms.Button();
            this.cboMaKH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimlai
            // 
            this.btnTimlai.Location = new System.Drawing.Point(296, 387);
            this.btnTimlai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(100, 28);
            this.btnTimlai.TabIndex = 104;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.UseVisualStyleBackColor = true;
            // 
            // cboMaKH
            // 
            this.cboMaKH.FormattingEnabled = true;
            this.cboMaKH.Location = new System.Drawing.Point(250, 128);
            this.cboMaKH.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaKH.Name = "cboMaKH";
            this.cboMaKH.Size = new System.Drawing.Size(241, 24);
            this.cboMaKH.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 102;
            this.label5.Text = "Mã KH";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(440, 385);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.TabIndex = 101;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(152, 385);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimkiem.TabIndex = 100;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(32, 203);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(627, 154);
            this.DataGridView.TabIndex = 99;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(250, 161);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(241, 22);
            this.txtTenKH.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 97;
            this.label6.Text = "Tên KH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 35);
            this.label1.TabIndex = 96;
            this.label1.Text = "TÌM KIẾM KHÁCH HÀNG";
            // 
            // frmTimkiemKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 457);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.cboMaKH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "frmTimkiemKH";
            this.Text = "frmTimkiemKH";
            this.Load += new System.EventHandler(this.frmTimkiemKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.ComboBox cboMaKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}