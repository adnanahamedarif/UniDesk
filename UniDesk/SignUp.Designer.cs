using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniDesk
{
    partial class SignUp
    {
        private System.ComponentModel.IContainer components = null;

        // Control declarations (only once)
        private Label lblTitle;
        private Label lblName;
        private Label lblEmail;
        private Label lblStudentId;
        private Label lblPassword;
        private Label lblConfirmPassword;

        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtStudentId;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;

        private Button btnCreate;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Create controls
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.lblEmail = new Label();
            this.lblStudentId = new Label();
            this.lblPassword = new Label();
            this.lblConfirmPassword = new Label();

            this.txtName = new TextBox();
            this.txtEmail = new TextBox();
            this.txtStudentId = new TextBox();
            this.txtPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();

            this.btnCreate = new Button();
            this.btnBack = new Button();

            this.SuspendLayout();

            // Form Settings
            this.BackColor = Color.White;
            this.ClientSize = new Size(500, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Create Account";

            // Title
            this.lblTitle.Text = "Create Account";
            this.lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.RoyalBlue;
            this.lblTitle.Location = new Point(110, 30);
            this.lblTitle.AutoSize = true;

            // Full Name
            this.lblName.Text = "Full Name";
            this.lblName.Location = new Point(60, 100);
            this.lblName.Font = new Font("Segoe UI", 10);
            this.lblName.AutoSize = true;

            this.txtName.Location = new Point(60, 125);
            this.txtName.Size = new Size(370, 30);
            this.txtName.Font = new Font("Segoe UI", 11);

            // Student ID
            this.lblStudentId.Text = "Student ID";
            this.lblStudentId.Location = new Point(60, 170);
            this.lblStudentId.Font = new Font("Segoe UI", 10);
            this.lblStudentId.AutoSize = true;

            this.txtStudentId.Location = new Point(60, 195);
            this.txtStudentId.Size = new Size(370, 30);
            this.txtStudentId.Font = new Font("Segoe UI", 11);

            // Email
            this.lblEmail.Text = "University Email";
            this.lblEmail.Location = new Point(60, 240);
            this.lblEmail.Font = new Font("Segoe UI", 10);
            this.lblEmail.AutoSize = true;

            this.txtEmail.Location = new Point(60, 265);
            this.txtEmail.Size = new Size(370, 30);
            this.txtEmail.Font = new Font("Segoe UI", 11);

            // Password
            this.lblPassword.Text = "Password";
            this.lblPassword.Location = new Point(60, 310);
            this.lblPassword.Font = new Font("Segoe UI", 10);
            this.lblPassword.AutoSize = true;

            this.txtPassword.Location = new Point(60, 335);
            this.txtPassword.Size = new Size(370, 30);
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.UseSystemPasswordChar = true;

            // Confirm Password
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.Location = new Point(60, 380);
            this.lblConfirmPassword.Font = new Font("Segoe UI", 10);
            this.lblConfirmPassword.AutoSize = true;

            this.txtConfirmPassword.Location = new Point(60, 405);
            this.txtConfirmPassword.Size = new Size(370, 30);
            this.txtConfirmPassword.Font = new Font("Segoe UI", 11);
            this.txtConfirmPassword.UseSystemPasswordChar = true;

            // Create Button
            this.btnCreate.Text = "Create Account";
            this.btnCreate.Location = new Point(60, 470);
            this.btnCreate.Size = new Size(370, 50);
            this.btnCreate.BackColor = Color.RoyalBlue;
            this.btnCreate.ForeColor = Color.White;
            this.btnCreate.FlatStyle = FlatStyle.Flat;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnCreate.Cursor = Cursors.Hand;

            // Back Button
            this.btnBack.Text = "Back to Login";
            this.btnBack.Location = new Point(60, 535);
            this.btnBack.Size = new Size(370, 45);
            this.btnBack.BackColor = Color.White;
            this.btnBack.ForeColor = Color.RoyalBlue;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderColor = Color.RoyalBlue;
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnBack.Cursor = Cursors.Hand;

            // Add Controls to Form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblStudentId);
            this.Controls.Add(this.txtStudentId);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBack);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}