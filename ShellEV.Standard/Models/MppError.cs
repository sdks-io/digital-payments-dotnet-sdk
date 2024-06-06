// <copyright file="MppError.cs" company="APIMatic">
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
    /// MppError.
    /// </summary>
    public class MppError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MppError"/> class.
        /// </summary>
        public MppError()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MppError"/> class.
        /// </summary>
        /// <param name="message">message.</param>
        /// <param name="reason">reason.</param>
        /// <param name="subject">subject.</param>
        /// <param name="subjectType">subjectType.</param>
        /// <param name="type">type.</param>
        public MppError(
            string message = null,
            string reason = null,
            string subject = null,
            string subjectType = null,
            string type = null)
        {
            this.Message = message;
            this.Reason = reason;
            this.Subject = subject;
            this.SubjectType = subjectType;
            this.Type = type;
        }

        /// <summary>
        /// Descriptive, human readable error message. Description of the error (e.g. This field is required and must to be between 1 and 255 characters long)
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        /// <summary>
        /// Additional classification specific for each error type e.g. 'noStock'. The nature of the issue (e.g. missing)
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }

        /// <summary>
        /// Identifier of the related object e.g. '1'. The field/attribute with an issue (e.g. First Name)
        /// </summary>
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        /// <summary>
        /// Type of the object related to the error e.g. 'entry'. The item it relates to (e.g. Parameter)
        /// </summary>
        [JsonProperty("subjectType", NullValueHandling = NullValueHandling.Ignore)]
        public string SubjectType { get; set; }

        /// <summary>
        /// Type of the error e.g. 'LowStockError', 'Validation Error'
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MppError : ({string.Join(", ", toStringOutput)})";
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
            return obj is MppError other &&                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.Subject == null && other.Subject == null) || (this.Subject?.Equals(other.Subject) == true)) &&
                ((this.SubjectType == null && other.SubjectType == null) || (this.SubjectType?.Equals(other.SubjectType) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message)}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason)}");
            toStringOutput.Add($"this.Subject = {(this.Subject == null ? "null" : this.Subject)}");
            toStringOutput.Add($"this.SubjectType = {(this.SubjectType == null ? "null" : this.SubjectType)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
        }
    }
}