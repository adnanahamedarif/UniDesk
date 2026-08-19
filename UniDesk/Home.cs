using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class Home : Form
    {
        private readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private string currentStudentId = string.Empty;
        private string currentStudentName = string.Empty;
        private string currentStudentEmail = string.Empty;
        private string currentStudentSemester = string.Empty;
        private DateTime? currentStudentLastUpdate;

        private Form activeChildForm;

        public string CurrentStudentId
        {
            get { return currentStudentId; }
        }

        public string CurrentStudentName
        {
            get { return currentStudentName; }
        }

        public string CurrentStudentEmail
        {
            get { return currentStudentEmail; }
        }

        public string CurrentStudentSemester
        {
            get { return currentStudentSemester; }
        }

        public DateTime? CurrentStudentLastUpdate
        {
            get { return currentStudentLastUpdate; }
        }

        public Home()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null,
                panel_Main,
                new object[] { true });
        }

        public Home(string studentId, string studentName) : this()
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentException(
                    "Student ID is required.",
                    nameof(studentId));
            }

            currentStudentId = studentId.Trim();

            currentStudentName =
                string.IsNullOrWhiteSpace(studentName)
                    ? "Student"
                    : studentName.Trim();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            if (!LoadStudentData())
                return;

            ShowChildForm(
                new Dashboard(
                    currentStudentId,
                    currentStudentName));
        }

        private bool LoadStudentData()
        {
            const string query = @"
    SELECT
        [name] AS FullName,
        [email] AS Email,
        [current_semester] AS CurrentSemester,
        [LastUpdated]
    FROM [users]
    WHERE [student_id] = @StudentId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@StudentId", SqlDbType.NVarChar, 50).Value = currentStudentId;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "No student account was found for ID: " + currentStudentId,
                                "Student Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return false;
                        }

                        currentStudentName = reader["FullName"] == DBNull.Value
                                    ? "Student"
                                     : reader["FullName"].ToString();

                        currentStudentEmail =
                            reader["Email"] == DBNull.Value
                                ? string.Empty
                                : reader["Email"].ToString();

                        currentStudentSemester =
                            reader["CurrentSemester"] == DBNull.Value
                                ? string.Empty
                                : reader["CurrentSemester"].ToString();

                        if (reader["LastUpdated"] == DBNull.Value)
                        {
                            currentStudentLastUpdate = null;
                        }
                        else
                        {
                            currentStudentLastUpdate =
                                Convert.ToDateTime(reader["LastUpdated"]);
                        }

                        

                        Text = "UniDesk - " + currentStudentName;
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "Could not load the student information.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private void ShowChildForm(Form childForm)
        {
            if (childForm == null)
                return;

            panel_Main.SuspendLayout();

            try
            {
                if (activeChildForm != null)
                {
                    panel_Main.Controls.Remove(activeChildForm);
                    activeChildForm.Close();
                    activeChildForm.Dispose();
                }

                activeChildForm = childForm;

                childForm.TopLevel = false;
                childForm.FormBorderStyle =
                    FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                panel_Main.Controls.Add(childForm);

                childForm.Show();
                childForm.BringToFront();
            }
            finally
            {
                panel_Main.ResumeLayout(true);
            }
        }

        private bool ValidateStudentId()
        {
            if (!string.IsNullOrWhiteSpace(currentStudentId))
                return true;

            MessageBox.Show(
                "Student ID is missing. Please log in again.",
                "Student ID Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return false;
        }

        private void SettingsForm_LogoutRequested(
    object sender,
    EventArgs e)
        {
            Hide();

            login loginForm = new login(); 

            loginForm.FormClosed += delegate
            {
                Close();
            };

            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            if (!LoadStudentData())
                return;

            ShowChildForm(
                new Dashboard(
                    currentStudentId,
                    currentStudentName));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new CGPA(currentStudentId));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new ToDoList());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new pomo());
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            Settings settingsForm =
                new Settings(currentStudentId);

            settingsForm.LogoutRequested +=
                SettingsForm_LogoutRequested;

            ShowChildForm(settingsForm);
        }

        private void classRoutineBtn_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new ClassRoutine(currentStudentId));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint( object sender,PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new ClassMaterials(currentStudentId));
        }
    }
}