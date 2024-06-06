// <copyright file="MppTokenManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ShellEV.Standard.Http.Request;
    using APIMatic.Core.Authentication;

    /// <summary>
    /// MppTokenManager Class.
    /// </summary>
    internal class MppTokenManager : AuthManager, IMppTokenCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MppTokenManager"/> class.
        /// </summary>
        /// <param name="mppToken">MppToken.</param>
        public MppTokenManager(MppTokenModel mppTokenModel)
        {
            Authorization = mppTokenModel?.Authorization;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("Authorization", Authorization).Required())
            );
        }

        /// <summary>
        /// Gets string value for authorization.
        /// </summary>
        public string Authorization { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="authorization"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string authorization)
        {
            return authorization.Equals(this.Authorization);
        }
    }

    public sealed class MppTokenModel
    {
        internal MppTokenModel()
        {
        }

        internal string Authorization { get; set; }

        /// <summary>
        /// Creates an object of the MppTokenModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(Authorization);
        }

        /// <summary>
        /// Builder class for MppTokenModel.
        /// </summary>
        public class Builder
        {
            private string authorization;

            public Builder(string authorization)
            {
                this.authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            }

            /// <summary>
            /// Sets Authorization.
            /// </summary>
            /// <param name="authorization">Authorization.</param>
            /// <returns>Builder.</returns>
            public Builder Authorization(string authorization)
            {
                this.authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
                return this;
            }


            /// <summary>
            /// Creates an object of the MppTokenModel using the values provided for the builder.
            /// </summary>
            /// <returns>MppTokenModel.</returns>
            public MppTokenModel Build()
            {
                return new MppTokenModel()
                {
                    Authorization = this.authorization
                };
            }
        }
    }
    
}