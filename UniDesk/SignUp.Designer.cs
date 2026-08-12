using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniDesk
{
    partial class SignUp
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.signup_login = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.signup_btn = new System.Windows.Forms.Button();
            this.signup_pass = new System.Windows.Forms.TextBox();
            this.signup_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.signup_close = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.signup_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.signup_studentId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.signup_currentSemester = new System.Windows.Forms.TextBox();
            this.signup_show_pass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(16, 273);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(496, 224);
            this.label1.TabIndex = 12;
            this.label1.Text = "Your academic journey starts here.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.signup_show_pass);
            this.panel1.Controls.Add(this.signup_currentSemester);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.signup_studentId);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.signup_name);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.signup_login);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.signup_btn);
            this.panel1.Controls.Add(this.signup_pass);
            this.panel1.Controls.Add(this.signup_email);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(736, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 575);
            this.panel1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(323, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "UniDesk ";
            // 
            // signup_login
            // 
            this.signup_login.BackColor = System.Drawing.Color.MidnightBlue;
            this.signup_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup_login.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_login.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.signup_login.Location = new System.Drawing.Point(58, 501);
            this.signup_login.Name = "signup_login";
            this.signup_login.Size = new System.Drawing.Size(108, 40);
            this.signup_login.TabIndex = 9;
            this.signup_login.Text = "Login";
            this.signup_login.UseVisualStyleBackColor = false;
            this.signup_login.Click += new System.EventHandler(this.signup_login_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Already have an account?";
            // 
            // signup_btn
            // 
            this.signup_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.signup_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup_btn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_btn.ForeColor = System.Drawing.Color.White;
            this.signup_btn.Location = new System.Drawing.Point(58, 424);
            this.signup_btn.Name = "signup_btn";
            this.signup_btn.Size = new System.Drawing.Size(336, 41);
            this.signup_btn.TabIndex = 7;
            this.signup_btn.Text = "Sign Up";
            this.signup_btn.UseVisualStyleBackColor = false;
            this.signup_btn.Click += new System.EventHandler(this.signup_btn_Click);
            // 
            // signup_pass
            // 
            this.signup_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_pass.Location = new System.Drawing.Point(57, 359);
            this.signup_pass.Name = "signup_pass";
            this.signup_pass.Size = new System.Drawing.Size(336, 26);
            this.signup_pass.TabIndex = 6;
            // 
            // signup_email
            // 
            this.signup_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_email.Location = new System.Drawing.Point(57, 298);
            this.signup_email.Name = "signup_email";
            this.signup_email.Size = new System.Drawing.Size(336, 26);
            this.signup_email.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email Address";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(340, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // signup_close
            // 
            this.signup_close.AutoSize = true;
            this.signup_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_close.Location = new System.Drawing.Point(1266, 9);
            this.signup_close.Name = "signup_close";
            this.signup_close.Size = new System.Drawing.Size(20, 20);
            this.signup_close.TabIndex = 15;
            this.signup_close.Text = "X";
            this.signup_close.Click += new System.EventHandler(this.signup_close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 37);
            this.label6.TabIndex = 11;
            this.label6.Text = "Get Started";
            // 
            // signup_name
            // 
            this.signup_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_name.Location = new System.Drawing.Point(57, 168);
            this.signup_name.Name = "signup_name";
            this.signup_name.Size = new System.Drawing.Size(336, 26);
            this.signup_name.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Name";
            // 
            // signup_studentId
            // 
            this.signup_studentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_studentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_studentId.Location = new System.Drawing.Point(57, 236);
            this.signup_studentId.Name = "signup_studentId";
            this.signup_studentId.Size = new System.Drawing.Size(167, 26);
            this.signup_studentId.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Student Id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(226, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Current Semester";
            // 
            // signup_currentSemester
            // 
            this.signup_currentSemester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_currentSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_currentSemester.Location = new System.Drawing.Point(230, 236);
            this.signup_currentSemester.Name = "signup_currentSemester";
            this.signup_currentSemester.Size = new System.Drawing.Size(163, 26);
            this.signup_currentSemester.TabIndex = 17;
            // 
            // signup_show_pass
            // 
            this.signup_show_pass.AutoSize = true;
            this.signup_show_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_show_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_show_pass.Location = new System.Drawing.Point(252, 394);
            this.signup_show_pass.Name = "signup_show_pass";
            this.signup_show_pass.Size = new System.Drawing.Size(141, 24);
            this.signup_show_pass.TabIndex = 18;
            this.signup_show_pass.Text = "Show Password";
            this.signup_show_pass.UseVisualStyleBackColor = true;
            this.signup_show_pass.CheckedChanged += new System.EventHandler(this.signup_show_pass_CheckedChanged);
            // 
            // SignUp
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1298, 705);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.signup_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Account";
            this.Load += new System.EventHandler(this.SignUp_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private PictureBox pictureBox1;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public Panel panel1;
        private Label label5;
        private Button signup_login;
        private Label label4;
        private Button signup_btn;
        private TextBox signup_pass;
        private TextBox signup_email;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox2;
        private Label signup_close;
        private Label label6;
        private TextBox signup_name;
        private Label label7;
        private TextBox signup_studentId;
        private Label label8;
        private TextBox signup_currentSemester;
        private Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private CheckBox signup_show_pass;
    }
}