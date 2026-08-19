using System.Drawing;
using System.Windows.Forms;
using UniDesk;

namespace UniDesk
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cgpa = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.classRoutineBtn = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.Settings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(265, 825);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(12, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(12, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Course Management";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(12, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(233, 41);
            this.button3.TabIndex = 4;
            this.button3.Text = "Assignment Tracker";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // cgpa
            // 
            this.cgpa.BackColor = System.Drawing.Color.Transparent;
            this.cgpa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cgpa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cgpa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgpa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cgpa.Location = new System.Drawing.Point(12, 417);
            this.cgpa.Name = "cgpa";
            this.cgpa.Size = new System.Drawing.Size(233, 41);
            this.cgpa.TabIndex = 7;
            this.cgpa.Text = "CGPA Calculator";
            this.cgpa.UseVisualStyleBackColor = false;
            this.cgpa.Click += new System.EventHandler(this.button4_Click);
            this.cgpa.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.cgpa.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(12, 357);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(233, 41);
            this.button5.TabIndex = 6;
            this.button5.Text = "Exam Schedule";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // classRoutineBtn
            // 
            this.classRoutineBtn.BackColor = System.Drawing.Color.Transparent;
            this.classRoutineBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.classRoutineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classRoutineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classRoutineBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.classRoutineBtn.Location = new System.Drawing.Point(12, 296);
            this.classRoutineBtn.Name = "classRoutineBtn";
            this.classRoutineBtn.Size = new System.Drawing.Size(233, 41);
            this.classRoutineBtn.TabIndex = 5;
            this.classRoutineBtn.Text = "Class Routine";
            this.classRoutineBtn.UseVisualStyleBackColor = false;
            this.classRoutineBtn.Click += new System.EventHandler(this.classRoutineBtn_Click);
            this.classRoutineBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.classRoutineBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Location = new System.Drawing.Point(12, 590);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(233, 41);
            this.button7.TabIndex = 10;
            this.button7.Text = "To-Do List";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button7.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button8.Location = new System.Drawing.Point(12, 530);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(233, 41);
            this.button8.TabIndex = 9;
            this.button8.Text = "Pomodoro Timer";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button8.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button9.Location = new System.Drawing.Point(12, 469);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(233, 41);
            this.button9.TabIndex = 8;
            this.button9.Text = "Class Materials";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.button9.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(89, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "UniDesk";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.White;
            this.panel_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Main.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_Main.Location = new System.Drawing.Point(266, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(1176, 825);
            this.panel_Main.TabIndex = 12;
            this.panel_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Settings.Location = new System.Drawing.Point(12, 751);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(233, 48);
            this.Settings.TabIndex = 13;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            this.Settings.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);
            this.Settings.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.Settings);
            this.panel1.Controls.Add(this.cgpa);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.classRoutineBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 825);
            this.panel1.TabIndex = 13;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 825);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.splitter1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cgpa;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button classRoutineBtn;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private Panel panel_Main;
        private Button Settings;
        private Panel panel1;
    }
}


