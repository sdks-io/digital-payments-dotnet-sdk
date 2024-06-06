// <copyright file="MppAccesTokenErrorResponseException.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using ShellEV.Standard;
    using ShellEV.Standard.Http.Client;
    using ShellEV.Standard.Models;
    using ShellEV.Standard.Utilities;

    /// <summary>
    /// MppAccesTokenErrorResponseException.
    /// </summary>
    public class MppAccesTokenErrorResponseException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MppAccesTokenErrorResponseException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public MppAccesTokenErrorResponseException(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// error code or short description
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// error code or short description due to invalid request or invalid client ID
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Description of the error
        /// </summary>
        [JsonProperty("error_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; }
    }
}