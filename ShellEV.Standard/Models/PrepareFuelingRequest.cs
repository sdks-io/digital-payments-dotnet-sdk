// <copyright file="PrepareFuelingRequest.cs" company="APIMatic">
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
    /// PrepareFuelingRequest.
    /// </summary>
    public class PrepareFuelingRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareFuelingRequest"/> class.
        /// </summary>
        public PrepareFuelingRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrepareFuelingRequest"/> class.
        /// </summary>
        /// <param name="latitude">latitude.</param>
        /// <param name="longitude">longitude.</param>
        /// <param name="stationId">stationId.</param>
        /// <param name="pumpId">pumpId.</param>
        /// <param name="sourceApplication">sourceApplication.</param>
        /// <param name="paymentDetails">paymentDetails.</param>
        /// <param name="maximumFuelingAmount">maximumFuelingAmount.</param>
        /// <param name="loyaltyDetails">loyaltyDetails.</param>
        /// <param name="deviceType">deviceType.</param>
        /// <param name="deviceDetails">deviceDetails.</param>
        public PrepareFuelingRequest(
            double latitude,
            double longitude,
            string stationId,
            string pumpId,
            string sourceApplication,
            List<Models.PaymentDetailsItems> paymentDetails,
            double? maximumFuelingAmount = null,
            List<Models.LoyaltyDetails> loyaltyDetails = null,
            string deviceType = null,
            List<Models.PrepareFuelingRequestDeviceDetailsItems> deviceDetails = null)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.MaximumFuelingAmount = maximumFuelingAmount;
            this.StationId = stationId;
            this.PumpId = pumpId;
            this.LoyaltyDetails = loyaltyDetails;
            this.SourceApplication = sourceApplication;
            this.DeviceType = deviceType;
            this.PaymentDetails = paymentDetails;
            this.DeviceDetails = deviceDetails;
        }

        /// <summary>
        /// The user’s current latitude
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// The user’s current longitude
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// The maximum fuelling amount that can be purchased. If the prepare fuelling is successful and the Customer starts fuelling their car, the pump will cut off once this threshold is reached. For B2B customers a maximum ceiling is set against their Shell Card. As a result, this can be left blank for B2B customers. If a value is provided it cannot be zero or lower and values that exceed ceiling will be ignored.
        /// </summary>
        [JsonProperty("maximumFuelingAmount", NullValueHandling = NullValueHandling.Ignore)]
        public double? MaximumFuelingAmount { get; set; }

        /// <summary>
        /// Expectation is that a user has to be located at a Shell petrol station in order to make this call. A user is recognised as being located at a Shell station if the user’s current location (as determined by GPS) is within 300 meters of a Shell station. Expectation is that requester will have established the Shell petrol station the user is located at prior to making this call by calling Station Locator APIs. The API will use stationId and siteCountry/GPS to verify the user is The user’s current latitude genuinely located at the specified Station. ‘mpp_station_id’ of the Station Locator API should be used. Leading ‘0’ should be dropped and only last four digits, should be used. E.G. for ‘00123’, only ‘0123’ should be used and for ‘04567’ only ‘4567’ should be used.
        /// </summary>
        [JsonProperty("stationId")]
        public string StationId { get; set; }

        /// <summary>
        /// A two digit numeric number of the pump as marked on the forecourt (e.g. pump number 12)
        /// </summary>
        [JsonProperty("pumpId")]
        public string PumpId { get; set; }

        /// <summary>
        /// Object containing Loyalty details
        /// </summary>
        [JsonProperty("loyaltyDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.LoyaltyDetails> LoyaltyDetails { get; set; }

        /// <summary>
        /// The ID of the source application making this call. Each 3rd Party will be issued with its own sourceApp ID that must be specified correctly here
        ///  *   3rdParty_App_Archetype
        /// </summary>
        [JsonProperty("sourceApplication")]
        public string SourceApplication { get; set; }

        /// <summary>
        /// The type of device making this call. Permitted values for deviceType:
        ///  *  car
        ///  *  phone
        /// </summary>
        [JsonProperty("deviceType", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceType { get; set; }

        /// <summary>
        /// Object containing Payment details
        /// </summary>
        [JsonProperty("paymentDetails")]
        public List<Models.PaymentDetailsItems> PaymentDetails { get; set; }

        /// <summary>
        /// Object containing device details
        /// </summary>
        [JsonProperty("deviceDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PrepareFuelingRequestDeviceDetailsItems> DeviceDetails { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PrepareFuelingRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is PrepareFuelingRequest other &&                this.Latitude.Equals(other.Latitude) &&
                this.Longitude.Equals(other.Longitude) &&
                ((this.MaximumFuelingAmount == null && other.MaximumFuelingAmount == null) || (this.MaximumFuelingAmount?.Equals(other.MaximumFuelingAmount) == true)) &&
                ((this.StationId == null && other.StationId == null) || (this.StationId?.Equals(other.StationId) == true)) &&
                ((this.PumpId == null && other.PumpId == null) || (this.PumpId?.Equals(other.PumpId) == true)) &&
                ((this.LoyaltyDetails == null && other.LoyaltyDetails == null) || (this.LoyaltyDetails?.Equals(other.LoyaltyDetails) == true)) &&
                ((this.SourceApplication == null && other.SourceApplication == null) || (this.SourceApplication?.Equals(other.SourceApplication) == true)) &&
                ((this.DeviceType == null && other.DeviceType == null) || (this.DeviceType?.Equals(other.DeviceType) == true)) &&
                ((this.PaymentDetails == null && other.PaymentDetails == null) || (this.PaymentDetails?.Equals(other.PaymentDetails) == true)) &&
                ((this.DeviceDetails == null && other.DeviceDetails == null) || (this.DeviceDetails?.Equals(other.DeviceDetails) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Latitude = {this.Latitude}");
            toStringOutput.Add($"this.Longitude = {this.Longitude}");
            toStringOutput.Add($"this.MaximumFuelingAmount = {(this.MaximumFuelingAmount == null ? "null" : this.MaximumFuelingAmount.ToString())}");
            toStringOutput.Add($"this.StationId = {(this.StationId == null ? "null" : this.StationId)}");
            toStringOutput.Add($"this.PumpId = {(this.PumpId == null ? "null" : this.PumpId)}");
            toStringOutput.Add($"this.LoyaltyDetails = {(this.LoyaltyDetails == null ? "null" : $"[{string.Join(", ", this.LoyaltyDetails)} ]")}");
            toStringOutput.Add($"this.SourceApplication = {(this.SourceApplication == null ? "null" : this.SourceApplication)}");
            toStringOutput.Add($"this.DeviceType = {(this.DeviceType == null ? "null" : this.DeviceType)}");
            toStringOutput.Add($"this.PaymentDetails = {(this.PaymentDetails == null ? "null" : $"[{string.Join(", ", this.PaymentDetails)} ]")}");
            toStringOutput.Add($"this.DeviceDetails = {(this.DeviceDetails == null ? "null" : $"[{string.Join(", ", this.DeviceDetails)} ]")}");
        }
    }
}