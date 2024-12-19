// <copyright file="DigitalPaymentEnablementController.cs" company="APIMatic">
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
    /// DigitalPaymentEnablementController.
    /// </summary>
    public class DigitalPaymentEnablementController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalPaymentEnablementController"/> class.
        /// </summary>
        internal DigitalPaymentEnablementController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Generates a DPAN and stores the relationship between the Reference ID, DPAN and the real PAN. This method is called during the customer registration process, ahead of any payment. The Reference ID is an identifier chosen by the client system for mobile payment registration. It must be unique in context of the client system, and is the key to obtaining and managing the payment details later.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.PaymentEnablementResponse response from the API call.</returns>
        public Models.PaymentEnablementResponse MpayV1TokensRefPut(
                Models.MobilePaymentRegistrationRequest body)
            => CoreHelper.RunTask(MpayV1TokensRefPutAsync(body));

        /// <summary>
        /// Generates a DPAN and stores the relationship between the Reference ID, DPAN and the real PAN. This method is called during the customer registration process, ahead of any payment. The Reference ID is an identifier chosen by the client system for mobile payment registration. It must be unique in context of the client system, and is the key to obtaining and managing the payment details later.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PaymentEnablementResponse response from the API call.</returns>
        public async Task<Models.PaymentEnablementResponse> MpayV1TokensRefPutAsync(
                Models.MobilePaymentRegistrationRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.PaymentEnablementResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/PaymentEnablement/v1/ref")
                  .WithAuth("oAuthTokenPost")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Error Occurred. The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, invalid request message).", (_reason, _context) => new PaymentEnablementErrorResponseException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized. The request has not been applied because it lacks valid authentication credentials for the target resource.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden. The server understood the request but refuses to authorize it.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Not Found. The origin server did not find a current representation for the target resource or is not willing to disclose that one exists.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal Server Error. The server encountered an unexpected condition that prevented it from fulfilling the request.", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}