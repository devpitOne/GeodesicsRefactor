using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	/// <summary>
	/// USeful methods to have on the double type
	/// </summary>
	public static class NumericExtensions
	{
		private static readonly double halfCircleDegrees = 180;
		/// <summary>
		/// Convert degrees to Radians.
		/// </summary>
		/// <param name="degrees">The value to convert to radians</param>
		/// <returns>The value in radians</returns>
		public static double DegreesToRadians(this double degrees)
		{
			return degrees * Math.PI / halfCircleDegrees;
		}

		/// <summary>
		/// Convert radians to degrees.
		/// </summary>
		/// <param name="radians">The value to convert to degrees</param>
		/// <returns>The value in degrees</returns>
		public static double RadiansToDegrees(this double radians)
		{
			return radians * halfCircleDegrees / Math.PI;
		}
	}
}
