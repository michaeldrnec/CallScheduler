namespace CallScheduler {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.doctorsFile = new System.Windows.Forms.OpenFileDialog();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textboxDoctorFilename = new System.Windows.Forms.TextBox();
            this.textboxRotationsFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.rotationsFile = new System.Windows.Forms.OpenFileDialog();
            this.textboxStartDate = new System.Windows.Forms.TextBox();
            this.textboxEndDate = new System.Windows.Forms.TextBox();
            this.textboxMaxPerRotation = new System.Windows.Forms.TextBox();
            this.textboxMaxPerLifetime = new System.Windows.Forms.TextBox();
            this.checkboxCrossCall = new System.Windows.Forms.CheckBox();
            this.textboxResults = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMaxSameShifts = new System.Windows.Forms.TextBox();
            this.textboxMaxConsecutive = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textboxMaxWeekends = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choose...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // doctorsFile
            // 
            this.doctorsFile.FileName = "*.csv";
            this.doctorsFile.FileOk += new System.ComponentModel.CancelEventHandler(this.doctorsFile_FileOk);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(211, 372);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textboxDoctorFilename
            // 
            this.textboxDoctorFilename.Location = new System.Drawing.Point(138, 14);
            this.textboxDoctorFilename.Name = "textboxDoctorFilename";
            this.textboxDoctorFilename.Size = new System.Drawing.Size(417, 20);
            this.textboxDoctorFilename.TabIndex = 2;
            // 
            // textboxRotationsFilename
            // 
            this.textboxRotationsFilename.Location = new System.Drawing.Point(138, 41);
            this.textboxRotationsFilename.Name = "textboxRotationsFilename";
            this.textboxRotationsFilename.Size = new System.Drawing.Size(417, 20);
            this.textboxRotationsFilename.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Doctors File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rotations File";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Choose...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rotationsFile
            // 
            this.rotationsFile.FileName = "*.csv";
            this.rotationsFile.FileOk += new System.ComponentModel.CancelEventHandler(this.rotationsFile_FileOk);
            // 
            // textboxStartDate
            // 
            this.textboxStartDate.Location = new System.Drawing.Point(138, 68);
            this.textboxStartDate.Name = "textboxStartDate";
            this.textboxStartDate.Size = new System.Drawing.Size(100, 20);
            this.textboxStartDate.TabIndex = 7;
            this.textboxStartDate.Text = "1/1/2011";
            this.textboxStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textboxEndDate
            // 
            this.textboxEndDate.Location = new System.Drawing.Point(370, 68);
            this.textboxEndDate.Name = "textboxEndDate";
            this.textboxEndDate.Size = new System.Drawing.Size(100, 20);
            this.textboxEndDate.TabIndex = 8;
            this.textboxEndDate.Text = "3/31/2011";
            this.textboxEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textboxMaxPerRotation
            // 
            this.textboxMaxPerRotation.Location = new System.Drawing.Point(138, 94);
            this.textboxMaxPerRotation.Name = "textboxMaxPerRotation";
            this.textboxMaxPerRotation.Size = new System.Drawing.Size(37, 20);
            this.textboxMaxPerRotation.TabIndex = 9;
            this.textboxMaxPerRotation.Text = "4";
            this.textboxMaxPerRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textboxMaxPerLifetime
            // 
            this.textboxMaxPerLifetime.Location = new System.Drawing.Point(370, 94);
            this.textboxMaxPerLifetime.Name = "textboxMaxPerLifetime";
            this.textboxMaxPerLifetime.Size = new System.Drawing.Size(31, 20);
            this.textboxMaxPerLifetime.TabIndex = 10;
            this.textboxMaxPerLifetime.Text = "30";
            this.textboxMaxPerLifetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkboxCrossCall
            // 
            this.checkboxCrossCall.AutoSize = true;
            this.checkboxCrossCall.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkboxCrossCall.Location = new System.Drawing.Point(465, 96);
            this.checkboxCrossCall.Name = "checkboxCrossCall";
            this.checkboxCrossCall.Size = new System.Drawing.Size(112, 17);
            this.checkboxCrossCall.TabIndex = 11;
            this.checkboxCrossCall.Text = "Cross Call Allowed";
            this.checkboxCrossCall.UseVisualStyleBackColor = true;
            // 
            // textboxResults
            // 
            this.textboxResults.Location = new System.Drawing.Point(23, 186);
            this.textboxResults.Multiline = true;
            this.textboxResults.Name = "textboxResults";
            this.textboxResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxResults.Size = new System.Drawing.Size(679, 180);
            this.textboxResults.TabIndex = 12;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(304, 372);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 13;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(399, 372);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 14;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Max Shifts/Rotation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Max Shifts Lifetime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Max Same Shifts/Month";
            // 
            // textBoxMaxSameShifts
            // 
            this.textBoxMaxSameShifts.Location = new System.Drawing.Point(138, 121);
            this.textBoxMaxSameShifts.Name = "textBoxMaxSameShifts";
            this.textBoxMaxSameShifts.Size = new System.Drawing.Size(37, 20);
            this.textBoxMaxSameShifts.TabIndex = 20;
            this.textBoxMaxSameShifts.Text = "2";
            this.textBoxMaxSameShifts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textboxMaxConsecutive
            // 
            this.textboxMaxConsecutive.Location = new System.Drawing.Point(370, 121);
            this.textboxMaxConsecutive.Name = "textboxMaxConsecutive";
            this.textboxMaxConsecutive.Size = new System.Drawing.Size(30, 20);
            this.textboxMaxConsecutive.TabIndex = 21;
            this.textboxMaxConsecutive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Max Consecutive Shifts/Rotation";
            // 
            // textboxMaxWeekends
            // 
            this.textboxMaxWeekends.Location = new System.Drawing.Point(546, 121);
            this.textboxMaxWeekends.Name = "textboxMaxWeekends";
            this.textboxMaxWeekends.Size = new System.Drawing.Size(31, 20);
            this.textboxMaxWeekends.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Max Weekends/Rotation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 402);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textboxMaxWeekends);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textboxMaxConsecutive);
            this.Controls.Add(this.textBoxMaxSameShifts);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textboxResults);
            this.Controls.Add(this.checkboxCrossCall);
            this.Controls.Add(this.textboxMaxPerLifetime);
            this.Controls.Add(this.textboxMaxPerRotation);
            this.Controls.Add(this.textboxEndDate);
            this.Controls.Add(this.textboxStartDate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textboxRotationsFilename);
            this.Controls.Add(this.textboxDoctorFilename);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog doctorsFile;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textboxDoctorFilename;
        private System.Windows.Forms.TextBox textboxRotationsFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog rotationsFile;
        private System.Windows.Forms.TextBox textboxStartDate;
        private System.Windows.Forms.TextBox textboxEndDate;
        private System.Windows.Forms.TextBox textboxMaxPerRotation;
        private System.Windows.Forms.TextBox textboxMaxPerLifetime;
        private System.Windows.Forms.CheckBox checkboxCrossCall;
        private System.Windows.Forms.TextBox textboxResults;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMaxSameShifts;
        private System.Windows.Forms.TextBox textboxMaxConsecutive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textboxMaxWeekends;
        private System.Windows.Forms.Label label9;
    }
}

