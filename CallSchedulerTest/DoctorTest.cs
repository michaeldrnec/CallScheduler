using CallScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallSchedulerTest {
    [TestClass]
    public class DoctorTest {
        [TestMethod]
        public void GetsMaxShiftsFromLineIfGiven()
        {
            var line = "Sheila,4,5/1/2011 - 5/5/2011";

            var doctor = Doctor.ParseDoctor(line);
            
            Assert.AreEqual(doctor.MaxShifts, 4);
        }

        [TestMethod]
        public void MaxShiftsIsMaxIntWhenNotGiven()
        {
            var line = "Sheila,5/1/2011 - 5/5/2011";

            var doctor = Doctor.ParseDoctor(line);

            Assert.AreEqual(doctor.MaxShifts, int.MaxValue);
        }
    }
}
