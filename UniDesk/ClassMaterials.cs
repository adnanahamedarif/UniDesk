using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class ClassMaterials : Form
    {
        private string studentId;
        private string studentName;
        private string userLocalPath;
        private string currentFolderPath;
        private Panel selectedFolderCard = null;
        private string selectedFilePath = null;
        private const string SearchPlaceholder = "Search files...";

        private readonly string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\OneDrive\Documents\loginData.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public ClassMaterials(string studentId)
        {
            InitializeComponent();
            this.studentId = studentId;

            try
            {
                InitializeUserStorage();
                LoadCoursesFromDatabase();
                SetupSearchPlaceholder();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Initialization Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUserStorage()
        {
            try
            {
                studentName = GetStudentName(studentId);
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                userLocalPath = Path.Combine(appDataPath, "UniDesk", "UserData", studentId);

                if (!Directory.Exists(userLocalPath))
                {
                    Directory.CreateDirectory(userLocalPath);
                }

            }
            catch (Exception ex)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                userLocalPath = Path.Combine(appDataPath, "UniDesk", "UserData", studentId);

                if (!Directory.Exists(userLocalPath))
                {
                    Directory.CreateDirectory(userLocalPath);
                }
            }
        }

        private string GetStudentName(string studentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name FROM users WHERE student_id = @studentId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting student name: {ex.Message}");
            }
            return studentId;
        }

        private void LoadCoursesFromDatabase()
        {
            cmbCourses.Items.Clear();
            cmbCourses.Items.Add("-- Select Course --");

            try
            {
                List<string> courses = new List<string>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT course_name 
                        FROM course 
                        WHERE student_id = @studentId
                        ORDER BY course_name";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                courses.Add(reader["course_name"].ToString());
                            }
                        }
                    }
                }

                if (courses.Count > 0)
                {
                    string coursesPath = Path.Combine(userLocalPath, "Courses");
                    if (!Directory.Exists(coursesPath)) Directory.CreateDirectory(coursesPath);

                    foreach (string courseName in courses)
                    {
                        cmbCourses.Items.Add(courseName);
                        string courseFolderPath = Path.Combine(coursesPath, courseName);
                        if (!Directory.Exists(courseFolderPath))
                        {
                            Directory.CreateDirectory(courseFolderPath);
                            CreateDefaultSubfolders(courseFolderPath);
                        }
                    }
                }
                else
                {
                    CreateDefaultCourse();
                }
            }
            catch (Exception ex)
            {
                CreateDefaultCourse();
            }

            cmbCourses.SelectedIndex = 0;
            UpdateFileCount(0);
        }

        private void CreateDefaultCourse()
        {
            try
            {
                string coursesPath = Path.Combine(userLocalPath, "Courses");
                if (!Directory.Exists(coursesPath)) Directory.CreateDirectory(coursesPath);

                string defaultCourse = "My Courses";
                string defaultPath = Path.Combine(coursesPath, defaultCourse);

                if (!Directory.Exists(defaultPath))
                {
                    Directory.CreateDirectory(defaultPath);
                    CreateDefaultSubfolders(defaultPath);
                }

                cmbCourses.Items.Add(defaultCourse);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating default course: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDefaultSubfolders(string coursePath)
        {
            string[] folders = { "Data Structures & Algorithms", "Database Management System", "Software Engineering", "Computer Networks", "Artificial Intelligence" };
            foreach (string folder in folders)
            {
                string folderPath = Path.Combine(coursePath, folder);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
        }

       

        // ============================================================
        // Modern UI Folder Cards Creation (Left Sidebar)
        // ============================================================
        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCourses.SelectedIndex > 0)
            {
                string courseName = cmbCourses.SelectedItem.ToString();
                LoadFolderCards(courseName);
            }
            else
            {
                flowFolders.Controls.Clear();
                flowFiles.Controls.Clear();
                currentFolderPath = string.Empty;
                UpdateFileCount(0);
            }
        }

        private void LoadFolderCards(string courseName)
        {
            flowFolders.Controls.Clear();
            string coursePath = Path.Combine(userLocalPath, "Courses", courseName);

            if (!Directory.Exists(coursePath))
            {
                Directory.CreateDirectory(coursePath);
                CreateDefaultSubfolders(coursePath);
            }

            // Create "All Files" Card First
            AddFolderCard("All Files", coursePath, isAllFiles: true);

            string[] subFolders = Directory.GetDirectories(coursePath);
            foreach (string folder in subFolders)
            {
                string folderName = Path.GetFileName(folder);
                AddFolderCard(folderName, folder, isAllFiles: false);
            }
        }

        private void AddFolderCard(string folderName, string folderPath, bool isAllFiles)
        {
            int fileCount = isAllFiles ?
                Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories).Length :
                Directory.GetFiles(folderPath).Length;

            Panel card = new Panel
            {
                Size = new Size(245, 54),
                Margin = new Padding(0, 0, 0, 8),
                BackColor = isAllFiles ? Color.FromArgb(226, 232, 240) : Color.White,
                Tag = folderPath,
                Cursor = Cursors.Hand
            };

            Label lblIcon = new Label
            {
                Text = "📁",
                Font = new Font("Segoe UI", 12F),
                Size = new Size(30, 30),
                Location = new Point(12, 12),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTitle = new Label
            {
                Text = folderName,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(45, 10),
                AutoSize = true
            };

            Label lblSub = new Label
            {
                Text = $"{fileCount} files",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(45, 28),
                AutoSize = true
            };

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblSub);

            // Wire Click Events
            Action selectAction = () =>
            {
                if (selectedFolderCard != null) selectedFolderCard.BackColor = Color.White;
                selectedFolderCard = card;
                card.BackColor = Color.FromArgb(226, 232, 240); // Highlight Active
                LoadFileCards(folderPath, isAllFiles);
            };

            card.Click += (s, e) => selectAction();
            lblTitle.Click += (s, e) => selectAction();
            lblSub.Click += (s, e) => selectAction();
            lblIcon.Click += (s, e) => selectAction();

            flowFolders.Controls.Add(card);

            if (isAllFiles)
            {
                selectedFolderCard = card;
                LoadFileCards(folderPath, true);
            }
        }

        // ============================================================
        // Modern UI File Cards Creation (Right Side Grid)
        // ============================================================
        private void LoadFileCards(string folderPath, bool searchSubdirectories = false)
        {
            flowFiles.Controls.Clear();
            currentFolderPath = folderPath;

            if (!Directory.Exists(folderPath)) return;

            try
            {
                string[] files = Directory.GetFiles(folderPath, "*.*",
                    searchSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    AddFileCard(fileInfo);
                }

                UpdateFileCount(files.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddFileCard(FileInfo fileInfo)
        {
            // Calculate 2-column width responsive
            int cardWidth = (flowFiles.Width - 40) / 2;
            if (cardWidth < 380) cardWidth = 380;

            Panel card = new Panel
            {
                Size = new Size(cardWidth, 100),
                Margin = new Padding(0, 0, 12, 12),
                BackColor = Color.White,
                Tag = fileInfo.FullName,
                Cursor = Cursors.Hand
            };

            string ext = fileInfo.Extension.TrimStart('.').ToUpper();
            if (string.IsNullOrEmpty(ext)) ext = "FILE";

            // Modern Pastel Icon Box
            Panel iconBox = new Panel
            {
                Size = new Size(42, 42),
                Location = new Point(14, 14),
                BackColor = ext == "PDF" ? Color.FromArgb(254, 226, 226) : Color.FromArgb(219, 234, 254)
            };

            Label lblDocIcon = new Label
            {
                Text = "📄",
                Font = new Font("Segoe UI", 12F),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            iconBox.Controls.Add(lblDocIcon);

            // Title
            Label lblName = new Label
            {
                Text = Path.GetFileNameWithoutExtension(fileInfo.Name),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(66, 12),
                Size = new Size(cardWidth - 140, 22),
                AutoEllipsis = true
            };

            // Metadata: Code · Size · Date
            Label lblMeta = new Label
            {
                Text = $"CSE301 · {FormatFileSize(fileInfo.Length)} · {fileInfo.LastWriteTime:yyyy-MM-dd}",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(66, 34),
                AutoSize = true
            };

            // File Tag Badge (e.g., PDF)
            Label lblTag = new Label
            {
                Text = ext,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = ext == "PDF" ? Color.FromArgb(220, 38, 38) : Color.FromArgb(37, 99, 235),
                BackColor = ext == "PDF" ? Color.FromArgb(254, 226, 226) : Color.FromArgb(219, 234, 254),
                Padding = new Padding(4, 2, 4, 2),
                Location = new Point(66, 62),
                AutoSize = true
            };

            // Favorite Badge
            Label lblFav = new Label
            {
                Text = "Favorite",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(217, 119, 6),
                BackColor = Color.FromArgb(254, 243, 199),
                Padding = new Padding(4, 2, 4, 2),
                Location = new Point(115, 62),
                AutoSize = true
            };

            // Download/Open Icon Button
            Label btnOpen = new Label
            {
                Text = "📥",
                Font = new Font("Segoe UI", 11F),
                Size = new Size(28, 28),
                Location = new Point(cardWidth - 40, 12),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Assemble Card
            card.Controls.Add(iconBox);
            card.Controls.Add(lblName);
            card.Controls.Add(lblMeta);
            card.Controls.Add(lblTag);
            card.Controls.Add(lblFav);
            card.Controls.Add(btnOpen);

            // Context Menu & Double Click Events
            card.ContextMenuStrip = materialsContextMenu;
            card.MouseClick += (s, e) => {
                selectedFilePath = fileInfo.FullName;
                if (e.Button == MouseButtons.Right)
                {
                    materialsContextMenu.Show(card, e.Location);
                }
            };

            btnOpen.Click += (s, e) => OpenFile(fileInfo.FullName);
            card.DoubleClick += (s, e) => OpenFile(fileInfo.FullName);
            lblName.DoubleClick += (s, e) => OpenFile(fileInfo.FullName);

            flowFiles.Controls.Add(card);
        }

        // ============================================================
        // File Actions & Helpers
        // ============================================================
        private void OpenFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)) return;
            try
            {
                Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.#} {sizes[order]}";
        }

        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFolderPath))
            {
                MessageBox.Show("Please select a folder first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog { Multiselect = true, Title = "Select files to add" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in dialog.FileNames)
                    {
                        string dest = Path.Combine(currentFolderPath, Path.GetFileName(file));
                        File.Copy(file, dest, true);
                    }
                    LoadFileCards(currentFolderPath);
                }
            }
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = SearchPlaceholder;
            txtSearch.ForeColor = Color.Gray;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == SearchPlaceholder)
            {
                txtSearch.Text = string.Empty;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = SearchPlaceholder;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
                e.SuppressKeyPress = true;
            }
        }

        private void PerformSearch()
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(query) || query == SearchPlaceholder || string.IsNullOrEmpty(currentFolderPath)) return;

            flowFiles.Controls.Clear();
            string[] files = Directory.GetFiles(currentFolderPath, "*.*", SearchOption.AllDirectories);
            var results = files.Where(f => Path.GetFileName(f).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (string file in results)
            {
                AddFileCard(new FileInfo(file));
            }
        }

        private void openMaterialMenuItem_Click(object sender, EventArgs e) => OpenFile(selectedFilePath);

        private void renameMaterialMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath)) return;
            string newName = PromptInput("Enter new name:", "Rename File");
            if (!string.IsNullOrEmpty(newName))
            {
                string dir = Path.GetDirectoryName(selectedFilePath);
                string newPath = Path.Combine(dir, newName);
                File.Move(selectedFilePath, newPath);
                LoadFileCards(currentFolderPath);
            }
        }

        private void deleteMaterialMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath)) return;
            if (MessageBox.Show("Are you sure you want to delete this file?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(selectedFilePath);
                LoadFileCards(currentFolderPath);
            }
        }

       

        private void UpdateFileCount(int count)
        {
            if (lblFileCount != null) lblFileCount.Text = $"Files: {count}";
        }

        private string PromptInput(string title, string caption)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 160;
                prompt.Text = caption;
                prompt.StartPosition = FormStartPosition.CenterParent;

                Label lbl = new Label() { Left = 20, Top = 15, Text = title, AutoSize = true };
                TextBox txt = new TextBox() { Left = 20, Top = 40, Width = 340 };
                Button btnOk = new Button() { Text = "OK", Left = 280, Top = 75, DialogResult = DialogResult.OK };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(txt);
                prompt.Controls.Add(btnOk);
                prompt.AcceptButton = btnOk;

                return prompt.ShowDialog() == DialogResult.OK ? txt.Text : string.Empty;
            }
        }
    }
}