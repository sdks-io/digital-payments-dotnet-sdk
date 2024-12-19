// <copyright file="PaymentEnablementResponse.cs" company="APIMatic">
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
    /// PaymentEnablementResponse.
    /// </summary>
    public class PaymentEnablementResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentEnablementResponse"/> class.
        /// </summary>
        public PaymentEnablementResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentEnablementResponse"/> class.
        /// </summary>
        /// <param name="dpanLast4">dpanLast4.</param>
        public PaymentEnablementResponse(
            string dpanLast4)
        {
            this.DpanLast4 = dpanLast4;
        }

        /// <summary>
        /// DPan Last number
        /// </summary>
        [JsonProperty("dpanLast4")]
        public string DpanLast4 { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PaymentEnablementResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PaymentEnablementResponse other &&
                (this.DpanLast4 == null && other.DpanLast4 == null ||
                 this.DpanLast4?.Equals(other.DpanLast4) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DpanLast4 = {this.DpanLast4 ?? "null"}");
        }
    }
}