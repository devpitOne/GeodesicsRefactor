using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Contracts
{
	/// <summary>
	/// Interface for a distance point. Inherits the IEquatable similar to System.Drawing.Point
	/// </summary>
	public interface IDistancePoint: IEquatable<IDistancePoint>
	{
		/// <summary>
		/// A latitude of a point
		/// </summary>
		double Latitude { get; set; }

		/// <summary>
		/// A longitude of a point
		/// </summary>
		double Longitude { get; set; }
	}
}
