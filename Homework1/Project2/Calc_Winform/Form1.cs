using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Winform
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            Buttons = new Button[4];
            Buttons[0] = button1; //加
            Buttons[1] = button2; //乘
            Buttons[2] = button3; //减
            Buttons[3] = button4; //除
            Buttons[3].Enabled = false;//除数为0时禁止除法
        }

        //第一个参数
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != parameter1.ToString())
            {
                //填入空值
                if("" == textBox1.Text)
                {
                    parameter1 = 0;
                    textBox1.Text = "0";
                    resultBox.Text = result.ToString();
                }
                //检测输入值是否合法
                try
                {
                    parameter1 = Convert.ToDouble(textBox1.Text);
                    resultBox.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    resultBox.Text = ex.Message;
                    textBox1.Text = parameter1.ToString();
                }
            }
        }

        //第二个参数
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //除数不能为0
            if (4 == sign && (0 == Convert.ToDouble(textBox2.Text)|| "" == textBox2.Text))
            {
                resultBox.Text = "除数不能为0";
                textBox2.Text = parameter2.ToString();
            }
            //正常输入
            else if (textBox2.Text != parameter2.ToString())
            {
                //填入空值
                if ("" == textBox2.Text)
                {
                    parameter2 = 0;
                    textBox2.Text = "0";
                    resultBox.Text = result.ToString();
                }
                //检测输入值是否合法
                try
                {
                    parameter2 = Convert.ToDouble(textBox2.Text);
                    resultBox.Text = result.ToString();
                }
                catch (Exception ex)
                {
                    resultBox.Text = ex.Message;
                    textBox2.Text = parameter2.ToString();
                }
                if (0 == parameter2)
                {
                    Buttons[3].Enabled = false;
                }
                else if(false == Buttons[3].Enabled)
                {
                    Buttons[3].Enabled = true;
                }
            }
        }

        //复制结果到剪切板
        private void result_Click(object sender, EventArgs e)
        {
            if (resultBox.Text.Equals(result.ToString()))
            {
                Clipboard.SetText(result.ToString());
                resultBox.Text = "结果已复制到剪切板";
            }
        }

        //加
        private void button1_Click(object sender, EventArgs e)
        {
            if(sign!=0)
                Buttons[sign-1].BackColor = Color.Gainsboro;
            sign = 1;
            button1.BackColor = Color.LightSteelBlue;
        }

        //减
        private void button3_Click(object sender, EventArgs e)
        {
            if (sign != 0)
                Buttons[sign - 1].BackColor = Color.Gainsboro;
            sign = 3;
            button3.BackColor = Color.LightSteelBlue;
        }

        //乘
        private void button2_Click(object sender, EventArgs e)
        {
            if (sign != 0)
                Buttons[sign - 1].BackColor = Color.Gainsboro;
            sign = 2;
            button2.BackColor = Color.LightSteelBlue;
        }

        //除
        private void button4_Click(object sender, EventArgs e)
        {
            if (sign != 0)
                Buttons[sign - 1].BackColor = Color.Gainsboro;
            sign = 4;
            button4.BackColor = Color.LightSteelBlue;
        }

        //计算结果
        private void button5_Click(object sender, EventArgs e)
        {
            switch (sign)
            {
                case 1:
                    result = parameter1 + parameter2;
                    break;
                case 2:
                    result = parameter1 * parameter2;
                    break;
                case 3:
                    result = parameter1 - parameter2;
                    break;
                case 4:
                    result = parameter1 / parameter2;
                    break;
                default:
                    break;
            }
            if (sign != 0)
            {
                resultBox.Text = result.ToString();
                Buttons[sign - 1].BackColor = Color.Gainsboro;
            }
            else
            {
                resultBox.Text = "未选择操作符";
            }
            sign = 0;
        }

        private double parameter1=0,parameter2=0,result=double.NaN;

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        int sign = 0;//加1乘2减3除4
        Button[] Buttons;
    }
}
