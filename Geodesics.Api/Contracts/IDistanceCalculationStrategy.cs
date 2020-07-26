using Geodesics.Api.Enums;

namespace Geodesics.Api.Contracts
{
	/// <summary>
	/// Interface for a Calculation Strategy, similar to a controller
	/// </summary>
	public interface IDistanceCalculationStrategy
	{
		/// <summary>
		/// Controller wrapper. Should call the distance Calculator CalculateDistance
		/// </summary>
		/// <param name="point1">A given point with latitude and longitude</param>
		/// <param name="point2">A second given point with latitude and longitude</param>
		/// <param name="measureUnit">The measurement unit eg. kilometers, miles, furlongs</param>
		/// <param name="distanceMethod">The distance calculation method to use eg. Euclidean, Geosdesic</param>
		/// <returns></returns>
		double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit, DistanceCalculationMethod distanceMethod);

	}
}
