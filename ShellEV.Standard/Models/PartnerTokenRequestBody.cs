// <copyright file="PartnerTokenRequestBody.cs" company="APIMatic">
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
    /// PartnerTokenRequestBody.
    /// </summary>
    public class PartnerTokenRequestBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerTokenRequestBody"/> class.
        /// </summary>
        public PartnerTokenRequestBody()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerTokenRequestBody"/> class.
        /// </summary>
        /// <param name="grantType">grant_type.</param>
        /// <param name="clientId">client_id.</param>
        /// <param name="clientSecret">client_secret.</param>
        public PartnerTokenRequestBody(
            string grantType,
            string clientId,
            string clientSecret)
        {
            this.GrantType = grantType;
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
        }

        /// <summary>
        /// In OAuth 2.0, the term grant typee refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow.
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        /// <summary>
        /// After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PartnerTokenRequestBody : ({string.Join(", ", toStringOutput)})";
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
            return obj is PartnerTokenRequestBody other &&                ((this.GrantType == null && other.GrantType == null) || (this.GrantType?.Equals(other.GrantType) == true)) &&
                ((this.ClientId == null && other.ClientId == null) || (this.ClientId?.Equals(other.ClientId) == true)) &&
                ((this.ClientSecret == null && other.ClientSecret == null) || (this.ClientSecret?.Equals(other.ClientSecret) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.GrantType = {(this.GrantType == null ? "null" : this.GrantType)}");
            toStringOutput.Add($"this.ClientId = {(this.ClientId == null ? "null" : this.ClientId)}");
            toStringOutput.Add($"this.ClientSecret = {(this.ClientSecret == null ? "null" : this.ClientSecret)}");
        }
    }
}