using Geodesics.Api.Contracts;
using Geodesics.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	public class PythagorousDistanceCalculator : BaseDistanceCalculator
	{
		public override DistanceCalculationMethod DistanceCalculationMethod { get => DistanceCalculationMethod.Pythagoras; }

		public override double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit)
		{
			var x = (point2.Longitude.DegreesToRadians() - point1.Longitude.DegreesToRadians()) *
					Math.Cos((point1.Latitude.DegreesToRadians() + point2.Latitude.DegreesToRadians()) / 2);
			var y = point2.Latitude.DegreesToRadians() - point1.Latitude.DegreesToRadians();
			return Math.Sqrt(x * x + y * y) * EarthRadius.GetValueOrDefault(measureUnit);		
		}
	}
}
