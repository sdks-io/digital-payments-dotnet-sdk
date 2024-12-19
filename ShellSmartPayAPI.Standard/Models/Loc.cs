// <copyright file="Loc.cs" company="APIMatic">
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
    /// Loc.
    /// </summary>
    public class Loc
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Loc"/> class.
        /// </summary>
        public Loc()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Loc"/> class.
        /// </summary>
        /// <param name="country">country.</param>
        /// <param name="ccode">ccode.</param>
        /// <param name="street">street.</param>
        /// <param name="pc">pc.</param>
        /// <param name="city">city.</param>
        /// <param name="region">region.</param>
        public Loc(
            string country,
            string ccode,
            string street = null,
            string pc = null,
            string city = null,
            string region = null)
        {
            this.Street = street;
            this.Pc = pc;
            this.City = city;
            this.Region = region;
            this.Country = country;
            this.Ccode = ccode;
        }

        /// <summary>
        /// The station’s full street address, including building number
        /// </summary>
        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        /// <summary>
        /// The station’s postcode
        /// </summary>
        [JsonProperty("pc", NullValueHandling = NullValueHandling.Ignore)]
        public string Pc { get; set; }

        /// <summary>
        /// The city the station is located within
        /// </summary>
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// The region the station is located within
        /// </summary>
        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }

        /// <summary>
        /// The name of the country (in English) the station is located within
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// The two-letter ISO 3166 country code of the country the station is located within
        /// </summary>
        [JsonProperty("ccode")]
        public string Ccode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Loc : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Loc other &&
                (this.Street == null && other.Street == null ||
                 this.Street?.Equals(other.Street) == true) &&
                (this.Pc == null && other.Pc == null ||
                 this.Pc?.Equals(other.Pc) == true) &&
                (this.City == null && other.City == null ||
                 this.City?.Equals(other.City) == true) &&
                (this.Region == null && other.Region == null ||
                 this.Region?.Equals(other.Region) == true) &&
                (this.Country == null && other.Country == null ||
                 this.Country?.Equals(other.Country) == true) &&
                (this.Ccode == null && other.Ccode == null ||
                 this.Ccode?.Equals(other.Ccode) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Street = {this.Street ?? "null"}");
            toStringOutput.Add($"Pc = {this.Pc ?? "null"}");
            toStringOutput.Add($"City = {this.City ?? "null"}");
            toStringOutput.Add($"Region = {this.Region ?? "null"}");
            toStringOutput.Add($"Country = {this.Country ?? "null"}");
            toStringOutput.Add($"Ccode = {this.Ccode ?? "null"}");
        }
    }
}