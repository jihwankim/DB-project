namespace DB_Project
{
    partial class Option
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OptionKeyDown = new System.Windows.Forms.CheckBox();
            this.OptionKeyPress = new System.Windows.Forms.CheckBox();
            this.OptionKeyUp = new System.Windows.Forms.CheckBox();
            this.OptionMouseMove = new System.Windows.Forms.CheckBox();
            this.OptionMouseLClick = new System.Windows.Forms.CheckBox();
            this.OptionMouseRClick = new System.Windows.Forms.CheckBox();
            this.OptionMouseWheel = new System.Windows.Forms.CheckBox();
            this.KeyOptionPanel = new System.Windows.Forms.Panel();
            this.MouseOptionPanel = new System.Windows.Forms.Panel();
            this.OptionOKButton = new System.Windows.Forms.Button();
            this.OptionCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OptionInterval = new System.Windows.Forms.TextBox();
            this.KeyOptionPanel.SuspendLayout();
            this.MouseOptionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionKeyDown
            // 
            this.OptionKeyDown.AutoSize = true;
            this.OptionKeyDown.Checked = true;
            this.OptionKeyDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionKeyDown.Location = new System.Drawing.Point(3, 3);
            this.OptionKeyDown.Name = "OptionKeyDown";
            this.OptionKeyDown.Size = new System.Drawing.Size(113, 16);
            this.OptionKeyDown.TabIndex = 0;
            this.OptionKeyDown.Text = "KeyDown Event";
            this.OptionKeyDown.UseVisualStyleBackColor = true;
            // 
            // OptionKeyPress
            // 
            this.OptionKeyPress.AutoSize = true;
            this.OptionKeyPress.Checked = true;
            this.OptionKeyPress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionKeyPress.Location = new System.Drawing.Point(3, 25);
            this.OptionKeyPress.Name = "OptionKeyPress";
            this.OptionKeyPress.Size = new System.Drawing.Size(114, 16);
            this.OptionKeyPress.TabIndex = 1;
            this.OptionKeyPress.Text = "KeyPress Event";
            this.OptionKeyPress.UseVisualStyleBackColor = true;
            // 
            // OptionKeyUp
            // 
            this.OptionKeyUp.AutoSize = true;
            this.OptionKeyUp.Checked = true;
            this.OptionKeyUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionKeyUp.Location = new System.Drawing.Point(3, 47);
            this.OptionKeyUp.Name = "OptionKeyUp";
            this.OptionKeyUp.Size = new System.Drawing.Size(96, 16);
            this.OptionKeyUp.TabIndex = 2;
            this.OptionKeyUp.Text = "KeyUp Event";
            this.OptionKeyUp.UseVisualStyleBackColor = true;
            // 
            // OptionMouseMove
            // 
            this.OptionMouseMove.AutoSize = true;
            this.OptionMouseMove.Checked = true;
            this.OptionMouseMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionMouseMove.Location = new System.Drawing.Point(3, 3);
            this.OptionMouseMove.Name = "OptionMouseMove";
            this.OptionMouseMove.Size = new System.Drawing.Size(133, 16);
            this.OptionMouseMove.TabIndex = 3;
            this.OptionMouseMove.Text = "Mouse Move Event";
            this.OptionMouseMove.UseVisualStyleBackColor = true;
            // 
            // OptionMouseLClick
            // 
            this.OptionMouseLClick.AutoSize = true;
            this.OptionMouseLClick.Checked = true;
            this.OptionMouseLClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionMouseLClick.Location = new System.Drawing.Point(3, 25);
            this.OptionMouseLClick.Name = "OptionMouseLClick";
            this.OptionMouseLClick.Size = new System.Drawing.Size(154, 16);
            this.OptionMouseLClick.TabIndex = 4;
            this.OptionMouseLClick.Text = "Mouse Left Click Event";
            this.OptionMouseLClick.UseVisualStyleBackColor = true;
            // 
            // OptionMouseRClick
            // 
            this.OptionMouseRClick.AutoSize = true;
            this.OptionMouseRClick.Checked = true;
            this.OptionMouseRClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionMouseRClick.Location = new System.Drawing.Point(4, 47);
            this.OptionMouseRClick.Name = "OptionMouseRClick";
            this.OptionMouseRClick.Size = new System.Drawing.Size(162, 16);
            this.OptionMouseRClick.TabIndex = 5;
            this.OptionMouseRClick.Text = "Mouse Right Click Event";
            this.OptionMouseRClick.UseVisualStyleBackColor = true;
            // 
            // OptionMouseWheel
            // 
            this.OptionMouseWheel.AutoSize = true;
            this.OptionMouseWheel.Checked = true;
            this.OptionMouseWheel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OptionMouseWheel.Location = new System.Drawing.Point(3, 69);
            this.OptionMouseWheel.Name = "OptionMouseWheel";
            this.OptionMouseWheel.Size = new System.Drawing.Size(136, 16);
            this.OptionMouseWheel.TabIndex = 6;
            this.OptionMouseWheel.Text = "Mouse Wheel Event";
            this.OptionMouseWheel.UseVisualStyleBackColor = true;
            // 
            // KeyOptionPanel
            // 
            this.KeyOptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KeyOptionPanel.Controls.Add(this.OptionKeyDown);
            this.KeyOptionPanel.Controls.Add(this.OptionKeyPress);
            this.KeyOptionPanel.Controls.Add(this.OptionKeyUp);
            this.KeyOptionPanel.Location = new System.Drawing.Point(12, 12);
            this.KeyOptionPanel.Name = "KeyOptionPanel";
            this.KeyOptionPanel.Size = new System.Drawing.Size(128, 67);
            this.KeyOptionPanel.TabIndex = 7;
            // 
            // MouseOptionPanel
            // 
            this.MouseOptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MouseOptionPanel.Controls.Add(this.OptionMouseMove);
            this.MouseOptionPanel.Controls.Add(this.OptionMouseLClick);
            this.MouseOptionPanel.Controls.Add(this.OptionMouseWheel);
            this.MouseOptionPanel.Controls.Add(this.OptionMouseRClick);
            this.MouseOptionPanel.Location = new System.Drawing.Point(12, 85);
            this.MouseOptionPanel.Name = "MouseOptionPanel";
            this.MouseOptionPanel.Size = new System.Drawing.Size(174, 89);
            this.MouseOptionPanel.TabIndex = 8;
            // 
            // OptionOKButton
            // 
            this.OptionOKButton.Location = new System.Drawing.Point(42, 249);
            this.OptionOKButton.Name = "OptionOKButton";
            this.OptionOKButton.Size = new System.Drawing.Size(41, 30);
            this.OptionOKButton.TabIndex = 9;
            this.OptionOKButton.Text = "OK";
            this.OptionOKButton.UseVisualStyleBackColor = true;
            this.OptionOKButton.Click += new System.EventHandler(this.OptionOKButton_Click);
            // 
            // OptionCancelButton
            // 
            this.OptionCancelButton.Location = new System.Drawing.Point(89, 249);
            this.OptionCancelButton.Name = "OptionCancelButton";
            this.OptionCancelButton.Size = new System.Drawing.Size(64, 30);
            this.OptionCancelButton.TabIndex = 10;
            this.OptionCancelButton.Text = "Cancel";
            this.OptionCancelButton.UseVisualStyleBackColor = true;
            this.OptionCancelButton.Click += new System.EventHandler(this.OptionCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "DB Query Interval (ms)";
            // 
            // OptionInterval
            // 
            this.OptionInterval.Location = new System.Drawing.Point(145, 199);
            this.OptionInterval.MaxLength = 5;
            this.OptionInterval.Name = "OptionInterval";
            this.OptionInterval.Size = new System.Drawing.Size(41, 21);
            this.OptionInterval.TabIndex = 13;
            this.OptionInterval.Text = "10";
            // 
            // Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 314);
            this.Controls.Add(this.OptionInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OptionCancelButton);
            this.Controls.Add(this.OptionOKButton);
            this.Controls.Add(this.MouseOptionPanel);
            this.Controls.Add(this.KeyOptionPanel);
            this.Name = "Option";
            this.Text = "Option";
            this.KeyOptionPanel.ResumeLayout(false);
            this.KeyOptionPanel.PerformLayout();
            this.MouseOptionPanel.ResumeLayout(false);
            this.MouseOptionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox OptionKeyDown;
        private System.Windows.Forms.CheckBox OptionKeyPress;
        private System.Windows.Forms.CheckBox OptionKeyUp;
        private System.Windows.Forms.CheckBox OptionMouseMove;
        private System.Windows.Forms.CheckBox OptionMouseLClick;
        private System.Windows.Forms.CheckBox OptionMouseRClick;
        private System.Windows.Forms.CheckBox OptionMouseWheel;
        private System.Windows.Forms.Panel KeyOptionPanel;
        private System.Windows.Forms.Panel MouseOptionPanel;
        private System.Windows.Forms.Button OptionOKButton;
        private System.Windows.Forms.Button OptionCancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OptionInterval;
    }
}