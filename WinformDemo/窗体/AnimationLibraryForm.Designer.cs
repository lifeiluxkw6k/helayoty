namespace WinformDemo
{
    partial class AnimationLibraryForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            WcleAnimationLibrary.AnimationTimer animationTimer1 = new WcleAnimationLibrary.AnimationTimer();
            WcleAnimationLibrary.AnimationOptions animationOptions1 = new WcleAnimationLibrary.AnimationOptions();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.animationType_cb = new System.Windows.Forms.ComboBox();
            this.startbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.x_nud = new System.Windows.Forms.NumericUpDown();
            this.time_nud = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.resetbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.amplitude_nud = new System.Windows.Forms.NumericUpDown();
            this.in_rb = new System.Windows.Forms.RadioButton();
            this.out_rb = new System.Windows.Forms.RadioButton();
            this.inout_rb = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exponent_nud = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.power_nud = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.oscillations_nud = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.springiness_nud = new System.Windows.Forms.NumericUpDown();
            this.bounces_nud = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.bounciness_nud = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.draw = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.animationComponent1 = new WinformControlLibraryExtension.AnimationComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitude_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exponent_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.power_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscillations_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.springiness_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bounces_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bounciness_nud)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BorderSkin.BorderColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.Title = "动画时间（毫秒）";
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.InterlacedColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.Title = "动画进度";
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea1.BorderColor = System.Drawing.Color.DarkGray;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.DarkGray;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(9, 120);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(134)))), ((int)(((byte)(250)))));
            series1.CustomProperties = "IsXAxisQuantitative=False";
            series1.EmptyPointStyle.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(134)))), ((int)(((byte)(250)))));
            series1.MarkerSize = 3;
            series1.Name = "Series1";
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(763, 339);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // animationType_cb
            // 
            this.animationType_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationType_cb.FormattingEnabled = true;
            this.animationType_cb.Items.AddRange(new object[] {
            "UniformMotion",
            "Ease",
            "Back",
            "Bounce",
            "Elastic",
            "Quadratic"});
            this.animationType_cb.Location = new System.Drawing.Point(69, 14);
            this.animationType_cb.Name = "animationType_cb";
            this.animationType_cb.Size = new System.Drawing.Size(138, 20);
            this.animationType_cb.TabIndex = 2;
            // 
            // startbtn
            // 
            this.startbtn.Location = new System.Drawing.Point(58, 558);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(75, 23);
            this.startbtn.TabIndex = 3;
            this.startbtn.Text = "动画开始";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "动画函数：";
            // 
            // x_nud
            // 
            this.x_nud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.x_nud.Location = new System.Drawing.Point(84, 471);
            this.x_nud.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.x_nud.Name = "x_nud";
            this.x_nud.Size = new System.Drawing.Size(49, 21);
            this.x_nud.TabIndex = 5;
            this.x_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x_nud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // time_nud
            // 
            this.time_nud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.time_nud.Location = new System.Drawing.Point(84, 498);
            this.time_nud.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.time_nud.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.time_nud.Name = "time_nud";
            this.time_nud.Size = new System.Drawing.Size(49, 21);
            this.time_nud.TabIndex = 6;
            this.time_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.time_nud.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "移动距离：";
            // 
            // resetbtn
            // 
            this.resetbtn.Location = new System.Drawing.Point(58, 525);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(75, 23);
            this.resetbtn.TabIndex = 9;
            this.resetbtn.Text = "动画复位";
            this.resetbtn.UseVisualStyleBackColor = true;
            this.resetbtn.Click += new System.EventHandler(this.resetbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.animationTime_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "回弹收缩的幅度（1）：";
            // 
            // amplitude_nud
            // 
            this.amplitude_nud.DecimalPlaces = 1;
            this.amplitude_nud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.amplitude_nud.Location = new System.Drawing.Point(366, 45);
            this.amplitude_nud.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.amplitude_nud.Name = "amplitude_nud";
            this.amplitude_nud.Size = new System.Drawing.Size(49, 21);
            this.amplitude_nud.TabIndex = 10;
            this.amplitude_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.amplitude_nud.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // in_rb
            // 
            this.in_rb.AutoSize = true;
            this.in_rb.Checked = true;
            this.in_rb.Location = new System.Drawing.Point(225, 17);
            this.in_rb.Name = "in_rb";
            this.in_rb.Size = new System.Drawing.Size(35, 16);
            this.in_rb.TabIndex = 12;
            this.in_rb.TabStop = true;
            this.in_rb.Text = "In";
            this.in_rb.UseVisualStyleBackColor = true;
            this.in_rb.CheckedChanged += new System.EventHandler(this.inout_CheckedChanged);
            // 
            // out_rb
            // 
            this.out_rb.AutoSize = true;
            this.out_rb.Location = new System.Drawing.Point(266, 17);
            this.out_rb.Name = "out_rb";
            this.out_rb.Size = new System.Drawing.Size(41, 16);
            this.out_rb.TabIndex = 13;
            this.out_rb.Text = "Out";
            this.out_rb.UseVisualStyleBackColor = true;
            this.out_rb.CheckedChanged += new System.EventHandler(this.inout_CheckedChanged);
            // 
            // inout_rb
            // 
            this.inout_rb.AutoSize = true;
            this.inout_rb.Location = new System.Drawing.Point(306, 17);
            this.inout_rb.Name = "inout_rb";
            this.inout_rb.Size = new System.Drawing.Size(47, 16);
            this.inout_rb.TabIndex = 14;
            this.inout_rb.Text = "Both";
            this.inout_rb.UseVisualStyleBackColor = true;
            this.inout_rb.CheckedChanged += new System.EventHandler(this.inout_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "动画总时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "动画内插e指数（2）：";
            // 
            // exponent_nud
            // 
            this.exponent_nud.Location = new System.Drawing.Point(165, 47);
            this.exponent_nud.Name = "exponent_nud";
            this.exponent_nud.Size = new System.Drawing.Size(49, 21);
            this.exponent_nud.TabIndex = 19;
            this.exponent_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exponent_nud.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "动画内插指定数字指数（2）：";
            // 
            // power_nud
            // 
            this.power_nud.Location = new System.Drawing.Point(165, 71);
            this.power_nud.Name = "power_nud";
            this.power_nud.Size = new System.Drawing.Size(49, 21);
            this.power_nud.TabIndex = 21;
            this.power_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.power_nud.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "动画回滑次数（3）：";
            // 
            // oscillations_nud
            // 
            this.oscillations_nud.Location = new System.Drawing.Point(366, 71);
            this.oscillations_nud.Name = "oscillations_nud";
            this.oscillations_nud.Size = new System.Drawing.Size(49, 21);
            this.oscillations_nud.TabIndex = 23;
            this.oscillations_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.oscillations_nud.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(477, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 26;
            this.label9.Text = "弹簧铡度（3）：";
            // 
            // springiness_nud
            // 
            this.springiness_nud.Location = new System.Drawing.Point(565, 41);
            this.springiness_nud.Name = "springiness_nud";
            this.springiness_nud.Size = new System.Drawing.Size(49, 21);
            this.springiness_nud.TabIndex = 25;
            this.springiness_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.springiness_nud.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // bounces_nud
            // 
            this.bounces_nud.Location = new System.Drawing.Point(565, 67);
            this.bounces_nud.Name = "bounces_nud";
            this.bounces_nud.Size = new System.Drawing.Size(49, 21);
            this.bounces_nud.TabIndex = 27;
            this.bounces_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bounces_nud.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "动画反弹次数（3）：";
            // 
            // bounciness_nud
            // 
            this.bounciness_nud.Location = new System.Drawing.Point(565, 93);
            this.bounciness_nud.Name = "bounciness_nud";
            this.bounciness_nud.Size = new System.Drawing.Size(49, 21);
            this.bounciness_nud.TabIndex = 29;
            this.bounciness_nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bounciness_nud.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(453, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "动画反弹弹性（2）：";
            // 
            // draw
            // 
            this.draw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.draw.Location = new System.Drawing.Point(402, 481);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(100, 100);
            this.draw.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(819, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 77);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label12.Location = new System.Drawing.Point(6, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "       ";
            // 
            // animationComponent1
            // 
            animationOptions1.Data = null;
            animationOptions1.EveryNewTimer = false;
            animationTimer1.Options = animationOptions1;
            this.animationComponent1.AnimationTimerObject = animationTimer1;
            this.animationComponent1.Options = animationOptions1;
            // 
            // AnimationLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1212, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.bounciness_nud);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bounces_nud);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.time_nud);
            this.Controls.Add(this.x_nud);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.springiness_nud);
            this.Controls.Add(this.oscillations_nud);
            this.Controls.Add(this.amplitude_nud);
            this.Controls.Add(this.power_nud);
            this.Controls.Add(this.exponent_nud);
            this.Controls.Add(this.animationType_cb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inout_rb);
            this.Controls.Add(this.out_rb);
            this.Controls.Add(this.in_rb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resetbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.chart1);
            this.Name = "AnimationLibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "动画定时器组件";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitude_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exponent_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.power_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscillations_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.springiness_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bounces_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bounciness_nud)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox animationType_cb;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown x_nud;
        private System.Windows.Forms.NumericUpDown time_nud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetbtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown amplitude_nud;
        private System.Windows.Forms.RadioButton in_rb;
        private System.Windows.Forms.RadioButton out_rb;
        private System.Windows.Forms.RadioButton inout_rb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown exponent_nud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown power_nud;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown oscillations_nud;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown springiness_nud;
        private System.Windows.Forms.NumericUpDown bounces_nud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bounciness_nud;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label draw;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private WinformControlLibraryExtension.AnimationComponent animationComponent1;
        private System.Windows.Forms.Label label12;
    }
}