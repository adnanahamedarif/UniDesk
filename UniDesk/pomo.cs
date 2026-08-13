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



        // Session Durations (in seconds)
        private const int WORK_DURATION = 25 * 60;      // 25 minutes
        private const int SHORT_BREAK = 5 * 60;         // 5 minutes
        private const int LONG_BREAK = 15 * 60;         // 15 minutes

        // UI Controls - declared but initialized in Designer
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Button Pause_btn;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.ProgressBar progressBar;

        public pomo()
        {
            InitializeComponent();
            InitializeTimer();
            SetSession(SessionType.Work);

        }


        private enum SessionType
        {
            Work,
            ShortBreak,
            LongBreak
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(1000); // 1 second interval
            timer.SynchronizingObject = this;
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
                    UpdateTimerDisplay();
                    UpdateProgressBar();
                }
                if (remainingSeconds <= 0)
                {
                    timer.Stop();
                    isRunning = false;
                    isPaused = false;

                }
                else
                {
                    lblTimer.ForeColor = isWorkSession
                        ? Color.FromArgb(0,0,0)
                        : Color.FromArgb(46, 204, 113);
                }

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
            remainingSeconds = totalSeconds;

            Start_btn.Enabled = true;
            Pause_btn.Enabled = false;
            Pause_btn.Text = "Pause";

            UpdateTimerDisplay();
            UpdateProgressBar();
        }


        private void SetSession(SessionType sessionType)
        {
            timer.Stop();

            isRunning = false;
            isPaused = false;

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

            Start_btn.Enabled = true;
            Pause_btn.Enabled = false;
            Pause_btn.Text = "Pause";

            UpdateTimerDisplay();
            UpdateProgressBar();
        }



        // Button Click Events
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (remainingSeconds <= 0)
            {
                ResetTimer();
            }

            isRunning = true;
            isPaused = false;

            timer.Start();

            Start_btn.Enabled = false;
            Pause_btn.Enabled = true;
            Pause_btn.Text = "Pause";
        }

        

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (!isRunning)
                return;

            if (!isPaused)
            {
                isPaused = true;
                timer.Stop();

                Pause_btn.Text = "Resume";
                Start_btn.Enabled = false;
            }
            else
            {
                isPaused = false;
                timer.Start();

                Pause_btn.Text = "Pause";
                Start_btn.Enabled = false;
            }

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



        private void Form_Load(object sender, EventArgs e)
        {
            SetSession(SessionType.Work);

        }

        private void Form_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Elapsed -= OnTick;
                timer.Dispose();
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }


}