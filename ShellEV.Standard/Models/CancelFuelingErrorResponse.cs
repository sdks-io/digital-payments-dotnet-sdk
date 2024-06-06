// <copyright file="CancelFuelingErrorResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard.Models
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
    using ShellEV.Standard.Utilities;

    /// <summary>
    /// CancelFuelingErrorResponse.
    /// </summary>
    public class CancelFuelingErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelFuelingErrorResponse"/> class.
        /// </summary>
        public CancelFuelingErrorResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelFuelingErrorResponse"/> class.
        /// </summary>
        /// <param name="errorCode">errorCode.</param>
        /// <param name="errorDescription">errorDescription.</param>
        /// <param name="errors">errors.</param>
        public CancelFuelingErrorResponse(
            string errorCode = null,
            string errorDescription = null,
            List<Models.MppError> errors = null)
        {
            this.ErrorCode = errorCode;
            this.ErrorDescription = errorDescription;
            this.Errors = errors;
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

            return $"CancelFuelingErrorResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is CancelFuelingErrorResponse other &&                ((this.ErrorCode == null && other.ErrorCode == null) || (this.ErrorCode?.Equals(other.ErrorCode) == true)) &&
                ((this.ErrorDescription == null && other.ErrorDescription == null) || (this.ErrorDescription?.Equals(other.ErrorDescription) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ErrorCode = {(this.ErrorCode == null ? "null" : this.ErrorCode)}");
            toStringOutput.Add($"this.ErrorDescription = {(this.ErrorDescription == null ? "null" : this.ErrorDescription)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }
    }
}