// <copyright file="ShellEVClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace ShellEV.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using ShellEV.Standard.Authentication;
    using ShellEV.Standard.Controllers;
    using ShellEV.Standard.Http.Client;
    using ShellEV.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class ShellEVClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://api-test.shell.com/ShellDigitalCommerceServices/Payments/B2B/Partner" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallBack httpCallBack;
        private readonly Lazy<ShellAPIPlatformSecurityAuthenticationController> shellAPIPlatformSecurityAuthentication;
        private readonly Lazy<DigitalPaymentEnablementController> digitalPaymentEnablement;
        private readonly Lazy<StationLocatorController> stationLocator;
        private readonly Lazy<FuelingController> fueling;
        private readonly Lazy<PartnerNotificationController> partnerNotification;

        private ShellEVClient(
            Environment environment,
            MppTokenModel mppTokenModel,
            OAuthTokenPostModel oAuthTokenPostModel,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.HttpClientConfiguration = httpClientConfiguration;
            MppTokenModel = mppTokenModel;
            var mppTokenManager = new MppTokenManager(mppTokenModel);
            OAuthTokenPostModel = oAuthTokenPostModel;
            var oAuthTokenPostManager = new OAuthTokenPostManager(oAuthTokenPostModel);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                    {"MppToken", mppTokenManager},
                    {"oAuthTokenPost", oAuthTokenPostManager},
                })
                .ApiCallback(httpCallBack)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();

            MppTokenCredentials = mppTokenManager;
            OAuthTokenPostCredentials = oAuthTokenPostManager;

            this.shellAPIPlatformSecurityAuthentication = new Lazy<ShellAPIPlatformSecurityAuthenticationController>(
                () => new ShellAPIPlatformSecurityAuthenticationController(globalConfiguration));
            this.digitalPaymentEnablement = new Lazy<DigitalPaymentEnablementController>(
                () => new DigitalPaymentEnablementController(globalConfiguration));
            this.stationLocator = new Lazy<StationLocatorController>(
                () => new StationLocatorController(globalConfiguration));
            this.fueling = new Lazy<FuelingController>(
                () => new FuelingController(globalConfiguration));
            this.partnerNotification = new Lazy<PartnerNotificationController>(
                () => new PartnerNotificationController(globalConfiguration));
        }

        /// <summary>
        /// Gets ShellAPIPlatformSecurityAuthenticationController controller.
        /// </summary>
        public ShellAPIPlatformSecurityAuthenticationController ShellAPIPlatformSecurityAuthenticationController => this.shellAPIPlatformSecurityAuthentication.Value;

        /// <summary>
        /// Gets DigitalPaymentEnablementController controller.
        /// </summary>
        public DigitalPaymentEnablementController DigitalPaymentEnablementController => this.digitalPaymentEnablement.Value;

        /// <summary>
        /// Gets StationLocatorController controller.
        /// </summary>
        public StationLocatorController StationLocatorController => this.stationLocator.Value;

        /// <summary>
        /// Gets FuelingController controller.
        /// </summary>
        public FuelingController FuelingController => this.fueling.Value;

        /// <summary>
        /// Gets PartnerNotificationController controller.
        /// </summary>
        public PartnerNotificationController PartnerNotificationController => this.partnerNotification.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with MppToken.
        /// </summary>
        public IMppTokenCredentials MppTokenCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with MppToken.
        /// </summary>
        public MppTokenModel MppTokenModel { get; private set; }

        /// <summary>
        /// Gets the credentials to use with OAuthTokenPost.
        /// </summary>
        public IOAuthTokenPostCredentials OAuthTokenPostCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with OAuthTokenPost.
        /// </summary>
        public OAuthTokenPostModel OAuthTokenPostModel { get; private set; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the ShellEVClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallBack(httpCallBack)
                .HttpClientConfig(config => config.Build());

            if (MppTokenModel != null)
            {
                builder.MppTokenCredentials(MppTokenModel.ToBuilder().Build());
            }

            if (OAuthTokenPostModel != null)
            {
                builder.OAuthTokenPostCredentials(OAuthTokenPostModel.ToBuilder().Build());
            }

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> ShellEVClient.</returns>
        internal static ShellEVClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("SHELL_EV_STANDARD_ENVIRONMENT");
            string authorization = System.Environment.GetEnvironmentVariable("SHELL_EV_STANDARD_AUTHORIZATION");
            string xApigeeAuthorization = System.Environment.GetEnvironmentVariable("SHELL_EV_STANDARD_X_APIGEE_AUTHORIZATION");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (authorization != null)
            {
                builder.MppTokenCredentials(new MppTokenModel
                .Builder(authorization)
                .Build());
            }

            if (xApigeeAuthorization != null)
            {
                builder.OAuthTokenPostCredentials(new OAuthTokenPostModel
                .Builder(xApigeeAuthorization)
                .Build());
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = ShellEV.Standard.Environment.Production;
            private MppTokenModel mppTokenModel = new MppTokenModel();
            private OAuthTokenPostModel oAuthTokenPostModel = new OAuthTokenPostModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for MppToken.
            /// </summary>
            /// <param name="mppTokenModel">MppTokenModel.</param>
            /// <returns>Builder.</returns>
            public Builder MppTokenCredentials(MppTokenModel mppTokenModel)
            {
                if (mppTokenModel is null)
                {
                    throw new ArgumentNullException(nameof(mppTokenModel));
                }

                this.mppTokenModel = mppTokenModel;
                return this;
            }

            /// <summary>
            /// Sets credentials for OAuthTokenPost.
            /// </summary>
            /// <param name="oAuthTokenPostModel">OAuthTokenPostModel.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthTokenPostCredentials(OAuthTokenPostModel oAuthTokenPostModel)
            {
                if (oAuthTokenPostModel is null)
                {
                    throw new ArgumentNullException(nameof(oAuthTokenPostModel));
                }

                this.oAuthTokenPostModel = oAuthTokenPostModel;
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }


           

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the ShellEVClient using the values provided for the builder.
            /// </summary>
            /// <returns>ShellEVClient.</returns>
            public ShellEVClient Build()
            {
                if (mppTokenModel.Authorization == null)
                {
                    mppTokenModel = null;
                }
                if (oAuthTokenPostModel.XApigeeAuthorization == null)
                {
                    oAuthTokenPostModel = null;
                }
                return new ShellEVClient(
                    environment,
                    mppTokenModel,
                    oAuthTokenPostModel,
                    httpCallBack,
                    httpClientConfig.Build());
            }
        }
    }
}
