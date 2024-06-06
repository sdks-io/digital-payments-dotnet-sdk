
# Mpp Acces Token Response

## Structure

`MppAccesTokenResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccessToken` | `string` | Optional | It is the token used in the requests that required to authenticate an user. |
| `TokenType` | `string` | Optional | type of token provided<br>**Default**: `"bearer"` |
| `ExpiresIn` | `long?` | Optional | validity of the access token in seconds |
| `Scope` | `string` | Optional | scope for the authentication protocol<br>**Default**: `"basic openid"` |

## Example (as JSON)

```json
{
  "access_token": "zn2GcAQugJQRJXcGXsmHZ8LMqVde",
  "token_type": "bearer",
  "expires_in": 3599,
  "scope": "basic openid"
}
```

