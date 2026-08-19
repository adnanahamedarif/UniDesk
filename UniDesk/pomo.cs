using System;
using System.Drawing;
using System.Windows.Forms;

namespace UniDesk
{
    public partial class pomo : Form
    {
        // ব্যাকগ্রাউন্ডে স্টেট ও সিস্টেম টাইম ধরে রাখার জন্য Static Variables
        private static System.Windows.Forms.Timer bgTimer;
        private static DateTime endTime;
        private static int remainingSeconds = 25 * 60;
        private static int totalSeconds = 25 * 60;
        private static bool isRunning = false;
        private static bool isPaused = false;
        private static SessionType currentSession = SessionType.Work;

        // Session Durations (in seconds)
        private const int WORK_DURATION = 25 * 60;      // 25 minutes
        private const int SHORT_BREAK = 5 * 60;         // 5 minutes
        private const int LONG_BREAK = 15 * 60;         // 15 minutes

        private enum SessionType
        {
            Work,
            ShortBreak,
            LongBreak
        }

        public pomo()
        {
            InitializeComponent();
            EnsureGlobalTimer();
        }

        private void EnsureGlobalTimer()
        {
            if (bgTimer == null)
            {
                bgTimer = new System.Windows.Forms.Timer();
                bgTimer.Interval = 1000; // 1 second
                bgTimer.Tick += GlobalTimer_Tick;
            }
        }

        private static void GlobalTimer_Tick(object sender, EventArgs e)
        {
            if (isRunning && !isPaused)
            {
                // আসল ব্যাকগ্রাউন্ড টাইম ক্যালকুলেশন
                TimeSpan remainingSpan = endTime - DateTime.Now;
                remainingSeconds = (int)Math.Max(0, remainingSpan.TotalSeconds);

                if (remainingSeconds <= 0)
                {
                    bgTimer.Stop();
                    isRunning = false;
                    isPaused = false;
                    MessageBox.Show("Time's up!", "Pomodoro Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // যদি pomo ফর্মটি বর্তমানে খোলা থাকে, তবে UI আপডেট হবে
                if (Application.OpenForms["pomo"] is pomo activeForm && !activeForm.IsDisposed)
                {
                    activeForm.UpdateTimerDisplay();
                    activeForm.UpdateProgressBar();
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // ফর্মে ফিরে আসলে বর্তমান সময় অনুযায়ী রিফ্রেশ
            if (isRunning && !isPaused)
            {
                TimeSpan remainingSpan = endTime - DateTime.Now;
                remainingSeconds = (int)Math.Max(0, remainingSpan.TotalSeconds);
            }

            UpdateUIState();
            UpdateTimerDisplay();
            UpdateProgressBar();
        }

        private void UpdateTimerDisplay()
        {
            TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
            lblTimer.Text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);

            if (remainingSeconds <= 60)
            {
                lblTimer.ForeColor = Color.FromArgb(231, 76, 60); // Red
            }
            else if (remainingSeconds <= 300)
            {
                lblTimer.ForeColor = Color.FromArgb(241, 196, 15); // Orange/Yellow
            }
            else
            {
                lblTimer.ForeColor = Color.White;
            }
        }

        private void UpdateProgressBar()
        {
            if (totalSeconds > 0)
            {
                int progress = (int)((double)(totalSeconds - remainingSeconds) / totalSeconds * 100);
                progressBar.Value = Math.Min(Math.Max(progress, 0), 100);
            }
        }

        private void UpdateUIState()
        {
            if (isRunning)
            {
                Start_btn.Enabled = false;
                Pause_btn.Enabled = true;
                Pause_btn.Text = isPaused ? "Resume" : "Pause";
            }
            else
            {
                Start_btn.Enabled = true;
                Pause_btn.Enabled = false;
                Pause_btn.Text = "Pause";
            }
        }

        private void ResetTimer()
        {
            bgTimer.Stop();
            isRunning = false;
            isPaused = false;
            remainingSeconds = totalSeconds;

            UpdateUIState();
            UpdateTimerDisplay();
            UpdateProgressBar();
        }

        private void SetSession(SessionType sessionType)
        {
            bgTimer.Stop();
            isRunning = false;
            isPaused = false;
            currentSession = sessionType;

            switch (sessionType)
            {
                case SessionType.Work:
                    totalSeconds = WORK_DURATION;
                    break;
                case SessionType.ShortBreak:
                    totalSeconds = SHORT_BREAK;
                    break;
                case SessionType.LongBreak:
                    totalSeconds = LONG_BREAK;
                    break;
            }

            remainingSeconds = totalSeconds;

            UpdateUIState();
            UpdateTimerDisplay();
            UpdateProgressBar();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (remainingSeconds <= 0)
            {
                ResetTimer();
            }

            isRunning = true;
            isPaused = false;

            // টাইমার শুরুর সাথে সাথে Target End Time নির্ধারণ
            endTime = DateTime.Now.AddSeconds(remainingSeconds);

            bgTimer.Start();
            UpdateUIState();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!isRunning)
                return;

            if (!isPaused)
            {
                isPaused = true;
                bgTimer.Stop();
            }
            else
            {
                isPaused = false;
                // রেজিউম করার সময় নতুন করে Target End Time আপডেট করা
                endTime = DateTime.Now.AddSeconds(remainingSeconds);
                bgTimer.Start();
            }

            UpdateUIState();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        private void ChangeSessionWithConfirmation(SessionType sessionType)
        {
            if (isRunning || isPaused)
            {
                DialogResult answer = MessageBox.Show(
                    "Change the current timer mode?",
                    "Change timer",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                    return;
            }

            SetSession(sessionType);
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // পেজ পরিবর্তন করলেও যেন ব্যাকগ্রাউন্ড টাইমার কন্টিনিউ হয়
        }

        private void focus_btn_Click(object sender, EventArgs e)
        {
            ChangeSessionWithConfirmation(SessionType.Work);
        }

        private void shortBreak_btn_Click(object sender, EventArgs e)
        {
            ChangeSessionWithConfirmation(SessionType.ShortBreak);
        }

        private void longBreak_btn_Click(object sender, EventArgs e)
        {
            ChangeSessionWithConfirmation(SessionType.LongBreak);
        }

        private void lblTimer_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) { }
    }
}