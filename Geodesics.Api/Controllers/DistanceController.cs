using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Geodesics.Api.Contracts;
using Geodesics.Api.Library;
using System.ComponentModel.DataAnnotations;
using Geodesics.Api.Enums;

namespace Geodesics.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DistanceController : ControllerBase
	{
		private readonly IDistanceCalculationStrategy _distanceStrategy;

		public DistanceController(IDistanceCalculationStrategy distanceStrategy)
		{
			_distanceStrategy = distanceStrategy;
		}

		/// <summary>
		/// Retrieves the distance between the provided points.
		/// </summary>
		/// <response code="200">Distance successfully calculated.</response>
		/// <response code="400">Latitude or longitude of any of the given points is out of range.</response>
		/// <response code="500">Unexpected server exception.</response>
		[HttpGet]
		[Route("{distanceMethod}/{measureUnit}")]
		public ActionResult<DistanceResponse> Get(DistanceCalculationMethod distanceMethod, MeasureUnit measureUnit,
			[FromQuery][Range(-90, 90, ErrorMessage = "Must be in [-90, 90] interval")] double point1Latitude,
			[FromQuery][Range(-180, 180, ErrorMessage = "Must be in [-180, 180] interval")] double point1Longitude,
			[FromQuery][Range(-90, 90, ErrorMessage = "Must be in [-90, 90] interval")] double point2Latitude,
			[FromQuery][Range(-180, 180, ErrorMessage = "Must be in [-180, 180] interval")] double point2Longitude)
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

			return new ActionResult<DistanceResponse>(new DistanceResponse
			{
				Distance = _distanceStrategy.CalculateDistance(point1, point2, measureUnit, distanceMethod)
			});
		}

	}
}
