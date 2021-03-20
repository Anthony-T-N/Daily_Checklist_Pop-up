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
        private bool show_switch = false;
        private bool hide_switch = false;
        private TimeSpan _ticks;
        private readonly List<CheckBox> check_boxes = new List<CheckBox>();
        private readonly TimeSpan _oneSecond = new TimeSpan(0, 0, 0, 1);
        private readonly DateTime end_of_day = new DateTime().Date.AddDays(1).AddTicks(-1); // End of day.
        private Rectangle workingArea;
        private bool debug_mode = false;
        private bool reset_offical_timer = false;
        private bool debug_info_switch = false;

        private bool checkbox_edit_mode = false;

        public Form1()
        {
            _ticks = Countdown_Calculations();
            InitializeComponent();
            BringToFront();

            #region [System tray startup]
            mynotifyicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't think there is an error.
            mynotifyicon.BalloonTipTitle = "[Daily_Checklist_Pop-up]";
            mynotifyicon.BalloonTipText = "[Program Minimized]";
            mynotifyicon.Icon = Resources.Icon1; //The tray icon to use
            mynotifyicon.Text = "[Daily_Checklist_Program]";
            //this.Form1_Resize(this, new EventArgs());
            Resize += new System.EventHandler(Window_Resize);
            mynotifyicon.MouseClick += NotifyIcon_MouseClick;
            #endregion

            workingArea = Screen.GetWorkingArea(this);
            Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);

            check_boxes = new List<CheckBox>()
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
            fast_forward_test_button.Visible = false;
            debug_checkbox.Visible = false;
            KeyPreview = true;

            change_checkbox_text_1.Visible = false;
            change_checkbox_text_2.Visible = false;
            change_checkbox_text_3.Visible = false;
            change_checkbox_text_4.Visible = false;
            change_checkbox_text_5.Visible = false;
            change_checkbox_text_6.Visible = false;

            KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            hide_button.Click += new EventHandler(Hide_Button_Click);
            fast_forward_test_button.Click += new EventHandler(Time_Test_Button_Click);
            debug_button.Click += new EventHandler(Debug_Button_Click);
            debug_checkbox.CheckedChanged += new EventHandler(Debug_Checkbox_CheckedChanged);
            edit_checkbox_button.Click += new EventHandler(edit_checkbox_button_click);
            // Window flashes when moved.
            LocationChanged += new EventHandler(Position_Check);
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
            //Position_check();
            Hourly_Notification();
            Debug_Info();
            if (countdown_progress_bar.Maximum >= countdown_progress_bar.Value)
            {
                countdown_progress_bar.Value++;
            }
            for (int i = 0; i <= check_boxes.Count - 1; i++)
            {
                // Debug.WriteLine(check_boxes[i].Checked);
                if (check_boxes[i].Checked == true)
                {
                    // Strike through checkbox text if ticked.
                    check_boxes[i].Font = new Font(check_boxes[i].Font, FontStyle.Strikeout);
                }
                else
                {
                    check_boxes[i].Font = new Font(check_boxes[i].Font, FontStyle.Regular);
                }
            }
            if (_ticks <= TimeSpan.Zero)
            {
                _ticks = Countdown_Calculations();
                day_countdown_timer_label.Text = "RESET_TIMER";
                countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
                // day_countdown_timer.Stop();
                for (int i = 0; i <= check_boxes.Count - 1; i++)
                {
                    check_boxes[i].Checked = false;
                }
            }
        }
        private void Debug_Info()
        {
            if (debug_info_switch == true)
            {
                Debug.WriteLine("show_switch: " + show_switch);
                Debug.WriteLine("hide_switch: " + hide_switch);
            }
        }
        private void edit_checkbox_button_click(object sender, EventArgs e)
        {
            checkBox1.Text = change_checkbox_text_1.Text;
            checkBox1.BackColor = System.Drawing.Color.DarkRed;
            Debug.WriteLine(change_checkbox_text_1.Text);

            Initiate_Checkbox_Edit_Mode();
        }

        private void Initiate_Checkbox_Edit_Mode()
        {
            // Form begins with debug_mode as false;
            if (checkbox_edit_mode == false)
            {
                Debug.WriteLine("[+] Checkbox Edit Mode On");
                checkbox_edit_mode = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;

                change_checkbox_text_1.Visible = true;
                change_checkbox_text_2.Visible = true;
                change_checkbox_text_3.Visible = true;
                change_checkbox_text_4.Visible = true;
                change_checkbox_text_5.Visible = true;
                change_checkbox_text_6.Visible = true;
            }
            else if (checkbox_edit_mode == true)
            {
                Debug.WriteLine("[+] Checkbox Edit Mode Off");
                checkbox_edit_mode = false;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;

                change_checkbox_text_1.Visible = false;
                change_checkbox_text_2.Visible = false;
                change_checkbox_text_3.Visible = false;
                change_checkbox_text_4.Visible = false;
                change_checkbox_text_5.Visible = false;
                change_checkbox_text_6.Visible = false;
            }
        }


        private void Debug_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (debug_checkbox.Checked)
            {
                debug_info_switch = true;
            }
            else if (!debug_checkbox.Checked)
            {
                debug_info_switch = false;
            }
        }
        // Approach 1 to initiate debug mode (Button press).
        private void Debug_Button_Click(object sender, EventArgs e)
        {
            Initiate_Debug_Mode();
        }
        // Approach 2 to initiate debug mode (Key press).
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If user presses shift + o.
            if (e.KeyChar == 79)
            {
                Initiate_Debug_Mode();
            }
        }
        private void Initiate_Debug_Mode()
        {
            // Form begins with debug_mode as false;
            if (debug_mode == false)
            {
                Debug.WriteLine("[+] Debug Mode On");
                debug_mode = true;
                hide_button.Visible = true;
                fast_forward_test_button.Visible = true;
                debug_checkbox.Visible = true;
            }
            else if (debug_mode == true)
            {
                Debug.WriteLine("[+] Debug Mode Off");
                debug_mode = false;
                hide_button.Visible = false;
                fast_forward_test_button.Visible = false;
                debug_checkbox.Visible = false;
            }
        }
        private void Window_Resize(object sender, EventArgs e)
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

        private TimeSpan Countdown_Calculations()
        {
            TimeSpan remaining_time = end_of_day.TimeOfDay - DateTime.Now.TimeOfDay;
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", remaining_time));
            return remaining_time;
        }
        private void Position_Check(object sender, EventArgs e)
        {
            if (Location != new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8))
            {
                Location = new Point((workingArea.Right - Size.Width) + 8, (workingArea.Bottom - Size.Height) + 8);
            }
        }
        private void Hourly_Notification()
        {
            if (debug_mode == false)
            {
                if (reset_offical_timer == true)
                {
                    Debug.WriteLine("Debug_Mode_Off");
                    Debug.WriteLine("Timer reset to default");
                    _ticks = Countdown_Calculations();
                    reset_offical_timer = false;
                }
                Debug.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
                Debug.WriteLine(DateTime.Now.ToString("mm"));
                bool hourly_notification_switch = false;
                for (int i = 0; i <= check_boxes.Count - 1; i++)
                {
                    // If now checkboxes have been checked.
                    if (check_boxes[i].Checked == false)
                    {
                        hourly_notification_switch = true;
                        // Show window when "mm" is 00 or 30.
                        if (DateTime.Now.ToString("mm") == "00" || DateTime.Now.ToString("mm") == "30" && hide_switch == false)
                        {
                            // Show();
                            this.WindowState = FormWindowState.Normal;
                            show_switch = false;
                            hide_switch = true;
                            return;
                        }
                        // Hide window when "mm" is 59 or 29.
                        if ((DateTime.Now.ToString("mm") == "59" || DateTime.Now.ToString("mm") == "29") && show_switch == false)
                        {
                            // Hide();
                            this.WindowState = FormWindowState.Minimized;
                            show_switch = true;
                            hide_switch = false;
                            return;
                        }
                    }
                }
                // Only reachable when all checkboxes have been checked.
                // [BUG: When all checkboxes are checked and window is unminimized. Window fails to minimise again when all checkboxes are checked again]
                if (hourly_notification_switch == false && show_switch == false)
                {
                    Debug.WriteLine("Keep Hidden");
                    this.WindowState = FormWindowState.Minimized;
                    show_switch = true;
                    //Hide();
                }
            }

            if (debug_mode == true)
            {
                if (reset_offical_timer == false)
                {
                    Debug.WriteLine("Countdown_Timer_Debug_On");
                    reset_offical_timer = true;
                }
                bool hourly_notification_switch = false;
                for (int i = 0; i <= check_boxes.Count - 1; i++)
                {
                    if (check_boxes[i].Checked == false)
                    {
                        hourly_notification_switch = true;
                        string day_countdown_timer_label_minutes = day_countdown_timer_label.Text.Substring(day_countdown_timer_label.Text.IndexOf(":") + 1, day_countdown_timer_label.Text.IndexOf(":"));
                        if ((day_countdown_timer_label_minutes == "00" || day_countdown_timer_label_minutes == "30") && hide_switch == false)
                        {
                            // Show();
                            WindowState = FormWindowState.Normal;
                            show_switch = false;
                            hide_switch = true;
                            return;
                        }
                        if ((day_countdown_timer_label_minutes == "59" || day_countdown_timer_label_minutes == "29") && show_switch == false)
                        {
                            // Hide();
                            WindowState = FormWindowState.Minimized;
                            show_switch = true;
                            hide_switch = false;
                            return;
                        }
                    }
                }
                // If all check_boxes are checked, keep window hidden and disable hourly notifcations.
                if (hourly_notification_switch == false && show_switch == false)
                {
                    Debug.WriteLine("Keep Hidden (Debug)");
                    WindowState = FormWindowState.Minimized;
                    show_switch = true;
                    //Hide();
                }
            }
        }
        private void Time_Test_Button_Click(object sender, EventArgs e)
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
        private void Hide_Button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Set Time To 1:30:25");
            _ticks = new TimeSpan(0, 1, 30, 25);
            countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
        }
    }
}