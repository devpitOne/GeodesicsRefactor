using Geodesics.Api.Contracts;
using Geodesics.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geodesics.Api.Library
{
	/// <summary>
	/// Concrete Strategy for distance calculation
	/// Included in IoC
	/// </summary>
	public class DistanceCalculationStrategy: IDistanceCalculationStrategy
	{
		private readonly IEnumerable<IDistanceCalculator> _distanceMethods;

		public DistanceCalculationStrategy(IEnumerable<IDistanceCalculator> distanceMethods)
		{
			_distanceMethods = distanceMethods;
		}


		public double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit, DistanceCalculationMethod distanceMethod)
		{
			//Saves calculation when points are equivalent
			if (point1.Equals(point2))
			{
				return 0;
			}
			else return _distanceMethods.FirstOrDefault(x => x.DistanceCalculationMethod == distanceMethod)?.CalculateDistance(point1, point2, measureUnit) ?? throw new ArgumentNullException(nameof(distanceMethod));
		}
	}
}
