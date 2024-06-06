// <copyright file="FuelingController.cs" company="APIMatic">
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
    /// FuelingController.
    /// </summary>
    public class FuelingController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuelingController"/> class.
        /// </summary>
        internal FuelingController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// The Digital Payments Service enables 3rd Parties to trigger the refuel process which, if successful, will unlock a pump/nozzle ready for fuelling. Enables a 3rd party to request an access token to start using fueling.
        ///    APIs.
        /// </summary>
        /// <param name="grantType">Required parameter: In OAuth 2.0, the term grant type refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow..</param>
        /// <param name="clientId">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page..</param>
        /// <param name="clientSecret">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential..</param>
        /// <returns>Returns the Models.MppAccesTokenResponse response from the API call.</returns>
        public Models.MppAccesTokenResponse MppToken(
                string grantType,
                string clientId,
                string clientSecret)
            => CoreHelper.RunTask(MppTokenAsync(grantType, clientId, clientSecret));

        /// <summary>
        /// The Digital Payments Service enables 3rd Parties to trigger the refuel process which, if successful, will unlock a pump/nozzle ready for fuelling. Enables a 3rd party to request an access token to start using fueling.
        ///    APIs.
        /// </summary>
        /// <param name="grantType">Required parameter: In OAuth 2.0, the term grant type refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow..</param>
        /// <param name="clientId">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page..</param>
        /// <param name="clientSecret">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.MppAccesTokenResponse response from the API call.</returns>
        public async Task<Models.MppAccesTokenResponse> MppTokenAsync(
                string grantType,
                string clientId,
                string clientSecret,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.MppAccesTokenResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/Fueling/v1/oauth/token")
                  .WithAuth("oAuthTokenPost")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("grant_type", grantType))
                      .Form(_form => _form.Setup("client_id", clientId))
                      .Form(_form => _form.Setup("client_secret", clientSecret))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized. The request has not been applied because it lacks valid authentication credentials for the target resource.", (_reason, _context) => new MppAccesTokenErrorResponseException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Enables a 3rd party to request to unlock a pump so that they may fill up to a pre-authorised limit. The fuel types that are unlocked may also be determined by permitted fuels stored against the user/entity profile.
        /// </summary>
        /// <param name="siteCountry">Required parameter: Country ISO code.</param>
        /// <param name="currency">Required parameter: Currency ISO code.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.PrepareFuelingResponse response from the API call.</returns>
        public Models.PrepareFuelingResponse MppPrepareFueling(
                string siteCountry,
                string currency,
                Models.PrepareFuelingRequest body)
            => CoreHelper.RunTask(MppPrepareFuelingAsync(siteCountry, currency, body));

        /// <summary>
        /// Enables a 3rd party to request to unlock a pump so that they may fill up to a pre-authorised limit. The fuel types that are unlocked may also be determined by permitted fuels stored against the user/entity profile.
        /// </summary>
        /// <param name="siteCountry">Required parameter: Country ISO code.</param>
        /// <param name="currency">Required parameter: Currency ISO code.</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PrepareFuelingResponse response from the API call.</returns>
        public async Task<Models.PrepareFuelingResponse> MppPrepareFuelingAsync(
                string siteCountry,
                string currency,
                Models.PrepareFuelingRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PrepareFuelingResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/Fueling/v1/fueling")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("oAuthTokenPost")
                      .Add("MppToken")
                  )
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Query(_query => _query.Setup("siteCountry", siteCountry))
                      .Query(_query => _query.Setup("currency", currency))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Error Occurred. Request did not include bearer token or token provided and is invalid.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden. Requestor is not permitted to call the API", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Not Found. Request received by the server but requested URL not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Enables a partner user to cancel pump reservation from the App.
        /// </summary>
        /// <param name="mppTransactionId">Required parameter: The ID of the transaction that’s being cancelled.</param>
        public void MppCancelFueling(
                string mppTransactionId)
            => CoreHelper.RunVoidTask(MppCancelFuelingAsync(mppTransactionId));

        /// <summary>
        /// Enables a partner user to cancel pump reservation from the App.
        /// </summary>
        /// <param name="mppTransactionId">Required parameter: The ID of the transaction that’s being cancelled.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task MppCancelFuelingAsync(
                string mppTransactionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/Fueling/v1/fueling/{mppTransactionId}")
                  .WithAndAuth(_andAuth => _andAuth
                      .Add("oAuthTokenPost")
                      .Add("MppToken")
                  )
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("mppTransactionId", mppTransactionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Error Occurred. The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, invalid request message). Please see below for information regarding structure of Response Body vs. all possible errors that could be returned.", (_reason, _context) => new CancelFuelingErrorResponseErrorException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized. Request did not include bearer token or token provided and is invalid.", (_reason, _context) => new CancelFuelingErrorResponseErrorException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden. Requestor is not permitted to call the API.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Not Found. Request received by the server but requested URL not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}