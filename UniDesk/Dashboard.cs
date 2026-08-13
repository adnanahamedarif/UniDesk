using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace UniDesk
{
    public partial class Dashboard : Form
    {

        private readonly string cgpaConnectionString =
    @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;
      Integrated Security=True;
      Connect Timeout=30;
      Encrypt=False;";

        private readonly string todoConnectionString =
            @"Server=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=C:\Users\USER\OneDrive\Documents\ToDoList.mdf;
      Integrated Security=True;
      TrustServerCertificate=True;";


        private readonly string currentStudentId;
        private readonly string currentStudentName;

        private decimal currentCgpaValue;



        public Dashboard(string studentId, string studentName)
        {
            InitializeComponent();

            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentException(
                    "Student ID was not passed to Dashboard.",
                    nameof(studentId));
            }

            currentStudentId = studentId.Trim();

            currentStudentName = string.IsNullOrWhiteSpace(studentName)
                            ? "Student"
                            : studentName.Trim();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            label1.Text = "Welcome, " + currentStudentName;

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            LoadCGPA();
            LoadPendingTaskCount();
        }




        private void LoadCGPA()
        {
            const string query = @"
        SELECT
            COUNT(*) AS TotalCourses,
            COALESCE(
                SUM(
                    CAST(credit AS DECIMAL(18, 2)) *
                    CASE LTRIM(RTRIM(grade))
                        WHEN 'A+' THEN 4.00
                        WHEN 'A'  THEN 3.75
                        WHEN 'B+' THEN 3.50
                        WHEN 'B'  THEN 3.25
                        WHEN 'C+' THEN 3.00
                        WHEN 'C'  THEN 2.75
                        WHEN 'D+' THEN 2.50
                        WHEN 'D'  THEN 2.25
                        WHEN 'F'  THEN 0.00
                        ELSE 0.00
                    END
                ) /
                NULLIF(
                    SUM(CAST(credit AS DECIMAL(18, 2))),
                    0
                ),
                0
            ) AS CurrentCGPA
        FROM dbo.CGPA
        WHERE student_id = @student_id;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(cgpaConnectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@student_id",
                        SqlDbType.VarChar,
                        100
                    ).Value = currentStudentId;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            total_Courses.Text =
                                Convert.ToInt32(reader["TotalCourses"]).ToString();

                            currentCgpaValue =
                                Convert.ToDecimal(reader["CurrentCGPA"]);

                            current_Cgpa.Text = show_cgpa.Checked
                                ? currentCgpaValue.ToString("0.00")
                                : "****";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                total_Courses.Text = "0";
                current_Cgpa.Text = "0.00";

                MessageBox.Show(
                    "CGPA load করা যায়নি:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadPendingTaskCount()
        {
            const string query = @"
        SELECT COUNT(*)
        FROM dbo.ToDoList
        WHERE LTRIM(RTRIM(Status)) = @Status;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(todoConnectionString))
                using (SqlCommand command =
                       new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Status",
                        SqlDbType.VarChar,
                        20
                    ).Value = "Pending";

                    connection.Open();

                    object result = command.ExecuteScalar();

                    pending_Task.Text =
                        Convert.ToInt32(result).ToString();
                }
            }
            catch (Exception ex)
            {
                pending_Task.Text = "0";

                MessageBox.Show(
                    "Pending task load করা যায়নি:\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }


        private void Dashboard_Activated(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void course_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void credit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void semester_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pending_Task_Click(object sender, EventArgs e)
        {

        }

        private void total_Courses_Click(object sender, EventArgs e)
        {

        }

        private void upcoming_Exam_Click(object sender, EventArgs e)
        {

        }

        private void current_Cgpa_Click(object sender, EventArgs e)
        {

        }

        private void show_cgpa_CheckedChanged(object sender, EventArgs e)
        {
            current_Cgpa.Text = show_cgpa.Checked
                ? currentCgpaValue.ToString("0.00")
                : "****";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://portal.aiub.edu/",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "AIUB Portal খোলা যায়নি:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://aiubconnect.com/",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "AIUB Connect খোলা যায়নি:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://studyhubb.great-site.net/home/dashboard",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Study Hub খোলা যায়নি:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
