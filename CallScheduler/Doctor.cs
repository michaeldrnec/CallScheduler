using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CallScheduler {
    public class Doctor {
        public string Name;
        public List<DateTime> Vacation = new List<DateTime>();
        public List<string> Rotations;
        public int OriginalRank;
        public int TotalShiftCount = 0;
        public int DoubleShiftsWorked = 0;

        public bool HasVacation(Slot slot) {
            return Vacation.Any(x => x == slot.date);
        }

        public void AddRotations(IEnumerable<string> rotationList) {
            Rotations = rotationList.ToList();
        }

        public static List<Doctor> GetDoctorsFromFile(string filename) {
            if (!File.Exists(filename)) {
                Console.WriteLine("That file does not exist");
                Environment.Exit(1);
            }
            var doctors = new List<Doctor>();
            using (var reader = new StreamReader(filename)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    var doctorInfo = line.Split(',');
                    var doctor = new Doctor { Name = doctorInfo[0] };
                    for (var i = 1; i < doctorInfo.Length; i++) {
                        var dateOfVacation = doctorInfo[i];
                        var dateSpan = doctorInfo[i].Trim().Split('-');
                        try
                        {
                            if (dateSpan.Length == 2)
                            {
                                foreach (
                                    var day in
                                        Scheduler.EachDay(DateTime.Parse(dateSpan[0]), DateTime.Parse(dateSpan[1])))
                                {
                                    doctor.Vacation.Add(day);
                                }
                            }
                            else
                            {
                                if (dateOfVacation.Trim() != String.Empty)
                                {
                                    doctor.Vacation.Add(DateTime.Parse(dateOfVacation));
                                }
                            }
                        } catch (Exception)
                        {
                            throw(new Exception(string.Format("Error reading doctor's file on line: {0}", line)));
                        }
                    }
                    doctors.Add(doctor);
                }
                reader.Close();
            }
            return doctors;
        }
    }
}
