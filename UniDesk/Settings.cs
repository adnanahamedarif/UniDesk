using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class Settings : Form
    {
        public event EventHandler LogoutRequested;

        private readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private readonly string currentStudentId = string.Empty;

        public Settings()
        {
            InitializeComponent();

            passwordTxt.UseSystemPasswordChar = true;
        }

        // Use this constructor from Home.
        public Settings(string studentId) : this()
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentException(
                    "Student ID is required.",
                    nameof(studentId));
            }

            currentStudentId = studentId.Trim();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (string.IsNullOrWhiteSpace(currentStudentId))
            {
                MessageBox.Show(
                    "Student ID is missing. Please log in again.",
                    "Settings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
                return;
            }

            LoadUserData();
        }

        private void LoadUserData()
        {
            const string query = @"
                SELECT
                    [name],
                    [email],
                    [current_semester],
                    [LastUpdated]
                FROM [users]
                WHERE [student_id] = @StudentId";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@StudentId",
                        SqlDbType.NVarChar,
                        50).Value = currentStudentId;

                    connection.Open();

                    using (SqlDataReader reader =
                           command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "No student account was found for ID: " +
                                currentStudentId,
                                "Student Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            Close();
                            return;
                        }

                        nameTxt.Text =
                            reader["name"] == DBNull.Value
                                ? string.Empty
                                : reader["name"].ToString();

                        emailTxt.Text =
                            reader["email"] == DBNull.Value
                                ? string.Empty
                                : reader["email"].ToString();

                        semesterTxt.Text =
                            reader["current_semester"] == DBNull.Value
                                ? string.Empty
                                : reader["current_semester"].ToString();

                      
                        passwordTxt.Clear();

                        if (reader["LastUpdated"] == DBNull.Value)
                        {
                            lastUpdateLbl.Text =
                                "Last Update: Never";
                        }
                        else
                        {
                            DateTime lastUpdated =
                                Convert.ToDateTime(
                                    reader["LastUpdated"]);

                            lastUpdateLbl.Text = lastUpdated.ToString("dd MMM yyyy, hh:mm tt");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load the settings.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string fullName = nameTxt.Text.Trim();
            string email = emailTxt.Text.Trim();
            string password = passwordTxt.Text;


            string semester = semesterTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(semester))
            {
                MessageBox.Show(
                    "Please enter the current semester.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                semesterTxt.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                emailTxt.Focus();
                return;
            }

            

            bool changePassword =
                !string.IsNullOrWhiteSpace(password);

            string query;

            if (changePassword)
            {
                query = @"
                    UPDATE [users]
                    SET
                        [name] = @FullName,
                        [email] = @Email,
                        [password] = @Password,
                        [current_semester] = @Semester,
                        [LastUpdated] = GETDATE()
                    WHERE [student_id] = @StudentId";
            }
            else
            {
                query = @"
                    UPDATE [users]
                    SET
                        [name] = @FullName,
                        [email] = @Email,
                        [current_semester] = @Semester,
                        [LastUpdated] = GETDATE()
                    WHERE [student_id] = @StudentId";
            }

            saveBtn.Enabled = false;

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@FullName",
                        SqlDbType.NVarChar,
                        100).Value = fullName;

                    command.Parameters.Add(
                        "@Email",
                        SqlDbType.NVarChar,
                        255).Value = email;

                    command.Parameters.Add(
                        "@Semester",
                         SqlDbType.NVarChar,
                         50).Value = semester;

                    command.Parameters.Add(
                        "@StudentId",
                        SqlDbType.NVarChar,
                        50).Value = currentStudentId;

                    if (changePassword)
                    {
                        command.Parameters.Add(
                            "@Password",
                            SqlDbType.NVarChar,
                            100).Value = password;
                    }

                    connection.Open();

                    int affectedRows =
                        command.ExecuteNonQuery();

                    if (affectedRows == 0)
                    {
                        MessageBox.Show(
                            "The student account could not be found.",
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    passwordTxt.Clear();

                    lastUpdateLbl.Text =
                        DateTime.Now.ToString(
                            "dd MMM yyyy, hh:mm tt");

                    MessageBox.Show(
                        "Settings updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not save the settings.\n\n" +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                saveBtn.Enabled = true;
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress address =
                    new MailAddress(email);

                return string.Equals(
                    address.Address,
                    email,
                    StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Are you sure you want to log out?",
                "Log Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            passwordTxt.Clear();

            if (LogoutRequested != null)
            {
                LogoutRequested(
                    this,
                    EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lastUpdateLbl_Click(object sender, EventArgs e)
        {

        }
    }
}