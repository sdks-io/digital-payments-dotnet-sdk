// <copyright file="PrepareFuelingResponse.cs" company="APIMatic">
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
    /// PrepareFuelingResponse.
    /// </summary>
    public class PrepareFuelingResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareFuelingResponse"/> class.
        /// </summary>
        public PrepareFuelingResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareFuelingResponse"/> class.
        /// </summary>
        /// <param name="mppTransactionId">mppTransactionId.</param>
        /// <param name="products">products.</param>
        public PrepareFuelingResponse(
            string mppTransactionId,
            List<string> products = null)
        {
            this.MppTransactionId = mppTransactionId;
            this.Products = products;
        }

        /// <summary>
        /// The unique identifier of the Order. NB at this stage the Customer hasn’t actually bought anything so there’s no formal transaction associated with the Order. A transaction is not processed until refuelling has been completed successfully and will be triggered by returning the nozzle to the pump.
        /// </summary>
        [JsonProperty("mppTransactionId")]
        public string MppTransactionId { get; set; }

        /// <summary>
        /// An array of Strings that contain the list of products that the user can purchase at the specified Station/Pump. The text is localized based on the country.
        /// </summary>
        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Products { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PrepareFuelingResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is PrepareFuelingResponse other &&                ((this.MppTransactionId == null && other.MppTransactionId == null) || (this.MppTransactionId?.Equals(other.MppTransactionId) == true)) &&
                ((this.Products == null && other.Products == null) || (this.Products?.Equals(other.Products) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MppTransactionId = {(this.MppTransactionId == null ? "null" : this.MppTransactionId)}");
            toStringOutput.Add($"this.Products = {(this.Products == null ? "null" : $"[{string.Join(", ", this.Products)} ]")}");
        }
    }
}