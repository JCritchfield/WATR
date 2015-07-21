namespace WATR_GUI
{
    partial class WATRMainForm
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
            this.deviceBox = new System.Windows.Forms.GroupBox();
            this.viewBox = new System.Windows.Forms.Button();
            this.deviceListBox = new System.Windows.Forms.ListBox();
            this.deviceBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceBox
            // 
            this.deviceBox.Controls.Add(this.viewBox);
            this.deviceBox.Controls.Add(this.deviceListBox);
            this.deviceBox.Location = new System.Drawing.Point(12, 12);
            this.deviceBox.Name = "deviceBox";
            this.deviceBox.Size = new System.Drawing.Size(274, 403);
            this.deviceBox.TabIndex = 0;
            this.deviceBox.TabStop = false;
            this.deviceBox.Text = "Devices";
            // 
            // viewBox
            // 
            this.viewBox.Location = new System.Drawing.Point(6, 367);
            this.viewBox.Name = "viewBox";
            this.viewBox.Size = new System.Drawing.Size(262, 23);
            this.viewBox.TabIndex = 1;
            this.viewBox.Text = "View";
            this.viewBox.UseVisualStyleBackColor = true;
            this.viewBox.Click += new System.EventHandler(this.viewBox_Click);
            // 
            // deviceListBox
            // 
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.Location = new System.Drawing.Point(6, 19);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(262, 342);
            this.deviceListBox.TabIndex = 0;
            // 
            // WATRMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 427);
            this.Controls.Add(this.deviceBox);
            this.Name = "WATRMainForm";
            this.Text = "WATR Interface";
            this.deviceBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox deviceBox;
        private System.Windows.Forms.ListBox deviceListBox;
        private System.Windows.Forms.Button viewBox;
    }
}