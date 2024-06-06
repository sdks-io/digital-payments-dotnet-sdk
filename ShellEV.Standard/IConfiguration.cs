// <copyright file="IConfiguration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard
{
    using System;
    using System.Net;
    using ShellEV.Standard.Authentication;
    using ShellEV.Standard.Models;

    /// <summary>
    /// IConfiguration.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets Current API environment.
        /// </summary>
        Environment Environment { get; }

        /// <summary>
        /// Gets the credentials to use with MppToken.
        /// </summary>
        IMppTokenCredentials MppTokenCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with MppToken.
        /// </summary>
        MppTokenModel MppTokenModel { get; }

        /// <summary>
        /// Gets the credentials to use with OAuthTokenPost.
        /// </summary>
        IOAuthTokenPostCredentials OAuthTokenPostCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with OAuthTokenPost.
        /// </summary>
        OAuthTokenPostModel OAuthTokenPostModel { get; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        string GetBaseUri(Server alias = Server.Default);
    }
}