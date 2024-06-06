// <copyright file="ControllerTestBase.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Types;
    using NUnit.Framework;
    using ShellEV.Standard;
    using ShellEV.Standard.Authentication;
    using ShellEV.Standard.Http.Client;
    using ShellEV.Standard.Models;

    /// <summary>
    /// ControllerTestBase Class.
    /// </summary>
    [TestFixture]
    public class ControllerTestBase
    {
        /// <summary>
        /// Assert precision.
        /// </summary>
        protected const double AssertPrecision = 0.1;

        /// <summary>
        /// Gets HttpCallBackHandler.
        /// </summary>
        internal HttpCallBack HttpCallBack { get; private set; } = new HttpCallBack();

        /// <summary>
        /// Gets ShellEVClient Client.
        /// </summary>
        protected ShellEVClient Client { get; private set; }

        /// <summary>
        /// Set up the client.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            ShellEVClient config = ShellEVClient.CreateFromEnvironment();
            this.Client = config.ToBuilder()
                .HttpCallBack(HttpCallBack)
                .Build();
        }
    }
}