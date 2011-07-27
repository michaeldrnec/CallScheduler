using System;
using System.Collections.Generic;
using System.Linq;

namespace CallScheduler {
    public class DoctorQueue {
        public List<Doctor> doctors;

        public DoctorQueue(List<Doctor> doctors) {
            this.doctors = doctors;
        }

        public List<Doctor> GetRankedDoctorList(bool is24)
        {
            if (is24) {
                var orderedList =
                    doctors.OrderBy(x => x.DoubleShiftsWorked).ThenBy(y => y.TotalShiftCount).ThenBy(z => z.OriginalRank).ToList();
                return orderedList;
            } else
            {
                var orderedList = doctors.OrderBy(x => x.TotalShiftCount).ThenBy(y => y.OriginalRank).ToList();
                return orderedList;
            }
        }

        public IEnumerable<Doctor> GetEligibleDoctors(Slot slot) {
            return GetRankedDoctorList(slot.is24)
                .Where(x => !x.HasVacation(slot))
                .Where(x => x.Rotations[slot.rotationNumber] == slot.location);
        }

        public IEnumerable<Doctor> GetCrossCallDoctors(Slot slot) {
            return GetRankedDoctorList(slot.is24)
                .Where(x => !x.HasVacation(slot))
                .Where(x => x.Rotations[slot.rotationNumber] != "NA" && x.Rotations[slot.rotationNumber] != slot.location);
        }

        public void ThisDoctorWasChosen(Doctor chosenDoctor, bool is24)
        {
            var doctor = doctors.Where(x => x.Name == chosenDoctor.Name).First();
            if (is24)
            {
                doctor.DoubleShiftsWorked++;
                doctor.TotalShiftCount = doctor.TotalShiftCount + 2;
            }
            else
            {
                doctor.TotalShiftCount++;
            }
        }
    }
}
