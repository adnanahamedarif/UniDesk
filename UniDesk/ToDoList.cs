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

        private DataTable originalTable; // To store unfiltered data

        public ToDoList()
        {
            InitializeComponent();

            // Wire up the button click events
            this.AutoScroll= true;
            this.addbtn.Click += new EventHandler(this.addbtn_Click);
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Click += new EventHandler(this.button2_Click);
            this.searchTextBox.TextChanged += new EventHandler(this.searchTextBox_TextChanged);

            // Setup DataGridView
            SetupDataGridView();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            LoadTasks();
            UpdateDashboard();
            CenterContent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Not currently used
        }

        private string GetConnectionString()
        {
            return connectionString;
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add columns
            DataGridViewTextBoxColumn serialColumn = new DataGridViewTextBoxColumn();
            serialColumn.Name = "Serial";
            serialColumn.HeaderText = "ID";
            serialColumn.DataPropertyName = "Serial";
            serialColumn.Width = 60;
            serialColumn.Visible = false;
            dataGridView1.Columns.Add(serialColumn);

            DataGridViewTextBoxColumn taskColumn = new DataGridViewTextBoxColumn();
            taskColumn.Name = "Task";
            taskColumn.HeaderText = "Task";
            taskColumn.DataPropertyName = "Task";
            taskColumn.Width = 350;
            dataGridView1.Columns.Add(taskColumn);

            DataGridViewTextBoxColumn taskDateColumn = new DataGridViewTextBoxColumn();
            taskDateColumn.Name = "TaskDate";
            taskDateColumn.HeaderText = "Due Date";
            taskDateColumn.DataPropertyName = "TaskDate";
            taskDateColumn.Width = 140;
            taskDateColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns.Add(taskDateColumn);

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            statusColumn.DataPropertyName = "Status";
            statusColumn.Width = 120;
            dataGridView1.Columns.Add(statusColumn);

            // Handle cell formatting for colors
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);

            // Handle row painting for overdue dates
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Format Status column with color
            if (e.ColumnIndex == dataGridView1.Columns["Status"].Index && e.RowIndex >= 0)
            {
                string status = e.Value?.ToString();
                if (status == "Pending")
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 224, 178);
                    e.CellStyle.ForeColor = Color.FromArgb(255, 140, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (status == "Completed")
                {
                    e.CellStyle.BackColor = Color.FromArgb(200, 230, 200);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 128, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string status = row.Cells["Status"].Value?.ToString();
            DateTime taskDate = Convert.ToDateTime(row.Cells["TaskDate"].Value);

            // Highlight overdue tasks (date < today and status is pending)
            if (taskDate.Date < DateTime.Today.Date && status == "Pending")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(220, 0, 0);
                row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
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

                    // Check for duplicate tasks
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

                if (duplicateTasks.Any())
                {
                    // You can highlight duplicates or show a warning
                    // For now, we'll just keep track of them
                }
            }
        }

        private void UpdateDashboard()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Get total tasks
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ToDoList", conn))
                    {
                        int total = Convert.ToInt32(cmd.ExecuteScalar());
                        lblTotalTasks.Text = total.ToString();
                    }

                    // Get pending tasks
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ToDoList WHERE Status = 'Pending'", conn))
                    {
                        int pending = Convert.ToInt32(cmd.ExecuteScalar());
                        lblPendingTasks.Text = pending.ToString();
                    }

                    // Get completed tasks
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ToDoList WHERE Status = 'Completed'", conn))
                    {
                        int completed = Convert.ToInt32(cmd.ExecuteScalar());
                        lblCompletedTasks.Text = completed.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error silently
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

            // Check for duplicate task
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Not used
        }

        private void lblTotalLabel_Click(object sender, EventArgs e)
        {
            // Not used
        }

       

        private void ToDoList_Resize(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void CenterContent()
        {
            if (panelContainer != null)
            {
                // ডকিং বন্ধ করতে হবে যেন Location কাজ করে
                panelContainer.Dock = DockStyle.None;

                // নিখুঁত মাঝখানে আনার হিসাব
                int x = (this.ClientSize.Width - panelContainer.Width) / 2;
                int y = panelContainer.Location.Y;

                if (x < 0) x = 0; // স্ক্রিন ছোট হলে যেন মাইনাস না হয়ে যায়

                panelContainer.Location = new Point(x, y);
            }
        }
    }
}