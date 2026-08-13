using System;
using System.Reflection;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class Home : Form
    {
        private readonly string currentStudentId = string.Empty;
        private readonly string currentStudentName = string.Empty;

        public string CurrentStudentId
        {
            get { return currentStudentId; }
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

            currentStudentName = string.IsNullOrWhiteSpace(studentName)
                ? "Student"
                : studentName.Trim();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentStudentId))
            {
                MessageBox.Show(
                    "Student ID is missing. Please log in again.",
                    "Student ID Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            ShowChildForm(new Dashboard(currentStudentId, currentStudentName));
        }

        private void ShowChildForm(Form childForm)
        {
            panel_Main.SuspendLayout();

            try
            {
                foreach (Control control in panel_Main.Controls)
                {
                    control.Dispose();
                }

                panel_Main.Controls.Clear();

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
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




        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new Dashboard(currentStudentId,currentStudentName));
        }




        private void button4_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentId())
                return;

            ShowChildForm(new CGPA(currentStudentId));
        }



        private void button7_Click(object sender, EventArgs e)
        {
            ShowChildForm(new ToDoList());
        }



        private void button8_Click(object sender, EventArgs e)
        {
            ShowChildForm(new pomo());
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}