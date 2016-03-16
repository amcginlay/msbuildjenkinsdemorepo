using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZones;

namespace TimesZonesTest
{
    /// <summary>
    /// Summary description for UTCTimeServiceTest
    /// </summary>
    [TestClass]
    public class UTCTimeServiceTest
    {
        public UTCTimeServiceTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
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
        [Ignore]
        public void TestGivenAValidUTCTimeServiceWhenGetTimeCalledThenTimeIsMidday()
        {
            // arrange
            var utcTimeService = new UTCTimeService();
            // act
            var dateTime = utcTimeService.GetTime();
            // assert
            Assert.AreEqual(new DateTime(2016, 2, 11, 12, 0, 0), dateTime);
        }
    }
}
