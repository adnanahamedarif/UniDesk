using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class Home : Form
    {
        // কন্টেন্ট লোডের জন্য Panel
        private Panel contentPanel;

        public Home()
        {
            InitializeComponent();
            InitializeContentPanel();

        }

        private void InitializeContentPanel()
        {
            // contentPanel তৈরি করুন - ডান পাশে নির্দিষ্ট মাপে থাকবে
            contentPanel = new Panel
            {
                BackColor = Color.White,
                Location = new Point(275, 12), // সাইডবারের পর থেকে শুরু
                Size = new Size(1145, 790)     // আপনার ফর্মের সাইজ অনুযায়ী অ্যাডজাস্ট করে নিন
            };

            // যাতে ফর্ম বড়-ছোট করলে প্যানেলও এডজাস্ট হয়
            contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Home ফর্মে Panel যোগ করুন
            this.Controls.Add(contentPanel);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new ToDoList());
        }

        private void LoadFormInPanel(Form form)
        {
            // পূর্ববর্তী কন্টেন্ট清除 করুন
            contentPanel.Controls.Clear();

            // ফর্মটি Panel-এ লোড করুন
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}