using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CallScheduler
{
    public class Scheduler
    {
        public List<Slot> Schedule;
        public List<Rotation> Rotations;
        public List<Doctor> Doctors;
        public int MaxShiftsPerRotation;
        private int MaxShiftsPerLifetime;
        private int MaxSameShifts;
        public int MaxConsecutiveShifts;
        private int MaxWeekends;
        private bool CrossCallAllowed;

        public Scheduler()
        {
        }

        public Scheduler(List<Doctor> doctors, SchedulerBean bean)
        {
            MaxShiftsPerRotation = bean.MaxPerRotation;
            MaxShiftsPerLifetime = bean.MaxPerLifetime;
            MaxSameShifts = bean.MaxSameShifts;
            MaxConsecutiveShifts = bean.MaxConsecutiveShifts;
            MaxWeekends = bean.MaxWeekends;
            CrossCallAllowed = bean.crossCall;

            Schedule = new List<Slot>();
            Rotations = new List<Rotation>();
            Doctors = doctors.Select(x => x.Clone()).Cast<Doctor>().ToList();
            LoadRotations(bean.rotationsFilename);
            var startDate = DateTime.Parse(bean.startDate);
            var endDate = DateTime.Parse(bean.endDate);
            if (startDate < Rotations.First().startDate || endDate > Rotations.Last().endDate)
            {
                throw (new Exception("Start/End dates are outside the range of loaded rotations."));
            }
            BuildCalendar(startDate, endDate);
        }

        private void LoadRotations(string rotationFileName)
        {
            if (!File.Exists(rotationFileName))
            {
                Console.WriteLine("That file does not exist");
                Environment.Exit(1);
            }
            int i = 1;
            using (var reader = new StreamReader(rotationFileName))
            {
                string line;
                line = reader.ReadLine();
                var listOfRotations = line.Split(',');
                foreach (var item in listOfRotations)
                {
                    if (item.Contains("-"))
                    {
                        var rotation = new Rotation(item);
                        Rotations.Add(rotation);
                    }
                }
                while ((line = reader.ReadLine()) != null)
                {
                    var locations = line.Split(',');
                    var found = Doctors.Where(x => x.Name == locations[0]);
                    if (found.Any())
                    {
                        var doctorToWorkOn = found.First();
                        doctorToWorkOn.AddRotations(locations.Skip(1));
                        doctorToWorkOn.OriginalRank = i++;
                    }
                }
                reader.Close();
            }
        }

        private void BuildCalendar(DateTime startDate, DateTime endDate)
        {
            var week = 0;
            foreach (var day in EachDay(startDate, endDate))
            {
                if (day.DayOfWeek == DayOfWeek.Friday)
                {
                    week = week + 1;
                    AddSlotsToSchedule(day, week, 1, false);
                }
                else if (day.DayOfWeek == DayOfWeek.Saturday)
                {
                    AddSlotsToSchedule(day, week, 2, true);
                }
                else if (day.DayOfWeek == DayOfWeek.Sunday)
                {
                    AddSlotsToSchedule(day, week, 3, false);
                }
            }
        }

        private void AddSlotsToSchedule(DateTime day, int week, int shift, bool is24)
        {
            var rotationNumber = Rotations.FindIndex(x => day >= x.startDate && day <= x.endDate);
            Schedule.Add(new Slot(day, "CT", shift, true, week, is24, rotationNumber));
            Schedule.Add(new Slot(day, "CT", shift, false, week, is24, rotationNumber));
            Schedule.Add(new Slot(day, "W", shift, true, week, is24, rotationNumber));
            Schedule.Add(new Slot(day, "W", shift, false, week, is24, rotationNumber));
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void Populate(int seed)
        {
            var order = GetRandomOrder(seed);
            var doctorQueue = new DoctorQueue(Doctors);
            for (var i = 0; i < order.Length; i++)
            {
                var callDoctors = doctorQueue.GetEligibleDoctors(Schedule[order[i]]);
                foreach (var currentDoctor in callDoctors)
                {
                    if (CanWork(Schedule[order[i]], currentDoctor))
                    {
                        Schedule[order[i]].doctor = currentDoctor;
                        doctorQueue.ThisDoctorWasChosen(currentDoctor, Schedule[order[i]].is24);
                        break;
                    }
                }
            }

            if (!CrossCallAllowed)
                return;

            for (var i = 0; i < order.Length; i++)
            {
                if (Schedule[order[i]].NotAssigned())
                {
                    var crossCallDoctors = doctorQueue.GetCrossCallDoctors(Schedule[order[i]]);
                    foreach (var currentDoctor in crossCallDoctors)
                    {
                        if (CanWork(Schedule[order[i]], currentDoctor))
                        {
                            Schedule[order[i]].doctor = currentDoctor;
                            doctorQueue.ThisDoctorWasChosen(currentDoctor, Schedule[order[i]].is24);
                            Schedule[order[i]].crossCall = true;
                            break;
                        }
                    }
                }
            }
        }

        private int[] GetRandomOrder(int seed)
        {
            var order = new int[Schedule.Count];
            for (var x = 0; x < Schedule.Count; x++)
            {
                order[x] = x;
            }
            if (seed != 0)
            {
                var random = new Random(seed);
                for (var i = 0; i < order.Length; i++)
                {
                    var swapIndex = random.Next(i, order.Length);
                    if (swapIndex != i)
                    {
                        var temp = order[i];
                        order[i] = order[swapIndex];
                        order[swapIndex] = temp;
                    }
                }
            }
            return order;
        }

        private bool CanWork(Slot slot, Doctor doctor)
        {
            if (DoctorAlreadyWorkingThisWeekend(slot, doctor))
            {
                return false;
            }
            if (DoctorHasExceededMaxDaysThisRotation(slot, doctor))
            {
                return false;
            }
            if (DoctorHasExceededMaxLifetime(slot, doctor))
            {
                return false;
            }
            if (DoctorHasExceededMaxSameShiftsPerRotation(slot, doctor))
            {
                return false;
            }
            if (DoctorWouldExceedMaxConsecutiveShifts(slot, doctor))
            {
                return false;
            }
            if (DoctorHasExceededMaxWeekendsPerRotation(slot, doctor))
            {
                return false;
            }
            if (DoctorHasExceededHisPersonalMaxShifts(slot, doctor))
            {
                return false;
            }
            return true;
        }

        private bool DoctorHasExceededMaxWeekendsPerRotation(Slot slot, Doctor doctor)
        {
            if (MaxWeekends == 0)
                return false;
            return GetSlotsByDoctorAndRotation(doctor, slot).Count() >= MaxWeekends;
        }

        public bool DoctorWouldExceedMaxConsecutiveShifts(Slot slot, Doctor doctor)
        {
            if (MaxConsecutiveShifts == 0)
                return false;
            var list = GetSlotsByDoctorAndRotation(doctor, slot).ToList();
            list.Add(slot);
            return CalcMaxConsecutiveShifts(list.OrderBy(x => x.week)) > MaxConsecutiveShifts;
        }

        private int CalcMaxConsecutiveShifts(IOrderedEnumerable<Slot> list)
        {
            int max = 0;
            int current = 1;
            int last = -99;
            foreach (var day in list)
            {
                if (last + 1 != day.week)
                {
                    current = 1;
                }
                else
                {
                    current++;
                }
                max = current > max ? current : max;
                last = day.week;
            }
            return max;
        }

        private bool DoctorAlreadyWorkingThisWeekend(Slot slot, Doctor doctor)
        {
            return Schedule.Where(x => x.week == slot.week).Where(x => x.doctor == doctor).Any();
        }

        public bool DoctorHasExceededMaxDaysThisRotation(Slot slot, Doctor doctor)
        {
            if (MaxShiftsPerRotation == 0)
                return false;
            var list = GetSlotsByDoctorAndRotation(doctor, slot).ToList();
            list.Add(slot);

            return CountShifts(list) >
                   MaxShiftsPerRotation;
        }

        private int CountShifts(IList<Slot> listOfShifts)
        {
            var count = 0;
            foreach (var slot in listOfShifts)
            {
                count++;
                if (slot.is24)
                {
                    count++;
                }
            }
            return count;
        }

        private IEnumerable<Slot> GetSlotsByDoctorAndRotation(Doctor doctor, Slot slot)
        {
            return Schedule.Where(x => x.doctor == doctor && x.rotationNumber == slot.rotationNumber);
        }

        private bool DoctorHasExceededMaxLifetime(Slot slot, Doctor doctor)
        {
            if (MaxShiftsPerLifetime == 0)
                return false;
            return doctor.TotalShiftCount + (slot.is24 ? 2 : 1) > MaxShiftsPerLifetime;
        }

        public bool DoctorHasExceededHisPersonalMaxShifts(Slot slot, Doctor doctor)
        {
            return doctor.TotalShiftCount + (slot.is24 ? 2 : 1) > doctor.MaxShifts;
        }

        private bool DoctorHasExceededMaxSameShiftsPerRotation(Slot slot, Doctor doctor)
        {
            if (MaxSameShifts == 0)
                return false;
            return GetSlotsByDoctorAndRotation(doctor, slot).Where(x => x.shift == slot.shift).Count() >= MaxSameShifts;
        }

        public StringBuilder OutputSchedule()
        {
            var output = OutputScheduleForLocation("CT");
            output.AppendLine();
            output.Append(OutputScheduleForLocation("W").ToString());
            return output;
        }

        private StringBuilder OutputScheduleForLocation(string location)
        {
            var output = new StringBuilder();
            output.AppendLine("Location: " + location);
            output.AppendLine("Day,Date,Primary,Backup");
            foreach (var day in Schedule.Where(x => x.location == location))
            {
                if (day.primary)
                {
                    output.Append(string.Format("{0},{1}", day.date.DayOfWeek, day.date.ToString("MM/dd/yyyy")));
                }
                output.Append(GetDoctorName(day));
                if (!day.primary)
                {
                    output.AppendLine();
                }
            }
            return output;
        }

        private string GetDoctorName(Slot slot)
        {
            return slot.doctor != null
                       ? string.Format(",{0}{1}", slot.doctor.Name, slot.crossCall ? " (C)" : string.Empty)
                       : ",<blank>";
        }

        public StringBuilder OutputDoctors()
        {
            var output = new StringBuilder();
            output.AppendLine("Doctor,Total Shifts,Double Shifts,Oncall Dates");
            foreach (var curDoctor in Doctors)
            {
                var days = Schedule.Where(x => x.doctor != null && x.doctor.Name == curDoctor.Name).ToList();
                output.Append(string.Format("{0},{1},{2}", curDoctor.Name, curDoctor.TotalShiftCount,
                                            curDoctor.DoubleShiftsWorked));
                foreach (var day in days)
                {
                    output.Append(string.Format(",{0} {1} ({2})", day.date.DayOfWeek, day.date.ToString("MM/dd/yyyy"),
                                                day.location));
                }
                output.AppendLine();
            }
            return output;
        }

        public int BlankCount()
        {
            return Schedule.Count(x => x.doctor == null);
        }
    }
}