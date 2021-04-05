using Daily_Checklist_Pop_up.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private bool persistence_option_switch = false;

        private List<string> default_checkbox_options = new List<string>()
        {
            "Cleaning", "Digital Cleaning", "Exercise", "Github", "Programming", "Example"
        };

        private List<TextBox> change_checkboxes_text_list = new List<TextBox>();
        private bool checkbox_edit_mode = false;

        public Form1()
        {
            Start_up_window();

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

            change_checkboxes_text_list = new List<TextBox>()
            {
                change_checkbox_text_1,
                change_checkbox_text_2,
                change_checkbox_text_3,
                change_checkbox_text_4,
                change_checkbox_text_5,
                change_checkbox_text_6
            };

            for (int i = 0; i <= change_checkboxes_text_list.Count - 1; i++)
            {
                change_checkboxes_text_list[i].Visible = false;
                change_checkboxes_text_list[i].Text = check_boxes[i].Text;
            }
            current_mode_label.Visible = false;
            current_mode_label_2.Visible = false;

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

            #region [Event Handlers]
            KeyPress += new KeyPressEventHandler(Form1_KeyPress);
            hide_button.Click += new EventHandler(Hide_Test_Button_Click);
            fast_forward_test_button.Click += new EventHandler(Forward_Time_Test_Button_Click);
            debug_button.Click += new EventHandler(Debug_Button_Click);
            debug_checkbox.CheckedChanged += new EventHandler(Debug_Checkbox_CheckedChanged);
            edit_checkbox_button.Click += new EventHandler(Edit_checkbox_button_click);
            revert_default_checkbox_options_button.Click += new EventHandler(Revert_Default_Checkbox_Options_Button_Click);
            // Window flashes when moved.
            LocationChanged += new EventHandler(Position_Check);
            #endregion
        }
        private void Start_up_window()
        {
            // Option to allow application to run at startup.
            // Displays the MessageBox.
            DialogResult result;
            result = MessageBox.Show("Always start application at start-up ? ", "Options Window", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Debug.WriteLine("Start at startup");
            }
            else if (result == System.Windows.Forms.DialogResult.No)
            {
                Debug.WriteLine("Do not start at start-up");
            }
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                Debug.WriteLine("Exit");
                System.Environment.Exit(0);
            }
            // Option for persistent checkbox options.
            DialogResult persistent_question_window;
            persistent_question_window = MessageBox.Show("Persistent checkbox options ? ", "Options Window", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (persistent_question_window == System.Windows.Forms.DialogResult.Yes)
            {
                Debug.WriteLine("Enable persistent checkbox options");
                persistence_option_switch = true;
            }
            else if (persistent_question_window == System.Windows.Forms.DialogResult.No)
            {
                Debug.WriteLine("Do not enable persistent checkbox options");
                persistence_option_switch = false;
            }
            else if (persistent_question_window == System.Windows.Forms.DialogResult.Cancel)
            {
                Debug.WriteLine("Exit");
                System.Environment.Exit(0);
            }
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
        private void Edit_checkbox_button_click(object sender, EventArgs e)
        {
            for (int i = 0; i <= change_checkboxes_text_list.Count - 1; i++)
            {
                check_boxes[i].Text = change_checkboxes_text_list[i].Text;
                // Checkbox text limit below 16.
                if (change_checkboxes_text_list[i].Text.Length >= 17)
                {
                    change_checkboxes_text_list[i].Text = change_checkboxes_text_list[i].Text.Substring(0, 16);
                    MessageBox.Show("Maximum checkbox text length reached! " + "\r\n" + "[Checkbox " + i + "]", "Checkbox Text Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                check_boxes[i].Text = change_checkboxes_text_list[i].Text;
            }
            Initiate_Checkbox_Edit_Mode();
        }

        private void Initiate_Checkbox_Edit_Mode()
        {
            Change_Mode_Label("Edit Checkbox Mode");
            // Form begins with check_edit_mode as false;
            if (checkbox_edit_mode == false)
            {
                Debug.WriteLine("[+] Checkbox Edit Mode On");
                checkbox_edit_mode = true;

                for (int i = 0; i <= change_checkboxes_text_list.Count - 1; i++)
                {
                    change_checkboxes_text_list[i].Visible = true;
                }
            }
            else if (checkbox_edit_mode == true)
            {
                Debug.WriteLine("[+] Checkbox Edit Mode Off");
                checkbox_edit_mode = false;

                for (int i = 0; i <= change_checkboxes_text_list.Count - 1; i++)
                {
                    change_checkboxes_text_list[i].Visible = false;
                }
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
            Change_Mode_Label("Debug Mode");
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
        private void Change_Mode_Label(string label_text)
        {
            if (label_text == "Edit Checkbox Mode")
            {
                if (current_mode_label.Visible == false)
                {
                    current_mode_label.Visible = true;
                    current_mode_label.Text = label_text;
                }
                else if (current_mode_label.Visible == true)
                {
                    current_mode_label.Visible = false;
                }
            }
            else if (label_text == "Debug Mode")
            {
                if (current_mode_label_2.Visible == false)
                {
                    current_mode_label_2.Visible = true;
                    current_mode_label_2.Text = label_text;
                }
                else if (current_mode_label_2.Visible == true)
                {
                    current_mode_label_2.Visible = false;
                }
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
        private void Forward_Time_Test_Button_Click(object sender, EventArgs e)
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
        private void Hide_Test_Button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Set Time To 1:30:25");
            _ticks = new TimeSpan(0, 1, 30, 25);
            countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
        }

        private void Revert_Default_Checkbox_Options_Button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Revert Checkbox Options To Default");
            for (int i = 0; i <= check_boxes.Count - 1; i++)
            {
                check_boxes[i].Text = default_checkbox_options[i];
                change_checkboxes_text_list[i].Text = default_checkbox_options[i];
            }
        }
        private void Persistence_Option()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "[current_checkbox_options].txt");
            if (persistence_option_switch == true)
            {
                if (System.IO.File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    for (int i = lines.Length; i > 0; i--)
                    {
                        string last_lines = lines[lines.Length - i];
                        System.Console.WriteLine(last_lines);
                    }
                }
                else if (!System.IO.File.Exists(path))
                {
                    Debug.WriteLine(" ");
                    Debug.WriteLine("[*] Text file does not exist. Creating a new one.");
                    Debug.WriteLine(" ");
                }
            }
        }
    }
}