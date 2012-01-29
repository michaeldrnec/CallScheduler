using System;
using System.Text;
using System.Windows.Forms;

namespace CallScheduler
{
    public partial class Form1 : Form
    {
        public string Results
        {
            get { return textboxResults.Text; }
            set { textboxResults.Text = value; }
        }

        public Form1()
        {
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

        private void buttonRun_Click(object sender, System.EventArgs e)
        {
            if (AnyRequiredFieldsEmpty())
            {
                MessageBox.Show("Not all required fields are filled.");
                return;
            }
            var bean = GetSchedulerConfigParams();

            try
            {
                var doctors = Doctor.GetDoctorsFromFile(textboxDoctorFilename.Text);
                var runs = GetNumberOfRandomRuns();
                var seedList = GetSeedList(runs);
                var keep = new Scheduler(doctors, bean);
                keep.Populate(0);
                var best = keep.BlankCount();
                var bestSeed = 0;
                var randomOutput = new StringBuilder();
                randomOutput.AppendLine(string.Format("Default Blanks: {0}  Seed: {1}", best, bestSeed));

                foreach (var seed in seedList)
                {
                    var schedule = new Scheduler(doctors, bean);

                    schedule.Populate(seed);
                    var blankCount = schedule.BlankCount();
                    if (blankCount < best)
                    {
                        keep = schedule;
                        best = blankCount;
                        bestSeed = seed;
                    }
                    
                }
                if (keep != null)
                {
                    randomOutput.AppendLine(string.Format("Best Blanks: {0}  Seed: {1}", best, bestSeed));
                    var output = new StringBuilder();
                    output.AppendLine(randomOutput.ToString());
                    output.AppendLine();
                    output.AppendLine(keep.OutputSchedule().ToString());
                    output.AppendLine();
                    output.Append(keep.OutputDoctors().ToString());
                    textboxResults.Text = output.ToString();
                }
            }
            catch (Exception error)
            {
                Results = error.Message;
            }
        }

        private SchedulerBean GetSchedulerConfigParams()
        {
            var bean = new SchedulerBean();
            
            if (!int.TryParse(textboxMaxPerRotation.Text, out bean.MaxPerRotation))
            {
                bean.MaxPerRotation = 0;
            }
            if (!int.TryParse(textboxMaxPerLifetime.Text, out bean.MaxPerLifetime))
            {
                bean.MaxPerLifetime = 0;
            }
            if (!int.TryParse(textBoxMaxSameShifts.Text, out bean.MaxSameShifts))
            {
                bean.MaxSameShifts = 0;
            }
            if (!int.TryParse(textboxMaxConsecutive.Text, out bean.MaxConsecutiveShifts))
            {
                bean.MaxConsecutiveShifts = 0;
            }
            if (!int.TryParse(textboxMaxWeekends.Text, out bean.MaxWeekends))
            {
                bean.MaxWeekends = 0;
            }
            bean.startDate = textboxStartDate.Text;
            bean.endDate = textboxEndDate.Text;
            bean.crossCall = checkboxCrossCall.Checked;
            bean.rotationsFilename = textboxRotationsFilename.Text;
            return bean;
        }

        private int GetNumberOfRandomRuns()
        {
            int runs;
            if (!int.TryParse(textboxRandomRuns.Text, out runs))
            {
                runs = 0;
            }
            return runs;
        }

        private int[] GetSeedList(int runs)
        {
            var seedList = new int[runs];
            for (var i = 0; i < runs; i++)
            {
                seedList[i] = DateTime.Now.Ticks.GetHashCode();
                System.Threading.Thread.Sleep(15);
            }
            return seedList;
        }

        private bool AnyRequiredFieldsEmpty()
        {
            return textboxDoctorFilename.Text == string.Empty
                   || textboxRotationsFilename.Text == string.Empty
                   || textboxStartDate.Text == string.Empty
                   || textboxEndDate.Text == string.Empty;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textboxResults.Text);
        }
    }
}

public class SchedulerBean
{
    public int MaxPerRotation, MaxPerLifetime, MaxSameShifts, MaxConsecutiveShifts, MaxWeekends;
    public string rotationsFilename;
    public string startDate;
    public string endDate;
    public bool crossCall;
}