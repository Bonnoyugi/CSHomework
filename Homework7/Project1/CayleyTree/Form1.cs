//待改进的地方：锁和解锁在不同的地方进行，可能会导致程序锁死

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (leng>200||leng<20)
            {
                MessageBox.Show("主干长度只能取值于20至200之间", "主干长度错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (per1 > 1 || per2 > 1)
            {
                MessageBox.Show("分支长度比只能取值0至1之间", "分支长度错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowDefaultInfo();
            LockAll();
            if (graphics == null) graphics = this.panel1.CreateGraphics();
            if (graphics != null) graphics.Clear(panel1.BackColor);
            drawCayleyTree(depth, panel1.Width/2, panel1.Height-20, leng, -Math.PI / 2);
        }

        private Graphics graphics;
        int depth = 10;//递归深度
        double leng = 100;//主干长度
        int th1 = 30;//左分支角度
        int th2 = 20;//右分支角度
        double per1 = 0.6;//右分支长度比
        double per2 = 0.7;//左分支长度比 
        Pen pen = new Pen(Color.Blue);

        void LockAll()
        {
            btnDraw.Enabled = false;
            nudDepth.Enabled = false;
            tbTrunkLength.Enabled = false;
            tkbRightAngle.Enabled = false;
            tkbLeftAngle.Enabled = false;
            tbRightLenRate.Enabled = false;
            tbLeftLenRate.Enabled = false;
            btnColor.Enabled = false;
            state.Visible = true;//貌似没有其他的状态，考虑性能用可见性代替字符更改
            Update();
        }

        void UnlockAll()
        {
            btnDraw.Enabled = true;
            nudDepth.Enabled = true;
            tbTrunkLength.Enabled = true;
            tkbRightAngle.Enabled = true;
            tkbLeftAngle.Enabled = true;
            tbRightLenRate.Enabled = true;
            tbLeftLenRate.Enabled = true;
            btnColor.Enabled = true;
            state.Visible = false;
            Update();
        }

        void ShowDefaultInfo()
        {
            nudDepth.Value = depth;
            tbTrunkLength.Text = leng.ToString();
            tkbRightAngle.Value = th1;
            tkbLeftAngle.Value = th2;
            tbRightLenRate.Text = per1.ToString();
            tbLeftLenRate.Text = per2.ToString();
            btnColor.BackColor = pen.Color;
            btnColor.ForeColor = Color.FromArgb(Color.White.ToArgb() - pen.Color.ToArgb());
            Update();
        }

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;//n不能为0，否则不会被解锁

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1 * Math.PI / 180);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2 * Math.PI / 180);

            if (n == depth)
            {
                UnlockAll();
            }
        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            Application.DoEvents();//绘制时间较长时，为避免缓冲区内的输入在按钮enable后被响应，所以在绘制时(此时locked控件为disabled)处理这些输入
            graphics.DrawLine(
                pen,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void tbTrunkLength_TextChanged(object sender, EventArgs e)
        {
            TextboxAddZero(tbTrunkLength);
            if(tbTrunkLength.Text!="")
                leng = Double.Parse(tbTrunkLength.Text.ToString());
        }

        private void TextboxAddZero(TextBox tb)
        {
            if (tb.Text.StartsWith("."))
            {
                tb.Text = tbTrunkLength.Text.Insert(0, "0");
                tb.Select(tbTrunkLength.Text.Length, 0);
            }
        }

        private void tbTrunkLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextboxInputDouble(e, tbTrunkLength);
        }

        private void TextboxInputDouble(KeyPressEventArgs e, TextBox tb)
        {
            if ((!(Char.IsNumber(e.KeyChar))) && (e.KeyChar != (char)8) && (e.KeyChar != (char)46))//只允许数字、小数点和backspace
            {
                e.Handled = true;
            }
            else if ((int)e.KeyChar == 46 && tb.Text.Contains((char)46))//只允许一个小数点，关于小数点位置等判断，在TextChanged依照相应要求补充！
            {
                e.Handled = true;
            }
        }

        private void tbRightLenRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextboxInputDouble(e, tbRightLenRate);
        }

        private void tbRightLenRate_TextChanged(object sender, EventArgs e)
        {
            TextboxAddZero(tbRightLenRate);
            if (tbRightLenRate.Text != "")
                per1 = Double.Parse(tbRightLenRate.Text.ToString());
        }

        private void tbLeftLenRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextboxInputDouble(e, tbLeftLenRate);
        }

        private void tbLeftLenRate_TextChanged(object sender, EventArgs e)
        {
            TextboxAddZero(tbLeftLenRate);
            if (tbLeftLenRate.Text != "")
                per2 = Double.Parse(tbLeftLenRate.Text.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDefaultInfo();
            state.Visible = false;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            pen.Color = colorDialog.Color;
            btnColor.BackColor = pen.Color;
            btnColor.ForeColor = Color.FromArgb(Color.White.ToArgb() - pen.Color.ToArgb());
        }

        private void nudDeoth_ValueChanged(object sender, EventArgs e)
        {
            depth = (int)nudDepth.Value;
        }

        private void tkbRightAngle_Scroll(object sender, EventArgs e)
        {
            th1 = tkbRightAngle.Value;
        }

        private void tkbLeftAngle_Scroll(object sender, EventArgs e)
        {
            th2 = tkbLeftAngle.Value;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            graphics = this.panel1.CreateGraphics();
        }
    }
}
