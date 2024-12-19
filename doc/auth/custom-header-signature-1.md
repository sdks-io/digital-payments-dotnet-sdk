
# Custom Header Signature



Documentation for accessing and setting credentials for oAuthTokenPost.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| X-Apigee-Authorization | `string` | API Gateway Access token to be passed for Authentiction. The calling party’s OAuth 2.0/bearer token that’s required for using the Shell API Platform. ([How to obtain APIGEE access token?](page:guided-walkthrough/walkthrough1)) | `XApigeeAuthorization` | `XApigeeAuthorization` |



**Note:** Auth credentials can be set using `OAuthTokenPostCredentials` in the client builder and accessed through `OAuthTokenPostCredentials` method in the client instance.

## Usage Example

### Client Initialization

You must provide credentials in the client as shown in the following code snippet.

```csharp
ShellSmartPayAPIClient client = new ShellSmartPayAPIClient.Builder()
    .OAuthTokenPostCredentials(
        new OAuthTokenPostModel.Builder(
            "X-Apigee-Authorization"
        )
        .Build())
    .Build();
```


