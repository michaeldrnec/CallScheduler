using System;

namespace CallScheduler
{
    public class Slot
    {
        public DateTime date;
        public Doctor doctor;
        public string location;
        public int shift;
        public bool primary;
        public int week;
        public bool is24;
        public int rotationNumber;
        public bool crossCall;

        public Slot(DateTime date, string location, int shift, bool primary, int week, bool is24, int rotationNumber)
        {
            this.date = date;
            this.location = location;
            this.shift = shift;
            this.primary = primary;
            this.week = week;
            this.is24 = is24;
            this.rotationNumber = rotationNumber;
        }

        public bool NotAssigned()
        {
            return doctor == null;
        }
    }
}