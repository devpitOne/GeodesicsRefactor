using Geodesics.Api.Contracts;
using Geodesics.Api.Enums;
using System;
using System.Collections.Generic;

namespace Geodesics.Api.Library
{
	public class GeodesicCurveDistanceCalculator : BaseDistanceCalculator
	{
		public override DistanceCalculationMethod DistanceCalculationMethod { get => DistanceCalculationMethod.GeodesicCurve; }

		public override double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit)
		{
			var point2DistFromOrigin = PointOriginDegrees - point2.Latitude;
			var point1DistFromOrigin = PointOriginDegrees - point1.Latitude;
			var diffLongitude = point1.Longitude - point2.Longitude;
			var cosP = Math.Cos(point2DistFromOrigin.DegreesToRadians()) * Math.Cos(point1DistFromOrigin.DegreesToRadians()) +
					   Math.Sin(point2DistFromOrigin.DegreesToRadians()) * Math.Sin(point1DistFromOrigin.DegreesToRadians()) * Math.Cos(diffLongitude.DegreesToRadians());
			var degreesOfAngle = Math.Acos(cosP).RadiansToDegrees();
			return Math.PI * degreesOfAngle * EarthRadius.GetValueOrDefault(measureUnit) / 180;
		}
	}
}
