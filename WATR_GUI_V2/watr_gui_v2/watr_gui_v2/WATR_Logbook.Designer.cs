namespace watr_gui_v2
{
    partial class WATR_Logbook
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
            this.logbookRecordView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logbookRecordView)).BeginInit();
            this.SuspendLayout();
            // 
            // logbookRecordView
            // 
            this.logbookRecordView.AllowUserToAddRows = false;
            this.logbookRecordView.AllowUserToDeleteRows = false;
            this.logbookRecordView.AllowUserToOrderColumns = true;
            this.logbookRecordView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logbookRecordView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logbookRecordView.Location = new System.Drawing.Point(12, 12);
            this.logbookRecordView.Name = "logbookRecordView";
            this.logbookRecordView.Size = new System.Drawing.Size(788, 320);
            this.logbookRecordView.TabIndex = 0;
            // 
            // WATR_Logbook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(812, 382);
            this.Controls.Add(this.logbookRecordView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WATR_Logbook";
            this.Text = "Logbook";
            ((System.ComponentModel.ISupportInitialize)(this.logbookRecordView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logbookRecordView;
    }
}