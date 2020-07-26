using Geodesics.Api.Contracts;
using Geodesics.Api.Enums;
using System;
using System.Collections.Generic;

namespace Geodesics.Api.Library
{
	/// <summary>
	/// Abstract implementation of IDistanceCalculator
	/// Necessary for the strategy pattern and to hold the constants
	/// Constants are a refactor candidate for a CalculatorConstants singleton
	/// </summary>
	public abstract class BaseDistanceCalculator : IDistanceCalculator
	{
		protected const double PointOriginDegrees = 90;
        protected readonly Dictionary<MeasureUnit, double> EarthRadius = new Dictionary<MeasureUnit, double> {
            {MeasureUnit.Km, 6371 },
            {MeasureUnit.Mile, 3959 }
        };

		#region Public Methods
		public abstract DistanceCalculationMethod DistanceCalculationMethod { get; }

		public virtual double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
