using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace UniDesk
{
    public partial class login : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30");
        public login()
        {
            InitializeComponent();
            login_pass.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void login_createAcc_btn_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide();

        }

        private void login_show_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_show_pass.Checked)
            {
                login_pass.PasswordChar = '\0';
            }
            else
            {
                login_pass.PasswordChar = '*'; 
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string studentId = login_student_id.Text.Trim();
            string password = login_pass.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            const string query = @"
        SELECT name
        FROM dbo.users
        WHERE student_id = @student_id
          AND password = @password;";

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.Add(
                        "@student_id",
                        SqlDbType.VarChar,
                        50
                    ).Value = studentId;

                    cmd.Parameters.Add(
                        "@password",
                        SqlDbType.VarChar,
                        255
                    ).Value = password;

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        string studentName = result.ToString();

                        Home homeForm = new Home(
                            studentId,
                            studentName
                        );

                        homeForm.FormClosed +=
                            (s, args) => Close();

                        homeForm.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid student ID or password.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error connecting to the database:\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
    }
}

