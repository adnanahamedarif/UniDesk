using System;
using System.Reflection;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class Home : Form
    {
        private readonly string currentStudentId = string.Empty;

        // Read-only property
        public string CurrentStudentId
        {
            get { return currentStudentId; }
        }

        // Kept for the WinForms Designer
        public Home()
        {
            InitializeComponent();

            // Prevent panel_Main flickering
            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null,
                panel_Main,
                new object[] { true });
        }

        // Use this constructor after successful login
        public Home(string studentId) : this()
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentException(
                    "Student ID is required.",
                    nameof(studentId));
            }

            currentStudentId = studentId.Trim();
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel_Main.SuspendLayout();

            try
            {
                panel_Main.Controls.Clear();

                ToDoList toDoList = new ToDoList
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                panel_Main.Controls.Add(toDoList);
                toDoList.Show();
                toDoList.BringToFront();
            }
            finally
            {
                panel_Main.ResumeLayout();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentStudentId))
            {
                MessageBox.Show(
                    "Student ID is missing. Please log in again.",
                    "Student ID error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            panel_Main.SuspendLayout();

            try
            {
                panel_Main.Controls.Clear();

                CGPA cgpaForm = new CGPA(currentStudentId)
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                panel_Main.Controls.Add(cgpaForm);
                cgpaForm.Show();
                cgpaForm.BringToFront();
            }
            finally
            {
                panel_Main.ResumeLayout();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel_Main.SuspendLayout();

            try
            {
                panel_Main.Controls.Clear();

                pomo pomoForm = new pomo
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                panel_Main.Controls.Add(pomoForm);
                pomoForm.Show();
                pomoForm.BringToFront();
            }
            finally
            {
                panel_Main.ResumeLayout();
            }
        }
    }
}