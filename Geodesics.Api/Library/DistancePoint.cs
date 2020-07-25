using Geodesics.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	public class DistancePoint : IEquatable<DistancePoint>, IDistancePoint
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public bool Equals(DistancePoint other)
		{
			return Latitude == other.Latitude && Longitude == other.Longitude;
		}
	}
}
