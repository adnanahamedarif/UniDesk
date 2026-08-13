using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class CGPA : Form
    {
        private readonly string connectionString =
             @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;";



        private readonly string currentStudentId;


        public CGPA(string studentId)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentException(
                    "Student ID was not passed to the CGPA form.",
                    nameof(studentId));
            }

            currentStudentId = studentId;
        }



        private void CGPA_Load(object sender, EventArgs e)
        {
            ConfigureControls();
            LoadCourses();
        }

        private void ConfigureControls()
        {
            credit.Items.Clear();
            credit.Items.AddRange(new object[] { 1, 2, 3 });

            grade.Items.Clear();
            grade.Items.AddRange(new object[]
            {
                "A+", "A", "B+", "B",
                "C+", "C", "D+", "D", "F"
            });

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private decimal GetGradePoint(string selectedGrade)
        {
            switch (selectedGrade)
            {
                case "A+": return 4.00m;
                case "A": return 3.75m;
                case "B+": return 3.50m;
                case "B": return 3.25m;
                case "C+": return 3.00m;
                case "C": return 2.75m;
                case "D+": return 2.50m;
                case "D": return 2.25m;
                case "F": return 0.00m;

                default:
                    throw new ArgumentException("Invalid grade.");
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void semester_TextChanged(object sender, EventArgs e)
        {
        }

        private void grade_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void credit_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void course_name_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }
        private void add_course_Click(object sender, EventArgs e)
        {
            string courseName = course_name.Text.Trim();
            string selectedGrade = grade.Text.Trim();
            string selectedSemester = semester.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter the course name.");
                course_name.Focus();
                return;
            }

            if (!int.TryParse(credit.Text, out int selectedCredit) ||
                selectedCredit <= 0)
            {
                MessageBox.Show("Please select a valid credit.");
                credit.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedGrade))
            {
                MessageBox.Show("Please select a grade.");
                grade.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedSemester))
            {
                MessageBox.Show("Please enter the semester.");
                semester.Focus();
                return;
            }

            const string query = @"
                INSERT INTO dbo.CGPA
                    (student_id, course_name, credit, grade, semester)
                VALUES
                    (@student_id, @course_name, @credit, @grade, @semester);";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@student_id", SqlDbType.VarChar, 100)
                        .Value = currentStudentId;

                    command.Parameters.Add("@course_name", SqlDbType.NVarChar, 150)
                        .Value = courseName;

                    command.Parameters.Add("@credit", SqlDbType.Int)
                        .Value = selectedCredit;

                    command.Parameters.Add("@grade", SqlDbType.VarChar, 2)
                        .Value = selectedGrade;

                    command.Parameters.Add("@semester", SqlDbType.NVarChar, 30)
                        .Value = selectedSemester;

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                LoadCourses();
                ClearInputs();

                MessageBox.Show(
                    "Course added successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not add the course.\n\n" + ex.Message,
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            const string query = @"
                SELECT
                    cgpa_id,
                    course_name,
                    credit,
                    grade,
                    semester
                FROM dbo.CGPA
                WHERE student_id = @student_id
                ORDER BY cgpa_id DESC;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@student_id", SqlDbType.VarChar, 100)
                        .Value = currentStudentId;

                    using (SqlDataAdapter adapter =
                           new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }

                if (dataGridView1.Columns["cgpa_id"] != null)
                {
                    dataGridView1.Columns["cgpa_id"].Visible = false;
                }

                if (dataGridView1.Columns["course_name"] != null)
                    dataGridView1.Columns["course_name"].HeaderText = "Course";

                if (dataGridView1.Columns["credit"] != null)
                    dataGridView1.Columns["credit"].HeaderText = "Credit";

                if (dataGridView1.Columns["grade"] != null)
                    dataGridView1.Columns["grade"].HeaderText = "Grade";

                if (dataGridView1.Columns["semester"] != null)
                    dataGridView1.Columns["semester"].HeaderText = "Semester";

                CalculateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load courses.\n\n" + ex.Message,
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals()
        {
            int totalCredits = 0;
            decimal totalQualityPoints = 0m;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (!int.TryParse(
                    Convert.ToString(row.Cells["credit"].Value),
                    out int courseCredit))
                {
                    continue;
                }

                string courseGrade =
                    Convert.ToString(row.Cells["grade"].Value);

                if (string.IsNullOrWhiteSpace(courseGrade))
                    continue;

                decimal gradePoint = GetGradePoint(courseGrade);

                totalCredits += courseCredit;
                totalQualityPoints += courseCredit * gradePoint;
            }

            decimal calculatedCgpa = totalCredits == 0
                ? 0m
                : totalQualityPoints / totalCredits;

            total_credit.Text = totalCredits.ToString();
            total_cgpa.Text = calculatedCgpa.ToString("0.00");
        }

        private void remove_course_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to remove.");
                return;
            }

            DataGridViewRow selectedRow =
                dataGridView1.SelectedRows[0];

            if (selectedRow.Cells["cgpa_id"].Value == null)
            {
                MessageBox.Show("The selected course ID was not found.");
                return;
            }

            int cgpaId = Convert.ToInt32(
                selectedRow.Cells["cgpa_id"].Value);

            string courseName = Convert.ToString(
                selectedRow.Cells["course_name"].Value);

            DialogResult answer = MessageBox.Show(
                $"Do you want to remove \"{courseName}\"?",
                "Confirm removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
                return;

            const string query = @"
                DELETE FROM dbo.CGPA
                WHERE cgpa_id = @cgpa_id
                  AND student_id = @student_id;";

            try
            {
                int affectedRows;

                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@cgpa_id", SqlDbType.Int)
                        .Value = cgpaId;

                    command.Parameters.Add("@student_id", SqlDbType.VarChar, 100)
                        .Value = currentStudentId;

                    connection.Open();
                    affectedRows = command.ExecuteNonQuery();
                }

                if (affectedRows == 0)
                {
                    MessageBox.Show("The course could not be found.");
                    return;
                }

                LoadCourses();

                MessageBox.Show(
                    "Course removed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not remove the course.\n\n" + ex.Message,
                    "Database error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            course_name.Clear();
            credit.SelectedIndex = -1;
            grade.SelectedIndex = -1;
            semester.Clear();
            course_name.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void total_cgpa_Click(object sender, EventArgs e)
        {

        }
    }
}