namespace watr_gui_v2
{
    partial class WATR_BackEndSS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WATR_BackEndSS));
            this.loadProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.logoPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // loadProgressBar
            // 
            this.loadProgressBar.Location = new System.Drawing.Point(12, 327);
            this.loadProgressBar.Name = "loadProgressBar";
            this.loadProgressBar.Size = new System.Drawing.Size(601, 23);
            this.loadProgressBar.TabIndex = 0;
            // 
            // progressLabel
            // 
            this.progressLabel.Location = new System.Drawing.Point(135, 311);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(354, 13);
            this.progressLabel.TabIndex = 1;
            this.progressLabel.Text = "This is a progress label and shows what is exactly going on at the moment";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoPic
            // 
            this.logoPic.BackColor = System.Drawing.Color.Transparent;
            this.logoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(12, 12);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(601, 216);
            this.logoPic.TabIndex = 2;
            this.logoPic.TabStop = false;
            // 
            // WATR_BackEndSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(625, 362);
            this.Controls.Add(this.logoPic);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.loadProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WATR_BackEndSS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadProgressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.PictureBox logoPic;
    }
}

