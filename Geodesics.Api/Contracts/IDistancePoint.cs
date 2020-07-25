using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Contracts
{
	public interface IDistancePoint
	{
		double Latitude { get; set; }

		double Longitude { get; set; }
	}
}
