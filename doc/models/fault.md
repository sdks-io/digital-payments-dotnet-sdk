
# Fault

## Structure

`Fault`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Faultstring` | `string` | Optional | The description of the error. |
| `Detail` | [`Detail`](../../doc/models/detail.md) | Optional | - |

## Example (as JSON)

```json
{
  "faultstring": "Invalid ApiKey for given resource",
  "detail": {
    "errorcode": "errorcode6"
  }
}
```

