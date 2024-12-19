// <copyright file="MppAccesTokenErrorResponseException.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
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
using ShellSmartPayAPI.Standard;
using ShellSmartPayAPI.Standard.Http.Client;
using ShellSmartPayAPI.Standard.Models;
using ShellSmartPayAPI.Standard.Utilities;

namespace ShellSmartPayAPI.Standard.Exceptions
{
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"MppAccesTokenErrorResponseException : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            base.ToString(toStringOutput);
            toStringOutput.Add($"Error = {this.Error ?? "null"}");
            toStringOutput.Add($"ErrorCode = {this.ErrorCode ?? "null"}");
            toStringOutput.Add($"ErrorDescription = {this.ErrorDescription ?? "null"}");
        }
    }
}