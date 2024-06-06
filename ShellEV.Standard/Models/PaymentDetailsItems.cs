// <copyright file="PaymentDetailsItems.cs" company="APIMatic">
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
    /// PaymentDetailsItems.
    /// </summary>
    public class PaymentDetailsItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDetailsItems"/> class.
        /// </summary>
        public PaymentDetailsItems()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDetailsItems"/> class.
        /// </summary>
        /// <param name="paymentMethodId">paymentMethodId.</param>
        /// <param name="paymentProperties">paymentProperties.</param>
        /// <param name="paymentCategory">paymentCategory.</param>
        public PaymentDetailsItems(
            string paymentMethodId,
            Models.PaymentProperties paymentProperties,
            string paymentCategory = null)
        {
            this.PaymentCategory = paymentCategory;
            this.PaymentMethodId = paymentMethodId;
            this.PaymentProperties = paymentProperties;
        }

        /// <summary>
        /// The type of commercial transaction. Permitted value\:
        ///  *  B2B
        /// </summary>
        [JsonProperty("paymentCategory", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentCategory { get; set; }

        /// <summary>
        /// The payment method used to make the transaction. Possible values include:
        ///   *  euroShell
        /// </summary>
        [JsonProperty("paymentMethodId")]
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Object containing Payment Property details Please note:
        ///    All the attributes are optional as they serve all payment methods (i.e. different payment methods require different fields to be filled/mandated). As a result, some of these fields will be mandatory depending on the selected payment method and the API will return an error if they are not completed
        /// </summary>
        [JsonProperty("paymentProperties")]
        public Models.PaymentProperties PaymentProperties { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentDetailsItems : ({string.Join(", ", toStringOutput)})";
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
            return obj is PaymentDetailsItems other &&                ((this.PaymentCategory == null && other.PaymentCategory == null) || (this.PaymentCategory?.Equals(other.PaymentCategory) == true)) &&
                ((this.PaymentMethodId == null && other.PaymentMethodId == null) || (this.PaymentMethodId?.Equals(other.PaymentMethodId) == true)) &&
                ((this.PaymentProperties == null && other.PaymentProperties == null) || (this.PaymentProperties?.Equals(other.PaymentProperties) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentCategory = {(this.PaymentCategory == null ? "null" : this.PaymentCategory)}");
            toStringOutput.Add($"this.PaymentMethodId = {(this.PaymentMethodId == null ? "null" : this.PaymentMethodId)}");
            toStringOutput.Add($"this.PaymentProperties = {(this.PaymentProperties == null ? "null" : this.PaymentProperties.ToString())}");
        }
    }
}