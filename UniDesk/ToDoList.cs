using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class ToDoList : Form
    {
        private readonly string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\USER\OneDrive\Documents\ToDoList.mdf;
Integrated Security=True;
TrustServerCertificate=True;";

        private DataTable originalTable; 

        public ToDoList()
        {
            InitializeComponent();

            this.AutoScroll = true;
            this.addbtn.Click += new EventHandler(this.addbtn_Click);
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Click += new EventHandler(this.button2_Click);
            this.searchTextBox.TextChanged += new EventHandler(this.searchTextBox_TextChanged);

            
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            LoadTasks();
            UpdateDashboard();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        




        private void LoadTasks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT Serial, Task, TaskDate, Status FROM ToDoList ORDER BY Serial", conn))
                {
                    originalTable = new DataTable();
                    adapter.Fill(originalTable);

                    dataGridView1.DataSource = originalTable;
                    if (dataGridView1.Columns["Serial"] != null)
                    {
                        dataGridView1.Columns["Serial"].Visible = false;
                    }

                    CheckForDuplicates();

                    UpdateDashboard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckForDuplicates()
        {
            if (originalTable != null)
            {
                var duplicateTasks = originalTable.AsEnumerable()
                    .GroupBy(r => r.Field<string>("Task"))
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

            }
        }

        private void UpdateDashboard()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ToDoList", conn))
                    {
                        int total = Convert.ToInt32(cmd.ExecuteScalar());
                        lblTotalTasks.Text = total.ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ToDoList WHERE Status = 'Pending'", conn))
                    {
                        int pending = Convert.ToInt32(cmd.ExecuteScalar());
                        lblPendingTasks.Text = pending.ToString();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ToDoList WHERE Status = 'Completed'", conn))
                    {
                        int completed = Convert.ToInt32(cmd.ExecuteScalar());
                        lblCompletedTasks.Text = completed.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dataGridView1.DataSource = originalTable;
                return;
            }

            if (originalTable != null)
            {
                DataTable filteredTable = originalTable.Clone();

                foreach (DataRow row in originalTable.Rows)
                {
                    string task = row["Task"].ToString().ToLower();
                    if (task.Contains(searchText))
                    {
                        filteredTable.ImportRow(row);
                    }
                }

                dataGridView1.DataSource = filteredTable;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string taskText = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(taskText))
            {
                MessageBox.Show("Please enter a task.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM ToDoList WHERE Task = @Task", conn))
                    {
                        cmd.Parameters.AddWithValue("@Task", taskText);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("This task already exists. Please enter a different task.",
                                "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for duplicates: " + ex.Message);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO ToDoList (Task, TaskDate, Status) VALUES (@Task, @TaskDate, @Status)", conn))
                {
                    cmd.Parameters.AddWithValue("@Task", taskText);
                    cmd.Parameters.AddWithValue("@TaskDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Status", "Pending");

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                textBox1.Clear();
                LoadTasks();
                UpdateDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to mark as complete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Serial"].Value);
            string taskName = dataGridView1.SelectedRows[0].Cells["Task"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Mark task '{taskName}' as completed?",
                "Confirm Complete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE ToDoList SET Status = @Status WHERE Serial = @Serial", conn))
                {
                    cmd.Parameters.AddWithValue("@Status", "Completed");
                    cmd.Parameters.AddWithValue("@Serial", serial);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task marked as completed!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadTasks();
                UpdateDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating task: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int serial = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Serial"].Value);
            string taskName = dataGridView1.SelectedRows[0].Cells["Task"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete task: '{taskName}'?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM ToDoList WHERE Serial = @Serial", conn))
                {
                    cmd.Parameters.AddWithValue("@Serial", serial);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Task deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadTasks();
                UpdateDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting task: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}