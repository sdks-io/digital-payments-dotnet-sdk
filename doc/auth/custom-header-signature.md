
# Custom Header Signature



Documentation for accessing and setting credentials for MppToken.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| Authorization | `string` | Access token to be passed for Mobile Payment Platform Authentication ([How to obtain Digital Payments access token?](page:guided-walkthrough/walkthrough1)) | `Authorization` | `Authorization` |



**Note:** Auth credentials can be set using `MppTokenCredentials` in the client builder and accessed through `MppTokenCredentials` method in the client instance.

## Usage Example

### Client Initialization

You must provide credentials in the client as shown in the following code snippet.

```csharp
ShellSmartPayAPIClient client = new ShellSmartPayAPIClient.Builder()
    .MppTokenCredentials(
        new MppTokenModel.Builder(
            "Authorization"
        )
        .Build())
    .Build();
```


