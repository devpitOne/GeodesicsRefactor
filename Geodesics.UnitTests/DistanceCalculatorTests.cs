using Geodesics.Api.Contracts;
using Geodesics.Api.Enums;
using Geodesics.Api.Library;
using NUnit.Framework;
using System;

namespace Geodesics.UnitTests
{
    [TestFixture]
    public class DistanceCalculatorTests
    {
        private IDistanceCalculator instanceUnderTest;
        [SetUp]
        public void Setup() {
            instanceUnderTest = new GeodesicCurveDistanceCalculator();
        }

        [TestCase]
        public void GivenCaseTest()
        {
            var point1 = new DistancePoint {
                Latitude = 53.297975,
                Longitude = -6.372663
            };
            var point2 = new DistancePoint {
                Latitude = 41.385101,
                Longitude = -81.440440
            };
            var result = instanceUnderTest.CalculateDistance(point1, point2, MeasureUnit.Km);
            Assert.AreEqual(5536.338682266685, result);
        }

        [TestCase]
        public void GivenCaseInMilesTest()
        {
            var point1 = new DistancePoint
            {
                Latitude = 53.297975,
                Longitude = -6.372663
            };
            var point2 = new DistancePoint
            {
                Latitude = 41.385101,
                Longitude = -81.440440
            };
            var result = instanceUnderTest.CalculateDistance(point1, point2, MeasureUnit.Mile);
            Assert.AreEqual(Math.Round(5536.338682266685 * 0.62141), Math.Round(result));
        }

        [TestCase]
        public void SamePointCaseTest()
        {
            var point1 = new DistancePoint
            {
                Latitude = 0,
                Longitude = 0
            };
            var result = instanceUnderTest.CalculateDistance(point1, point1, MeasureUnit.Km);
            Assert.AreEqual(0, result);
        }

        [TestCase]
        public void PythagorousCaseTest()
		{
            instanceUnderTest = new PythagorousDistanceCalculator();
            var point1 = new DistancePoint
            {
                Latitude = 90,
                Longitude = 57.295779513082323
            };
            var point2 = new DistancePoint
            {
                Latitude = -90,
                Longitude = 57.295779513082323
            };
            var result = instanceUnderTest.CalculateDistance(point1, point2, MeasureUnit.Km);
            Assert.AreEqual(Math.Round(20015.08), Math.Round(result));
        }
    }
}