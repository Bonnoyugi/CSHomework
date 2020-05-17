using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crawler
{
    public partial class Form1 : Form
    {
        Crawler crawler = new Crawler();
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            crawler.PageDownloaded += Crawler_PageDownloaded;
        }

        //重要！利用委托机制实现逻辑与窗体的分离，利用invoke处理不同的进程对窗体控件的处理
        private void Crawler_PageDownloaded(Crawler crawler, int index, string url, string info)
        {
            var pageInfo = new { Index = index, URL = url, Status = info };
            Action action = () => { bindingSource1.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bindingSource1.Clear();
            crawler.startUrl = textBox1.Text;
            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(crawler.Start);
            thread.Start();
        }
    }
}
