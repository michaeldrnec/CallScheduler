using System;

namespace CallScheduler {
    public class Rotation {
        public DateTime startDate;
        public DateTime endDate;

        public Rotation(string dateRange) {
            var dates = dateRange.Split('-');
            if (dates.Length == 2) {
                startDate = DateTime.Parse(dates[0]);
                endDate = DateTime.Parse(dates[1]);
            }
        }
    }
}
