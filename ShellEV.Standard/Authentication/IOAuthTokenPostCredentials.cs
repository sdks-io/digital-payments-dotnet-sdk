// <copyright file="IOAuthTokenPostCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard.Authentication
{
    using System;

    /// <summary>
    /// Authentication configuration interface for OAuthTokenPost.
    /// </summary>
    public interface IOAuthTokenPostCredentials
    {
        /// <summary>
        /// Gets string value for xApigeeAuthorization.
        /// </summary>
        string XApigeeAuthorization { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="xApigeeAuthorization"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string xApigeeAuthorization);
    }
}