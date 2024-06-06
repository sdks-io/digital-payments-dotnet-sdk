// <copyright file="AroundLocationArray.cs" company="APIMatic">
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
    /// AroundLocationArray.
    /// </summary>
    public class AroundLocationArray
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AroundLocationArray"/> class.
        /// </summary>
        public AroundLocationArray()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AroundLocationArray"/> class.
        /// </summary>
        /// <param name="data">data.</param>
        public AroundLocationArray(
            List<Models.AroundLocationArrayDataItems> data)
        {
            this.Data = data;
        }

        /// <summary>
        /// An array of station objects
        /// </summary>
        [JsonProperty("data")]
        public List<Models.AroundLocationArrayDataItems> Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AroundLocationArray : ({string.Join(", ", toStringOutput)})";
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
            return obj is AroundLocationArray other &&                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : $"[{string.Join(", ", this.Data)} ]")}");
        }
    }
}