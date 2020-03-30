namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDraw = new System.Windows.Forms.Button();
            this.tbTrunkLength = new System.Windows.Forms.TextBox();
            this.tbRightLenRate = new System.Windows.Forms.TextBox();
            this.tbLeftLenRate = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnColor = new System.Windows.Forms.Button();
            this.tkbRightAngle = new System.Windows.Forms.TrackBar();
            this.tkbLeftAngle = new System.Windows.Forms.TrackBar();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.state = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRightAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbLeftAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDraw.Location = new System.Drawing.Point(551, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(254, 56);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "开始绘制";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // tbTrunkLength
            // 
            this.tbTrunkLength.Location = new System.Drawing.Point(130, 34);
            this.tbTrunkLength.MaxLength = 10;
            this.tbTrunkLength.Name = "tbTrunkLength";
            this.tbTrunkLength.Size = new System.Drawing.Size(100, 25);
            this.tbTrunkLength.TabIndex = 2;
            this.tbTrunkLength.TextChanged += new System.EventHandler(this.tbTrunkLength_TextChanged);
            this.tbTrunkLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTrunkLength_KeyPress);
            // 
            // tbRightLenRate
            // 
            this.tbRightLenRate.Location = new System.Drawing.Point(130, 189);
            this.tbRightLenRate.Name = "tbRightLenRate";
            this.tbRightLenRate.Size = new System.Drawing.Size(100, 25);
            this.tbRightLenRate.TabIndex = 5;
            this.tbRightLenRate.TextChanged += new System.EventHandler(this.tbRightLenRate_TextChanged);
            this.tbRightLenRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRightLenRate_KeyPress);
            // 
            // tbLeftLenRate
            // 
            this.tbLeftLenRate.Location = new System.Drawing.Point(130, 220);
            this.tbLeftLenRate.Name = "tbLeftLenRate";
            this.tbLeftLenRate.Size = new System.Drawing.Size(100, 25);
            this.tbLeftLenRate.TabIndex = 6;
            this.tbLeftLenRate.TextChanged += new System.EventHandler(this.tbLeftLenRate_TextChanged);
            this.tbLeftLenRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLeftLenRate_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 400);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "递归深度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "主干长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "右分支角度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "左分支角度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "右分支长度比";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "左分支长度比";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "画笔颜色";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbTrunkLength, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbLeftLenRate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbRightLenRate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnColor, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tkbRightAngle, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tkbLeftAngle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudDepth, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(551, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 305);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // btnColor
            // 
            this.btnColor.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnColor.Location = new System.Drawing.Point(130, 251);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 39);
            this.btnColor.TabIndex = 16;
            this.btnColor.Text = "选择颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // tkbRightAngle
            // 
            this.tkbRightAngle.Location = new System.Drawing.Point(130, 65);
            this.tkbRightAngle.Maximum = 120;
            this.tkbRightAngle.Minimum = 1;
            this.tkbRightAngle.Name = "tkbRightAngle";
            this.tkbRightAngle.Size = new System.Drawing.Size(104, 56);
            this.tkbRightAngle.TabIndex = 17;
            this.tkbRightAngle.Value = 1;
            this.tkbRightAngle.Scroll += new System.EventHandler(this.tkbRightAngle_Scroll);
            // 
            // tkbLeftAngle
            // 
            this.tkbLeftAngle.Location = new System.Drawing.Point(130, 127);
            this.tkbLeftAngle.Maximum = 120;
            this.tkbLeftAngle.Minimum = 1;
            this.tkbLeftAngle.Name = "tkbLeftAngle";
            this.tkbLeftAngle.Size = new System.Drawing.Size(104, 56);
            this.tkbLeftAngle.TabIndex = 18;
            this.tkbLeftAngle.Value = 1;
            this.tkbLeftAngle.Scroll += new System.EventHandler(this.tkbLeftAngle_Scroll);
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(130, 3);
            this.nudDepth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(120, 25);
            this.nudDepth.TabIndex = 19;
            this.nudDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDepth.ValueChanged += new System.EventHandler(this.nudDeoth_ValueChanged);
            // 
            // state
            // 
            this.state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.state.AutoSize = true;
            this.state.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.state.Location = new System.Drawing.Point(657, 386);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(148, 30);
            this.state.TabIndex = 17;
            this.state.Text = "绘制中...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 425);
            this.Controls.Add(this.state);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDraw);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "CayleyTree";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbRightAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbLeftAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox tbTrunkLength;
        private System.Windows.Forms.TextBox tbRightLenRate;
        private System.Windows.Forms.TextBox tbLeftLenRate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TrackBar tkbRightAngle;
        private System.Windows.Forms.TrackBar tkbLeftAngle;
        private System.Windows.Forms.NumericUpDown nudDepth;
    }
}

