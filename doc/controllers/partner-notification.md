# Partner Notification

```csharp
PartnerNotificationController partnerNotificationController = client.PartnerNotificationController;
```

## Class Name

`PartnerNotificationController`

## Methods

* [Partner Token](../../doc/controllers/partner-notification.md#partner-token)
* [Finalise Fueling](../../doc/controllers/partner-notification.md#finalise-fueling)
* [Cancel Fueling](../../doc/controllers/partner-notification.md#cancel-fueling)


# Partner Token

To access the Partner’s endpoints, for sending callback messages, Shell will need to connect to the Partner API end points. It is recemmended that the partner offers OAuth 2.0 as a standard for call back APIs and will require the OAuth 2.0 token for authentication. Note this needs to be implemented over HTTPS

:information_source: **Note** This endpoint does not require authentication.

```csharp
PartnerTokenAsync(
    string grantType,
    string clientId,
    string clientSecret)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `grantType` | `string` | Form, Required | In OAuth 2.0, the term grant typee refers to the way an application gets an access token. OAuth 2.0 defines several grant types, including the authorization code flow. |
| `clientId` | `string` | Form, Required | After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. |
| `clientSecret` | `string` | Form, Required | After registering your app, you will receive a client ID and a client secret. The client ID is considered public information, and is used to build login URLs, or included in Javascript source code on a page. The client secret must be kept confidential. |

## Response Type

[`Task<Models.AccessTokenResponse>`](../../doc/models/access-token-response.md)

## Example Usage

```csharp
string grantType = "client_credentials";
string clientId = "SOFflRakNlwnWlxfOXQ4GHDVyqGawuKA";
string clientSecret = "cRnWgw7gACqM3gVS";
try
{
    AccessTokenResponse result = await partnerNotificationController.PartnerTokenAsync(
        grantType,
        clientId,
        clientSecret
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 401 | Unauthorized | [`AccessTokenErrorException`](../../doc/models/access-token-error-exception.md) |


# Finalise Fueling

Enables Shell to inform partner of the successful completion of a transaction. Note this needs to be implemented over HTTPS

:information_source: **Note** This endpoint does not require authentication.

```csharp
FinaliseFuelingAsync(
    Models.FinaliseFuelingRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`FinaliseFuelingRequest`](../../doc/models/finalise-fueling-request.md) | Body, Optional | - |

## Response Type

`Task`

## Example Usage

```csharp
FinaliseFuelingRequest body = new FinaliseFuelingRequest
{
    SiteName = "Pentahof Site B 9997",
    Timestamp = 1548429960631L,
    VolumeQuantity = 10.4,
    VolumeUnit = "LTR",
    FinalPrice = 23.3,
    Currency = "GBP",
    Status = "FINISHED",
    SiteAddress = "Test Geman Address",
    OriginalPrice = 23.3,
    Discount = 0,
    MppTransactionId = "000000006KCC",
};

try
{
    await partnerNotificationController.FinaliseFuelingAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request | `ApiException` |
| 401 | Unauthorized | `ApiException` |


# Cancel Fueling

Enables Shell to inform partner that a Mobile Payment transaction has been cancelled by Shell as an error/issue occured. Note this needs to be implemented over HTTPS

:information_source: **Note** This endpoint does not require authentication.

```csharp
CancelFuelingAsync(
    Models.CancelFuelingRequest body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CancelFuelingRequest`](../../doc/models/cancel-fueling-request.md) | Body, Optional | - |

## Response Type

`Task`

## Example Usage

```csharp
CancelFuelingRequest body = new CancelFuelingRequest
{
    MppTransactionId = "000000001E5M",
    ReasonCode = "CANCELLED",
};

try
{
    await partnerNotificationController.CancelFuelingAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad Request | `ApiException` |
| 401 | Unauthorized | `ApiException` |

