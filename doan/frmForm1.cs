using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace doan
{
    public partial class frmForm1 : Form
    {
        public frmForm1()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNhanvien f = new Forms.frmNhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmKhachhang f = new Forms.frmKhachhang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmNhacungcap f = new Forms.frmNhacungcap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hãngSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHangsanxuat f = new Forms.frmHangsanxuat();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

      

        private void loạiỔCứngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmOcung f = new Forms.frmOcung();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void loạiDungLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmDungluong f = new Forms.frmDungluong();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tốcĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTocdo f = new Forms.frmTocdo();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void ổCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmOcd f = new Forms.frmOcd();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void chuộtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChuot f = new Forms.frmChuot();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void khoMáyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmKhomay f = new Forms.frmKhomay();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void cỡMànHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmComh f = new Forms.frmComh();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void loạiMànHìnhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmManhinh f = new Forms.frmManhinh();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

      

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmCongviec f = new Forms.frmCongviec();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHoadonnhap f = new Forms.frmHoadonnhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void chiTiếtHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChitietHDN f = new Forms.frmChitietHDN();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmHoadonban f = new Forms.frmHoadonban();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void chiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChitietHDB f = new Forms.frmChitietHDB();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmTimHDN f = new Forms.frmTimHDN();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void tìmKiếmKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmTimkiemKH f = new Forms.frmTimkiemKH();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnBánMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBCBanmay f = new Forms.frmBCBanmay();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void máyKhôngBánĐượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBCNhapmay f = new Forms.frmBCNhapmay();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void top5HóaĐơnMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBCTop5HDB f = new Forms.frmBCTop5HDB();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void khácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loạiRAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmRam f = new Forms.frmRam();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void uSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmUsb f = new Forms.frmUsb();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void bànPhímToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBanphim f = new Forms.frmBanphim();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void loạiMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmLoaimay f = new Forms.frmLoaimay();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void frmForm1_Load(object sender, EventArgs e)
        {

        }

        private void loaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmLoa f = new Forms.frmLoa();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void chipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmChip f = new Forms.frmChip();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnNhậpMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frmBCmaykhongbanduoc f = new Forms.frmBCmaykhongbanduoc();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void hóaĐơnBánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frmTimHDBan f = new Forms.frmTimHDBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
