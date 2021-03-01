using Daily_Checklist_Pop_up.Properties;
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
        private bool temporary_unforce_switch = false;
        private TimeSpan _ticks;
        private readonly List<CheckBox> checkBoxes = new List<CheckBox>();
        private readonly TimeSpan _oneSecond = new TimeSpan(0, 0, 0, 1);
        private readonly DateTime end_of_day = new DateTime().Date.AddDays(1).AddTicks(-1); // End of day.
        Rectangle workingArea;
        private bool temporary_unforce_switch_2 = false;
        private bool debug_mode = false;

        public Form1()
        {
            _ticks = Countdown_calculations();
            InitializeComponent();
            BringToFront();

            #region [System tray startup]
            mynotifyicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't think there is an error.
            mynotifyicon.BalloonTipTitle = "[Daily_Checklist_Pop-up]";
            mynotifyicon.BalloonTipText = "[Program Minimized]";
            mynotifyicon.Icon = Resources.Icon1; //The tray icon to use
            mynotifyicon.Text = "[Daily_Checklist_Program]";
            //this.Form1_Resize(this, new EventArgs());
            Resize += new System.EventHandler(Form1_Resize);
            mynotifyicon.MouseClick += NotifyIcon_MouseClick;
            #endregion

            workingArea = Screen.GetWorkingArea(this);
            Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);

            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);

            checkBoxes = new List<CheckBox>()
            {
                    checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6
            };

            #region [Progress bar and timer]
            countdown_progress_bar.Maximum = (int)end_of_day.TimeOfDay.TotalSeconds;
            Debug.WriteLine("Total Seconds: " + countdown_progress_bar.Maximum);
            countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
            Debug.WriteLine("Total Seconds: " + countdown_progress_bar.Value);
            day_countdown_timer.Tick += Day_countdown_timer_Tick;
            day_countdown_timer.Interval = 1000;
            day_countdown_timer.Start();
            #endregion

            hide_button.Visible = false;
            time_test_button.Visible = false;

            hide_button.Click += new EventHandler(Hide_button_Click);
            time_test_button.Click += new EventHandler(Time_test_button_Click);
            debug_button.Click += new EventHandler(Debug_Button_Click);

        }
        private void Day_countdown_timer_Tick(object sender, EventArgs e)
        {
            /*
            // [BUG: Notification Window Constantly Steals Focus]
            Focus();
            Activate();
            this.TopMost = true;
            this.TopMost = false;
            */
            _ticks = _ticks.Subtract(_oneSecond);
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", _ticks));
            // Debug.WriteLine(this.Location);
            day_countdown_timer_label.Text = string.Format("{0:hh\\:mm\\:ss}", _ticks);
            Position_check();
            Hourly_notification();
            if (countdown_progress_bar.Maximum >= countdown_progress_bar.Value)
            {
                countdown_progress_bar.Value++;
            }
            for (int i = 0; i <= checkBoxes.Count - 1; i++)
            {
                // Debug.WriteLine(checkBoxes[i].Checked);
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
                _ticks = Countdown_calculations();
                day_countdown_timer_label.Text = "RESET_TIMER";
                countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
                // day_countdown_timer.Stop();
                for (int i = 0; i <= checkBoxes.Count - 1; i++)
                {
                    checkBoxes[i].Checked = false;
                }
            }
        }
        private void Debug_Button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[+] Debug Mode");
            debug_mode = true;
            hide_button.Visible = true;
            time_test_button.Visible = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If user presses shift + o.
            if (e.KeyChar == 79)
            {
                Debug.WriteLine("[+] Debug Mode");
                debug_mode = true;
                hide_button.Visible = true;
                time_test_button.Visible = true;
            }
        }

        /*
        private void location_check(object sender, EventArgs e)
        {
            if (this.Location != new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8))
            {
                this.Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);
            }
        }
        */
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                mynotifyicon.Visible = true;
                mynotifyicon.ShowBalloonTip(500);
                ShowInTaskbar = false;
            }
        }
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            mynotifyicon.Visible = false;
        }

        private TimeSpan Countdown_calculations()
        {
            TimeSpan remaining_time = end_of_day.TimeOfDay - DateTime.Now.TimeOfDay;
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", remaining_time));
            return remaining_time;
        }
        private void Position_check()
        {
            if (Location != new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8))
            {
                Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);
            }
        }

        private void Hourly_notification()
        {
            if (debug_mode == true)
            {
                Debug.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                Debug.WriteLine(DateTime.Now.ToString("mm"));
                bool hourly_notification_switch = false;
                for (int i = 0; i <= checkBoxes.Count - 1; i++)
                {
                    if (checkBoxes[i].Checked == false)
                    {
                        if (DateTime.Now.ToString("mm") == "00" || DateTime.Now.ToString("mm") == "30" && temporary_unforce_switch_2 == false)
                        {
                            // Show();
                            this.WindowState = FormWindowState.Normal;
                            temporary_unforce_switch = false;
                            temporary_unforce_switch_2 = true;
                            return;
                        }
                        if ((DateTime.Now.ToString("mm") == "59" || DateTime.Now.ToString("mm") == "29") && temporary_unforce_switch == false)
                        {
                            // Hide();
                            this.WindowState = FormWindowState.Minimized;
                            temporary_unforce_switch = true;
                            temporary_unforce_switch_2 = false;
                            return;
                        }
                    }
                }
                if (hourly_notification_switch == false && temporary_unforce_switch == false)
                {
                    Debug.WriteLine("Keep Hidden");
                    this.WindowState = FormWindowState.Minimized;
                    temporary_unforce_switch = true;
                    //Hide();
                }
            }

            if (debug_mode == true)
            {
                bool hourly_notification_switch = false;
                for (int i = 0; i <= checkBoxes.Count - 1; i++)
                {
                    if (checkBoxes[i].Checked == false)
                    {
                        hourly_notification_switch = true;
                        string day_countdown_timer_label_minutes = day_countdown_timer_label.Text.Substring(day_countdown_timer_label.Text.IndexOf(":") + 1, day_countdown_timer_label.Text.IndexOf(":"));
                        // [BUG: Window stays opened regardless of attempts to minimize the form when timer's minutes set at 30]
                        if ((day_countdown_timer_label_minutes == "00" || day_countdown_timer_label_minutes == "30") && temporary_unforce_switch_2 == false)
                        {
                            // Show();
                            WindowState = FormWindowState.Normal;
                            temporary_unforce_switch = false;
                            temporary_unforce_switch_2 = true;
                            return;
                        }
                        if ((day_countdown_timer_label_minutes == "59" || day_countdown_timer_label_minutes == "29") && temporary_unforce_switch == false)
                        {
                            // Hide();
                            WindowState = FormWindowState.Minimized;
                            temporary_unforce_switch = true;
                            temporary_unforce_switch_2 = false;
                            return;
                        }
                    }
                }
                // If all checkboxes are checked, keep window hidden and disable hourly notifcations.
                if (hourly_notification_switch == false && temporary_unforce_switch == false)
                {
                    Debug.WriteLine("Keep Hidden");
                    WindowState = FormWindowState.Minimized;
                    temporary_unforce_switch = true;
                    //Hide();
                }
            }
        }

        private void Time_test_button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Reduce time by 01:01:01");
            TimeSpan time_reduce = new TimeSpan(0, 1, 1, 1);
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
        private void Hide_button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Set Time To 1:30:25");
            _ticks = new TimeSpan(0, 1, 30, 25);
            //_ticks = _ticks.Subtract(new TimeSpan(0, 0, 1, 10));
        }
    }
}
