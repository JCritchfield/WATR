namespace WATR_GUI
{
    partial class WATRSensorForm
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
            this.components = new System.ComponentModel.Container();
            this.refreshTicker = new System.Windows.Forms.Timer(this.components);
            this.valuesBox = new System.Windows.Forms.GroupBox();
            this.tempLabel = new System.Windows.Forms.Label();
            this.humidityLabel = new System.Windows.Forms.Label();
            this.moistureLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.infoSSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dateTimeInfoSSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.batterySSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.batteryPercentageSSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.valuesBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // valuesBox
            // 
            this.valuesBox.Controls.Add(this.moistureLabel);
            this.valuesBox.Controls.Add(this.humidityLabel);
            this.valuesBox.Controls.Add(this.tempLabel);
            this.valuesBox.Location = new System.Drawing.Point(12, 12);
            this.valuesBox.Name = "valuesBox";
            this.valuesBox.Size = new System.Drawing.Size(285, 133);
            this.valuesBox.TabIndex = 0;
            this.valuesBox.TabStop = false;
            this.valuesBox.Text = "Current Values";
            // 
            // tempLabel
            // 
            this.tempLabel.BackColor = System.Drawing.Color.White;
            this.tempLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tempLabel.Location = new System.Drawing.Point(6, 19);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(273, 27);
            this.tempLabel.TabIndex = 0;
            this.tempLabel.Text = "Temperature: 0 F";
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humidityLabel
            // 
            this.humidityLabel.BackColor = System.Drawing.Color.White;
            this.humidityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.humidityLabel.Location = new System.Drawing.Point(6, 59);
            this.humidityLabel.Name = "humidityLabel";
            this.humidityLabel.Size = new System.Drawing.Size(273, 27);
            this.humidityLabel.TabIndex = 0;
            this.humidityLabel.Text = "Humidity Level: 0%";
            this.humidityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moistureLabel
            // 
            this.moistureLabel.BackColor = System.Drawing.Color.White;
            this.moistureLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moistureLabel.Location = new System.Drawing.Point(6, 99);
            this.moistureLabel.Name = "moistureLabel";
            this.moistureLabel.Size = new System.Drawing.Size(273, 27);
            this.moistureLabel.TabIndex = 0;
            this.moistureLabel.Text = "Moisture Level: 0%";
            this.moistureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoSSLabel,
            this.dateTimeInfoSSLabel,
            this.batterySSLabel,
            this.batteryPercentageSSLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(309, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // infoSSLabel
            // 
            this.infoSSLabel.Name = "infoSSLabel";
            this.infoSSLabel.Size = new System.Drawing.Size(86, 17);
            this.infoSSLabel.Text = "Last Refreshed:";
            // 
            // dateTimeInfoSSLabel
            // 
            this.dateTimeInfoSSLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeInfoSSLabel.Name = "dateTimeInfoSSLabel";
            this.dateTimeInfoSSLabel.Size = new System.Drawing.Size(38, 17);
            this.dateTimeInfoSSLabel.Text = "Never";
            // 
            // batterySSLabel
            // 
            this.batterySSLabel.Name = "batterySSLabel";
            this.batterySSLabel.Size = new System.Drawing.Size(135, 17);
            this.batterySSLabel.Spring = true;
            this.batterySSLabel.Text = "Battery Level:";
            this.batterySSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // batteryPercentageSSLabel
            // 
            this.batteryPercentageSSLabel.Name = "batteryPercentageSSLabel";
            this.batteryPercentageSSLabel.Size = new System.Drawing.Size(35, 17);
            this.batteryPercentageSSLabel.Text = "100%";
            // 
            // WATRSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 411);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.valuesBox);
            this.Name = "WATRSensorForm";
            this.Text = "SensorForm";
            this.valuesBox.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer refreshTicker;
        private System.Windows.Forms.GroupBox valuesBox;
        private System.Windows.Forms.Label moistureLabel;
        private System.Windows.Forms.Label humidityLabel;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel infoSSLabel;
        private System.Windows.Forms.ToolStripStatusLabel dateTimeInfoSSLabel;
        private System.Windows.Forms.ToolStripStatusLabel batterySSLabel;
        private System.Windows.Forms.ToolStripStatusLabel batteryPercentageSSLabel;
    }
}