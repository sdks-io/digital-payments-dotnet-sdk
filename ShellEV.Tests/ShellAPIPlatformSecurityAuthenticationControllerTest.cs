// <copyright file="ShellAPIPlatformSecurityAuthenticationControllerTest.cs" company="APIMatic">
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
    /// ShellAPIPlatformSecurityAuthenticationControllerTest.
    /// </summary>
    [TestFixture]
    public class ShellAPIPlatformSecurityAuthenticationControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ShellAPIPlatformSecurityAuthenticationController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.ShellAPIPlatformSecurityAuthenticationController;
        }

        /// <summary>
        /// To obtain APIGEE access token.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestOauthTokenPost()
        {
            // Parameters for the API call
            string grantType = "client_credentials";
            string clientId = "SOFflRakNlwnWlxfOXQ4GHDVyqGawuKA";
            string clientSecret = "cRnWgw7gACqM3gVS";

            // Perform API call
            Standard.Models.AccessTokenResponse result = null;
            try
            {
                result = await this.controller.OauthTokenPostAsync(grantType, clientId, clientSecret);
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