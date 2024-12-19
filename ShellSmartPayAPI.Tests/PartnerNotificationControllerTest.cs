// <copyright file="PartnerNotificationControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using APIMatic.Core.Utilities;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using ShellSmartPayAPI.Standard;
using ShellSmartPayAPI.Standard.Controllers;
using ShellSmartPayAPI.Standard.Exceptions;
using ShellSmartPayAPI.Standard.Http.Client;
using ShellSmartPayAPI.Standard.Http.Response;
using ShellSmartPayAPI.Standard.Utilities;

namespace ShellSmartPayAPI.Tests
{
    /// <summary>
    /// PartnerNotificationControllerTest.
    /// </summary>
    [TestFixture]
    public class PartnerNotificationControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private PartnerNotificationController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.PartnerNotificationController;
        }

        /// <summary>
        /// To access the Partner’s endpoints, for sending callback messages, Shell will need to connect to the Partner API end points. It is recemmended that the partner offers OAuth 2.0 as a standard for call back APIs and will require the OAuth 2.0 token for authentication. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestPartnerToken()
        {
            // Parameters for the API call
            string grantType = "client_credentials";
            string clientId = "SOFflRakNlwnWlxfOXQ4GHDVyqGawuKA";
            string clientSecret = "cRnWgw7gACqM3gVS";

            // Perform API call
            Standard.Models.AccessTokenResponse result = null;
            try
            {
                result = await this.controller.PartnerTokenAsync(grantType, clientId, clientSecret);
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
        /// Enables Shell to inform partner of the successful completion of a transaction. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestFinaliseFueling()
        {
            // Parameters for the API call
            Standard.Models.FinaliseFuelingRequest body = null;

            // Perform API call
            try
            {
                await this.controller.FinaliseFuelingAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }

        /// <summary>
        /// Enables Shell to inform partner that a Mobile Payment transaction has been cancelled by Shell as an error/issue occured. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCancelFueling()
        {
            // Parameters for the API call
            Standard.Models.CancelFuelingRequest body = null;

            // Perform API call
            try
            {
                await this.controller.CancelFuelingAsync(body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }
    }
}