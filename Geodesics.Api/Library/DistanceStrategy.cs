using Geodesics.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	public class DistanceStrategy: IDistanceStrategy
	{
		private readonly IEnumerable<IDistanceMethod> _distanceMethods;

		public DistanceStrategy(IEnumerable<IDistanceMethod> distanceMethods)
		{
			_distanceMethods = distanceMethods;
		}


		public double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit, Contracts.DistanceMethod distanceMethod)
		{
			return _distanceMethods.FirstOrDefault(x => x.DistanceMethod == distanceMethod)?.CalculateDistance(point1, point2, measureUnit) ?? throw new ArgumentNullException(nameof(distanceMethod));
		}
	}
}
