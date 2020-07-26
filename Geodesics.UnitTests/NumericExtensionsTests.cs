using Geodesics.Api.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geodesics.UnitTests
{
	[TestFixture]
	class NumericExtensionsTests
	{
		[TestCase]
		public void DegreesToRadiansTest()
		{
			var radianAsDegrees = 57.295779513082323;
			var result = radianAsDegrees.DegreesToRadians();
			Assert.AreEqual(1, result);
		}

		[TestCase]
		public void RadiansToDegreesTest()
		{
			var oneRadian = 1.0;
			var result = oneRadian.RadiansToDegrees();
			Assert.AreEqual(57.295779513082323, result);
		}
	}
}
