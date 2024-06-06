// <copyright file="FinaliseFuelingRequest.cs" company="APIMatic">
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
    /// FinaliseFuelingRequest.
    /// </summary>
    public class FinaliseFuelingRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinaliseFuelingRequest"/> class.
        /// </summary>
        public FinaliseFuelingRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinaliseFuelingRequest"/> class.
        /// </summary>
        /// <param name="siteName">siteName.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="volumeQuantity">volumeQuantity.</param>
        /// <param name="volumeUnit">volumeUnit.</param>
        /// <param name="finalPrice">finalPrice.</param>
        /// <param name="currency">currency.</param>
        /// <param name="status">status.</param>
        /// <param name="siteAddress">siteAddress.</param>
        /// <param name="originalPrice">originalPrice.</param>
        /// <param name="discount">discount.</param>
        /// <param name="payment">payment.</param>
        /// <param name="products">products.</param>
        /// <param name="mppTransactionId">mppTransactionId.</param>
        public FinaliseFuelingRequest(
            string siteName = null,
            long? timestamp = null,
            double? volumeQuantity = null,
            string volumeUnit = null,
            double? finalPrice = null,
            string currency = null,
            string status = null,
            string siteAddress = null,
            double? originalPrice = null,
            double? discount = null,
            Models.FinaliseFuelingRequestPayment payment = null,
            List<Models.FinaliseFuelingRequestProductsItems> products = null,
            string mppTransactionId = null)
        {
            this.SiteName = siteName;
            this.Timestamp = timestamp;
            this.VolumeQuantity = volumeQuantity;
            this.VolumeUnit = volumeUnit;
            this.FinalPrice = finalPrice;
            this.Currency = currency;
            this.Status = status;
            this.SiteAddress = siteAddress;
            this.OriginalPrice = originalPrice;
            this.Discount = discount;
            this.Payment = payment;
            this.Products = products;
            this.MppTransactionId = mppTransactionId;
        }

        /// <summary>
        /// Gets or sets SiteName.
        /// </summary>
        [JsonProperty("siteName", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets Timestamp.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets VolumeQuantity.
        /// </summary>
        [JsonProperty("volumeQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public double? VolumeQuantity { get; set; }

        /// <summary>
        /// Gets or sets VolumeUnit.
        /// </summary>
        [JsonProperty("volumeUnit", NullValueHandling = NullValueHandling.Ignore)]
        public string VolumeUnit { get; set; }

        /// <summary>
        /// Gets or sets FinalPrice.
        /// </summary>
        [JsonProperty("finalPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? FinalPrice { get; set; }

        /// <summary>
        /// Gets or sets Currency.
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets SiteAddress.
        /// </summary>
        [JsonProperty("siteAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteAddress { get; set; }

        /// <summary>
        /// Gets or sets OriginalPrice.
        /// </summary>
        [JsonProperty("originalPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? OriginalPrice { get; set; }

        /// <summary>
        /// Gets or sets Discount.
        /// </summary>
        [JsonProperty("discount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or sets Payment.
        /// </summary>
        [JsonProperty("payment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FinaliseFuelingRequestPayment Payment { get; set; }

        /// <summary>
        /// Gets or sets Products.
        /// </summary>
        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.FinaliseFuelingRequestProductsItems> Products { get; set; }

        /// <summary>
        /// Gets or sets MppTransactionId.
        /// </summary>
        [JsonProperty("mppTransactionId", NullValueHandling = NullValueHandling.Ignore)]
        public string MppTransactionId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FinaliseFuelingRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is FinaliseFuelingRequest other &&                ((this.SiteName == null && other.SiteName == null) || (this.SiteName?.Equals(other.SiteName) == true)) &&
                ((this.Timestamp == null && other.Timestamp == null) || (this.Timestamp?.Equals(other.Timestamp) == true)) &&
                ((this.VolumeQuantity == null && other.VolumeQuantity == null) || (this.VolumeQuantity?.Equals(other.VolumeQuantity) == true)) &&
                ((this.VolumeUnit == null && other.VolumeUnit == null) || (this.VolumeUnit?.Equals(other.VolumeUnit) == true)) &&
                ((this.FinalPrice == null && other.FinalPrice == null) || (this.FinalPrice?.Equals(other.FinalPrice) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.SiteAddress == null && other.SiteAddress == null) || (this.SiteAddress?.Equals(other.SiteAddress) == true)) &&
                ((this.OriginalPrice == null && other.OriginalPrice == null) || (this.OriginalPrice?.Equals(other.OriginalPrice) == true)) &&
                ((this.Discount == null && other.Discount == null) || (this.Discount?.Equals(other.Discount) == true)) &&
                ((this.Payment == null && other.Payment == null) || (this.Payment?.Equals(other.Payment) == true)) &&
                ((this.Products == null && other.Products == null) || (this.Products?.Equals(other.Products) == true)) &&
                ((this.MppTransactionId == null && other.MppTransactionId == null) || (this.MppTransactionId?.Equals(other.MppTransactionId) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SiteName = {(this.SiteName == null ? "null" : this.SiteName)}");
            toStringOutput.Add($"this.Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp.ToString())}");
            toStringOutput.Add($"this.VolumeQuantity = {(this.VolumeQuantity == null ? "null" : this.VolumeQuantity.ToString())}");
            toStringOutput.Add($"this.VolumeUnit = {(this.VolumeUnit == null ? "null" : this.VolumeUnit)}");
            toStringOutput.Add($"this.FinalPrice = {(this.FinalPrice == null ? "null" : this.FinalPrice.ToString())}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.SiteAddress = {(this.SiteAddress == null ? "null" : this.SiteAddress)}");
            toStringOutput.Add($"this.OriginalPrice = {(this.OriginalPrice == null ? "null" : this.OriginalPrice.ToString())}");
            toStringOutput.Add($"this.Discount = {(this.Discount == null ? "null" : this.Discount.ToString())}");
            toStringOutput.Add($"this.Payment = {(this.Payment == null ? "null" : this.Payment.ToString())}");
            toStringOutput.Add($"this.Products = {(this.Products == null ? "null" : $"[{string.Join(", ", this.Products)} ]")}");
            toStringOutput.Add($"this.MppTransactionId = {(this.MppTransactionId == null ? "null" : this.MppTransactionId)}");
        }
    }
}