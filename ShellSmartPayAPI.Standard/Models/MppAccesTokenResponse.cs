// <copyright file="MppAccesTokenResponse.cs" company="APIMatic">
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
    /// MppAccesTokenResponse.
    /// </summary>
    public class MppAccesTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MppAccesTokenResponse"/> class.
        /// </summary>
        public MppAccesTokenResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MppAccesTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        /// <param name="tokenType">token_type.</param>
        /// <param name="expiresIn">expires_in.</param>
        /// <param name="scope">scope.</param>
        public MppAccesTokenResponse(
            string accessToken = null,
            string tokenType = "bearer",
            long? expiresIn = null,
            string scope = "basic openid")
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.ExpiresIn = expiresIn;
            this.Scope = scope;
        }

        /// <summary>
        /// It is the token used in the requests that required to authenticate an user.
        /// </summary>
        [JsonProperty("access_token", NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        /// <summary>
        /// type of token provided
        /// </summary>
        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        /// <summary>
        /// validity of the access token in seconds
        /// </summary>
        [JsonProperty("expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExpiresIn { get; set; }

        /// <summary>
        /// scope for the authentication protocol
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"MppAccesTokenResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is MppAccesTokenResponse other &&
                (this.AccessToken == null && other.AccessToken == null ||
                 this.AccessToken?.Equals(other.AccessToken) == true) &&
                (this.TokenType == null && other.TokenType == null ||
                 this.TokenType?.Equals(other.TokenType) == true) &&
                (this.ExpiresIn == null && other.ExpiresIn == null ||
                 this.ExpiresIn?.Equals(other.ExpiresIn) == true) &&
                (this.Scope == null && other.Scope == null ||
                 this.Scope?.Equals(other.Scope) == true);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AccessToken = {this.AccessToken ?? "null"}");
            toStringOutput.Add($"TokenType = {this.TokenType ?? "null"}");
            toStringOutput.Add($"ExpiresIn = {(this.ExpiresIn == null ? "null" : this.ExpiresIn.ToString())}");
            toStringOutput.Add($"Scope = {this.Scope ?? "null"}");
        }
    }
}