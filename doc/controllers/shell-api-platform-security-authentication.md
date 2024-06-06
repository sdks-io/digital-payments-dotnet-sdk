# Shell API Platform Security Authentication

```csharp
ShellAPIPlatformSecurityAuthenticationController shellAPIPlatformSecurityAuthenticationController = client.ShellAPIPlatformSecurityAuthenticationController;
```

## Class Name

`ShellAPIPlatformSecurityAuthenticationController`


# Oauth Token Post

To obtain APIGEE access token

:information_source: **Note** This endpoint does not require authentication.

```csharp
OauthTokenPostAsync(
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
    AccessTokenResponse result = await shellAPIPlatformSecurityAuthenticationController.OauthTokenPostAsync(
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

