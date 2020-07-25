using Geodesics.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	public class GeodesicCurveDistanceMethod : BaseDistanceMethod
	{
		public override DistanceMethod DistanceMethod { get => DistanceMethod.GeodesicCurve; }
		public override double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit)
		{
			var a = PointOriginDegrees - point2.Latitude;
			var b = PointOriginDegrees - point1.Latitude;
			var fi = point1.Longitude - point2.Longitude;
			var cosP = Math.Cos(DegreesToRadians(a)) * Math.Cos(DegreesToRadians(b)) +
					   Math.Sin(DegreesToRadians(a)) * Math.Sin(DegreesToRadians(b)) * Math.Cos(DegreesToRadians(fi));
			var n = RadiansToDegrees(Math.Acos(cosP));
			var d = Math.PI * n * GetEarthRadius(measureUnit) / 180;
			return d;
		}
	}
}
