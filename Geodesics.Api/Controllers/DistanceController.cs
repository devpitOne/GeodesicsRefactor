using System;
using Microsoft.AspNetCore.Mvc;

namespace Geodesics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {
        private const double PointOriginDegrees = 90;
        private const double HalfCircleDegrees = 180.0;

        /// <summary>
        /// Retrieves the distance between the provided points.
        /// </summary>
        /// <response code="200">Distance successfully calculated.</response>
        /// <response code="400">Latitude or longitude of any of the given points is out of range.</response>
        /// <response code="500">Unexpected server exception.</response>
        [HttpGet]
        [Route("{distanceMethod}/{measureUnit}")]
        public ActionResult<DistanceResponse> Get(DistanceMethod distanceMethod, MeasureUnit measureUnit,
            [FromQuery] double point1Latitude, [FromQuery] double point1Longitude,
            [FromQuery] double point2Latitude, [FromQuery] double point2Longitude)
        {
            var point1 = new DistancePoint
            {
                Latitude = point1Latitude,
                Longitude = point1Longitude
            };
            var point2 = new DistancePoint
            {
                Latitude = point2Latitude,
                Longitude = point2Longitude
            };
            try
            {
                ValidatePoint(point1);
                ValidatePoint(point2);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }

            switch (distanceMethod)
            {
                case DistanceMethod.GeodesicCurve:
                    return new ActionResult<DistanceResponse>(new DistanceResponse
                    {
                        Distance = CalculateGeodesicCurve(point1, point2, measureUnit)
                    });
                case DistanceMethod.Pythagoras:
                    return new ActionResult<DistanceResponse>(new DistanceResponse
                    {
                        Distance = CalculatePythagoras(point1, point2, measureUnit)
                    });
                default:
                    throw new ArgumentOutOfRangeException(nameof(distanceMethod), distanceMethod, null);
            }
        }

        private void ValidatePoint(DistancePoint point)
        {
            if (point.Latitude < -90 || point.Latitude > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(point.Latitude), "Must be in [-90, 90] interval");
            }
            if (point.Longitude < -180 || point.Longitude > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(point.Longitude), "Must be in [-180, 180] interval");
            }
        }

        private static double CalculateGeodesicCurve(DistancePoint point1, DistancePoint point2, MeasureUnit measureUnit)
        {
            var a = PointOriginDegrees - point2.Latitude;
            var b = PointOriginDegrees - point1.Latitude;
            var fi = point1.Longitude - point2.Longitude;
            var cosP = Math.Cos(DegreesToRadians(a)) * Math.Cos(DegreesToRadians(b)) +
                       Math.Sin(DegreesToRadians(a)) * Math.Sin(DegreesToRadians(b)) * Math.Cos(DegreesToRadians(fi));
            var n = RadiansToDegrees(Math.Acos(cosP));
            var d = Math.PI * n * GetEarthRadius(measureUnit) / 180;
            return d;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / HalfCircleDegrees;
        }

        private static double RadiansToDegrees(double radians)
        {
            return radians * HalfCircleDegrees / Math.PI;
        }

        private static double GetEarthRadius(MeasureUnit measureUnit)
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

        private static double CalculatePythagoras(DistancePoint point1, DistancePoint point2, MeasureUnit measureUnit)
        {
            var x = (DegreesToRadians(point2.Longitude) - DegreesToRadians(point1.Longitude)) *
                    Math.Cos((DegreesToRadians(point1.Latitude) + DegreesToRadians(point2.Latitude)) / 2);
            var y = DegreesToRadians(point2.Latitude) - DegreesToRadians(point1.Latitude);
            var d = Math.Sqrt(x * x + y * y) * GetEarthRadius(measureUnit);
            return d;
        }
    }

    public class DistancePoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public enum DistanceMethod
    {
        GeodesicCurve,
        Pythagoras
    }

    public class DistanceResponse
    {
        public double Distance { get; set; }
    }

    public enum MeasureUnit
    {
        Km,
        Mile
    }
}
