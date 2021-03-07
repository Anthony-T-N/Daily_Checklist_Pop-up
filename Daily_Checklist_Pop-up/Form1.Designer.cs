
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.day_countdown_timer = new System.Windows.Forms.Timer(this.components);
            this.day_countdown_timer_label = new System.Windows.Forms.Label();
            this.fast_forward_test_button = new System.Windows.Forms.Button();
            this.countdown_progress_bar = new System.Windows.Forms.ProgressBar();
            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.hide_button = new System.Windows.Forms.Button();
            this.debug_button = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.debug_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox4
            // 
            resources.ApplyResources(this.checkBox4, "checkBox4");
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            resources.ApplyResources(this.checkBox5, "checkBox5");
            this.checkBox5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            resources.ApplyResources(this.checkBox6, "checkBox6");
            this.checkBox6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // day_countdown_timer_label
            // 
            resources.ApplyResources(this.day_countdown_timer_label, "day_countdown_timer_label");
            this.day_countdown_timer_label.BackColor = System.Drawing.Color.Transparent;
            this.day_countdown_timer_label.ForeColor = System.Drawing.Color.White;
            this.day_countdown_timer_label.Name = "day_countdown_timer_label";
            // 
            // fast_forward_test_button
            // 
            this.fast_forward_test_button.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.fast_forward_test_button, "fast_forward_test_button");
            this.fast_forward_test_button.Name = "fast_forward_test_button";
            this.fast_forward_test_button.UseVisualStyleBackColor = false;
            // 
            // countdown_progress_bar
            // 
            this.countdown_progress_bar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.countdown_progress_bar.ForeColor = System.Drawing.Color.Blue;
            resources.ApplyResources(this.countdown_progress_bar, "countdown_progress_bar");
            this.countdown_progress_bar.Name = "countdown_progress_bar";
            // 
            // hide_button
            // 
            this.hide_button.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.hide_button, "hide_button");
            this.hide_button.Name = "hide_button";
            this.hide_button.UseVisualStyleBackColor = false;
            // 
            // debug_button
            // 
            resources.ApplyResources(this.debug_button, "debug_button");
            this.debug_button.Name = "debug_button";
            this.debug_button.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // debug_checkbox
            // 
            resources.ApplyResources(this.debug_checkbox, "debug_checkbox");
            this.debug_checkbox.Name = "debug_checkbox";
            this.debug_checkbox.UseVisualStyleBackColor = true;
            this.debug_checkbox.CheckedChanged += new System.EventHandler(this.debug_checkbox_CheckedChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Controls.Add(this.debug_checkbox);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.debug_button);
            this.Controls.Add(this.hide_button);
            this.Controls.Add(this.day_countdown_timer_label);
            this.Controls.Add(this.fast_forward_test_button);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.countdown_progress_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
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
        private System.Windows.Forms.Button fast_forward_test_button;
        private System.Windows.Forms.NotifyIcon mynotifyicon;
        private System.Windows.Forms.Button hide_button;
        private System.Windows.Forms.Button debug_button;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox debug_checkbox;
    }
}

