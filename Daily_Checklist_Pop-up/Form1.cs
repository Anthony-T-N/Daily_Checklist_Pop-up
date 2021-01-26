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
        private readonly TimeSpan _oneSecond = new TimeSpan(0, 0, 0, 1);

        public Form1()
        {
            _ticks = countdown_calculations();
            InitializeComponent();
            countdown_progress_bar.Maximum = 10;
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
            day_countdown_timer_label.Text = string.Format("{0:hh\\:mm\\:ss}", _ticks);
            countdown_progress_bar.Value++;
            if (_ticks <= TimeSpan.Zero)
            {
                _ticks = countdown_calculations();
                this.day_countdown_timer_label.Text = "RESET_TIMER";
                // day_countdown_timer.Stop();
                List<CheckBox> checkBoxes = new List<CheckBox>()
                {
                    checkBox1,
                    checkBox2,
                    checkBox3,
                    checkBox4,
                    checkBox5,
                    checkBox6
                };
                for (int i = 0; i <= checkBoxes.Count - 1; i++)
                {
                    checkBoxes[i].Checked = false;
                }
            }
        }
        private TimeSpan countdown_calculations()
        {
            // Determine time left in current local day and apply countdown on window countdown label.
            DateTime end_of_day = new DateTime().Date.AddDays(1).AddTicks(-1); // End of day.
            TimeSpan remaining_time = end_of_day.TimeOfDay - DateTime.Now.TimeOfDay;
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", remaining_time));
            return remaining_time;
        }
        private bool time_test_button_clicked = false;
        private void time_test_button_Click(object sender, EventArgs e)
        {
            TimeSpan time_reduce = new TimeSpan(0, 1, 1, 1);
            Debug.WriteLine("Clicked");
            time_test_button_clicked = true;
            _ticks = _ticks.Subtract(time_reduce);
        }
    }
}