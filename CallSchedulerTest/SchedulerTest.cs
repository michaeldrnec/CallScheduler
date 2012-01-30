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

        [TestMethod]
        public void TrueWhenTwoSaturdaysExceedsMaxShiftsPerRotation()
        {
            var doctor = new Doctor();
            doctor.Name = "House";
            var scheduler = new Scheduler();
            scheduler.Schedule = new List<Slot>();
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 10), "CT", 2, true, 2, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 17), "CT", 2, true, 3, true, 1));
            scheduler.Schedule[0].doctor = doctor;

            scheduler.MaxShiftsPerRotation = 3;
            Assert.IsTrue(scheduler.DoctorHasExceededMaxDaysThisRotation(scheduler.Schedule[1], doctor));
        }
        [TestMethod]
        public void FalseWhenMaxShiftsPerRotationIsZero() {
            var doctor = new Doctor();
            doctor.Name = "House";
            var scheduler = new Scheduler();
            scheduler.Schedule = new List<Slot>();
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 10), "CT", 2, true, 2, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 17), "CT", 2, true, 3, true, 1));
            scheduler.Schedule[0].doctor = doctor;

            scheduler.MaxShiftsPerRotation = 0;
            Assert.IsFalse(scheduler.DoctorHasExceededMaxDaysThisRotation(scheduler.Schedule[1], doctor));
        }

        [TestMethod]
        public void FalseWhenDoesNotExceedMaxShiftsPerRotation() {
            var doctor = new Doctor();
            doctor.Name = "House";
            var scheduler = new Scheduler();
            scheduler.Schedule = new List<Slot>();
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 10), "CT", 2, true, 2, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 17), "CT", 2, true, 3, true, 1));
            scheduler.Schedule[0].doctor = doctor;

            scheduler.MaxShiftsPerRotation = 4;
            Assert.IsFalse(scheduler.DoctorHasExceededMaxDaysThisRotation(scheduler.Schedule[1], doctor));
        }

        [TestMethod]
        public void FalseWhenSingleShiftDoesNotExceedMaxShiftsPerRotation() {
            var doctor = new Doctor();
            doctor.Name = "House";
            var scheduler = new Scheduler();
            scheduler.Schedule = new List<Slot>();
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 9), "CT", 1, true, 2, false, 1));
            scheduler.Schedule.Add(new Slot(new DateTime(2011, 9, 17), "CT", 2, true, 3, true, 1));
            scheduler.Schedule[0].doctor = doctor;

            scheduler.MaxShiftsPerRotation = 3;
            Assert.IsFalse(scheduler.DoctorHasExceededMaxDaysThisRotation(scheduler.Schedule[1], doctor));
        }

        [TestMethod]
        public void TrueWhenDoctorExceededMaxShiftsForDoctor()
        {
            var doctor = new Doctor();
            doctor.Name = "House";
            doctor.MaxShifts = 3;
            doctor.TotalShiftCount = 2;

            var scheduler = new Scheduler();
            Assert.IsTrue(scheduler.DoctorHasExceededHisPersonalMaxShifts(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1), doctor));
        }

        [TestMethod]
        public void FalseWhenDoctorDoesnotExceedMaxShiftsForDoctor() {
            var doctor = new Doctor();
            doctor.Name = "House";
            doctor.MaxShifts = 5;
            doctor.TotalShiftCount = 2;

            var scheduler = new Scheduler();
            Assert.IsFalse(scheduler.DoctorHasExceededHisPersonalMaxShifts(new Slot(new DateTime(2011, 9, 3), "CT", 2, true, 1, true, 1), doctor));
        }
    }
}
