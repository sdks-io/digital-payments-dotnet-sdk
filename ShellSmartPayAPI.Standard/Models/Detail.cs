// <copyright file="Detail.cs" company="APIMatic">
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
    /// Detail.
    /// </summary>
    public class Detail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Detail"/> class.
        /// </summary>
        public Detail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Detail"/> class.
        /// </summary>
        /// <param name="errorcode">errorcode.</param>
        public Detail(
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
            return $"Detail : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Detail other &&
                (this.Errorcode == null && other.Errorcode == null ||
                 this.Errorcode?.Equals(other.Errorcode) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errorcode = {this.Errorcode ?? "null"}");
        }
    }
}