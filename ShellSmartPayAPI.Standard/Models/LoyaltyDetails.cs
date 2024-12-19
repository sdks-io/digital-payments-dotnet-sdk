// <copyright file="LoyaltyDetails.cs" company="APIMatic">
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
    /// LoyaltyDetails.
    /// </summary>
    public class LoyaltyDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyDetails"/> class.
        /// </summary>
        public LoyaltyDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyDetails"/> class.
        /// </summary>
        /// <param name="loyaltyId">loyaltyId.</param>
        /// <param name="loyaltyType">loyaltyType.</param>
        public LoyaltyDetails(
            string loyaltyId,
            string loyaltyType)
        {
            this.LoyaltyId = loyaltyId;
            this.LoyaltyType = loyaltyType;
        }

        /// <summary>
        /// The user’s Loyalty card number. Although this is optional the expectation is that if this is specified then loyaltyType must also be specified
        /// </summary>
        [JsonProperty("loyaltyId")]
        public string LoyaltyId { get; set; }

        /// <summary>
        /// Loyalty type being used, associated to the loyalty ID being passed. Possible values are 'Shell'
        /// </summary>
        [JsonProperty("loyaltyType")]
        public string LoyaltyType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is LoyaltyDetails other &&
                (this.LoyaltyId == null && other.LoyaltyId == null ||
                 this.LoyaltyId?.Equals(other.LoyaltyId) == true) &&
                (this.LoyaltyType == null && other.LoyaltyType == null ||
                 this.LoyaltyType?.Equals(other.LoyaltyType) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyId = {this.LoyaltyId ?? "null"}");
            toStringOutput.Add($"LoyaltyType = {this.LoyaltyType ?? "null"}");
        }
    }
}