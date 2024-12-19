// <copyright file="Fault.cs" company="APIMatic">
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
    /// Fault.
    /// </summary>
    public class Fault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fault"/> class.
        /// </summary>
        public Fault()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fault"/> class.
        /// </summary>
        /// <param name="faultstring">faultstring.</param>
        /// <param name="detail">detail.</param>
        public Fault(
            string faultstring = null,
            Models.Detail detail = null)
        {
            this.Faultstring = faultstring;
            this.Detail = detail;
        }

        /// <summary>
        /// The description of the error.
        /// </summary>
        [JsonProperty("faultstring", NullValueHandling = NullValueHandling.Ignore)]
        public string Faultstring { get; set; }

        /// <summary>
        /// Gets or sets Detail.
        /// </summary>
        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Detail Detail { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Fault : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Fault other &&
                (this.Faultstring == null && other.Faultstring == null ||
                 this.Faultstring?.Equals(other.Faultstring) == true) &&
                (this.Detail == null && other.Detail == null ||
                 this.Detail?.Equals(other.Detail) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Faultstring = {this.Faultstring ?? "null"}");
            toStringOutput.Add($"Detail = {(this.Detail == null ? "null" : this.Detail.ToString())}");
        }
    }
}