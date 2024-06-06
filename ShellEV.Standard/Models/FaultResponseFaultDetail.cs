// <copyright file="FaultResponseFaultDetail.cs" company="APIMatic">
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
    /// FaultResponseFaultDetail.
    /// </summary>
    public class FaultResponseFaultDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FaultResponseFaultDetail"/> class.
        /// </summary>
        public FaultResponseFaultDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FaultResponseFaultDetail"/> class.
        /// </summary>
        /// <param name="errorcode">errorcode.</param>
        public FaultResponseFaultDetail(
            string errorcode = null)
        {
            this.Errorcode = errorcode;
        }

        /// <summary>
        /// The error code.
        /// </summary>
        [JsonProperty("errorcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Errorcode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FaultResponseFaultDetail : ({string.Join(", ", toStringOutput)})";
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
            return obj is FaultResponseFaultDetail other &&                ((this.Errorcode == null && other.Errorcode == null) || (this.Errorcode?.Equals(other.Errorcode) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errorcode = {(this.Errorcode == null ? "null" : this.Errorcode)}");
        }
    }
}