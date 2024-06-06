
# Custom Header Signature



Documentation for accessing and setting credentials for oAuthTokenPost.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| X-Apigee-Authorization | `string` | APIGEE access token ([How to obtain APIGEE access token?](page:guided-walkthrough/walkthrough1)) | `XApigeeAuthorization` | `XApigeeAuthorization` |



**Note:** Auth credentials can be set using `OAuthTokenPostCredentials` in the client builder and accessed through `OAuthTokenPostCredentials` method in the client instance.

## Usage Example

### Client Initialization

You must provide credentials in the client as shown in the following code snippet.

```csharp
ShellEV.Standard.ShellEVClient client = new ShellEV.Standard.ShellEVClient.Builder()
    .OAuthTokenPostCredentials(
        new OAuthTokenPostModel.Builder(
            "X-Apigee-Authorization"
        )
        .Build())
    .Build();
```


