using System;
using System.Windows.Forms;

namespace CallScheduler {
    public partial class Form1 : Form {

        public string Results
        {
            get { return textboxResults.Text; }
            set { textboxResults.Text = value; }
        }
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            doctorsFile.ShowDialog();
        }

        private void doctorsFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textboxDoctorFilename.Text = doctorsFile.FileName;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            rotationsFile.ShowDialog();
        }

        private void rotationsFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            textboxRotationsFilename.Text = rotationsFile.FileName;
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRun_Click(object sender, System.EventArgs e) {
            if (textboxDoctorFilename.Text == string.Empty
                || textboxRotationsFilename.Text == string.Empty
                || textboxStartDate.Text == string.Empty
                || textboxEndDate.Text == string.Empty)
            {
                MessageBox.Show("Not all required fields are filled.");
                return;
            }
            int MaxPerRotation, MaxPerLifetime, MaxSameShifts, MaxConsecutiveShifts;
            if (!int.TryParse(textboxMaxPerRotation.Text, out MaxPerRotation))
            {
                MaxPerRotation = 0;
            }
            if (!int.TryParse(textboxMaxPerLifetime.Text, out MaxPerLifetime))
            {
                MaxPerLifetime = 0;
            }
            if (!int.TryParse(textBoxMaxSameShifts.Text, out MaxSameShifts)) {
                MaxSameShifts = 0;
            }
            if (!int.TryParse(textboxMaxConsecutive.Text, out MaxConsecutiveShifts)) {
                MaxConsecutiveShifts = 0;
            }

            try
            {
                var doctors = Doctor.GetDoctorsFromFile(textboxDoctorFilename.Text);
                var schedule = new Scheduler(textboxRotationsFilename.Text, textboxStartDate.Text, textboxEndDate.Text,
                                             doctors, MaxPerRotation, MaxPerLifetime, MaxSameShifts, MaxConsecutiveShifts, checkboxCrossCall.Checked);
                schedule.Populate();
                var output = schedule.OutputSchedule();
                output.AppendLine();
                output.Append(schedule.OutputDoctors(doctors).ToString());
                textboxResults.Text = output.ToString();
            } catch (Exception error)
            {
                Results = error.Message;
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textboxResults.Text);
        }
    }
}
