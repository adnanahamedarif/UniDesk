using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UniDesk
{
    public partial class SignUp : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30");
        public SignUp()
        {
            InitializeComponent();
            signup_pass.PasswordChar = '*';
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void SignUp_Load_1(object sender, EventArgs e)
        {

        }

        private void signup_login_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide ();
        }

        private void signup_close_Click(object sender, EventArgs e)
        {
            Application.Exit ();
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            string studentId = signup_studentId.Text.Trim();
            string name = signup_name.Text.Trim();
            string semester = signup_currentSemester.Text.Trim();
            string email = signup_email.Text.Trim();
            string password = signup_pass.Text.Trim();

            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string checkUserQuery = "SELECT COUNT(*) FROM users WHERE student_id = @studentId OR email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@studentId", studentId);
                        checkCmd.Parameters.AddWithValue("@email", email);
                        int userCount = (int)checkCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("A user with this Student ID or Email already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO users (student_id, name, current_semester, email, password) VALUES (@studentId, @name, @semester, @email, @password)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connect))
                    {
                        insertCmd.Parameters.AddWithValue("@studentId", studentId);
                        insertCmd.Parameters.AddWithValue("@name", name);
                        insertCmd.Parameters.AddWithValue("@semester", semester);
                        insertCmd.Parameters.AddWithValue("@email", email);
                        insertCmd.Parameters.AddWithValue("@password", password); 

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            

                            Form loginForm = new login();
                            loginForm.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void signup_show_pass_CheckedChanged(object sender, EventArgs e)
        {
            signup_pass.PasswordChar = signup_show_pass.Checked ? '\0' : '*';
        }
    }
}
