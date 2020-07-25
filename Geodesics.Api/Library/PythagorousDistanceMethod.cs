using Geodesics.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	public class PythagorousDistanceMethod : BaseDistanceMethod
	{
		public override DistanceMethod DistanceMethod { get => DistanceMethod.Pythagoras; }

		public override double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit)
		{
			var x = (DegreesToRadians(point2.Longitude) - DegreesToRadians(point1.Longitude)) *
					Math.Cos((DegreesToRadians(point1.Latitude) + DegreesToRadians(point2.Latitude)) / 2);
			var y = DegreesToRadians(point2.Latitude) - DegreesToRadians(point1.Latitude);
			var d = Math.Sqrt(x * x + y * y) * GetEarthRadius(measureUnit);
			return d;
		}
	}
}
