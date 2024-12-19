// <copyright file="MobilePaymentRegistrationRequest.cs" company="APIMatic">
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
    /// MobilePaymentRegistrationRequest.
    /// </summary>
    public class MobilePaymentRegistrationRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobilePaymentRegistrationRequest"/> class.
        /// </summary>
        public MobilePaymentRegistrationRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MobilePaymentRegistrationRequest"/> class.
        /// </summary>
        /// <param name="referenceId">referenceId.</param>
        /// <param name="pan">pan.</param>
        /// <param name="panExpiry">panExpiry.</param>
        /// <param name="period">period.</param>
        /// <param name="accountId">AccountId.</param>
        /// <param name="payerId">PayerId.</param>
        /// <param name="colCoId">ColCoId.</param>
        /// <param name="collectingCompanies">CollectingCompanies.</param>
        public MobilePaymentRegistrationRequest(
            string referenceId,
            string pan,
            string panExpiry,
            int period,
            string accountId,
            string payerId,
            string colCoId,
            List<Models.CollectingCompany> collectingCompanies)
        {
            this.ReferenceId = referenceId;
            this.Pan = pan;
            this.PanExpiry = panExpiry;
            this.Period = period;
            this.AccountId = accountId;
            this.PayerId = payerId;
            this.ColCoId = colCoId;
            this.CollectingCompanies = collectingCompanies;
        }

        /// <summary>
        /// <![CDATA[
        /// Unique Reference ID the DPAN is registered to. The Reference ID has been implemented to accept normal alphanumeric characters plus the following ‘special characters’&colon;  dot, underscore and hyphen. The following characters are not acceptable&colon; , / @ !  &num; & * ()
        /// ]]>
        /// </summary>
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Original card PAN (generated on creation of Card (see Card Order Service))
        /// </summary>
        [JsonProperty("pan")]
        public string Pan { get; set; }

        /// <summary>
        /// Expiry Date associated with the PAN in format YYMM.
        /// </summary>
        [JsonProperty("panExpiry")]
        public string PanExpiry { get; set; }

        /// <summary>
        /// Specifies how many months the DPAN should be valid for. If not present, the Token Server determines the expiry date using its default algorithm. Note that the Token Server might not respect this value and use configured business rules to override the requested validity period
        /// </summary>
        [JsonProperty("period")]
        public int Period { get; set; }

        /// <summary>
        /// In Shell, a Payer can have several accounts (representing company branches, divisions or generally different cost-centers that a customer wants to group cards on). You can specify this property or the AccountNumber.
        /// </summary>
        [JsonProperty("AccountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// The Payer Id, or the Customer Id of the Payment Customer. In Shell, a Payer is a customer belonging to a specific market geography. A Payer can have several Accounts; each account can then have different groups of cards.
        /// </summary>
        [JsonProperty("PayerId")]
        public string PayerId { get; set; }

        /// <summary>
        /// The ID of the Collecting Company (in GFN), also known as Shell Code of the selected payer. This property is mandatory if the ColCoCode code is not passed
        /// </summary>
        [JsonProperty("ColCoId")]
        public string ColCoId { get; set; }

        /// <summary>
        /// Array of Colco Ids
        /// </summary>
        [JsonProperty("CollectingCompanies")]
        public List<Models.CollectingCompany> CollectingCompanies { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"MobilePaymentRegistrationRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is MobilePaymentRegistrationRequest other &&
                (this.ReferenceId == null && other.ReferenceId == null ||
                 this.ReferenceId?.Equals(other.ReferenceId) == true) &&
                (this.Pan == null && other.Pan == null ||
                 this.Pan?.Equals(other.Pan) == true) &&
                (this.PanExpiry == null && other.PanExpiry == null ||
                 this.PanExpiry?.Equals(other.PanExpiry) == true) &&
                (this.Period.Equals(other.Period)) &&
                (this.AccountId == null && other.AccountId == null ||
                 this.AccountId?.Equals(other.AccountId) == true) &&
                (this.PayerId == null && other.PayerId == null ||
                 this.PayerId?.Equals(other.PayerId) == true) &&
                (this.ColCoId == null && other.ColCoId == null ||
                 this.ColCoId?.Equals(other.ColCoId) == true) &&
                (this.CollectingCompanies == null && other.CollectingCompanies == null ||
                 this.CollectingCompanies?.Equals(other.CollectingCompanies) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add($"Pan = {this.Pan ?? "null"}");
            toStringOutput.Add($"PanExpiry = {this.PanExpiry ?? "null"}");
            toStringOutput.Add($"Period = {this.Period}");
            toStringOutput.Add($"AccountId = {this.AccountId ?? "null"}");
            toStringOutput.Add($"PayerId = {this.PayerId ?? "null"}");
            toStringOutput.Add($"ColCoId = {this.ColCoId ?? "null"}");
            toStringOutput.Add($"CollectingCompanies = {(this.CollectingCompanies == null ? "null" : $"[{string.Join(", ", this.CollectingCompanies)} ]")}");
        }
    }
}