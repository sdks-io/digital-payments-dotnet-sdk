// <copyright file="IMppTokenCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;

namespace ShellSmartPayAPI.Standard.Authentication
{
    /// <summary>
    /// Authentication configuration interface for MppToken.
    /// </summary>
    public interface IMppTokenCredentials
    {
        /// <summary>
        /// Gets string value for authorization.
        /// </summary>
        string Authorization { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="authorization"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string authorization);
    }
}