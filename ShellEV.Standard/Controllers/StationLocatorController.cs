// <copyright file="StationLocatorController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using ShellEV.Standard;
    using ShellEV.Standard.Exceptions;
    using ShellEV.Standard.Http.Client;
    using ShellEV.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// StationLocatorController.
    /// </summary>
    public class StationLocatorController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StationLocatorController"/> class.
        /// </summary>
        internal StationLocatorController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Returns all sites within specified radius of specified GPS location. Sites of all Types are returned. This call must be used when attempting to establish the station the user is located at as part of fuelling journey (i.e. user has to be within 300m of station to be considered located at the station). This API could also be used as a general query to find nearby Shell locations.
        /// </summary>
        /// <param name="m">Required parameter: API Method to be executed.</param>
        /// <param name="lon">Required parameter: The user’s current longitude.</param>
        /// <param name="lat">Required parameter: The user’s current latitude.</param>
        /// <param name="radius">Required parameter: The search radius in kilometers.</param>
        /// <param name="offerCode">Optional parameter: This enables requestor to specify locations that will honour the specified (advanced) offer code.</param>
        /// <param name="n">Optional parameter: This enables requestor to limit the number of locations that are returned and defaulted to a maximum of 250 locations. Locations returned based on distance to User’s location as-the-crow-flies..</param>
        /// <param name="amenities">Optional parameter: This enables requestor to filter locations based on one or more amenities (e.g. Filter locations so that only those with a Toilet are returned)..</param>
        /// <param name="countries">Optional parameter: This enables requestor to filter locations based on one or more Countries (i.e. by country codes)..</param>
        /// <returns>Returns the Models.AroundLocationArray response from the API call.</returns>
        public Models.AroundLocationArray StationlocatorV1StationsGetAroundLocation(
                string m,
                double lon,
                double lat,
                double radius,
                string offerCode = null,
                int? n = null,
                List<string> amenities = null,
                List<string> countries = null)
            => CoreHelper.RunTask(StationlocatorV1StationsGetAroundLocationAsync(m, lon, lat, radius, offerCode, n, amenities, countries));

        /// <summary>
        /// Returns all sites within specified radius of specified GPS location. Sites of all Types are returned. This call must be used when attempting to establish the station the user is located at as part of fuelling journey (i.e. user has to be within 300m of station to be considered located at the station). This API could also be used as a general query to find nearby Shell locations.
        /// </summary>
        /// <param name="m">Required parameter: API Method to be executed.</param>
        /// <param name="lon">Required parameter: The user’s current longitude.</param>
        /// <param name="lat">Required parameter: The user’s current latitude.</param>
        /// <param name="radius">Required parameter: The search radius in kilometers.</param>
        /// <param name="offerCode">Optional parameter: This enables requestor to specify locations that will honour the specified (advanced) offer code.</param>
        /// <param name="n">Optional parameter: This enables requestor to limit the number of locations that are returned and defaulted to a maximum of 250 locations. Locations returned based on distance to User’s location as-the-crow-flies..</param>
        /// <param name="amenities">Optional parameter: This enables requestor to filter locations based on one or more amenities (e.g. Filter locations so that only those with a Toilet are returned)..</param>
        /// <param name="countries">Optional parameter: This enables requestor to filter locations based on one or more Countries (i.e. by country codes)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AroundLocationArray response from the API call.</returns>
        public async Task<Models.AroundLocationArray> StationlocatorV1StationsGetAroundLocationAsync(
                string m,
                double lon,
                double lat,
                double radius,
                string offerCode = null,
                int? n = null,
                List<string> amenities = null,
                List<string> countries = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AroundLocationArray>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/SiteData/v1/stations/")
                  .WithAuth("oAuthTokenPost")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("m", m))
                      .Query(_query => _query.Setup("lon", lon))
                      .Query(_query => _query.Setup("lat", lat))
                      .Query(_query => _query.Setup("radius", radius))
                      .Query(_query => _query.Setup("offer_code", offerCode))
                      .Query(_query => _query.Setup("n", n))
                      .Query(_query => _query.Setup("amenities", amenities))
                      .Query(_query => _query.Setup("countries", countries))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad request", (_reason, _context) => new StationLocatorBadRequestException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new StationLocatorUnauthorizedException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbbiden", (_reason, _context) => new StationLocatorForbiddenException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Not Found", (_reason, _context) => new StationLocatorNotFoundException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error", (_reason, _context) => new StationLocatorInternalServerErrorException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}