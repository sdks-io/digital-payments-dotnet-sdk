# Station Locator

```csharp
StationLocatorController stationLocatorController = client.StationLocatorController;
```

## Class Name

`StationLocatorController`


# Stationlocator V1 Stations Get Around Location

Returns all sites within specified radius of specified GPS location. Sites of all Types are returned. This call must be used when attempting to establish the station the user is located at as part of fuelling journey (i.e. user has to be within 300m of station to be considered located at the station). This API could also be used as a general query to find nearby Shell locations

```csharp
StationlocatorV1StationsGetAroundLocationAsync(
    string m,
    double lon,
    double lat,
    double radius,
    string offerCode = null,
    int? n = null,
    List<string> amenities = null,
    List<string> countries = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `m` | `string` | Query, Required | API Method to be executed |
| `lon` | `double` | Query, Required | The user’s current longitude |
| `lat` | `double` | Query, Required | The user’s current latitude |
| `radius` | `double` | Query, Required | The search radius in kilometers |
| `offerCode` | `string` | Query, Optional | This enables requestor to specify locations that will honour the specified (advanced) offer code |
| `n` | `int?` | Query, Optional | This enables requestor to limit the number of locations that are returned and defaulted to a maximum of 250 locations. Locations returned based on distance to User’s location as-the-crow-flies. |
| `amenities` | `List<string>` | Query, Optional | This enables requestor to filter locations based on one or more amenities (e.g. Filter locations so that only those with a Toilet are returned). |
| `countries` | `List<string>` | Query, Optional | This enables requestor to filter locations based on one or more Countries (i.e. by country codes). |

## Response Type

[`Task<Models.AroundLocationArray>`](../../doc/models/around-location-array.md)

## Example Usage

```csharp
string m = "aroundLocation";
double lon = 77.6730103;
double lat = 12.9132169;
double radius = 0.3;
try
{
    AroundLocationArray result = await stationLocatorController.StationlocatorV1StationsGetAroundLocationAsync(
        m,
        lon,
        lat,
        radius
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
| 400 | Bad request | [`StationLocatorBadRequestException`](../../doc/models/station-locator-bad-request-exception.md) |
| 401 | Unauthorized | [`StationLocatorUnauthorizedException`](../../doc/models/station-locator-unauthorized-exception.md) |
| 403 | Forbbiden | [`StationLocatorForbiddenException`](../../doc/models/station-locator-forbidden-exception.md) |
| 404 | Not Found | [`StationLocatorNotFoundException`](../../doc/models/station-locator-not-found-exception.md) |
| 500 | Internal Server Error | [`StationLocatorInternalServerErrorException`](../../doc/models/station-locator-internal-server-error-exception.md) |

