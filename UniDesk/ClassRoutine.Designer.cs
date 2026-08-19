namespace UniDesk
{
    partial class ClassRoutine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassRoutine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.weeklyRoutine = new System.Windows.Forms.DataGridView();
            this.addClass_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.semester_label = new System.Windows.Forms.Label();
            this.editClassBtn = new System.Windows.Forms.Button();
            this.deleteClassBtn = new System.Windows.Forms.Button();
            this.todaysClass_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyRoutine)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1166, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class Routine";
            // 
            // weeklyRoutine
            // 
            this.weeklyRoutine.AllowUserToAddRows = false;
            this.weeklyRoutine.AllowUserToDeleteRows = false;
            this.weeklyRoutine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.weeklyRoutine.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.weeklyRoutine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.weeklyRoutine.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.weeklyRoutine.DefaultCellStyle = dataGridViewCellStyle2;
            this.weeklyRoutine.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.weeklyRoutine.EnableHeadersVisualStyles = false;
            this.weeklyRoutine.Location = new System.Drawing.Point(46, 371);
            this.weeklyRoutine.Name = "weeklyRoutine";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.weeklyRoutine.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.weeklyRoutine.RowHeadersVisible = false;
            this.weeklyRoutine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.weeklyRoutine.Size = new System.Drawing.Size(1073, 303);
            this.weeklyRoutine.TabIndex = 1;
            this.weeklyRoutine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // addClass_btn
            // 
            this.addClass_btn.BackColor = System.Drawing.Color.MediumBlue;
            this.addClass_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClass_btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.addClass_btn.Location = new System.Drawing.Point(723, 696);
            this.addClass_btn.Name = "addClass_btn";
            this.addClass_btn.Size = new System.Drawing.Size(126, 36);
            this.addClass_btn.TabIndex = 2;
            this.addClass_btn.Text = "Add Class";
            this.addClass_btn.UseVisualStyleBackColor = false;
            this.addClass_btn.Click += new System.EventHandler(this.addClass_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Weekly Routine";
            // 
            // semester_label
            // 
            this.semester_label.AutoSize = true;
            this.semester_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semester_label.Location = new System.Drawing.Point(850, 128);
            this.semester_label.Name = "semester_label";
            this.semester_label.Size = new System.Drawing.Size(125, 25);
            this.semester_label.TabIndex = 4;
            this.semester_label.Text = "Semester: ";
            this.semester_label.Click += new System.EventHandler(this.semester_label_Click);
            // 
            // editClassBtn
            // 
            this.editClassBtn.BackColor = System.Drawing.Color.Purple;
            this.editClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editClassBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.editClassBtn.Location = new System.Drawing.Point(855, 696);
            this.editClassBtn.Name = "editClassBtn";
            this.editClassBtn.Size = new System.Drawing.Size(127, 36);
            this.editClassBtn.TabIndex = 6;
            this.editClassBtn.Text = "Edit Class";
            this.editClassBtn.UseVisualStyleBackColor = false;
            this.editClassBtn.Click += new System.EventHandler(this.editClassBtn_Click);
            // 
            // deleteClassBtn
            // 
            this.deleteClassBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteClassBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteClassBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.deleteClassBtn.Location = new System.Drawing.Point(992, 696);
            this.deleteClassBtn.Name = "deleteClassBtn";
            this.deleteClassBtn.Size = new System.Drawing.Size(127, 36);
            this.deleteClassBtn.TabIndex = 7;
            this.deleteClassBtn.Text = "Delete Class";
            this.deleteClassBtn.UseVisualStyleBackColor = false;
            this.deleteClassBtn.Click += new System.EventHandler(this.deleteClassBtn_Click);
            // 
            // todaysClass_panel
            // 
            this.todaysClass_panel.BackColor = System.Drawing.Color.White;
            this.todaysClass_panel.Location = new System.Drawing.Point(46, 156);
            this.todaysClass_panel.Name = "todaysClass_panel";
            this.todaysClass_panel.Size = new System.Drawing.Size(1073, 162);
            this.todaysClass_panel.TabIndex = 8;
            this.todaysClass_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.todaysClass_panel_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Today\'s Classes";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ClassRoutine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1167, 826);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.todaysClass_panel);
            this.Controls.Add(this.deleteClassBtn);
            this.Controls.Add(this.editClassBtn);
            this.Controls.Add(this.semester_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addClass_btn);
            this.Controls.Add(this.weeklyRoutine);
            this.Controls.Add(this.panel1);
            this.Name = "ClassRoutine";
            this.Text = "ClassRoutine";
            this.Load += new System.EventHandler(this.ClassRoutine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyRoutine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView weeklyRoutine;
        private System.Windows.Forms.Button addClass_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label semester_label;
        private System.Windows.Forms.Button editClassBtn;
        private System.Windows.Forms.Button deleteClassBtn;
        private System.Windows.Forms.Panel todaysClass_panel;
        private System.Windows.Forms.Label label3;
    }
}