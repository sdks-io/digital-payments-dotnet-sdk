// <copyright file="FuelingControllerTest.cs" company="APIMatic">
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
    /// FuelingControllerTest.
    /// </summary>
    [TestFixture]
    public class FuelingControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private FuelingController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.FuelingController;
        }

        /// <summary>
        /// The Digital Payments Service enables 3rd Parties to trigger the refuel process which, if successful, will unlock a pump/nozzle ready for fuelling. Enables a 3rd party to request an access token to start using fueling.
        ///   APIs.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestMppToken()
        {
            // Parameters for the API call
            string grantType = "client_credentials";
            string clientId = "b2bmpp-cli";
            string clientSecret = "f20935d8f14a44bd1f0923cc4c4fa63f7b25922330cd5080f735f1a2769ece77ce245cfe8ba4cbd2a58544ee5113c200b8e37a7be33311e4b6f3c785bf3f37d2";

            // Perform API call
            Standard.Models.MppAccesTokenResponse result = null;
            try
            {
                result = await this.controller.MppTokenAsync(grantType, clientId, clientSecret);
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

        /// <summary>
        /// Enables a partner user to cancel pump reservation from the App.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestMppCancelFueling()
        {
            // Parameters for the API call
            string mppTransactionId = "000000001C48";

            // Perform API call
            try
            {
                await this.controller.MppCancelFuelingAsync(mppTransactionId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Enables a partner user to cancel pump reservation from the App.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestMppCancelFueling1()
        {
            // Parameters for the API call
            string mppTransactionId = "000000001C48";

            // Perform API call
            try
            {
                await this.controller.MppCancelFuelingAsync(mppTransactionId);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(204, HttpCallBack.Response.StatusCode, "Status should be 204");
        }
    }
}