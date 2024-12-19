
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Test`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `MppTokenCredentials` | [`MppTokenCredentials`](auth/custom-header-signature.md) | The Credentials Setter for Custom Header Signature |
| `OAuthTokenPostCredentials` | [`OAuthTokenPostCredentials`](auth/custom-header-signature-1.md) | The Credentials Setter for Custom Header Signature |

The API client can be initialized as follows:

```csharp
ShellSmartPayAPIClient client = new ShellSmartPayAPIClient.Builder()
    .MppTokenCredentials(
        new MppTokenModel.Builder(
            "Authorization"
        )
        .Build())
    .OAuthTokenPostCredentials(
        new OAuthTokenPostModel.Builder(
            "X-Apigee-Authorization"
        )
        .Build())
    .Environment(ShellSmartPayAPI.Standard.Environment.Test)
    .Build();
```

## Shell SmartPay APIClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| ShellAPIPlatformSecurityAuthenticationController | Gets ShellAPIPlatformSecurityAuthenticationController controller. |
| DigitalPaymentEnablementController | Gets DigitalPaymentEnablementController controller. |
| StationLocatorController | Gets StationLocatorController controller. |
| FuelingController | Gets FuelingController controller. |
| PartnerNotificationController | Gets PartnerNotificationController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | [`IHttpClientConfiguration`](http-client-configuration.md) |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |
| MppTokenCredentials | Gets the credentials to use with MppToken. | [`IMppTokenCredentials`](auth/custom-header-signature.md) |
| OAuthTokenPostCredentials | Gets the credentials to use with OAuthTokenPost. | [`IOAuthTokenPostCredentials`](auth/custom-header-signature-1.md) |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Shell)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Shell SmartPay APIClient using the values provided for the builder. | `Builder` |

## Shell SmartPay APIClient Builder Class

Class to build instances of Shell SmartPay APIClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<`[`HttpClientConfiguration.Builder`](http-client-configuration-builder.md)`> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `MppTokenCredentials(Action<MppTokenModel.Builder> action)` | Sets credentials for MppToken. | `Builder` |
| `OAuthTokenPostCredentials(Action<OAuthTokenPostModel.Builder> action)` | Sets credentials for OAuthTokenPost. | `Builder` |

