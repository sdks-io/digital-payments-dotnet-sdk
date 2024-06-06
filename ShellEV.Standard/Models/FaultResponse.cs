// <copyright file="FaultResponse.cs" company="APIMatic">
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
    /// FaultResponse.
    /// </summary>
    public class FaultResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaultResponse"/> class.
        /// </summary>
        public FaultResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaultResponse"/> class.
        /// </summary>
        /// <param name="fault">fault.</param>
        public FaultResponse(
            Models.FaultResponseFault fault = null)
        {
            this.Fault = fault;
        }

        /// <summary>
        /// Gets or sets Fault.
        /// </summary>
        [JsonProperty("fault", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FaultResponseFault Fault { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FaultResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is FaultResponse other &&                ((this.Fault == null && other.Fault == null) || (this.Fault?.Equals(other.Fault) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Fault = {(this.Fault == null ? "null" : this.Fault.ToString())}");
        }
    }
}