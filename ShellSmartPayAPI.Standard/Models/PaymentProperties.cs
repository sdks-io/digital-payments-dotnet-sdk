// <copyright file="PaymentProperties.cs" company="APIMatic">
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
    /// PaymentProperties.
    /// </summary>
    public class PaymentProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentProperties"/> class.
        /// </summary>
        public PaymentProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentProperties"/> class.
        /// </summary>
        /// <param name="cardIdentifier">cardIdentifier.</param>
        /// <param name="paymentType">paymentType.</param>
        /// <param name="clientMetadataId">clientMetadataId.</param>
        /// <param name="token">token.</param>
        /// <param name="identifier">identifier.</param>
        /// <param name="network">network.</param>
        /// <param name="odometer">odometer.</param>
        /// <param name="fleetId">fleetId.</param>
        /// <param name="externalRefId">externalRefId.</param>
        public PaymentProperties(
            string cardIdentifier,
            string paymentType = null,
            string clientMetadataId = null,
            string token = null,
            string identifier = null,
            string network = null,
            string odometer = null,
            string fleetId = null,
            string externalRefId = null)
        {
            this.PaymentType = paymentType;
            this.ClientMetadataId = clientMetadataId;
            this.Token = token;
            this.Identifier = identifier;
            this.Network = network;
            this.CardIdentifier = cardIdentifier;
            this.Odometer = odometer;
            this.FleetId = fleetId;
            this.ExternalRefId = externalRefId;
        }

        /// <summary>
        /// The type of payment (e.g. Credit Card, Debit Card)
        /// </summary>
        [JsonProperty("paymentType", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentType { get; set; }

        /// <summary>
        /// This is only used for PayPal. During the creation of the user’s profile an ID (clientMetadataId) will have been created by PayPal and stored by Shell. Thus, when PayPal payments are made this ID must be included in order for the payment to be processed
        /// </summary>
        [JsonProperty("clientMetadataId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientMetadataId { get; set; }

        /// <summary>
        /// This is only used for ApplePay and AndroidPay. Users using either of these payment methods use device biometrics to authenticate themselves against their respective payment method/provider (e.g. retina, fingerprint). Successful authentication will result in Apple/Android issuing a Payment Token which should be specified here
        /// </summary>
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        /// <summary>
        /// This is the payment identifier and it is only used for ApplePay and AndroidPay.
        /// </summary>
        [JsonProperty("identifier", NullValueHandling = NullValueHandling.Ignore)]
        public string Identifier { get; set; }

        /// <summary>
        /// This is the payment network (e.g. Visa, Mastercard) and it is only used for ApplePay and AndroidPay.
        /// </summary>
        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public string Network { get; set; }

        /// <summary>
        /// This is only relevant for transactions made by B2B customers using the Shell Card payment method. The ‘cardIdentifier’ is the unique identifier provided by Commercial Fleet and shared with the Shell mobile payments platform. This reference ID is used in interactions with the Commercial Fleet application to retrieve the fueling token - use the cardIdentifier when requesting a DPAN.
        /// </summary>
        [JsonProperty("cardIdentifier")]
        public string CardIdentifier { get; set; }

        /// <summary>
        /// This is only relevant for transactions made by B2B customers using a Shell Card payment method. During set up of the user’s Shell Card it’s possible to configure the card such that users are forced to provide an odometer reading before a Sale can begin processing. This field must be filled if the B2B user’s Shell Card has been configured this way but will be left blank in all other cases.
        /// </summary>
        [JsonProperty("odometer", NullValueHandling = NullValueHandling.Ignore)]
        public string Odometer { get; set; }

        /// <summary>
        /// Only relevant if Customer attempting to pay with B2B Shell Card. Customers attempting to pay with a B2B Shell Card may have to specify their Fleet ID as an extra authorisation/security step. Shell Card configuration will determine whether or not Fleet ID needs to be provided. Please note this field is a 6 character numeric field.
        /// </summary>
        [JsonProperty("fleetId", NullValueHandling = NullValueHandling.Ignore)]
        public string FleetId { get; set; }

        /// <summary>
        /// This is only used for transactions made by B2B customers using the Shell Card payment method.
        ///  In this scenario the expectation is that :\ a B2B entity has been successfully created that includes the external party’s reference for the entity (e.g. Contract Number, VRN, customer email); a new Shell Card (SFC) has been successfully created; and Shell Card and B2B Entity have been linked.
        /// 
        ///  externalRefId refers to the 3rd Parties External Reference for the B2B entity and will therefore be used to verify the Customer and SFC before attempting to process a payment using the SFC card
        /// </summary>
        [JsonProperty("externalRefId", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalRefId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PaymentProperties : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PaymentProperties other &&
                (this.PaymentType == null && other.PaymentType == null ||
                 this.PaymentType?.Equals(other.PaymentType) == true) &&
                (this.ClientMetadataId == null && other.ClientMetadataId == null ||
                 this.ClientMetadataId?.Equals(other.ClientMetadataId) == true) &&
                (this.Token == null && other.Token == null ||
                 this.Token?.Equals(other.Token) == true) &&
                (this.Identifier == null && other.Identifier == null ||
                 this.Identifier?.Equals(other.Identifier) == true) &&
                (this.Network == null && other.Network == null ||
                 this.Network?.Equals(other.Network) == true) &&
                (this.CardIdentifier == null && other.CardIdentifier == null ||
                 this.CardIdentifier?.Equals(other.CardIdentifier) == true) &&
                (this.Odometer == null && other.Odometer == null ||
                 this.Odometer?.Equals(other.Odometer) == true) &&
                (this.FleetId == null && other.FleetId == null ||
                 this.FleetId?.Equals(other.FleetId) == true) &&
                (this.ExternalRefId == null && other.ExternalRefId == null ||
                 this.ExternalRefId?.Equals(other.ExternalRefId) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"PaymentType = {this.PaymentType ?? "null"}");
            toStringOutput.Add($"ClientMetadataId = {this.ClientMetadataId ?? "null"}");
            toStringOutput.Add($"Token = {this.Token ?? "null"}");
            toStringOutput.Add($"Identifier = {this.Identifier ?? "null"}");
            toStringOutput.Add($"Network = {this.Network ?? "null"}");
            toStringOutput.Add($"CardIdentifier = {this.CardIdentifier ?? "null"}");
            toStringOutput.Add($"Odometer = {this.Odometer ?? "null"}");
            toStringOutput.Add($"FleetId = {this.FleetId ?? "null"}");
            toStringOutput.Add($"ExternalRefId = {this.ExternalRefId ?? "null"}");
        }
    }
}