using Geodesics.Api.Contracts;

namespace Geodesics.Api.Library
{
	public class DistancePoint : IDistancePoint
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public bool Equals(IDistancePoint other)
		{
			return Latitude == other.Latitude && Longitude == other.Longitude;
		}
	}
}
