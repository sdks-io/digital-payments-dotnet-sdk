// <copyright file="ShellAPIPlatformSecurityAuthenticationController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
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
using ShellSmartPayAPI.Standard;
using ShellSmartPayAPI.Standard.Exceptions;
using ShellSmartPayAPI.Standard.Http.Client;
using ShellSmartPayAPI.Standard.Utilities;
using System.Net.Http;

namespace ShellSmartPayAPI.Standard.Controllers
{
    /// <summary>
    /// ShellAPIPlatformSecurityAuthenticationController.
    /// </summary>
    public class ShellAPIPlatformSecurityAuthenticationController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellAPIPlatformSecurityAuthenticationController"/> class.
        /// </summary>
        internal ShellAPIPlatformSecurityAuthenticationController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// To obtain APIGEE access token.
        /// </summary>
        /// <param name="grantType">Required parameter: In OAuth 2.0, the term grant typee refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow..</param>
        /// <param name="clientId">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page..</param>
        /// <param name="clientSecret">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential..</param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        public Models.AccessTokenResponse OauthTokenPost(
                string grantType,
                string clientId,
                string clientSecret)
            => CoreHelper.RunTask(OauthTokenPostAsync(grantType, clientId, clientSecret));

        /// <summary>
        /// To obtain APIGEE access token.
        /// </summary>
        /// <param name="grantType">Required parameter: In OAuth 2.0, the term grant typee refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow..</param>
        /// <param name="clientId">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page..</param>
        /// <param name="clientSecret">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        public async Task<Models.AccessTokenResponse> OauthTokenPostAsync(
                string grantType,
                string clientId,
                string clientSecret,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AccessTokenResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/oauth/token")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("grant_type", grantType))
                      .Form(_form => _form.Setup("client_id", clientId))
                      .Form(_form => _form.Setup("client_secret", clientSecret))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new AccessTokenErrorException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}