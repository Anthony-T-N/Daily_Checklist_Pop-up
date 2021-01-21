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
        private double _ticks;

        public Form1()
        {
            _ticks = countdown_calculations();
            InitializeComponent();
            day_countdown_timer.Tick += day_countdown_timer_Tick;
            day_countdown_timer.Interval = 1000;
            day_countdown_timer.Start();
            countdown_calculations();
        }

        private void day_countdown_timer_Tick(object sender, EventArgs e)
        {
            _ticks--;
            this.day_countdown_timer_label.Text = _ticks.ToString();
            if (_ticks <= 5)
            {
                this.day_countdown_timer_label.Text = "DONE";
                day_countdown_timer.Stop();
            }
        }
        private double countdown_calculations()
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
            var remaining_time = end_of_day.TimeOfDay.TotalHours - DateTime.Now.TimeOfDay.TotalHours;
            Debug.WriteLine(remaining_time.ToString("HH:mm:ss tt"));
            Debug.WriteLine(string.Format("{0:HH:mm:ss tt}", remaining_time));
            return remaining_time;
        }
    }
}
