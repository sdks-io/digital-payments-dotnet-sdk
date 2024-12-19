// <copyright file="OpeningHour.cs" company="APIMatic">
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
    /// OpeningHour.
    /// </summary>
    public class OpeningHour
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningHour"/> class.
        /// </summary>
        public OpeningHour()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningHour"/> class.
        /// </summary>
        /// <param name="closingFromHours">Closing_From_Hours.</param>
        /// <param name="closingFromMinutes">Closing_From_Minutes.</param>
        /// <param name="closingToHours">Closing_To_Hours.</param>
        /// <param name="closingToMinutes">Closing_To_Minutes.</param>
        /// <param name="fromDay">From_Day.</param>
        /// <param name="openingFromHours">Opening_From_Hours.</param>
        /// <param name="openingFromMinutes">Opening_From_Minutes.</param>
        /// <param name="openingToHours">Opening_To_Hours.</param>
        /// <param name="openingToMinutes">Opening_To_Minutes.</param>
        /// <param name="toDay">To_Day.</param>
        public OpeningHour(
            string closingFromHours = null,
            string closingFromMinutes = null,
            string closingToHours = null,
            string closingToMinutes = null,
            string fromDay = null,
            string openingFromHours = null,
            string openingFromMinutes = null,
            string openingToHours = null,
            string openingToMinutes = null,
            string toDay = null)
        {
            this.ClosingFromHours = closingFromHours;
            this.ClosingFromMinutes = closingFromMinutes;
            this.ClosingToHours = closingToHours;
            this.ClosingToMinutes = closingToMinutes;
            this.FromDay = fromDay;
            this.OpeningFromHours = openingFromHours;
            this.OpeningFromMinutes = openingFromMinutes;
            this.OpeningToHours = openingToHours;
            this.OpeningToMinutes = openingToMinutes;
            this.ToDay = toDay;
        }

        /// <summary>
        /// Gets or sets ClosingFromHours.
        /// </summary>
        [JsonProperty("Closing_From_Hours", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingFromHours { get; set; }

        /// <summary>
        /// Gets or sets ClosingFromMinutes.
        /// </summary>
        [JsonProperty("Closing_From_Minutes", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingFromMinutes { get; set; }

        /// <summary>
        /// Gets or sets ClosingToHours.
        /// </summary>
        [JsonProperty("Closing_To_Hours", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingToHours { get; set; }

        /// <summary>
        /// Gets or sets ClosingToMinutes.
        /// </summary>
        [JsonProperty("Closing_To_Minutes", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingToMinutes { get; set; }

        /// <summary>
        /// Gets or sets FromDay.
        /// </summary>
        [JsonProperty("From_Day", NullValueHandling = NullValueHandling.Ignore)]
        public string FromDay { get; set; }

        /// <summary>
        /// Gets or sets OpeningFromHours.
        /// </summary>
        [JsonProperty("Opening_From_Hours", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningFromHours { get; set; }

        /// <summary>
        /// Gets or sets OpeningFromMinutes.
        /// </summary>
        [JsonProperty("Opening_From_Minutes", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningFromMinutes { get; set; }

        /// <summary>
        /// Gets or sets OpeningToHours.
        /// </summary>
        [JsonProperty("Opening_To_Hours", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningToHours { get; set; }

        /// <summary>
        /// Gets or sets OpeningToMinutes.
        /// </summary>
        [JsonProperty("Opening_To_Minutes", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningToMinutes { get; set; }

        /// <summary>
        /// Gets or sets ToDay.
        /// </summary>
        [JsonProperty("To_Day", NullValueHandling = NullValueHandling.Ignore)]
        public string ToDay { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OpeningHour : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is OpeningHour other &&
                (this.ClosingFromHours == null && other.ClosingFromHours == null ||
                 this.ClosingFromHours?.Equals(other.ClosingFromHours) == true) &&
                (this.ClosingFromMinutes == null && other.ClosingFromMinutes == null ||
                 this.ClosingFromMinutes?.Equals(other.ClosingFromMinutes) == true) &&
                (this.ClosingToHours == null && other.ClosingToHours == null ||
                 this.ClosingToHours?.Equals(other.ClosingToHours) == true) &&
                (this.ClosingToMinutes == null && other.ClosingToMinutes == null ||
                 this.ClosingToMinutes?.Equals(other.ClosingToMinutes) == true) &&
                (this.FromDay == null && other.FromDay == null ||
                 this.FromDay?.Equals(other.FromDay) == true) &&
                (this.OpeningFromHours == null && other.OpeningFromHours == null ||
                 this.OpeningFromHours?.Equals(other.OpeningFromHours) == true) &&
                (this.OpeningFromMinutes == null && other.OpeningFromMinutes == null ||
                 this.OpeningFromMinutes?.Equals(other.OpeningFromMinutes) == true) &&
                (this.OpeningToHours == null && other.OpeningToHours == null ||
                 this.OpeningToHours?.Equals(other.OpeningToHours) == true) &&
                (this.OpeningToMinutes == null && other.OpeningToMinutes == null ||
                 this.OpeningToMinutes?.Equals(other.OpeningToMinutes) == true) &&
                (this.ToDay == null && other.ToDay == null ||
                 this.ToDay?.Equals(other.ToDay) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ClosingFromHours = {this.ClosingFromHours ?? "null"}");
            toStringOutput.Add($"ClosingFromMinutes = {this.ClosingFromMinutes ?? "null"}");
            toStringOutput.Add($"ClosingToHours = {this.ClosingToHours ?? "null"}");
            toStringOutput.Add($"ClosingToMinutes = {this.ClosingToMinutes ?? "null"}");
            toStringOutput.Add($"FromDay = {this.FromDay ?? "null"}");
            toStringOutput.Add($"OpeningFromHours = {this.OpeningFromHours ?? "null"}");
            toStringOutput.Add($"OpeningFromMinutes = {this.OpeningFromMinutes ?? "null"}");
            toStringOutput.Add($"OpeningToHours = {this.OpeningToHours ?? "null"}");
            toStringOutput.Add($"OpeningToMinutes = {this.OpeningToMinutes ?? "null"}");
            toStringOutput.Add($"ToDay = {this.ToDay ?? "null"}");
        }
    }
}