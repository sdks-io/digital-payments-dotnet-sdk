
# Finalise Fueling Request

## Structure

`FinaliseFuelingRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SiteName` | `string` | Optional | - |
| `Timestamp` | `long?` | Optional | - |
| `VolumeQuantity` | `double?` | Optional | - |
| `VolumeUnit` | `string` | Optional | - |
| `FinalPrice` | `double?` | Optional | - |
| `Currency` | `string` | Optional | - |
| `Status` | `string` | Optional | - |
| `SiteAddress` | `string` | Optional | - |
| `OriginalPrice` | `double?` | Optional | - |
| `Discount` | `double?` | Optional | - |
| `Payment` | [`FinaliseFuelingRequestPayment`](../../doc/models/finalise-fueling-request-payment.md) | Optional | - |
| `Products` | [`List<FinaliseFuelingRequestProductsItems>`](../../doc/models/finalise-fueling-request-products-items.md) | Optional | - |
| `MppTransactionId` | `string` | Optional | - |

## Example (as JSON)

```json
{
  "siteName": "Pentahof Site B 9997",
  "timestamp": 1548429960631,
  "volumeQuantity": 10.4,
  "volumeUnit": "LTR",
  "finalPrice": 23.3,
  "currency": "GBP",
  "status": "FINISHED",
  "siteAddress": "Test Geman Address",
  "originalPrice": 23.3,
  "discount": 0,
  "mppTransactionId": "000000006KCC"
}
```

