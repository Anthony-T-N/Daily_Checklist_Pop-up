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

        public Form1()
        {
            _ticks = countdown_calculations();
            InitializeComponent();
            day_countdown_timer.Tick += day_countdown_timer_Tick;
            day_countdown_timer.Interval = 1000;
            day_countdown_timer.Start();
        }

        private void day_countdown_timer_Tick(object sender, EventArgs e)
        {
            _ticks.Subtract(TimeSpan.FromSeconds(1));
            Debug.WriteLine(_ticks.ToString());
            // this.day_countdown_timer_label.Text = _ticks.ToString();
            this.day_countdown_timer_label.Text = string.Format("{0:HH:mm:ss}", _ticks.ToString());
            if (_ticks.Seconds <= 0)
            {
                this.day_countdown_timer_label.Text = "DONE";
                day_countdown_timer.Stop();
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

            DateTime end_of_day = new DateTime().Date.AddDays(1).AddTicks(-1);
            DateTime start_of_day = new DateTime();
            /*
            TimeSpan current_time = new TimeSpan();
            current_time = DateTime.Now.TimeOfDay;
            */
            Debug.WriteLine(end_of_day.TimeOfDay.TotalHours);
            Debug.WriteLine(DateTime.Now.TimeOfDay.TotalHours);
            TimeSpan remaining_time = end_of_day.TimeOfDay - DateTime.Now.TimeOfDay;
            // Debug.WriteLine(remaining_time.ToString("HH:mm:ss"));
            Debug.WriteLine(string.Format("{0:HH:mm:ss tt}", end_of_day));
            Debug.WriteLine(string.Format("{0:hh\\:mm\\:ss}", remaining_time));
           // remaining_time = string.Format("{0:HH:mm:ss tt}", remaining_time);
            return remaining_time;
        }
    }
}
