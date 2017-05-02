namespace EM2Project
{
    partial class UserInterface
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
        /// Required method for Designer support - do modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._startButton = new System.Windows.Forms.Button();
            this._pauseButton = new System.Windows.Forms.Button();
            this._resumeButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._materialsList = new System.Windows.Forms.ListBox();
            this._timeShown = new System.Windows.Forms.TextBox();
            this._timeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _timer
            // 
            this._timer.Interval = 250;
            this._timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // _startButton
            // 
            this._startButton.Location = new System.Drawing.Point(12, 12);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(75, 23);
            this._startButton.TabIndex = 1;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _pauseButton
            // 
            this._pauseButton.Enabled = false;
            this._pauseButton.Location = new System.Drawing.Point(109, 12);
            this._pauseButton.Name = "_pauseButton";
            this._pauseButton.Size = new System.Drawing.Size(75, 23);
            this._pauseButton.TabIndex = 2;
            this._pauseButton.Text = "Pause";
            this._pauseButton.UseVisualStyleBackColor = true;
            this._pauseButton.Click += new System.EventHandler(this._pauseButton_Click);
            // 
            // _resumeButton
            // 
            this._resumeButton.Enabled = false;
            this._resumeButton.Location = new System.Drawing.Point(206, 12);
            this._resumeButton.Name = "_resumeButton";
            this._resumeButton.Size = new System.Drawing.Size(75, 23);
            this._resumeButton.TabIndex = 3;
            this._resumeButton.Text = "Resume";
            this._resumeButton.UseVisualStyleBackColor = true;
            this._resumeButton.Click += new System.EventHandler(this._resumeButton_Click);
            // 
            // _clearButton
            // 
            this._clearButton.Enabled = false;
            this._clearButton.Location = new System.Drawing.Point(311, 12);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 4;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this._clearButton_Click);
            // 
            // _materialsList
            // 
            this._materialsList.FormattingEnabled = true;
            this._materialsList.Items.AddRange(new object[] {
            "Glass",
            "Diamond",
            "Water",
            "Air",
            "Brett",
            "Mystery"});
            this._materialsList.Location = new System.Drawing.Point(505, 12);
            this._materialsList.Name = "_materialsList";
            this._materialsList.Size = new System.Drawing.Size(120, 82);
            this._materialsList.TabIndex = 5;
            this._materialsList.SelectedIndex = 3;
            this._materialsList.SelectedIndexChanged += new System.EventHandler(this._materialsList_SelectedIndexChanged);
            // 
            // _timeShown
            // 
            this._timeShown.Enabled = false;
            this._timeShown.Location = new System.Drawing.Point(93, 56);
            this._timeShown.Name = "_timeShown";
            this._timeShown.Size = new System.Drawing.Size(91, 20);
            this._timeShown.TabIndex = 6;
            this._timeShown.Text = "0";
            // 
            // _timeLabel
            // 
            this._timeLabel.AutoSize = true;
            this._timeLabel.Location = new System.Drawing.Point(2, 59);
            this._timeLabel.Name = "_timeLabel";
            this._timeLabel.Size = new System.Drawing.Size(85, 13);
            this._timeLabel.TabIndex = 7;
            this._timeLabel.Text = "Time Elapsed (s)";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(637, 376);
            this.Controls.Add(this._timeLabel);
            this.Controls.Add(this._timeShown);
            this.Controls.Add(this._materialsList);
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this._resumeButton);
            this.Controls.Add(this._pauseButton);
            this.Controls.Add(this._startButton);
            this.Name = "UserInterface";
            this.Text = "Photon in a Box";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _pauseButton;
        private System.Windows.Forms.Button _resumeButton;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.ListBox _materialsList;
        private System.Windows.Forms.TextBox _timeShown;
        private System.Windows.Forms.Label _timeLabel;
    }
}

