// <copyright file="PartnerNotificationController.cs" company="APIMatic">
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
    /// PartnerNotificationController.
    /// </summary>
    public class PartnerNotificationController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerNotificationController"/> class.
        /// </summary>
        internal PartnerNotificationController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// To access the Partner’s endpoints, for sending callback messages, Shell will need to connect to the Partner API end points. It is recemmended that the partner offers OAuth 2.0 as a standard for call back APIs and will require the OAuth 2.0 token for authentication. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <param name="grantType">Required parameter: In OAuth 2.0, the term grant typee refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow..</param>
        /// <param name="clientId">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page..</param>
        /// <param name="clientSecret">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential..</param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        public Models.AccessTokenResponse PartnerToken(
                string grantType,
                string clientId,
                string clientSecret)
            => CoreHelper.RunTask(PartnerTokenAsync(grantType, clientId, clientSecret));

        /// <summary>
        /// To access the Partner’s endpoints, for sending callback messages, Shell will need to connect to the Partner API end points. It is recemmended that the partner offers OAuth 2.0 as a standard for call back APIs and will require the OAuth 2.0 token for authentication. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <param name="grantType">Required parameter: In OAuth 2.0, the term grant typee refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow..</param>
        /// <param name="clientId">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page..</param>
        /// <param name="clientSecret">Required parameter: After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        public async Task<Models.AccessTokenResponse> PartnerTokenAsync(
                string grantType,
                string clientId,
                string clientSecret,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.AccessTokenResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/token")
                  .Parameters(_parameters => _parameters
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("grant_type", grantType))
                      .Form(_form => _form.Setup("client_id", clientId))
                      .Form(_form => _form.Setup("client_secret", clientSecret))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new AccessTokenErrorException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Enables Shell to inform partner of the successful completion of a transaction. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        public void FinaliseFueling(
                Models.FinaliseFuelingRequest body = null)
            => CoreHelper.RunVoidTask(FinaliseFuelingAsync(body));

        /// <summary>
        /// Enables Shell to inform partner of the successful completion of a transaction. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task FinaliseFuelingAsync(
                Models.FinaliseFuelingRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/finaliseFueling")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Enables Shell to inform partner that a Mobile Payment transaction has been cancelled by Shell as an error/issue occured. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        public void CancelFueling(
                Models.CancelFuelingRequest body = null)
            => CoreHelper.RunVoidTask(CancelFuelingAsync(body));

        /// <summary>
        /// Enables Shell to inform partner that a Mobile Payment transaction has been cancelled by Shell as an error/issue occured. Note this needs to be implemented over HTTPS.
        /// </summary>
        /// <param name="body">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CancelFuelingAsync(
                Models.CancelFuelingRequest body = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/cancelFueling")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}