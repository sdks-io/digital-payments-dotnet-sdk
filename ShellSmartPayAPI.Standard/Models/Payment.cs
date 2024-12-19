// <copyright file="Payment.cs" company="APIMatic">
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
    /// Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        public Payment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="method">method.</param>
        /// <param name="cardId">cardId.</param>
        /// <param name="cardLastDigits">cardLastDigits.</param>
        public Payment(
            string method = null,
            string cardId = null,
            string cardLastDigits = null)
        {
            this.Method = method;
            this.CardId = cardId;
            this.CardLastDigits = cardLastDigits;
        }

        /// <summary>
        /// Gets or sets Method.
        /// </summary>
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets CardId.
        /// </summary>
        [JsonProperty("cardId", NullValueHandling = NullValueHandling.Ignore)]
        public string CardId { get; set; }

        /// <summary>
        /// Gets or sets CardLastDigits.
        /// </summary>
        [JsonProperty("cardLastDigits", NullValueHandling = NullValueHandling.Ignore)]
        public string CardLastDigits { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Payment : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Payment other &&
                (this.Method == null && other.Method == null ||
                 this.Method?.Equals(other.Method) == true) &&
                (this.CardId == null && other.CardId == null ||
                 this.CardId?.Equals(other.CardId) == true) &&
                (this.CardLastDigits == null && other.CardLastDigits == null ||
                 this.CardLastDigits?.Equals(other.CardLastDigits) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Method = {this.Method ?? "null"}");
            toStringOutput.Add($"CardId = {this.CardId ?? "null"}");
            toStringOutput.Add($"CardLastDigits = {this.CardLastDigits ?? "null"}");
        }
    }
}