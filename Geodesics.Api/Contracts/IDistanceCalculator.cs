using Geodesics.Api.Enums;

namespace Geodesics.Api.Contracts
{
	/// <summary>
	/// Interface for a DistanceCalculator type, coupled with DistanceCalculationMethod
	/// </summary>
	public interface IDistanceCalculator
	{
		/// <summary>
		/// The Distance Calculation Method this calculator is for
		/// </summary>
		DistanceCalculationMethod DistanceCalculationMethod { get; }

		/// <summary>
		/// The distance calculation method
		/// </summary>
		/// <param name="point1">A given point with latitude and longitude</param>
		/// <param name="point2">A second given point with latitude and longitude</param>
		/// <param name="measureUnit">The measurement unit eg. kilometers, miles, furlongs</param>
		/// <returns></returns>
		double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit);
	}
}
