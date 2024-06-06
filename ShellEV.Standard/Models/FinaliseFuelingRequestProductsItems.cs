// <copyright file="FinaliseFuelingRequestProductsItems.cs" company="APIMatic">
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
    /// FinaliseFuelingRequestProductsItems.
    /// </summary>
    public class FinaliseFuelingRequestProductsItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinaliseFuelingRequestProductsItems"/> class.
        /// </summary>
        public FinaliseFuelingRequestProductsItems()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinaliseFuelingRequestProductsItems"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="productName">productName.</param>
        /// <param name="unitPrice">unitPrice.</param>
        public FinaliseFuelingRequestProductsItems(
            string productId = null,
            string productName = null,
            double? unitPrice = null)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
        }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets ProductName.
        /// </summary>
        [JsonProperty("productName", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets UnitPrice.
        /// </summary>
        [JsonProperty("unitPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? UnitPrice { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FinaliseFuelingRequestProductsItems : ({string.Join(", ", toStringOutput)})";
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
            return obj is FinaliseFuelingRequestProductsItems other &&                ((this.ProductId == null && other.ProductId == null) || (this.ProductId?.Equals(other.ProductId) == true)) &&
                ((this.ProductName == null && other.ProductName == null) || (this.ProductName?.Equals(other.ProductName) == true)) &&
                ((this.UnitPrice == null && other.UnitPrice == null) || (this.UnitPrice?.Equals(other.UnitPrice) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ProductId = {(this.ProductId == null ? "null" : this.ProductId)}");
            toStringOutput.Add($"this.ProductName = {(this.ProductName == null ? "null" : this.ProductName)}");
            toStringOutput.Add($"this.UnitPrice = {(this.UnitPrice == null ? "null" : this.UnitPrice.ToString())}");
        }
    }
}