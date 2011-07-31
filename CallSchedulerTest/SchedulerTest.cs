using System;
using System.Collections.Generic;
using CallScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallSchedulerTest {
    [TestClass]
    public class SchedulerTest {
        public SchedulerTest() {
        }

        private TestContext testContextInstance;

        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TrueWhenAlreadyScheduledTwoDaysInARow()
        {
            var doctor = new Doctor();
            doctor.Name = "House";
            var scheduler = new Scheduler();
            scheduler.Schedule = new List<Slot>();
            scheduler.Schedule.Add(new Slot(new DateTime(2011,9,3), "CT", 2, true, 1, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011,9,11), "CT", 1, true, 2, false, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011,9,16), "CT", 3, true, 3, false, 1));
            scheduler.Schedule[0].doctor = doctor;
            scheduler.Schedule[1].doctor = doctor;

            scheduler.MaxConsecutiveShifts = 2;

            Assert.IsTrue(scheduler.DoctorWouldExceedMaxConsecutiveShifts(scheduler.Schedule[2], doctor));
        }
        [TestMethod]
        public void TrueWhenDayBeingScheduledWouldExceedMax() {
            var doctor = new Doctor();
            doctor.Name = "House";
            var scheduler = new Scheduler();
            scheduler.Schedule = new List<Slot>();
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 11), "CT", 1, true, 2, false, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 16), "CT", 3, true, 3, false, 1));
            scheduler.Schedule[0].doctor = doctor;
            scheduler.Schedule[2].doctor = doctor;

            scheduler.MaxConsecutiveShifts = 2;

            Assert.IsTrue(scheduler.DoctorWouldExceedMaxConsecutiveShifts(scheduler.Schedule[1], doctor));
        }
    }
}
