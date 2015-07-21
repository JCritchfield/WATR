namespace watr_gui_v2
{
    partial class WATR_DeviceInfoForm
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
            this.forceRefreshButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.batteryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.batteryPercentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastUpdateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastUpdateDateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sensorInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.refreshRateGroupBox = new System.Windows.Forms.GroupBox();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.setRefreshButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moistureLevelTextBox = new System.Windows.Forms.TextBox();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.humidityTextBox = new System.Windows.Forms.TextBox();
            this.temperatureTextBox = new System.Windows.Forms.TextBox();
            this.viewLogButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.sensorInfoGroupBox.SuspendLayout();
            this.refreshRateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // forceRefreshButton
            // 
            this.forceRefreshButton.Location = new System.Drawing.Point(12, 213);
            this.forceRefreshButton.Name = "forceRefreshButton";
            this.forceRefreshButton.Size = new System.Drawing.Size(136, 23);
            this.forceRefreshButton.TabIndex = 0;
            this.forceRefreshButton.Text = "Force Refresh";
            this.forceRefreshButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batteryStatusLabel,
            this.batteryPercentStatusLabel,
            this.lastUpdateLabel,
            this.lastUpdateDateLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(305, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // batteryStatusLabel
            // 
            this.batteryStatusLabel.Name = "batteryStatusLabel";
            this.batteryStatusLabel.Size = new System.Drawing.Size(47, 17);
            this.batteryStatusLabel.Text = "Battery:";
            // 
            // batteryPercentStatusLabel
            // 
            this.batteryPercentStatusLabel.Name = "batteryPercentStatusLabel";
            this.batteryPercentStatusLabel.Size = new System.Drawing.Size(58, 17);
            this.batteryPercentStatusLabel.Text = "Unknown";
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.Size = new System.Drawing.Size(116, 17);
            this.lastUpdateLabel.Spring = true;
            this.lastUpdateLabel.Text = "Last Update:";
            this.lastUpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lastUpdateDateLabel
            // 
            this.lastUpdateDateLabel.Name = "lastUpdateDateLabel";
            this.lastUpdateDateLabel.Size = new System.Drawing.Size(38, 17);
            this.lastUpdateDateLabel.Text = "Never";
            // 
            // sensorInfoGroupBox
            // 
            this.sensorInfoGroupBox.Controls.Add(this.refreshRateGroupBox);
            this.sensorInfoGroupBox.Controls.Add(this.panel1);
            this.sensorInfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.sensorInfoGroupBox.Name = "sensorInfoGroupBox";
            this.sensorInfoGroupBox.Size = new System.Drawing.Size(281, 195);
            this.sensorInfoGroupBox.TabIndex = 2;
            this.sensorInfoGroupBox.TabStop = false;
            this.sensorInfoGroupBox.Text = "Sensor Information";
            // 
            // refreshRateGroupBox
            // 
            this.refreshRateGroupBox.Controls.Add(this.minutesLabel);
            this.refreshRateGroupBox.Controls.Add(this.numericUpDown1);
            this.refreshRateGroupBox.Controls.Add(this.setRefreshButton);
            this.refreshRateGroupBox.Location = new System.Drawing.Point(12, 143);
            this.refreshRateGroupBox.Name = "refreshRateGroupBox";
            this.refreshRateGroupBox.Size = new System.Drawing.Size(260, 46);
            this.refreshRateGroupBox.TabIndex = 5;
            this.refreshRateGroupBox.TabStop = false;
            this.refreshRateGroupBox.Text = "Refresh Timer Settings";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(130, 20);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(44, 13);
            this.minutesLabel.TabIndex = 6;
            this.minutesLabel.Text = "Minutes";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 18);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(118, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // setRefreshButton
            // 
            this.setRefreshButton.Location = new System.Drawing.Point(194, 12);
            this.setRefreshButton.Name = "setRefreshButton";
            this.setRefreshButton.Size = new System.Drawing.Size(60, 28);
            this.setRefreshButton.TabIndex = 4;
            this.setRefreshButton.Text = "Apply";
            this.setRefreshButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.temperatureLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.moistureLevelTextBox);
            this.panel1.Controls.Add(this.humidityLabel);
            this.panel1.Controls.Add(this.humidityTextBox);
            this.panel1.Controls.Add(this.temperatureTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 118);
            this.panel1.TabIndex = 3;
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.temperatureLabel.Location = new System.Drawing.Point(3, 12);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(124, 23);
            this.temperatureLabel.TabIndex = 1;
            this.temperatureLabel.Text = "Temperature:";
            this.temperatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Moisture Level:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // moistureLevelTextBox
            // 
            this.moistureLevelTextBox.BackColor = System.Drawing.Color.White;
            this.moistureLevelTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moistureLevelTextBox.Location = new System.Drawing.Point(133, 78);
            this.moistureLevelTextBox.Name = "moistureLevelTextBox";
            this.moistureLevelTextBox.ReadOnly = true;
            this.moistureLevelTextBox.Size = new System.Drawing.Size(125, 20);
            this.moistureLevelTextBox.TabIndex = 2;
            // 
            // humidityLabel
            // 
            this.humidityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.humidityLabel.Location = new System.Drawing.Point(3, 44);
            this.humidityLabel.Name = "humidityLabel";
            this.humidityLabel.Size = new System.Drawing.Size(124, 23);
            this.humidityLabel.TabIndex = 1;
            this.humidityLabel.Text = "Humidity:";
            this.humidityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // humidityTextBox
            // 
            this.humidityTextBox.BackColor = System.Drawing.Color.White;
            this.humidityTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.humidityTextBox.Location = new System.Drawing.Point(133, 47);
            this.humidityTextBox.Name = "humidityTextBox";
            this.humidityTextBox.ReadOnly = true;
            this.humidityTextBox.Size = new System.Drawing.Size(125, 20);
            this.humidityTextBox.TabIndex = 2;
            // 
            // temperatureTextBox
            // 
            this.temperatureTextBox.BackColor = System.Drawing.Color.White;
            this.temperatureTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.temperatureTextBox.Location = new System.Drawing.Point(133, 15);
            this.temperatureTextBox.Name = "temperatureTextBox";
            this.temperatureTextBox.ReadOnly = true;
            this.temperatureTextBox.Size = new System.Drawing.Size(125, 20);
            this.temperatureTextBox.TabIndex = 2;
            // 
            // viewLogButton
            // 
            this.viewLogButton.Location = new System.Drawing.Point(157, 213);
            this.viewLogButton.Name = "viewLogButton";
            this.viewLogButton.Size = new System.Drawing.Size(136, 23);
            this.viewLogButton.TabIndex = 0;
            this.viewLogButton.Text = "View Log";
            this.viewLogButton.UseVisualStyleBackColor = true;
            // 
            // WATR_DeviceInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 261);
            this.Controls.Add(this.sensorInfoGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.viewLogButton);
            this.Controls.Add(this.forceRefreshButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WATR_DeviceInfoForm";
            this.Text = "Device #n";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WATR_DeviceInfoForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.sensorInfoGroupBox.ResumeLayout(false);
            this.refreshRateGroupBox.ResumeLayout(false);
            this.refreshRateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel batteryStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel batteryPercentStatusLabel;
        private System.Windows.Forms.GroupBox sensorInfoGroupBox;
        private System.Windows.Forms.ToolStripStatusLabel lastUpdateLabel;
        private System.Windows.Forms.ToolStripStatusLabel lastUpdateDateLabel;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox moistureLevelTextBox;
        private System.Windows.Forms.TextBox humidityTextBox;
        private System.Windows.Forms.TextBox temperatureTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox refreshRateGroupBox;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.Button setRefreshButton;
        public System.Windows.Forms.Button forceRefreshButton;
        public System.Windows.Forms.Button viewLogButton;
    }
}