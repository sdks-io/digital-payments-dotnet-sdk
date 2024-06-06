// <copyright file="Environment.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    /// <summary>
    /// Available environments.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Environment
    {
        /// <summary>
        /// Digital Payment APIs.
        /// </summary>
        [EnumMember(Value = "production")]
        Production,
    }
}
