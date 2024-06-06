// <copyright file="CollectingCompany.cs" company="APIMatic">
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
    /// CollectingCompany.
    /// </summary>
    public class CollectingCompany
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectingCompany"/> class.
        /// </summary>
        public CollectingCompany()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectingCompany"/> class.
        /// </summary>
        /// <param name="colCoId">ColCoId.</param>
        public CollectingCompany(
            string colCoId)
        {
            this.ColCoId = colCoId;
        }

        /// <summary>
        /// The ID of the Collecting Company (in GFN), also known as Shell Code of the selected payer. This property is mandatory if the ColCoCode code is not passed
        /// </summary>
        [JsonProperty("ColCoId")]
        public string ColCoId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CollectingCompany : ({string.Join(", ", toStringOutput)})";
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
            return obj is CollectingCompany other &&                ((this.ColCoId == null && other.ColCoId == null) || (this.ColCoId?.Equals(other.ColCoId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ColCoId = {(this.ColCoId == null ? "null" : this.ColCoId)}");
        }
    }
}