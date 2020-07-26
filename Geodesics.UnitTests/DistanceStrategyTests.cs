using Geodesics.Api.Contracts;
using Geodesics.Api.Enums;
using Geodesics.Api.Library;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Geodesics.UnitTests
{
	[TestFixture]
	public class DistanceStrategyTests
	{
		private IDistanceCalculationStrategy instanceUnderTest;
		[SetUp]
		public void Setup()
		{
			var inputList = new List<IDistanceCalculator>();
			instanceUnderTest = new DistanceCalculationStrategy(inputList);
		}

		[TestCase]
		public void CalculateDistanceOnSamePointTest()
		{
			var point1 = new DistancePoint { Latitude = 1, Longitude = 1 };
			var result = instanceUnderTest.CalculateDistance(point1, point1, MeasureUnit.Km, DistanceCalculationMethod.GeodesicCurve);
			Assert.AreEqual(0, result);
		}

		[TestCase]
		public void CalculateDistanceWithNoCalculatorsTest()
		{
			var point1 = new DistancePoint { Latitude = 1, Longitude = 1 };
			var point2 = new DistancePoint { Latitude = 1, Longitude = 2 };
			try
			{
				var result = instanceUnderTest.CalculateDistance(point1, point2, MeasureUnit.Km, DistanceCalculationMethod.GeodesicCurve);
			}
			catch (ArgumentNullException) {
				Assert.Pass();
			}
			Assert.Fail();
		}

		[TestCase]
		public void CalculateDistanceWithMatchingCalculatorTest()
		{
			//setup
			var point1 = new DistancePoint { Latitude = 1, Longitude = 1 };
			var point2 = new DistancePoint { Latitude = 1, Longitude = 2 };
			var inputList = new List<IDistanceCalculator>();
			var mockCalculator = new Mock<IDistanceCalculator>();
			mockCalculator.Setup(x => x.DistanceCalculationMethod).Returns(DistanceCalculationMethod.GeodesicCurve);
			mockCalculator.Setup(x => x.CalculateDistance(point1, point2, MeasureUnit.Km)).Returns(1);
			inputList.Add(mockCalculator.Object);
			instanceUnderTest = new DistanceCalculationStrategy(inputList);			

			//execution
			var result = instanceUnderTest.CalculateDistance(point1, point2, MeasureUnit.Km, DistanceCalculationMethod.GeodesicCurve);
			Assert.AreEqual(1, result);
		}
	}
}