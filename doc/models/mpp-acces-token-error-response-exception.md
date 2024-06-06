
# Mpp Acces Token Error Response Exception

## Structure

`MppAccesTokenErrorResponseException`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Error` | `string` | Required | error code or short description |
| `ErrorCode` | `string` | Required | error code or short description due to invalid request or invalid client ID |
| `ErrorDescription` | `string` | Optional | Description of the error |

## Example (as JSON)

```json
{
  "error": "invalid_request",
  "error_code": "Invalid_client",
  "error_description": "Missing grant type"
}
```

