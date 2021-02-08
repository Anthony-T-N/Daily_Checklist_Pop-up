using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_Checklist_Pop_up
{
    public partial class Form1 : Form
    {
        private TimeSpan _ticks;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private readonly TimeSpan _oneSecond = new TimeSpan(0, 0, 0, 1);
        private DateTime end_of_day = new DateTime().Date.AddDays(1).AddTicks(-1); // End of day.
        Rectangle workingArea;

        public Form1()
        {
            _ticks = countdown_calculations();
            InitializeComponent();
            BringToFront();

            #region [System tray startup]
            mynotifyicon.BalloonTipText = "Application Minimized.";
            mynotifyicon.BalloonTipTitle = "test";
            this.Resize += SetMinimizeState;
            mynotifyicon.Click += ToggleMinimizeState;
            #endregion

            workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);
            checkBoxes = new List<CheckBox>()
            {
                    checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6
            };

            #region [Progress bar and timer]
            countdown_progress_bar.Maximum = (int)end_of_day.TimeOfDay.TotalSeconds;
            Debug.WriteLine("Total Seconds: " + countdown_progress_bar.Maximum);
            countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
            Debug.WriteLine("Total Seconds: " + countdown_progress_bar.Value);
            day_countdown_timer.Tick += day_countdown_timer_Tick;
            day_countdown_timer.Interval = 1000;
            day_countdown_timer.Start();
            #endregion

            time_test_button.Click += new EventHandler(time_test_button_Click);

        }
        private void day_countdown_timer_Tick(object sender, EventArgs e)
        {
            hourly_notification();
            _ticks = _ticks.Subtract(_oneSecond);
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", _ticks));
            Debug.WriteLine(this.Location);
            day_countdown_timer_label.Text = string.Format("{0:hh\\:mm\\:ss}", _ticks);
            position_check();
            if (countdown_progress_bar.Maximum >= countdown_progress_bar.Value)
            {
                countdown_progress_bar.Value++;
            }
            for (int i = 0; i <= checkBoxes.Count - 1; i++)
            {
                Debug.WriteLine(checkBoxes[i].Checked);
                if (checkBoxes[i].Checked == true)
                {
                    // Strike through checkbox text if ticked.
                    checkBoxes[i].Font = new Font(checkBoxes[i].Font, FontStyle.Strikeout);
                }
                else
                {
                    checkBoxes[i].Font = new Font(checkBoxes[i].Font, FontStyle.Regular);
                }
            }
            if (_ticks <= TimeSpan.Zero)
            {
                _ticks = countdown_calculations();
                this.day_countdown_timer_label.Text = "RESET_TIMER";
                countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
                // day_countdown_timer.Stop();
                for (int i = 0; i <= checkBoxes.Count - 1; i++)
                {
                    checkBoxes[i].Checked = false;
                }
            }
        }
        private TimeSpan countdown_calculations()
        {
            TimeSpan remaining_time = end_of_day.TimeOfDay - DateTime.Now.TimeOfDay;
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", remaining_time));
            return remaining_time;
        }
        private void position_check()
        {
            if (this.Location != new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8))
            {
                this.Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);
            }
        }

        private void hourly_notification()
        {
            Debug.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            if (DateTime.Now.ToString("mm") == "00")
            {
                Debug.WriteLine("Check");
            }
        }

        // Toggle state between Normal and Minimized.
        private void ToggleMinimizeState(object sender, EventArgs e)
        {
            bool isMinimized = this.WindowState == FormWindowState.Minimized;
            this.WindowState = (isMinimized) ? FormWindowState.Normal : FormWindowState.Minimized;
        }

        // Show/Hide window and tray icon to match window state.
        private void SetMinimizeState(object sender, EventArgs e)
        {
            bool isMinimized = this.WindowState == FormWindowState.Minimized;

            this.ShowInTaskbar = !isMinimized;
            mynotifyicon.Visible = isMinimized;
            if (isMinimized) mynotifyicon.ShowBalloonTip(500, "Application", "Application minimized to tray.", ToolTipIcon.Info);
        }

        private void time_test_button_Click(object sender, EventArgs e)
        {
            TimeSpan time_reduce = new TimeSpan(0, 1, 1, 1);
            Debug.WriteLine("Clicked");
            if (((int)time_reduce.TotalSeconds + countdown_progress_bar.Value) <= countdown_progress_bar.Maximum)
            {
                countdown_progress_bar.Value += (int)time_reduce.TotalSeconds;
            }
            else
            {
                Debug.WriteLine("Add 10 Secs");
                countdown_progress_bar.Value += 10;
            }
            _ticks = _ticks.Subtract(time_reduce);
        }
    }
}
