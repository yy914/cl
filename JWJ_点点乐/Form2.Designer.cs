namespace JWJ_点点乐
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.settime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.setdifficult = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p3 = new System.Windows.Forms.PictureBox();
            this.p4 = new System.Windows.Forms.PictureBox();
            this.p5 = new System.Windows.Forms.PictureBox();
            this.p6 = new System.Windows.Forms.PictureBox();
            this.p7 = new System.Windows.Forms.PictureBox();
            this.p8 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.settime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p8)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "时间长度：";
            // 
            // settime
            // 
            this.settime.Location = new System.Drawing.Point(150, 46);
            this.settime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.settime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.settime.Name = "settime";
            this.settime.Size = new System.Drawing.Size(68, 25);
            this.settime.TabIndex = 1;
            this.settime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "分钟";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "难 度 值：";
            // 
            // setdifficult
            // 
            this.setdifficult.FormattingEnabled = true;
            this.setdifficult.Items.AddRange(new object[] {
            "简单",
            "中等",
            "难"});
            this.setdifficult.Location = new System.Drawing.Point(150, 91);
            this.setdifficult.Name = "setdifficult";
            this.setdifficult.Size = new System.Drawing.Size(106, 23);
            this.setdifficult.TabIndex = 4;
            this.setdifficult.Text = "简单";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "选择宠物：";
            // 
            // p1
            // 
            this.p1.Image = ((System.Drawing.Image)(resources.GetObject("p1.Image")));
            this.p1.Location = new System.Drawing.Point(51, 176);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(60, 54);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p1.TabIndex = 6;
            this.p1.TabStop = false;
            this.p1.Click += new System.EventHandler(this.p1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // p2
            // 
            this.p2.Image = ((System.Drawing.Image)(resources.GetObject("p2.Image")));
            this.p2.Location = new System.Drawing.Point(127, 176);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(60, 54);
            this.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p2.TabIndex = 9;
            this.p2.TabStop = false;
            this.p2.Click += new System.EventHandler(this.p1_Click);
            // 
            // p3
            // 
            this.p3.Image = ((System.Drawing.Image)(resources.GetObject("p3.Image")));
            this.p3.Location = new System.Drawing.Point(204, 176);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(60, 54);
            this.p3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p3.TabIndex = 10;
            this.p3.TabStop = false;
            this.p3.Click += new System.EventHandler(this.p1_Click);
            // 
            // p4
            // 
            this.p4.Image = ((System.Drawing.Image)(resources.GetObject("p4.Image")));
            this.p4.Location = new System.Drawing.Point(280, 176);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(60, 54);
            this.p4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p4.TabIndex = 11;
            this.p4.TabStop = false;
            this.p4.Click += new System.EventHandler(this.p1_Click);
            // 
            // p5
            // 
            this.p5.Image = ((System.Drawing.Image)(resources.GetObject("p5.Image")));
            this.p5.Location = new System.Drawing.Point(51, 251);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(60, 54);
            this.p5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p5.TabIndex = 12;
            this.p5.TabStop = false;
            this.p5.Click += new System.EventHandler(this.p1_Click);
            // 
            // p6
            // 
            this.p6.Image = ((System.Drawing.Image)(resources.GetObject("p6.Image")));
            this.p6.Location = new System.Drawing.Point(127, 251);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(60, 54);
            this.p6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p6.TabIndex = 13;
            this.p6.TabStop = false;
            this.p6.Click += new System.EventHandler(this.p1_Click);
            // 
            // p7
            // 
            this.p7.Image = ((System.Drawing.Image)(resources.GetObject("p7.Image")));
            this.p7.Location = new System.Drawing.Point(204, 251);
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(60, 54);
            this.p7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p7.TabIndex = 14;
            this.p7.TabStop = false;
            this.p7.Click += new System.EventHandler(this.p1_Click);
            // 
            // p8
            // 
            this.p8.Image = ((System.Drawing.Image)(resources.GetObject("p8.Image")));
            this.p8.Location = new System.Drawing.Point(280, 251);
            this.p8.Name = "p8";
            this.p8.Size = new System.Drawing.Size(60, 54);
            this.p8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.p8.TabIndex = 15;
            this.p8.TabStop = false;
            this.p8.Click += new System.EventHandler(this.p1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 403);
            this.Controls.Add(this.p8);
            this.Controls.Add(this.p7);
            this.Controls.Add(this.p6);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setdifficult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.settime);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 450);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏设置";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.settime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown settime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox setdifficult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.PictureBox p3;
        private System.Windows.Forms.PictureBox p4;
        private System.Windows.Forms.PictureBox p5;
        private System.Windows.Forms.PictureBox p6;
        private System.Windows.Forms.PictureBox p7;
        private System.Windows.Forms.PictureBox p8;
    }
}