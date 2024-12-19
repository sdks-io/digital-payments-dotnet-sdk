// <copyright file="DeviceDetail.cs" company="APIMatic">
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
    /// DeviceDetail.
    /// </summary>
    public class DeviceDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDetail"/> class.
        /// </summary>
        public DeviceDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDetail"/> class.
        /// </summary>
        /// <param name="deviceId">deviceId.</param>
        /// <param name="model">model.</param>
        /// <param name="osVersion">osVersion.</param>
        /// <param name="otherDeviceInformation">otherDeviceInformation.</param>
        public DeviceDetail(
            string deviceId = null,
            string model = null,
            string osVersion = null,
            string otherDeviceInformation = null)
        {
            this.DeviceId = deviceId;
            this.Model = model;
            this.OsVersion = osVersion;
            this.OtherDeviceInformation = otherDeviceInformation;
        }

        /// <summary>
        /// This is the mobile device’s unique ID (Vendor ID for iOS vs. Android ID for Android). This is only used for transactions made via the Shell Mobile App and will therefore be mandatory for requests originating from Shell’s mobile app but can be ignored by all other parties.
        /// </summary>
        [JsonProperty("deviceId", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; set; }

        /// <summary>
        /// This is the mobile device’s model (machine name/systemInfo for iOS vs. Build.MODEL for Android).  This is only used for transactions made via the Shell Mobile App and will therefore be mandatory for requests originating from Shell’s mobile app but can be ignored by all other parties.
        /// </summary>
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        /// <summary>
        /// This is the mobile device’s OS Version. This is only used for transactions made via the Shell Mobile App and will therefore be mandatory for requests originating from Shell’s mobile app but can be ignored by all other parties.
        /// </summary>
        [JsonProperty("osVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string OsVersion { get; set; }

        /// <summary>
        /// This is only used for transactions made via Android versions of the Shell Mobile App and will therefore be mandatory for requests originating from Shell’s Android mobile app but can be ignored by all other devices and/or parties.
        /// This field is used to capture the Shell App build that was used to make this call.
        /// </summary>
        [JsonProperty("otherDeviceInformation", NullValueHandling = NullValueHandling.Ignore)]
        public string OtherDeviceInformation { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DeviceDetail : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is DeviceDetail other &&
                (this.DeviceId == null && other.DeviceId == null ||
                 this.DeviceId?.Equals(other.DeviceId) == true) &&
                (this.Model == null && other.Model == null ||
                 this.Model?.Equals(other.Model) == true) &&
                (this.OsVersion == null && other.OsVersion == null ||
                 this.OsVersion?.Equals(other.OsVersion) == true) &&
                (this.OtherDeviceInformation == null && other.OtherDeviceInformation == null ||
                 this.OtherDeviceInformation?.Equals(other.OtherDeviceInformation) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"DeviceId = {this.DeviceId ?? "null"}");
            toStringOutput.Add($"Model = {this.Model ?? "null"}");
            toStringOutput.Add($"OsVersion = {this.OsVersion ?? "null"}");
            toStringOutput.Add($"OtherDeviceInformation = {this.OtherDeviceInformation ?? "null"}");
        }
    }
}