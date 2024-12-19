// <copyright file="CancelFuelingErrorResponseErrorException.cs" company="APIMatic">
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
    /// CancelFuelingErrorResponseErrorException.
    /// </summary>
    public class CancelFuelingErrorResponseErrorException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelFuelingErrorResponseErrorException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public CancelFuelingErrorResponseErrorException(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// The high level error code (e.g. missing data)
        /// </summary>
        [JsonProperty("errorCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// The high level error message (e.g. mandatory fields have not been specified.
        /// </summary>
        [JsonProperty("errorDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Array of error objects. Majority of the time the errorCode and errorDescription will suffice
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.MppError> Errors { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CancelFuelingErrorResponseErrorException : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            base.ToString(toStringOutput);
            toStringOutput.Add($"ErrorCode = {this.ErrorCode ?? "null"}");
            toStringOutput.Add($"ErrorDescription = {this.ErrorDescription ?? "null"}");
            toStringOutput.Add($"Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }
    }
}