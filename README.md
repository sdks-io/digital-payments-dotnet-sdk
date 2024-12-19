
# Getting Started with Shell SmartPay API

## Introduction

The APIs detailed within this document will enable Shell's Fleet Solutions Customers to digitalize Shell Card/s and use them to pay to refuel their vehicles at Shell Stations.

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package sdksio.DigitalpaymentsSDK --version 1.1.0
```

You can also view the package at:
https://www.nuget.org/packages/sdksio.DigitalpaymentsSDK/1.1.0

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Test`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `MppTokenCredentials` | [`MppTokenCredentials`](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/auth/custom-header-signature.md) | The Credentials Setter for Custom Header Signature |
| `OAuthTokenPostCredentials` | [`OAuthTokenPostCredentials`](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/auth/custom-header-signature-1.md) | The Credentials Setter for Custom Header Signature |

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

## Environments

The SDK can be configured to use a different environment for making API calls. Available environments are:

### Fields

| Name | Description |
|  --- | --- |
| Test | **Default** |
| Production | - |

## Authorization

This API uses the following authentication schemes.

* [`MppToken (Custom Header Signature)`](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/auth/custom-header-signature.md)
* [`oAuthTokenPost (Custom Header Signature)`](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/auth/custom-header-signature-1.md)

## List of APIs

* [Shell API Platform Security Authentication](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/controllers/shell-api-platform-security-authentication.md)
* [Digital Payment Enablement](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/controllers/digital-payment-enablement.md)
* [Station Locator](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/controllers/station-locator.md)
* [Partner Notification](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/controllers/partner-notification.md)
* [Fueling](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/controllers/fueling.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/http-request.md)
* [HttpResponse](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/http-string-response.md)
* [HttpContext](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/sdks-io/digital-payments-dotnet-sdk/tree/1.1.0/doc/api-exception.md)

