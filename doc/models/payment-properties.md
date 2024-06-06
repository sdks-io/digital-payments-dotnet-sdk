
# Payment Properties

Object containing Payment Property details Please note:
All the attributes are optional as they serve all payment methods (i.e. different payment methods require different fields to be filled/mandated). As a result, some of these fields will be mandatory depending on the selected payment method and the API will return an error if they are not completed

## Structure

`PaymentProperties`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `PaymentType` | `string` | Optional | The type of payment (e.g. Credit Card, Debit Card) |
| `ClientMetadataId` | `string` | Optional | This is only used for PayPal. During the creation of the user’s profile an ID (clientMetadataId) will have been created by PayPal and stored by Shell. Thus, when PayPal payments are made this ID must be included in order for the payment to be processed |
| `Token` | `string` | Optional | This is only used for ApplePay and AndroidPay. Users using either of these payment methods use device biometrics to authenticate themselves against their respective payment method/provider (e.g. retina, fingerprint). Successful authentication will result in Apple/Android issuing a Payment Token which should be specified here |
| `Identifier` | `string` | Optional | This is the payment identifier and it is only used for ApplePay and AndroidPay. |
| `Network` | `string` | Optional | This is the payment network (e.g. Visa, Mastercard) and it is only used for ApplePay and AndroidPay. |
| `CardIdentifier` | `string` | Required | This is only relevant for transactions made by B2B customers using the Shell Card payment method. The ‘cardIdentifier’ is the unique identifier provided by Commercial Fleet and shared with the Shell mobile payments platform. This reference ID is used in interactions with the Commercial Fleet application to retrieve the fueling token - use the cardIdentifier when requesting a DPAN. |
| `Odometer` | `string` | Optional | This is only relevant for transactions made by B2B customers using a Shell Card payment method. During set up of the user’s Shell Card it’s possible to configure the card such that users are forced to provide an odometer reading before a Sale can begin processing. This field must be filled if the B2B user’s Shell Card has been configured this way but will be left blank in all other cases. |
| `FleetId` | `string` | Optional | Only relevant if Customer attempting to pay with B2B Shell Card. Customers attempting to pay with a B2B Shell Card may have to specify their Fleet ID as an extra authorisation/security step. Shell Card configuration will determine whether or not Fleet ID needs to be provided. Please note this field is a 6 character numeric field. |
| `ExternalRefId` | `string` | Optional | This is only used for transactions made by B2B customers using the Shell Card payment method.<br><br>In this scenario the expectation is that :\ a B2B entity has been successfully created that includes the external party’s reference for the entity (e.g. Contract Number, VRN, customer email); a new Shell Card (SFC) has been successfully created; and Shell Card and B2B Entity have been linked.<br><br>externalRefId refers to the 3rd Parties External Reference for the B2B entity and will therefore be used to verify the Customer and SFC before attempting to process a payment using the SFC card |

## Example (as JSON)

```json
{
  "paymentType": "paymentType0",
  "clientMetadataId": "clientMetadataId4",
  "token": "token0",
  "identifier": "identifier6",
  "network": "network8",
  "cardIdentifier": "cardIdentifier6"
}
```

