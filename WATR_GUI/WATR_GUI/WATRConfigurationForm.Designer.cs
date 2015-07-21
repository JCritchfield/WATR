namespace WATR_GUI
{
    partial class WATRConfigurationForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.page1 = new System.Windows.Forms.Panel();
            this.nextButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.page2 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.finalPage = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.page1.SuspendLayout();
            this.page2.SuspendLayout();
            this.finalPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 481);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(171, 128);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // page1
            // 
            this.page1.Controls.Add(this.label1);
            this.page1.Location = new System.Drawing.Point(186, 12);
            this.page1.Name = "page1";
            this.page1.Size = new System.Drawing.Size(488, 411);
            this.page1.TabIndex = 3;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(599, 429);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(518, 429);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 4;
            this.backButton.Text = "Previous";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // page2
            // 
            this.page2.Controls.Add(this.label3);
            this.page2.Controls.Add(this.label2);
            this.page2.Controls.Add(this.refreshButton);
            this.page2.Controls.Add(this.comboBox1);
            this.page2.Location = new System.Drawing.Point(691, 12);
            this.page2.Name = "page2";
            this.page2.Size = new System.Drawing.Size(488, 411);
            this.page2.TabIndex = 3;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(227, 240);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(78, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to WATR! Since this is your first time running this program, please take " +
    "a moment to provide a few details necessary to run this program.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(168, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 54);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please select which serial port your device is connected on:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(180, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 54);
            this.label3.TabIndex = 0;
            this.label3.Text = "If you do not see your device, please check your connection and then press \"Refre" +
    "sh\" below";
            // 
            // finalPage
            // 
            this.finalPage.Controls.Add(this.label5);
            this.finalPage.Location = new System.Drawing.Point(1185, 12);
            this.finalPage.Name = "finalPage";
            this.finalPage.Size = new System.Drawing.Size(488, 411);
            this.finalPage.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(171, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 54);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thank you! The program is now ready for use and will continue loading.";
            // 
            // finishButton
            // 
            this.finishButton.Enabled = false;
            this.finishButton.Location = new System.Drawing.Point(680, 429);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 4;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Visible = false;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // WATRConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2250, 482);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.finalPage);
            this.Controls.Add(this.page2);
            this.Controls.Add(this.page1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WATRConfigurationForm";
            this.Text = "First Time Run Window";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.page1.ResumeLayout(false);
            this.page2.ResumeLayout(false);
            this.finalPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel page1;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel page2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel finalPage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button finishButton;

    }
}