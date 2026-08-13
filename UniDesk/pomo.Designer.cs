namespace UniDesk
{
    partial class pomo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTimer = new System.Windows.Forms.Label();
            this.Start_btn = new System.Windows.Forms.Button();
            this.Pause_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.focus_btn = new System.Windows.Forms.Button();
            this.shortBreak_btn = new System.Windows.Forms.Button();
            this.longBreak_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Comic Sans MS", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Black;
            this.lblTimer.Location = new System.Drawing.Point(69, 52);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(450, 144);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "25:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimer.Click += new System.EventHandler(this.lblTimer_Click);
            // 
            // Start_btn
            // 
            this.Start_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Start_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.Start_btn.FlatAppearance.BorderSize = 0;
            this.Start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_btn.ForeColor = System.Drawing.Color.Black;
            this.Start_btn.Location = new System.Drawing.Point(116, 240);
            this.Start_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(90, 37);
            this.Start_btn.TabIndex = 5;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = false;
            this.Start_btn.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Pause_btn
            // 
            this.Pause_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.Pause_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Pause_btn.Enabled = false;
            this.Pause_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.Pause_btn.FlatAppearance.BorderSize = 0;
            this.Pause_btn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.Pause_btn.ForeColor = System.Drawing.Color.Black;
            this.Pause_btn.Location = new System.Drawing.Point(244, 240);
            this.Pause_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Pause_btn.Name = "Pause_btn";
            this.Pause_btn.Size = new System.Drawing.Size(90, 37);
            this.Pause_btn.TabIndex = 6;
            this.Pause_btn.Text = "Pause";
            this.Pause_btn.UseVisualStyleBackColor = false;
            this.Pause_btn.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.reset_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reset_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.reset_btn.FlatAppearance.BorderSize = 0;
            this.reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.ForeColor = System.Drawing.Color.Black;
            this.reset_btn.Location = new System.Drawing.Point(375, 240);
            this.reset_btn.Margin = new System.Windows.Forms.Padding(2);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(90, 37);
            this.reset_btn.TabIndex = 8;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = false;
            this.reset_btn.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(116, 198);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(349, 15);
            this.progressBar.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 100);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 55);
            this.label1.TabIndex = 13;
            this.label1.Text = "Pomodoro timer";
            // 
            // focus_btn
            // 
            this.focus_btn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.focus_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.focus_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focus_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focus_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.focus_btn.Location = new System.Drawing.Point(116, 15);
            this.focus_btn.Name = "focus_btn";
            this.focus_btn.Size = new System.Drawing.Size(90, 34);
            this.focus_btn.TabIndex = 14;
            this.focus_btn.Text = "Focus";
            this.focus_btn.UseVisualStyleBackColor = false;
            this.focus_btn.Click += new System.EventHandler(this.focus_btn_Click);
            // 
            // shortBreak_btn
            // 
            this.shortBreak_btn.BackColor = System.Drawing.Color.DarkOrange;
            this.shortBreak_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shortBreak_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shortBreak_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortBreak_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.shortBreak_btn.Location = new System.Drawing.Point(212, 15);
            this.shortBreak_btn.Name = "shortBreak_btn";
            this.shortBreak_btn.Size = new System.Drawing.Size(137, 34);
            this.shortBreak_btn.TabIndex = 15;
            this.shortBreak_btn.Text = " Short Break";
            this.shortBreak_btn.UseVisualStyleBackColor = false;
            this.shortBreak_btn.Click += new System.EventHandler(this.shortBreak_btn_Click);
            // 
            // longBreak_btn
            // 
            this.longBreak_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.longBreak_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.longBreak_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.longBreak_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longBreak_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.longBreak_btn.Location = new System.Drawing.Point(355, 15);
            this.longBreak_btn.Name = "longBreak_btn";
            this.longBreak_btn.Size = new System.Drawing.Size(116, 34);
            this.longBreak_btn.TabIndex = 16;
            this.longBreak_btn.Text = " Long Break";
            this.longBreak_btn.UseVisualStyleBackColor = false;
            this.longBreak_btn.Click += new System.EventHandler(this.longBreak_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTimer);
            this.panel2.Controls.Add(this.longBreak_btn);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.shortBreak_btn);
            this.panel2.Controls.Add(this.Start_btn);
            this.panel2.Controls.Add(this.focus_btn);
            this.panel2.Controls.Add(this.Pause_btn);
            this.panel2.Controls.Add(this.reset_btn);
            this.panel2.Location = new System.Drawing.Point(292, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 295);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(292, 432);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 60);
            this.panel3.TabIndex = 18;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(449, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 49);
            this.label9.TabIndex = 20;
            this.label9.Text = "=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(291, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 49);
            this.label8.TabIndex = 19;
            this.label8.Text = "+";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(144, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 49);
            this.label7.TabIndex = 18;
            this.label7.Text = "+";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(484, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 35);
            this.label6.TabIndex = 17;
            this.label6.Text = "Success";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(347, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 35);
            this.label5.TabIndex = 16;
            this.label5.Text = "Action";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(201, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 35);
            this.label4.TabIndex = 15;
            this.label4.Text = "Focus";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 35);
            this.label3.TabIndex = 14;
            this.label3.Text = "Discipline";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(4, 518);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 37);
            this.label10.TabIndex = 19;
            this.label10.Text = "Plan Tasks";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 558);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(381, 256);
            this.textBox1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(174, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Note here";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pomo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1167, 826);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "pomo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🍅 Pomodoro Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button focus_btn;
        private System.Windows.Forms.Button shortBreak_btn;
        private System.Windows.Forms.Button longBreak_btn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}