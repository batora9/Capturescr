using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Capturescr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NativeMethods.SetProcessDPIAware(); // 最初に呼び出す
        }
        static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern bool SetProcessDPIAware();
        }


        private void topviewmenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //チェック状態を反転させる
            item.Checked = !item.Checked;
            if (topviewmenu.Checked == true)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Panelオブジェクトの作成
            Panel panel1 = new Panel();
            panel1.Size = new Size(200, 200);
            //スクロールバーが表示されるようにする
            panel1.AutoScroll = true;

            //PictureBoxオブジェクトの作成
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(0, 0);
            //画像を表示するとき、画像の大きさに合わせて
            //PictureBoxの大きさが変更させるようにする
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            //pictureBox1をpanel1にのせる
            panel1.Controls.Add(pictureBox1);
            //panel1をこのフォームにのせる
            this.Controls.Add(panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(bmp);
            //画面のコピー
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
            g.Dispose();

            //表示
            pictureBox1.Image = bmp;
        }

        private void deletepicmenu_Click(object sender, EventArgs e)
        {
            //pictureBox1に表示されている画像を消す
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
