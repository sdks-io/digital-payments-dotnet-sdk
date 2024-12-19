// <copyright file="Product.cs" company="APIMatic">
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
    /// Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">productId.</param>
        /// <param name="productName">productName.</param>
        /// <param name="unitPrice">unitPrice.</param>
        public Product(
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
            return $"Product : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Product other &&
                (this.ProductId == null && other.ProductId == null ||
                 this.ProductId?.Equals(other.ProductId) == true) &&
                (this.ProductName == null && other.ProductName == null ||
                 this.ProductName?.Equals(other.ProductName) == true) &&
                (this.UnitPrice == null && other.UnitPrice == null ||
                 this.UnitPrice?.Equals(other.UnitPrice) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ProductId = {this.ProductId ?? "null"}");
            toStringOutput.Add($"ProductName = {this.ProductName ?? "null"}");
            toStringOutput.Add($"UnitPrice = {(this.UnitPrice == null ? "null" : this.UnitPrice.ToString())}");
        }
    }
}