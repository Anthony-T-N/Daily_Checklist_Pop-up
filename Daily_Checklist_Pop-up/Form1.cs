sing System;
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
        private readonly TimeSpan _oneSecond = new TimeSpan(0, 0, 0, 1);
        private DateTime end_of_day = new DateTime().Date.AddDays(1).AddTicks(-1); // End of day.
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        public Form1()
        {
            _ticks = countdown_calculations();
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(1598, 873);
            checkBoxes = new List<CheckBox>()
            {
                    checkBox1,
                    checkBox2,
                    checkBox3,
                    checkBox4,
                    checkBox5,
                    checkBox6
            };
            countdown_progress_bar.Maximum = (int)end_of_day.TimeOfDay.TotalSeconds;
            Debug.WriteLine("Total Seconds: " + countdown_progress_bar.Maximum);
            countdown_progress_bar.Value = countdown_progress_bar.Maximum - (int)_ticks.TotalSeconds;
            Debug.WriteLine("Total Seconds: " + countdown_progress_bar.Value);
            day_countdown_timer.Tick += day_countdown_timer_Tick;
            day_countdown_timer.Interval = 1000;
            day_countdown_timer.Start();
            time_test_button.Click += new EventHandler(time_test_button_Click);
            Debug.WriteLine("End here");
        }
        private void day_countdown_timer_Tick(object sender, EventArgs e)
        {
            _ticks = _ticks.Subtract(_oneSecond);
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", _ticks));
            Debug.WriteLine(this.Location);
            day_countdown_timer_label.Text = string.Format("{0:hh\\:mm\\:ss}", _ticks);
            if (countdown_progress_bar.Maximum >= countdown_progress_bar.Value)
            {
                countdown_progress_bar.Value++;
            }
            for (int i = 0; i <= checkBoxes.Count - 1; i++)
            {
                Debug.WriteLine(checkBoxes[i].Checked);
                if (checkBoxes[i].Checked == true)
                {
                    checkBoxes[i].Font = new Font(checkBoxes[i].Font, FontStyle.Strikeout);
                }
                // Unstrike text if checkbox is unchecked.
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
            // Determine time left in current local day and apply countdown on window countdown label.
            TimeSpan remaining_time = end_of_day.TimeOfDay - DateTime.Now.TimeOfDay;
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", remaining_time));
            return remaining_time;
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
