using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class Dashboard : Form
    {
        private readonly string cgpaConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True; Connect Timeout=30; Encrypt=False;";

        private readonly string todoConnectionString = @"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\USER\OneDrive\Documents\ToDoList.mdf; Integrated Security=True; TrustServerCertificate=True;";

        private readonly string currentStudentId;
        private readonly string currentStudentName;

        private decimal currentCgpaValue;



        public Dashboard(string studentId, string studentName)
        {
            InitializeComponent();



            if (string.IsNullOrWhiteSpace(studentId ))
            {
                throw new ArgumentException(
                    "Student ID was not passed to Dashboard.", nameof(studentId));
            }

            currentStudentId = studentId.Trim();

            currentStudentName = string.IsNullOrWhiteSpace(studentName)
                ? "Student" : studentName.Trim();
        }





        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            label1.Text = $"Welcome, {currentStudentName}";

            LoadDashboardData();
        }



        private void LoadDashboardData()
        {
            LoadCGPA();
            LoadPendingTaskCount();
            LoadTodaysClasses();
        }





        private void LoadCGPA()
        {
            const string query = @" SELECT COUNT(*) AS TotalCourses, COALESCE( SUM(  CAST(credit AS DECIMAL(18, 2)) * CASE LTRIM(RTRIM(grade)) WHEN 'A+' THEN 4.00 WHEN 'A'  THEN 3.75 WHEN 'B+' THEN 3.50 WHEN 'B'  THEN 3.25 WHEN 'C+' THEN 3.00 WHEN 'C'  THEN 2.75 WHEN 'D+' THEN 2.50 WHEN 'D'  THEN 2.25 WHEN 'F'  THEN 0.00
                                    ELSE 0.00 END ) / NULLIF( SUM(CAST(credit AS DECIMAL(18, 2))), 0  ), 0 ) AS CurrentCGPA
                                    FROM dbo.CGPA
                                    WHERE student_id = @student_id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(cgpaConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@student_id", SqlDbType.VarChar, 100).Value = currentStudentId;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            total_Courses.Text = Convert.ToInt32(reader["TotalCourses"]).ToString();

                            currentCgpaValue = Convert.ToDecimal(reader["CurrentCGPA"]);

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

                MessageBox.Show( $"Failed to load CGPA details:\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void LoadPendingTaskCount()
        {
            const string query = @" SELECT COUNT(*) FROM dbo.ToDoList
                                    WHERE LTRIM(RTRIM(Status)) = @Status;";

            try
            {
                using (SqlConnection connection = new SqlConnection(todoConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = "Pending";

                    connection.Open();

                    object result = command.ExecuteScalar();

                    pending_Task.Text = Convert.ToInt32(result).ToString();
                }
            }
            catch (Exception ex)
            {
                pending_Task.Text = "0";

                MessageBox.Show(  $"Failed to load pending tasks:\n\n{ex.Message}", "Database Error",  MessageBoxButtons.OK,   MessageBoxIcon.Error);
            }
        }




        private void LoadTodaysClasses()
        {
            todays_classes.Controls.Clear();
            todays_classes.AutoScroll = true;

            string today = DateTime.Now.DayOfWeek.ToString();

            const string query = @"
                SELECT CourseName, InstructorName, RoomNumber, StartTime, EndTime, ClassType 
                FROM dbo.classes 
                WHERE LOWER(TRIM(Day)) = LOWER(@Today) 
                ORDER BY ClassId ASC;";

            try
            {
                using (SqlConnection connection = new SqlConnection(cgpaConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Today", SqlDbType.VarChar, 50).Value = today.Trim();
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Label noClassLabel = new Label
                            {
                                Text = $"No classes scheduled for today ({today}) 🎉",
                                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                                ForeColor = Color.DimGray,
                                AutoSize = true,
                                Location = new Point(15, 15)
                            };
                            todays_classes.Controls.Add(noClassLabel);
                            return;
                        }

                        int cardLeft = 10;
                        int cardTop = 10;
                        int cardWidth = 200;
                        int cardHeight = 110;

                        while (reader.Read())
                        {
                            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;
                            string instructor = reader["InstructorName"]?.ToString() ?? string.Empty;
                            string room = reader["RoomNumber"]?.ToString() ?? string.Empty;
                            string startTime = reader["StartTime"]?.ToString() ?? string.Empty;
                            string endTime = reader["EndTime"]?.ToString() ?? string.Empty;
                            string type = reader["ClassType"]?.ToString() ?? string.Empty;

                            Panel classCard = new Panel
                            {
                                Size = new Size(cardWidth, cardHeight),
                                Location = new Point(cardLeft, cardTop),
                                BackColor = Color.FromArgb(240, 244, 248),
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            Label lblTitle = new Label
                            {
                                Text = courseName,
                                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                                ForeColor = Color.FromArgb(24, 30, 54),
                                Location = new Point(8, 8),
                                AutoSize = true
                            };

                            Label lblTime = new Label
                            {
                                Text = $"Time: {startTime} - {endTime}",
                                Font = new Font("Segoe UI", 8f, FontStyle.Regular),
                                ForeColor = Color.DarkSlateGray,
                                Location = new Point(8, 32),
                                AutoSize = true
                            };

                            Label lblRoom = new Label
                            {
                                Text = $"Room: {room} ({type})",
                                Font = new Font("Segoe UI", 8f, FontStyle.Regular),
                                ForeColor = Color.DarkSlateGray,
                                Location = new Point(8, 52),
                                AutoSize = true
                            };

                            Label lblInstructor = new Label
                            {
                                Text = $"Instructor: {instructor}",
                                Font = new Font("Segoe UI", 8f, FontStyle.Italic),
                                ForeColor = Color.DimGray,
                                Location = new Point(8, 74),
                                AutoSize = true
                            };

                            classCard.Controls.Add(lblTitle);
                            classCard.Controls.Add(lblTime);
                            classCard.Controls.Add(lblRoom);
                            classCard.Controls.Add(lblInstructor);

                            todays_classes.Controls.Add(classCard);

                            cardLeft += cardWidth + 10;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load today's class schedule:\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK,  MessageBoxIcon.Error);
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



        private void show_cgpa_CheckedChanged(object sender, EventArgs e)
        {
            current_Cgpa.Text = show_cgpa.Checked
                ? currentCgpaValue.ToString("0.00")
                : "****";
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
                MessageBox.Show( $"Failed to open AIUB Portal:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(  $"Failed to open AIUB Connect:\n\n{ex.Message}",  "Error", MessageBoxButtons.OK,  MessageBoxIcon.Error);
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
                MessageBox.Show( $"Failed to open Study Hub:\n\n{ex.Message}",  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label1_Click(object sender, EventArgs e) { }
        private void course_name_TextChanged(object sender, EventArgs e) { }
        private void credit_SelectedIndexChanged(object sender, EventArgs e) { }
        private void grade_SelectedIndexChanged(object sender, EventArgs e) { }
        private void semester_TextChanged(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void pending_Task_Click(object sender, EventArgs e) { }
        private void total_Courses_Click(object sender, EventArgs e) { }
        private void upcoming_Exam_Click(object sender, EventArgs e) { }
        private void current_Cgpa_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void todays_classes_Paint(object sender, PaintEventArgs e) { }
    }
}