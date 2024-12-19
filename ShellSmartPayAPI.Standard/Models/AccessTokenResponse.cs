// <copyright file="AccessTokenResponse.cs" company="APIMatic">
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
    /// AccessTokenResponse.
    /// </summary>
    public class AccessTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenResponse"/> class.
        /// </summary>
        public AccessTokenResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        /// <param name="expiresIn">expires_in.</param>
        /// <param name="tokenType">token_type.</param>
        public AccessTokenResponse(
            string accessToken = null,
            string expiresIn = null,
            string tokenType = "Bearer")
        {
            this.AccessToken = accessToken;
            this.ExpiresIn = expiresIn;
            this.TokenType = tokenType;
        }

        /// <summary>
        /// It is the token used for the requests that required an authenticated user. This will be used for all the callback URLs.
        /// </summary>
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        /// <summary>
        /// validity of the access token in seconds
        /// </summary>
        [JsonProperty("expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Type of token provided
        /// </summary>
        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"AccessTokenResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is AccessTokenResponse other &&
                (this.AccessToken == null && other.AccessToken == null ||
                 this.AccessToken?.Equals(other.AccessToken) == true) &&
                (this.ExpiresIn == null && other.ExpiresIn == null ||
                 this.ExpiresIn?.Equals(other.ExpiresIn) == true) &&
                (this.TokenType == null && other.TokenType == null ||
                 this.TokenType?.Equals(other.TokenType) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AccessToken = {this.AccessToken ?? "null"}");
            toStringOutput.Add($"ExpiresIn = {this.ExpiresIn ?? "null"}");
            toStringOutput.Add($"TokenType = {this.TokenType ?? "null"}");
        }
    }
}