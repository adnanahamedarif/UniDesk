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
            // Main Container
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSessionCount = new System.Windows.Forms.Label();
            this.lblPhase = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cmbTimerMode = new System.Windows.Forms.ComboBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();

            // 
            // lblTimer (Main Timer Display)
            // 
            this.lblTimer.AutoSize = false;
            this.lblTimer.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblTimer.Location = new System.Drawing.Point(50, 60);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(400, 120);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "25:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblPhase (Work/Break Indicator)
            // 
            this.lblPhase.AutoSize = true;
            this.lblPhase.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblPhase.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblPhase.Location = new System.Drawing.Point(150, 20);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(200, 30);
            this.lblPhase.TabIndex = 1;
            this.lblPhase.Text = "💪 Work Time";
            this.lblPhase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblStatus (Status Text)
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(150, 190);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(200, 25);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSessionCount
            // 
            this.lblSessionCount.AutoSize = true;
            this.lblSessionCount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lblSessionCount.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblSessionCount.Location = new System.Drawing.Point(150, 220);
            this.lblSessionCount.Name = "lblSessionCount";
            this.lblSessionCount.Size = new System.Drawing.Size(200, 25);
            this.lblSessionCount.TabIndex = 3;
            this.lblSessionCount.Text = "Sessions: 0";
            this.lblSessionCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(50, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 15);
            this.progressBar.TabIndex = 4;
            this.progressBar.Value = 0;

            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(50, 290);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 45);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "▶️ Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnPause.Enabled = false;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(180, 290);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(120, 45);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "⏸️ Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);

            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(310, 290);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 45);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "⟳";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);

            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(380, 290);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(70, 45);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "⏹";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);

            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnSkip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnSkip.FlatAppearance.BorderSize = 0;
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkip.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnSkip.ForeColor = System.Drawing.Color.White;
            this.btnSkip.Location = new System.Drawing.Point(50, 345);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(400, 35);
            this.btnSkip.TabIndex = 9;
            this.btnSkip.Text = "⏭️ Skip Current Session";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.BtnSkip_Click);

            // 
            // cmbTimerMode
            // 
            this.cmbTimerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimerMode.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.cmbTimerMode.Items.AddRange(new object[] {
                "🍅 Pomodoro (25 min)",
                "☕ Short Break (5 min)",
                "☕ Long Break (15 min)",
                "⚙️ Custom"});
            this.cmbTimerMode.Location = new System.Drawing.Point(50, 400);
            this.cmbTimerMode.Name = "cmbTimerMode";
            this.cmbTimerMode.Size = new System.Drawing.Size(250, 30);
            this.cmbTimerMode.TabIndex = 10;
            this.cmbTimerMode.SelectedIndexChanged += new System.EventHandler(this.CmbTimerMode_SelectedIndexChanged);

            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.chkAutoStart.Location = new System.Drawing.Point(320, 403);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(130, 25);
            this.chkAutoStart.TabIndex = 11;
            this.chkAutoStart.Text = "Auto Start Break";
            this.chkAutoStart.UseVisualStyleBackColor = true;

            // 
            // pomo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 460);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.cmbTimerMode);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblSessionCount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPhase);
            this.Controls.Add(this.lblTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "pomo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🍅 Pomodoro Timer";
            this.Load += new System.EventHandler(this.Form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}