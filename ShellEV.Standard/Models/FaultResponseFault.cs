// <copyright file="FaultResponseFault.cs" company="APIMatic">
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
    /// FaultResponseFault.
    /// </summary>
    public class FaultResponseFault
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaultResponseFault"/> class.
        /// </summary>
        public FaultResponseFault()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaultResponseFault"/> class.
        /// </summary>
        /// <param name="faultstring">faultstring.</param>
        /// <param name="detail">detail.</param>
        public FaultResponseFault(
            string faultstring = null,
            Models.FaultResponseFaultDetail detail = null)
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
        public Models.FaultResponseFaultDetail Detail { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FaultResponseFault : ({string.Join(", ", toStringOutput)})";
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
            return obj is FaultResponseFault other &&                ((this.Faultstring == null && other.Faultstring == null) || (this.Faultstring?.Equals(other.Faultstring) == true)) &&
                ((this.Detail == null && other.Detail == null) || (this.Detail?.Equals(other.Detail) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Faultstring = {(this.Faultstring == null ? "null" : this.Faultstring)}");
            toStringOutput.Add($"this.Detail = {(this.Detail == null ? "null" : this.Detail.ToString())}");
        }
    }
}