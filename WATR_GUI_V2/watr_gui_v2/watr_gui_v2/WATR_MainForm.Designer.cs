namespace watr_gui_v2
{
    partial class WATR_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WATR_MainForm));
            this.deiveListGroup = new System.Windows.Forms.GroupBox();
            this.showAllButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.deviceListBox = new System.Windows.Forms.ListBox();
            this.deiveListGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // deiveListGroup
            // 
            this.deiveListGroup.Controls.Add(this.showAllButton);
            this.deiveListGroup.Controls.Add(this.refreshButton);
            this.deiveListGroup.Controls.Add(this.deviceListBox);
            this.deiveListGroup.Location = new System.Drawing.Point(12, 12);
            this.deiveListGroup.Name = "deiveListGroup";
            this.deiveListGroup.Size = new System.Drawing.Size(200, 342);
            this.deiveListGroup.TabIndex = 0;
            this.deiveListGroup.TabStop = false;
            this.deiveListGroup.Text = "Devices";
            // 
            // showAllButton
            // 
            this.showAllButton.Location = new System.Drawing.Point(6, 301);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(188, 32);
            this.showAllButton.TabIndex = 1;
            this.showAllButton.Text = "Show All";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(6, 263);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(188, 32);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh List";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // deviceListBox
            // 
            this.deviceListBox.FormattingEnabled = true;
            this.deviceListBox.Location = new System.Drawing.Point(6, 19);
            this.deviceListBox.Name = "deviceListBox";
            this.deviceListBox.Size = new System.Drawing.Size(188, 238);
            this.deviceListBox.TabIndex = 0;
            this.deviceListBox.SelectedIndexChanged += new System.EventHandler(this.deviceListBox_SelectedIndexChanged);
            // 
            // WATR_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 366);
            this.Controls.Add(this.deiveListGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WATR_MainForm";
            this.Text = "Device List";
            this.deiveListGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox deiveListGroup;
        private System.Windows.Forms.ListBox deviceListBox;
        private System.Windows.Forms.Button showAllButton;
        public System.Windows.Forms.Button refreshButton;
    }
}