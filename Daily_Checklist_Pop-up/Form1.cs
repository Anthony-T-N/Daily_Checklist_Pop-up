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
        private int _ticks = 1000;

        public Form1()
        {
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
            if (_ticks == 5)
            {
                this.day_countdown_timer_label.Text = "DONE";
                day_countdown_timer.Stop();
            }
        }
        private void countdown_calculations()
        {
            // Determine time left in current local day and apply countdown on window countdown label.
            DateTime start_of_day = new DateTime();
            var remaining = TimeSpan.FromHours(24) - start_of_day.TimeOfDay;
            Debug.WriteLine(remaining);
            DateTime startDate = DateTime.ParseExact(DateTime.Date, "yyyyMMdd");
            Debug.WriteLine(startDate);
        }
    }
}
