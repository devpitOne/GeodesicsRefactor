using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Contracts
{
	public interface IDistanceMethod
	{
		DistanceMethod DistanceMethod { get; }

		double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit);
	}
}
