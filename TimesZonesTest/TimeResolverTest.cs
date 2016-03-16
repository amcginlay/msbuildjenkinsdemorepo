using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeZones;
using System.Threading;
using Moq;

namespace TimesZonesTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TimeResolverTest
    {
        public TimeResolverTest()
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
        [ExpectedException(typeof(TimeZonesException))]
        public void TestGivenATimeResolverWithANullUCTTimeServiceWhenConstructedThenExceptionIsThrown()
        {
            //arrange
            var timeResolver = new TimeResolver(null);
            //act
            //assert
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForLondonIsCalledThenTimeMatchesUtc()
        {
            //arrange
            var currentTimeUtc = new DateTime(2016, 1, 1, 0, 0, 0); //DateTime.Now;
            //var utcTimeService = new FakeUTCTimeService();
            var utcTimeService = new Mock<IUTCTimeService>();
            utcTimeService.Setup(x => x.GetTime()).Returns(currentTimeUtc);
            var timeResolver = new TimeResolver(utcTimeService.Object);
            //act
            var resolvedTimeForLondon = timeResolver.GetTime(CityEnum.London);
            Thread.Sleep(1500);
            //assert
            Assert.AreEqual(currentTimeUtc, resolvedTimeForLondon);
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForLondonIsCalledThenUTCTimeServiceGetDateIsCalled()
        {
            //arrange
            var currentTimeUtc = new DateTime(2016, 1, 1, 0, 0, 0); //DateTime.Now;
            //var utcTimeService = new FakeUTCTimeService();
            var utcTimeService = new Mock<IUTCTimeService>();
            utcTimeService.Setup(x => x.GetTime()).Returns(currentTimeUtc);
            var timeResolver = new TimeResolver(utcTimeService.Object);
            //act
            var resolvedTimeForLondon = timeResolver.GetTime(CityEnum.London);
            Thread.Sleep(1500);
            //assert
            utcTimeService.Verify(x => x.GetTime(), Times.AtLeastOnce());
        }

        [TestMethod]
        public void TestGivenAValidTimeResolverWhenGetTimeForNewYorkIsCalledThenTimeMatchesUtcMinus5Hours()
        {
            //arrange
            var currentTimeUtc = new DateTime(2016, 1, 1, 0, 0, 0); //DateTime.Now;
            //var utcTimeService = new FakeUTCTimeService();
            var utcTimeService = new Mock<IUTCTimeService>();
            utcTimeService.Setup(x => x.GetTime()).Returns(currentTimeUtc);
            var timeResolver = new TimeResolver(utcTimeService.Object);
            //act
            var resolvedTimeForNewYork = timeResolver.GetTime(CityEnum.NewYork);
            var expectedResult = currentTimeUtc.AddHours(-5);
            //assert
            Assert.AreEqual(expectedResult, resolvedTimeForNewYork);
        }

    }
}
