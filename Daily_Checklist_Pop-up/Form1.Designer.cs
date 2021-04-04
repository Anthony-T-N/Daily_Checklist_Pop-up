
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
            this.debug_checkbox = new System.Windows.Forms.CheckBox();
            this.edit_checkbox_button = new System.Windows.Forms.Button();
            this.change_checkbox_text_1 = new System.Windows.Forms.TextBox();
            this.change_checkbox_text_2 = new System.Windows.Forms.TextBox();
            this.change_checkbox_text_3 = new System.Windows.Forms.TextBox();
            this.change_checkbox_text_4 = new System.Windows.Forms.TextBox();
            this.change_checkbox_text_5 = new System.Windows.Forms.TextBox();
            this.change_checkbox_text_6 = new System.Windows.Forms.TextBox();
            this.current_mode_label = new System.Windows.Forms.Label();
            this.current_mode_label_2 = new System.Windows.Forms.Label();
            this.revert_default_checkbox_options_button = new System.Windows.Forms.Button();
            this.MyToolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.checkBox5.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.checkBox5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = false;
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
            this.MyToolTip.SetToolTip(this.debug_button, resources.GetString("debug_button.ToolTip"));
            this.debug_button.UseVisualStyleBackColor = true;
            // 
            // debug_checkbox
            // 
            resources.ApplyResources(this.debug_checkbox, "debug_checkbox");
            this.debug_checkbox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.debug_checkbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.debug_checkbox.Name = "debug_checkbox";
            this.debug_checkbox.UseVisualStyleBackColor = false;
            this.debug_checkbox.CheckedChanged += new System.EventHandler(this.Debug_Checkbox_CheckedChanged);
            // 
            // edit_checkbox_button
            // 
            resources.ApplyResources(this.edit_checkbox_button, "edit_checkbox_button");
            this.edit_checkbox_button.Name = "edit_checkbox_button";
            this.MyToolTip.SetToolTip(this.edit_checkbox_button, resources.GetString("edit_checkbox_button.ToolTip"));
            this.edit_checkbox_button.UseVisualStyleBackColor = true;
            // 
            // change_checkbox_text_1
            // 
            resources.ApplyResources(this.change_checkbox_text_1, "change_checkbox_text_1");
            this.change_checkbox_text_1.Name = "change_checkbox_text_1";
            // 
            // change_checkbox_text_2
            // 
            resources.ApplyResources(this.change_checkbox_text_2, "change_checkbox_text_2");
            this.change_checkbox_text_2.Name = "change_checkbox_text_2";
            // 
            // change_checkbox_text_3
            // 
            resources.ApplyResources(this.change_checkbox_text_3, "change_checkbox_text_3");
            this.change_checkbox_text_3.Name = "change_checkbox_text_3";
            // 
            // change_checkbox_text_4
            // 
            resources.ApplyResources(this.change_checkbox_text_4, "change_checkbox_text_4");
            this.change_checkbox_text_4.Name = "change_checkbox_text_4";
            // 
            // change_checkbox_text_5
            // 
            resources.ApplyResources(this.change_checkbox_text_5, "change_checkbox_text_5");
            this.change_checkbox_text_5.Name = "change_checkbox_text_5";
            // 
            // change_checkbox_text_6
            // 
            resources.ApplyResources(this.change_checkbox_text_6, "change_checkbox_text_6");
            this.change_checkbox_text_6.Name = "change_checkbox_text_6";
            // 
            // current_mode_label
            // 
            resources.ApplyResources(this.current_mode_label, "current_mode_label");
            this.current_mode_label.BackColor = System.Drawing.Color.White;
            this.current_mode_label.Name = "current_mode_label";
            // 
            // current_mode_label_2
            // 
            resources.ApplyResources(this.current_mode_label_2, "current_mode_label_2");
            this.current_mode_label_2.BackColor = System.Drawing.Color.White;
            this.current_mode_label_2.Name = "current_mode_label_2";
            // 
            // revert_default_checkbox_options_button
            // 
            resources.ApplyResources(this.revert_default_checkbox_options_button, "revert_default_checkbox_options_button");
            this.revert_default_checkbox_options_button.Name = "revert_default_checkbox_options_button";
            this.MyToolTip.SetToolTip(this.revert_default_checkbox_options_button, resources.GetString("revert_default_checkbox_options_button.ToolTip"));
            this.revert_default_checkbox_options_button.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Controls.Add(this.revert_default_checkbox_options_button);
            this.Controls.Add(this.current_mode_label_2);
            this.Controls.Add(this.current_mode_label);
            this.Controls.Add(this.change_checkbox_text_6);
            this.Controls.Add(this.change_checkbox_text_5);
            this.Controls.Add(this.change_checkbox_text_4);
            this.Controls.Add(this.change_checkbox_text_3);
            this.Controls.Add(this.change_checkbox_text_2);
            this.Controls.Add(this.change_checkbox_text_1);
            this.Controls.Add(this.edit_checkbox_button);
            this.Controls.Add(this.debug_checkbox);
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
            this.MaximizeBox = false;
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
        private System.Windows.Forms.CheckBox debug_checkbox;
        private System.Windows.Forms.Button edit_checkbox_button;
        private System.Windows.Forms.TextBox change_checkbox_text_1;
        private System.Windows.Forms.TextBox change_checkbox_text_2;
        private System.Windows.Forms.TextBox change_checkbox_text_3;
        private System.Windows.Forms.TextBox change_checkbox_text_4;
        private System.Windows.Forms.TextBox change_checkbox_text_5;
        private System.Windows.Forms.TextBox change_checkbox_text_6;
        private System.Windows.Forms.Label current_mode_label;
        private System.Windows.Forms.Label current_mode_label_2;
        private System.Windows.Forms.Button revert_default_checkbox_options_button;
        private System.Windows.Forms.ToolTip MyToolTip;
    }
}

