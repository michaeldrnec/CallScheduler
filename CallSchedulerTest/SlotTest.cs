using CallScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CallSchedulerTest
{
    
    
    /// <summary>
    ///This is a test class for SlotTest and is intended
    ///to contain all SlotTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SlotTest {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for NotAssigned
        ///</summary>
        [TestMethod()]
        public void NotAssignedTest() {
            DateTime date = new DateTime(); // TODO: Initialize to an appropriate value
            string location = string.Empty; // TODO: Initialize to an appropriate value
            int shift = 0; // TODO: Initialize to an appropriate value
            bool primary = false; // TODO: Initialize to an appropriate value
            int week = 0; // TODO: Initialize to an appropriate value
            bool is24 = false; // TODO: Initialize to an appropriate value
            int rotationNumber = 0; // TODO: Initialize to an appropriate value
            Slot target = new Slot(date, location, shift, primary, week, is24, rotationNumber); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.NotAssigned();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Slot Constructor
        ///</summary>
        [TestMethod()]
        public void SlotConstructorTest() {
            DateTime date = new DateTime(); // TODO: Initialize to an appropriate value
            string location = string.Empty; // TODO: Initialize to an appropriate value
            int shift = 0; // TODO: Initialize to an appropriate value
            bool primary = false; // TODO: Initialize to an appropriate value
            int week = 0; // TODO: Initialize to an appropriate value
            bool is24 = false; // TODO: Initialize to an appropriate value
            int rotationNumber = 0; // TODO: Initialize to an appropriate value
            Slot target = new Slot(date, location, shift, primary, week, is24, rotationNumber);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
