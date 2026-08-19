using System.Drawing;
using System.Windows.Forms;

namespace UniDesk
{
    partial class ClassMaterials
    {
        private System.ComponentModel.IContainer components = null;

        // Main Containers
        private Panel mainPanel;

        // Header Controls
        private Panel searchPanel;
        private TextBox txtSearch;
        private Label lblSearchIcon;
        private Button btnUploadFile;
        private ComboBox cmbCourses;

        // Main Layout (Split Left/Right)
        private TableLayoutPanel mainTableLayout;

        // Left Sidebar - Folders
        private Panel sidebarPanel;
        private Label lblFoldersHeader;
        private FlowLayoutPanel flowFolders;

        // Right Main Content - File Cards Grid
        private Panel mainContentArea;
        private FlowLayoutPanel flowFiles;

        // Context Menu
        private ContextMenuStrip materialsContextMenu;
        private ToolStripMenuItem openMaterialMenuItem;
        private ToolStripSeparator materialMenuSeparator;
        private ToolStripMenuItem renameMaterialMenuItem;
        private ToolStripMenuItem deleteMaterialMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.flowFolders = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFoldersHeader = new System.Windows.Forms.Label();
            this.mainContentArea = new System.Windows.Forms.Panel();
            this.flowFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.materialsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMaterialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.renameMaterialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMaterialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPanel.SuspendLayout();
            this.mainTableLayout.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.mainContentArea.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.materialsContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.mainPanel.Controls.Add(this.statusStrip);
            this.mainPanel.Controls.Add(this.panel2);
            this.mainPanel.Controls.Add(this.btnUploadFile);
            this.mainPanel.Controls.Add(this.searchPanel);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.mainTableLayout);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(24, 20, 24, 10);
            this.mainPanel.Size = new System.Drawing.Size(1200, 750);
            this.mainPanel.TabIndex = 0;
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.sidebarPanel, 0, 0);
            this.mainTableLayout.Controls.Add(this.mainContentArea, 1, 0);
            this.mainTableLayout.Location = new System.Drawing.Point(21, 191);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.mainTableLayout.RowCount = 1;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayout.Size = new System.Drawing.Size(1155, 559);
            this.mainTableLayout.TabIndex = 1;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.Controls.Add(this.flowFolders);
            this.sidebarPanel.Controls.Add(this.lblFoldersHeader);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebarPanel.Location = new System.Drawing.Point(3, 18);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(264, 538);
            this.sidebarPanel.TabIndex = 0;
            // 
            // flowFolders
            // 
            this.flowFolders.AutoScroll = true;
            this.flowFolders.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowFolders.Location = new System.Drawing.Point(0, 35);
            this.flowFolders.Name = "flowFolders";
            this.flowFolders.Size = new System.Drawing.Size(267, 500);
            this.flowFolders.TabIndex = 1;
            this.flowFolders.WrapContents = false;
            // 
            // lblFoldersHeader
            // 
            this.lblFoldersHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFoldersHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFoldersHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblFoldersHeader.Location = new System.Drawing.Point(0, 0);
            this.lblFoldersHeader.Name = "lblFoldersHeader";
            this.lblFoldersHeader.Size = new System.Drawing.Size(264, 35);
            this.lblFoldersHeader.TabIndex = 0;
            this.lblFoldersHeader.Text = "Folders";
            // 
            // mainContentArea
            // 
            this.mainContentArea.Controls.Add(this.flowFiles);
            this.mainContentArea.Location = new System.Drawing.Point(273, 18);
            this.mainContentArea.Name = "mainContentArea";
            this.mainContentArea.Size = new System.Drawing.Size(879, 535);
            this.mainContentArea.TabIndex = 1;
            // 
            // flowFiles
            // 
            this.flowFiles.AutoScroll = true;
            this.flowFiles.Location = new System.Drawing.Point(3, 3);
            this.flowFiles.Name = "flowFiles";
            this.flowFiles.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.flowFiles.Size = new System.Drawing.Size(873, 525);
            this.flowFiles.TabIndex = 0;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.lblSearchIcon);
            this.searchPanel.Location = new System.Drawing.Point(12, 118);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.searchPanel.Size = new System.Drawing.Size(320, 40);
            this.searchPanel.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(74, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(233, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIcon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchIcon.Location = new System.Drawing.Point(5, 9);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(63, 24);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "Search:";
            // 
            // cmbCourses
            // 
            this.cmbCourses.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Location = new System.Drawing.Point(128, 7);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(253, 28);
            this.cmbCourses.TabIndex = 1;
            this.cmbCourses.SelectedIndexChanged += new System.EventHandler(this.cmbCourses_SelectedIndexChanged);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnUploadFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadFile.FlatAppearance.BorderSize = 0;
            this.btnUploadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadFile.ForeColor = System.Drawing.Color.White;
            this.btnUploadFile.Location = new System.Drawing.Point(831, 118);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(130, 40);
            this.btnUploadFile.TabIndex = 2;
            this.btnUploadFile.Text = "⬆ Upload File";
            this.btnUploadFile.UseVisualStyleBackColor = false;
            this.btnUploadFile.Click += new System.EventHandler(this.btnAddFiles_Click);
            // 
            // materialsContextMenu
            // 
            this.materialsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMaterialMenuItem,
            this.materialMenuSeparator,
            this.renameMaterialMenuItem,
            this.deleteMaterialMenuItem});
            this.materialsContextMenu.Name = "materialsContextMenu";
            this.materialsContextMenu.Size = new System.Drawing.Size(133, 76);
            // 
            // openMaterialMenuItem
            // 
            this.openMaterialMenuItem.Name = "openMaterialMenuItem";
            this.openMaterialMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openMaterialMenuItem.Text = "📂 Open";
            this.openMaterialMenuItem.Click += new System.EventHandler(this.openMaterialMenuItem_Click);
            // 
            // materialMenuSeparator
            // 
            this.materialMenuSeparator.Name = "materialMenuSeparator";
            this.materialMenuSeparator.Size = new System.Drawing.Size(129, 6);
            // 
            // renameMaterialMenuItem
            // 
            this.renameMaterialMenuItem.Name = "renameMaterialMenuItem";
            this.renameMaterialMenuItem.Size = new System.Drawing.Size(132, 22);
            this.renameMaterialMenuItem.Text = "✏️ Rename";
            this.renameMaterialMenuItem.Click += new System.EventHandler(this.renameMaterialMenuItem_Click);
            // 
            // deleteMaterialMenuItem
            // 
            this.deleteMaterialMenuItem.Name = "deleteMaterialMenuItem";
            this.deleteMaterialMenuItem.Size = new System.Drawing.Size(132, 22);
            this.deleteMaterialMenuItem.Text = "🗑️ Delete";
            this.deleteMaterialMenuItem.Click += new System.EventHandler(this.deleteMaterialMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 100);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbCourses);
            this.panel2.Location = new System.Drawing.Point(401, 118);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.panel2.Size = new System.Drawing.Size(399, 40);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Materials";
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFileCount,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(1000, 118);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(74, 40);
            this.statusStrip.TabIndex = 0;
            // 
            // lblFileCount
            // 
            this.lblFileCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(57, 21);
            this.lblFileCount.Text = "Files: 0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Course:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(157, 21);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ClassMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(950, 650);
            this.Name = "ClassMaterials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UniDesk - Course Materials";
            this.mainPanel.ResumeLayout(false);
            this.mainTableLayout.ResumeLayout(false);
            this.sidebarPanel.ResumeLayout(false);
            this.mainContentArea.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.materialsContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblFileCount;
        private Label label2;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}