// <copyright file="ShellSmartPayAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using APIMatic.Core;
using APIMatic.Core.Authentication;
using ShellSmartPayAPI.Standard.Authentication;
using ShellSmartPayAPI.Standard.Controllers;
using ShellSmartPayAPI.Standard.Http.Client;
using ShellSmartPayAPI.Standard.Utilities;

namespace ShellSmartPayAPI.Standard
{
    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class ShellSmartPayAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Test, new Dictionary<Enum, string>
                {
                    { Server.Shell, "https://api-test.shell.com/ShellDigitalCommerceServices/Payments/B2B/Partner" },
                }
            },
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Shell, "https://api.shell.com/ShellDigitalCommerceServices/Payments/B2B/Partner" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallback httpCallback;
        private readonly Lazy<ShellAPIPlatformSecurityAuthenticationController> shellAPIPlatformSecurityAuthentication;
        private readonly Lazy<DigitalPaymentEnablementController> digitalPaymentEnablement;
        private readonly Lazy<StationLocatorController> stationLocator;
        private readonly Lazy<FuelingController> fueling;
        private readonly Lazy<PartnerNotificationController> partnerNotification;

        private ShellSmartPayAPIClient(
            Environment environment,
            MppTokenModel mppTokenModel,
            OAuthTokenPostModel oAuthTokenPostModel,
            HttpCallback httpCallback,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallback = httpCallback;
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
                .ApiCallback(httpCallback)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Shell)
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
        public HttpCallback HttpCallback => this.httpCallback;

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
        /// <param name="alias">Default value:SHELL.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Shell)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the ShellSmartPayAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallback(httpCallback)
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
        /// <returns> ShellSmartPayAPIClient.</returns>
        internal static ShellSmartPayAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("SHELL_SMART_PAY_API_STANDARD_ENVIRONMENT");
            string authorization = System.Environment.GetEnvironmentVariable("SHELL_SMART_PAY_API_STANDARD_AUTHORIZATION");
            string xApigeeAuthorization = System.Environment.GetEnvironmentVariable("SHELL_SMART_PAY_API_STANDARD_X_APIGEE_AUTHORIZATION");

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
            private Environment environment = ShellSmartPayAPI.Standard.Environment.Test;
            private MppTokenModel mppTokenModel = new MppTokenModel();
            private OAuthTokenPostModel oAuthTokenPostModel = new OAuthTokenPostModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallback httpCallback;

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
            /// Sets the HttpCallback for the Builder.
            /// </summary>
            /// <param name="httpCallback"> http callback. </param>
            /// <returns>Builder.</returns>
            public Builder HttpCallback(HttpCallback httpCallback)
            {
                this.httpCallback = httpCallback;
                return this;
            }

            /// <summary>
            /// Creates an object of the ShellSmartPayAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>ShellSmartPayAPIClient.</returns>
            public ShellSmartPayAPIClient Build()
            {
                if (mppTokenModel.Authorization == null)
                {
                    mppTokenModel = null;
                }
                if (oAuthTokenPostModel.XApigeeAuthorization == null)
                {
                    oAuthTokenPostModel = null;
                }
                return new ShellSmartPayAPIClient(
                    environment,
                    mppTokenModel,
                    oAuthTokenPostModel,
                    httpCallback,
                    httpClientConfig.Build());
            }
        }
    }
}
