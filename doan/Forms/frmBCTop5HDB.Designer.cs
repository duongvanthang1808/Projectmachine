namespace doan.Forms
{
    partial class frmBCTop5HDB
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
            this.dvgBanHang = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnBaocao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgBanHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(565, 26);
            this.label3.TabIndex = 39;
            this.label3.Text = "TOP 5 HÓA ĐƠN CÓ TỔNG TIỀN BÁN LỚN NHẤT";
            // 
            // dvgBanHang
            // 
            this.dvgBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgBanHang.Location = new System.Drawing.Point(46, 130);
            this.dvgBanHang.Name = "dvgBanHang";
            this.dvgBanHang.Size = new System.Drawing.Size(544, 150);
            this.dvgBanHang.TabIndex = 38;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(514, 310);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 31);
            this.btnDong.TabIndex = 37;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(274, 310);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(75, 31);
            this.btnBoqua.TabIndex = 36;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = true;
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(46, 310);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(75, 31);
            this.btnBaocao.TabIndex = 35;
            this.btnBaocao.Text = "Báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // frmBCTop5HDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 362);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dvgBanHang);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnBaocao);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmBCTop5HDN";
            this.Text = "frmBCTop5HDN";
            this.Load += new System.EventHandler(this.frmBCTop5HDN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgBanHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dvgBanHang;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnBaocao;
    }
}