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

namespace UniDesk
{
    public partial class AddClass : Form
    {
        private readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        private int classId = 0;

        // 1. Default Constructor (For adding a new class)
        public AddClass()
        {
            InitializeComponent();
        }

        // 2. Overloaded Constructor (For editing an existing class)
        public AddClass(int id)
        {
            InitializeComponent();
            classId = id;
            this.Text = "Edit Class";

            // Load data immediately here so it never misses!
            if (classId > 0)
            {
                LoadClassDataForEditing();
            }
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            // Keep this empty or remove it if not needed
        }

        private void LoadClassDataForEditing()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT CourseName, InstructorName, RoomNumber, StartTime, EndTime, Day, ClassType FROM classes WHERE ClassId = @ClassId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                courseName_txt.Text = reader["CourseName"].ToString();
                                instructor_txt.Text = reader["InstructorName"].ToString();
                                room_txt.Text = reader["RoomNumber"].ToString();
                                startTime_txt.Text = reader["StartTime"].ToString();
                                endTime_txt.Text = reader["EndTime"].ToString();
                                day_cmb.Text = reader["Day"].ToString();
                                type_cmb.Text = reader["ClassType"].ToString();
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

        private void NewClassSaveBtn_Click(object sender, EventArgs e)
        {
            string courseName = courseName_txt.Text.Trim();
            string instructor = instructor_txt.Text.Trim();
            string room = room_txt.Text.Trim();
            string startTime = startTime_txt.Text.Trim();
            string endTime = endTime_txt.Text.Trim();
            string day = day_cmb.Text.Trim();
            string classType = type_cmb.Text.Trim();

            if (string.IsNullOrEmpty(courseName) || string.IsNullOrEmpty(instructor) ||
                string.IsNullOrEmpty(room) || string.IsNullOrEmpty(startTime) ||
                string.IsNullOrEmpty(endTime) || string.IsNullOrEmpty(day) || string.IsNullOrEmpty(classType))
            {
                MessageBox.Show("Please fill in all fields correctly!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "";

                    if (classId == 0)
                    {
                        query = "INSERT INTO classes (CourseName, InstructorName, RoomNumber, StartTime, EndTime, Day, ClassType) " +
                                "VALUES (@CourseName, @InstructorName, @RoomNumber, @StartTime, @EndTime, @Day, @ClassType)";
                    }
                    else
                    {
                        query = "UPDATE classes SET CourseName = @CourseName, InstructorName = @InstructorName, " +
                                "RoomNumber = @RoomNumber, StartTime = @StartTime, EndTime = @EndTime, " +
                                "Day = @Day, ClassType = @ClassType WHERE ClassId = @ClassId";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CourseName", courseName);
                        cmd.Parameters.AddWithValue("@InstructorName", instructor);
                        cmd.Parameters.AddWithValue("@RoomNumber", room);
                        cmd.Parameters.AddWithValue("@StartTime", startTime);
                        cmd.Parameters.AddWithValue("@EndTime", endTime);
                        cmd.Parameters.AddWithValue("@Day", day);
                        cmd.Parameters.AddWithValue("@ClassType", classType);

                        if (classId > 0)
                        {
                            cmd.Parameters.AddWithValue("@ClassId", classId);
                        }

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                string successMessage = (classId == 0) ? "Class saved successfully!" : "Class updated successfully!";
                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}