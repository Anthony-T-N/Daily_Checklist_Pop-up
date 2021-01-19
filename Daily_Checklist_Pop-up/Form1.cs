using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daily_Checklist_Pop_up
{
    public partial class Form1 : Form
    {
        private int _ticks = 0;

        public Form1()
        {
            InitializeComponent();
            day_countdown_timer.Tick += day_countdown_timer_Tick;
            day_countdown_timer.Interval = 1000;
            day_countdown_timer.Start();
        }

        private void day_countdown_timer_Tick(object sender, EventArgs e)
        {
            _ticks++;
            this.day_countdown_timer_label.Text = _ticks.ToString();
            if (_ticks == 5)
            {
                this.day_countdown_timer_label.Text = "DONE";
                day_countdown_timer.Stop();
            }
        }
    }
}
