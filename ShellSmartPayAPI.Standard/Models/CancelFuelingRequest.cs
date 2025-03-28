// <copyright file="CancelFuelingRequest.cs" company="APIMatic">
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
using ShellSmartPayAPI.Standard.Utilities;

namespace ShellSmartPayAPI.Standard.Models
{
    /// <summary>
    /// CancelFuelingRequest.
    /// </summary>
    public class CancelFuelingRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelFuelingRequest"/> class.
        /// </summary>
        public CancelFuelingRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelFuelingRequest"/> class.
        /// </summary>
        /// <param name="mppTransactionId">mppTransactionId.</param>
        /// <param name="reasonCode">reasonCode.</param>
        public CancelFuelingRequest(
            string mppTransactionId = null,
            string reasonCode = null)
        {
            this.MppTransactionId = mppTransactionId;
            this.ReasonCode = reasonCode;
        }

        /// <summary>
        /// Gets or sets MppTransactionId.
        /// </summary>
        [JsonProperty("mppTransactionId", NullValueHandling = NullValueHandling.Ignore)]
        public string MppTransactionId { get; set; }

        /// <summary>
        /// Gets or sets ReasonCode.
        /// </summary>
        [JsonProperty("reasonCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ReasonCode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CancelFuelingRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CancelFuelingRequest other &&
                (this.MppTransactionId == null && other.MppTransactionId == null ||
                 this.MppTransactionId?.Equals(other.MppTransactionId) == true) &&
                (this.ReasonCode == null && other.ReasonCode == null ||
                 this.ReasonCode?.Equals(other.ReasonCode) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"MppTransactionId = {this.MppTransactionId ?? "null"}");
            toStringOutput.Add($"ReasonCode = {this.ReasonCode ?? "null"}");
        }
    }
}