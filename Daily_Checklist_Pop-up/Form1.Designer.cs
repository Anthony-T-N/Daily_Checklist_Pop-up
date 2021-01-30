
namespace Daily_Checklist_Pop_up
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.day_countdown_timer = new System.Windows.Forms.Timer(this.components);
            this.day_countdown_timer_label = new System.Windows.Forms.Label();
            this.time_test_button = new System.Windows.Forms.Button();
            this.countdown_progress_bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox4.Location = new System.Drawing.Point(180, 74);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(71, 19);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Example";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox3.Location = new System.Drawing.Point(36, 74);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(68, 19);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Exercise";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox2.Location = new System.Drawing.Point(36, 49);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(110, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Digital Cleaning";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Location = new System.Drawing.Point(36, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Cleaning";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox5.Location = new System.Drawing.Point(180, 24);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(100, 19);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Programming";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox6.Location = new System.Drawing.Point(180, 49);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(62, 19);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "Github";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // day_countdown_timer_label
            // 
            this.day_countdown_timer_label.AutoSize = true;
            this.day_countdown_timer_label.BackColor = System.Drawing.Color.DarkBlue;
            this.day_countdown_timer_label.ForeColor = System.Drawing.Color.White;
            this.day_countdown_timer_label.Location = new System.Drawing.Point(135, 105);
            this.day_countdown_timer_label.Name = "day_countdown_timer_label";
            this.day_countdown_timer_label.Size = new System.Drawing.Size(37, 15);
            this.day_countdown_timer_label.TabIndex = 6;
            this.day_countdown_timer_label.Text = "Timer";
            // 
            // time_test_button
            // 
            this.time_test_button.Location = new System.Drawing.Point(2, 5);
            this.time_test_button.Name = "time_test_button";
            this.time_test_button.Size = new System.Drawing.Size(28, 82);
            this.time_test_button.TabIndex = 7;
            this.time_test_button.Text = "Test";
            this.time_test_button.UseVisualStyleBackColor = true;
            // 
            // countdown_progress_bar
            // 
            this.countdown_progress_bar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.countdown_progress_bar.ForeColor = System.Drawing.Color.Blue;
            this.countdown_progress_bar.Location = new System.Drawing.Point(12, 99);
            this.countdown_progress_bar.Name = "countdown_progress_bar";
            this.countdown_progress_bar.Size = new System.Drawing.Size(289, 28);
            this.countdown_progress_bar.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(313, 135);
            this.Controls.Add(this.day_countdown_timer_label);
            this.Controls.Add(this.time_test_button);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.countdown_progress_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily_Checklist_Pop-up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Timer day_countdown_timer;
        private System.Windows.Forms.Label day_countdown_timer_label;
        private System.Windows.Forms.ProgressBar countdown_progress_bar;
        private System.Windows.Forms.Button time_test_button;
    }
}

