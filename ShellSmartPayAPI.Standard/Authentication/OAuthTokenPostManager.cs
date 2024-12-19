// <copyright file="OAuthTokenPostManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShellSmartPayAPI.Standard.Http.Request;
using APIMatic.Core.Authentication;

namespace ShellSmartPayAPI.Standard.Authentication
{
    /// <summary>
    /// OAuthTokenPostManager Class.
    /// </summary>
    internal class OAuthTokenPostManager : AuthManager, IOAuthTokenPostCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthTokenPostManager"/> class.
        /// </summary>
        /// <param name="oAuthTokenPost">OAuthTokenPost.</param>
        public OAuthTokenPostManager(OAuthTokenPostModel oAuthTokenPostModel)
        {
            XApigeeAuthorization = oAuthTokenPostModel?.XApigeeAuthorization;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("X-Apigee-Authorization", XApigeeAuthorization).Required())
            );
        }

        /// <summary>
        /// Gets string value for xApigeeAuthorization.
        /// </summary>
        public string XApigeeAuthorization { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="xApigeeAuthorization"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string xApigeeAuthorization)
        {
            return xApigeeAuthorization.Equals(this.XApigeeAuthorization);
        }
    }

    public sealed class OAuthTokenPostModel
    {
        internal OAuthTokenPostModel()
        {
        }

        internal string XApigeeAuthorization { get; set; }

        /// <summary>
        /// Creates an object of the OAuthTokenPostModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(XApigeeAuthorization);
        }

        /// <summary>
        /// Builder class for OAuthTokenPostModel.
        /// </summary>
        public class Builder
        {
            private string xApigeeAuthorization;

            public Builder(string xApigeeAuthorization)
            {
                this.xApigeeAuthorization = xApigeeAuthorization ?? throw new ArgumentNullException(nameof(xApigeeAuthorization));
            }

            /// <summary>
            /// Sets XApigeeAuthorization.
            /// </summary>
            /// <param name="xApigeeAuthorization">XApigeeAuthorization.</param>
            /// <returns>Builder.</returns>
            public Builder XApigeeAuthorization(string xApigeeAuthorization)
            {
                this.xApigeeAuthorization = xApigeeAuthorization ?? throw new ArgumentNullException(nameof(xApigeeAuthorization));
                return this;
            }


            /// <summary>
            /// Creates an object of the OAuthTokenPostModel using the values provided for the builder.
            /// </summary>
            /// <returns>OAuthTokenPostModel.</returns>
            public OAuthTokenPostModel Build()
            {
                return new OAuthTokenPostModel()
                {
                    XApigeeAuthorization = this.xApigeeAuthorization
                };
            }
        }
    }
    
}