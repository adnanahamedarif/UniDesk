using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class ClassRoutine : Form
    {
        private readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private readonly string student_id;

        public ClassRoutine()
        {
            InitializeComponent();
        }

        public ClassRoutine(string id) : this()
        {
            student_id = id;
        }

        private void ClassRoutine_Load(object sender, EventArgs e)
        {
            LoadRoutineData();
            LoadUserSemester();
            LoadTodaysClasses(); // আজকের ক্লাস লোড করবে
        }

        private void LoadRoutineData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT ClassId, CourseName, InstructorName, RoomNumber, StartTime, EndTime, Day, ClassType FROM classes";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            weeklyRoutine.DataSource = dt;

                            // ✅ DataGridView-তে ClassId কলামটি হাইড করার জন্য নিচে এই লাইনটি যুক্ত করুন:
                            if (weeklyRoutine.Columns.Contains("ClassId"))
                            {
                                weeklyRoutine.Columns["ClassId"].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserSemester()
        {
            // আইডি পাস হয়েছে কি না তা চেক করা
            if (string.IsNullOrWhiteSpace(student_id))
            {
                semester_label.Text = "Semester: ID Not Passed!";
                MessageBox.Show("Student ID is empty! Pass the ID from Login form.", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT current_semester FROM users WHERE TRIM(student_id) = @student_id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@student_id", student_id.Trim());
                        con.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value && !string.IsNullOrWhiteSpace(result.ToString()))
                        {
                            semester_label.Text = "Semester: " + result.ToString();
                        }
                        else
                        {
                            semester_label.Text = "Semester: Not Found";
                            MessageBox.Show($"ID '{student_id}' matched no record in 'users' table!", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading semester: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                semester_label.Text = "Semester: Error";
            }
        }

        private void LoadTodaysClasses()
        {
            todaysClass_panel.Controls.Clear();
            todaysClass_panel.AutoScroll = true;

            // আজকের বার পাওয়া যাবে (যেমন: "Thursday")
            string today = DateTime.Now.DayOfWeek.ToString();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // TRIM() ব্যবহার করা হয়েছে যাতে দিনের নামের আগে বা পরে স্পেস থাকলেও ম্যাচ করে
                    string query = "SELECT CourseName, InstructorName, RoomNumber, StartTime, EndTime, ClassType " +
                                   "FROM classes WHERE LOWER(TRIM(Day)) = LOWER(@Today) ORDER BY ClassId ASC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Today", today.Trim());
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Label noClassLabel = new Label
                                {
                                    Text = $"No classes scheduled for today ({today}) ",
                                    Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                                    ForeColor = Color.DimGray,
                                    AutoSize = true,
                                    Location = new Point(20, 20)
                                };
                                todaysClass_panel.Controls.Add(noClassLabel);
                                return;
                            }

                            int cardLeft = 15;
                            int cardTop = 15;
                            int cardWidth = 220;
                            int cardHeight = 120;

                            while (reader.Read())
                            {
                                string courseName = reader["CourseName"]?.ToString() ?? "";
                                string instructor = reader["InstructorName"]?.ToString() ?? "";
                                string room = reader["RoomNumber"]?.ToString() ?? "";
                                string startTime = reader["StartTime"]?.ToString() ?? "";
                                string endTime = reader["EndTime"]?.ToString() ?? "";
                                string type = reader["ClassType"]?.ToString() ?? "";

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
                                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                    ForeColor = Color.FromArgb(24, 30, 54),
                                    Location = new Point(10, 8),
                                    AutoSize = true
                                };

                                Label lblTime = new Label
                                {
                                    Text = $"🕒 {startTime} - {endTime}",
                                    Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                                    ForeColor = Color.DarkSlateGray,
                                    Location = new Point(10, 35),
                                    AutoSize = true
                                };

                                Label lblRoom = new Label
                                {
                                    Text = $"📍 Room: {room} ({type})",
                                    Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                                    ForeColor = Color.DarkSlateGray,
                                    Location = new Point(10, 58),
                                    AutoSize = true
                                };

                                Label lblInstructor = new Label
                                {
                                    Text = $"👨‍🏫 {instructor}",
                                    Font = new Font("Segoe UI", 8.5f, FontStyle.Italic),
                                    ForeColor = Color.DimGray,
                                    Location = new Point(10, 82),
                                    AutoSize = true
                                };

                                classCard.Controls.Add(lblTitle);
                                classCard.Controls.Add(lblTime);
                                classCard.Controls.Add(lblRoom);
                                classCard.Controls.Add(lblInstructor);

                                todaysClass_panel.Controls.Add(classCard);

                                cardLeft += cardWidth + 15;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's classes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addClass_btn_Click(object sender, EventArgs e)
        {
            AddClass addClassForm = new AddClass();
            addClassForm.ShowDialog();
            RefreshAllData();
        }

        private void editClassBtn_Click(object sender, EventArgs e)
        {
            if (weeklyRoutine.SelectedRows.Count > 0 || weeklyRoutine.CurrentCell != null)
            {
                int rowIndex = weeklyRoutine.CurrentRow.Index;
                int classId = Convert.ToInt32(weeklyRoutine.Rows[rowIndex].Cells["ClassId"].Value);

                AddClass addClassForm = new AddClass(classId);
                addClassForm.ShowDialog();
                RefreshAllData();
            }
            else
            {
                MessageBox.Show("Please select a class to edit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteClassBtn_Click(object sender, EventArgs e)
        {
            if (weeklyRoutine.SelectedRows.Count > 0 || weeklyRoutine.CurrentCell != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int rowIndex = weeklyRoutine.CurrentRow.Index;
                        int classId = Convert.ToInt32(weeklyRoutine.Rows[rowIndex].Cells["ClassId"].Value);

                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            string query = "DELETE FROM classes WHERE ClassId = @ClassId";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@ClassId", classId);
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Class deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshAllData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a class to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshAllData()
        {
            LoadRoutineData();
            LoadTodaysClasses();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void semester_label_Click(object sender, EventArgs e)
        {
            LoadUserSemester();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void todaysClass_panel_Paint(object sender, PaintEventArgs e) {
           

        }
    }
}