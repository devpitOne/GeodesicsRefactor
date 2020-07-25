using Geodesics.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geodesics.Api.Library
{
	public abstract class BaseDistanceMethod : IDistanceMethod
	{
		protected const double PointOriginDegrees = 90;
		protected const double HalfCircleDegrees = 180.0;


        protected double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / HalfCircleDegrees;
        }

        protected double RadiansToDegrees(double radians)
        {
            return radians * HalfCircleDegrees / Math.PI;
        }

        protected double GetEarthRadius(MeasureUnit measureUnit)
        {
            switch (measureUnit)
            {
                case MeasureUnit.Km:
                    return 6371;
                case MeasureUnit.Mile:
                    return 3959;
                default:
                    throw new ArgumentOutOfRangeException(nameof(measureUnit));
            }
        }

		#region Public Methods
		public abstract DistanceMethod DistanceMethod { get; }

		public virtual double CalculateDistance(IDistancePoint point1, IDistancePoint point2, MeasureUnit measureUnit)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
