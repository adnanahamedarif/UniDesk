using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace UniDesk
{
    public partial class pomo : Form
    {
        // Timer Variables
        private System.Timers.Timer timer;
        private int remainingSeconds;
        private int totalSeconds;
        private bool isRunning = false;
        private bool isPaused = false;
        private bool isWorkSession = true;
        private int sessionCount = 0;

        // Session Durations (in seconds)
        private const int WORK_DURATION = 25 * 60;      // 25 minutes
        private const int SHORT_BREAK = 5 * 60;         // 5 minutes
        private const int LONG_BREAK = 15 * 60;         // 15 minutes
        private const int LONG_BREAK_INTERVAL = 4;      // After 4 work sessions

        // UI Controls - declared but initialized in Designer
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSessionCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.ComboBox cmbTimerMode;
        private System.Windows.Forms.CheckBox chkAutoStart;

        public pomo()
        {
            InitializeComponent();
            InitializeTimer();
            ResetTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(1000); // 1 second interval
            timer.Elapsed += OnTick;
            timer.AutoReset = true;
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            if (isRunning && !isPaused)
            {
                if (remainingSeconds > 0)
                {
                    remainingSeconds--;
                    UpdateUI();
                }
                else
                {
                    // Session Complete
                    isRunning = false;
                    timer.Stop();
                    OnSessionComplete();
                }
            }
        }

        private void UpdateUI()
        {
            // Update timer display on UI thread
            if (lblTimer.InvokeRequired)
            {
                lblTimer.Invoke(new Action(() => UpdateTimerDisplay()));
                progressBar.Invoke(new Action(() => UpdateProgressBar()));
            }
            else
            {
                UpdateTimerDisplay();
                UpdateProgressBar();
            }
        }

        private void UpdateTimerDisplay()
        {
            TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
            lblTimer.Text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);

            // Change color based on remaining time
            if (remainingSeconds <= 60) // Last minute
            {
                lblTimer.ForeColor = Color.Red;
            }
            else if (remainingSeconds <= 300) // Last 5 minutes
            {
                lblTimer.ForeColor = Color.Orange;
            }
            else
            {
                lblTimer.ForeColor = isWorkSession ? Color.FromArgb(52, 152, 219) : Color.FromArgb(46, 204, 113);
            }
        }

        private void UpdateProgressBar()
        {
            if (totalSeconds > 0)
            {
                int progress = (int)((double)(totalSeconds - remainingSeconds) / totalSeconds * 100);
                progressBar.Value = Math.Min(progress, 100);
            }
        }

        private void ResetTimer()
        {
            timer.Stop();
            isRunning = false;
            isPaused = false;

            if (isWorkSession)
            {
                remainingSeconds = WORK_DURATION;
                totalSeconds = WORK_DURATION;
                lblPhase.Text = "💪 Work Time";
                lblPhase.ForeColor = Color.FromArgb(52, 152, 219);
            }
            else
            {
                remainingSeconds = (sessionCount % LONG_BREAK_INTERVAL == 0) ? LONG_BREAK : SHORT_BREAK;
                totalSeconds = remainingSeconds;
                lblPhase.Text = sessionCount % LONG_BREAK_INTERVAL == 0 ? "☕ Long Break" : "☕ Short Break";
                lblPhase.ForeColor = Color.FromArgb(46, 204, 113);
            }

            UpdateTimerDisplay();
            progressBar.Value = 0;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnPause.Text = "⏸️ Pause";

            UpdateStatus("Ready");
        }

        private void OnSessionComplete()
        {
            if (isWorkSession)
            {
                sessionCount++;
                UpdateSessionCount();

                // Play notification sound (optional)
                System.Media.SystemSounds.Beep.Play();

                MessageBox.Show($"Work session completed! 🎉\nYou've completed {sessionCount} session(s).",
                    "Pomodoro Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                isWorkSession = false;

                if (chkAutoStart.Checked)
                {
                    StartTimer();
                }
                else
                {
                    ResetTimer();
                    UpdateStatus("Break Time - Click Start to begin");
                }
            }
            else
            {
                // Break completed
                System.Media.SystemSounds.Beep.Play();

                MessageBox.Show("Break time is over! Let's get back to work! 💪",
                    "Break Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                isWorkSession = true;

                if (chkAutoStart.Checked)
                {
                    StartTimer();
                }
                else
                {
                    ResetTimer();
                    UpdateStatus("Work Time - Click Start to begin");
                }
            }
        }

        private void UpdateSessionCount()
        {
            lblSessionCount.Text = $"Sessions: {sessionCount}";
        }

        private void UpdateStatus(string status)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action(() => lblStatus.Text = status));
            }
            else
            {
                lblStatus.Text = status;
            }
        }

        // Button Click Events
        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void StartTimer()
        {
            if (!isRunning)
            {
                ResetTimer();
                isRunning = true;
                isPaused = false;
                timer.Start();
                btnStart.Enabled = false;
                btnPause.Enabled = true;
                btnPause.Text = "⏸️ Pause";
                UpdateStatus("Running...");
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                if (isPaused)
                {
                    // Resume
                    isPaused = false;
                    timer.Start();
                    btnPause.Text = "⏸️ Pause";
                    UpdateStatus("Running...");
                }
                else
                {
                    // Pause
                    isPaused = true;
                    timer.Stop();
                    btnPause.Text = "▶️ Resume";
                    UpdateStatus("Paused");
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetTimer();
            UpdateStatus("Reset");
            btnPause.Enabled = false;
            btnPause.Text = "⏸️ Pause";
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isRunning = false;
            isPaused = false;
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnPause.Text = "⏸️ Pause";
            UpdateStatus("Stopped");

            if (isWorkSession)
            {
                remainingSeconds = WORK_DURATION;
                totalSeconds = WORK_DURATION;
            }
            else
            {
                remainingSeconds = (sessionCount % LONG_BREAK_INTERVAL == 0) ? LONG_BREAK : SHORT_BREAK;
                totalSeconds = remainingSeconds;
            }
            UpdateTimerDisplay();
            progressBar.Value = 0;
        }

        private void BtnSkip_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Skip current session?", "Confirm Skip",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                timer.Stop();
                isRunning = false;
                remainingSeconds = 0;
                OnSessionComplete();
            }
        }

        private void CmbTimerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                switch (cmbTimerMode.SelectedIndex)
                {
                    case 0: // Pomodoro (Default)
                        isWorkSession = true;
                        ResetTimer();
                        break;
                    case 1: // Short Break
                        isWorkSession = false;
                        remainingSeconds = SHORT_BREAK;
                        totalSeconds = SHORT_BREAK;
                        ResetTimer();
                        break;
                    case 2: // Long Break
                        isWorkSession = false;
                        remainingSeconds = LONG_BREAK;
                        totalSeconds = LONG_BREAK;
                        ResetTimer();
                        break;
                    case 3: // Custom
                        // You can add custom time input here
                        break;
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            cmbTimerMode.SelectedIndex = 0;
            UpdateSessionCount();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();
        }
    }
}