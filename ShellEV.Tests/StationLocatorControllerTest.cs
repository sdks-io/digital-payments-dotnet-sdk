// <copyright file="StationLocatorControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using ShellEV.Standard;
    using ShellEV.Standard.Controllers;
    using ShellEV.Standard.Exceptions;
    using ShellEV.Standard.Http.Client;
    using ShellEV.Standard.Http.Response;
    using ShellEV.Standard.Utilities;

    /// <summary>
    /// StationLocatorControllerTest.
    /// </summary>
    [TestFixture]
    public class StationLocatorControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private StationLocatorController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.StationLocatorController;
        }

        /// <summary>
        /// Returns all sites within specified radius of specified GPS location. Sites of all Types are returned. This call must be used when attempting to establish the station the user is located at as part of fuelling journey (i.e. user has to be within 300m of station to be considered located at the station). This API could also be used as a general query to find nearby Shell locations.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestStationlocatorV1StationsGetAroundLocation()
        {
            // Parameters for the API call
            string m = "aroundLocation";
            double lon = 77.6730103;
            double lat = 12.9132169;
            double radius = 0.3;
            string offerCode = null;
            int? n = null;
            List<string> amenities = null;
            List<string> countries = null;

            // Perform API call
            Standard.Models.AroundLocationArray result = null;
            try
            {
                result = await this.controller.StationlocatorV1StationsGetAroundLocationAsync(m, lon, lat, radius, offerCode, n, amenities, countries);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    HttpCallBack.Response.Headers),
                    "Headers should match");
        }
    }
}