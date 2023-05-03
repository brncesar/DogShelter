# API Dog Shelter

- [API Dog Shelter](#api-dog-shelver)
    - [Dog](#dog)
    	- [Find available dogs by size endpoint](#dog-find-available-dogs-by-size-endpoint)
    		- [Request parameters](#dog-find-available-dogs-by-size-request-parameters)
			- [Server response](#dog-find-available-dogs-by-size-server-response)
    	- [Add endpoint](#dog-add-endpoint)
    		- [Request parameters](#dog-add-request-parameters)
			- [Server response](#dog-add-server-response)




## Dog

### Dog: Find available dogs by size - endpoint
```json
GET {{host}}/api/Dog/FindAvailableDogsBySize?size={{size2find}}
```

#### Dog: Find available dogs by size - request parameters
```json
{
	"size": "L"
}
```
| Attribute | Required | Type   | Length| Description
|-----------| :------: |--------|------:|-------------
| **size**  | yes      | char   |     1 | Dog's size » 'S'mall - 'M'edium - 'L'arge


>Parameter size only accepts the letters 's', 'm' and 'l' regardless of letter case.

#### Dog: Find available dogs by size - server response
```json
[
    {
		"id"                   : "33875c07-6498-44e6-ac09-1d30890480f4",
		"name"                 : "Scooby Doo",
		"breedName"            : "Great Dane",
		"bredFor"              : "Hunting & holding boars, Guardian",
		"breedGroup"           : "Working",
		"lifeSpan"             : "7 - 10 years",
		"temperament"          : "Friendly, Devoted, Reserved, Gentle, Confident, Loving",
		"heightAverageMetric"  : 76,
		"heightAverageImperial": 30
    }
]
```
> Returns an array with the found items. If no item is found, it returns an empty array.

---

### Dog: Add - endpoint
```json
POST {{host}}/api/Dog/AddDog
```

#### Dog: Add - request parameters
```json
{
	"name"   : "Scooby Doo",
	"breedId": 124
}
```
| Attribute   | Required | Type   | Length| Description
|-------------| :------: |--------|------:|-------------
| **name**    | yes      | string |    50 | Dog's name
| **breedId** | yes      | int    |   --- | Breed id on The Dog API


#### Dog: Add - server response
```json
{
  "id"                   : "33875c07-6498-44e6-ac09-1d30890480f4",
  "name"                 : "Scooby Doo",
  "breedName"            : "Great Dane",
  "bredFor"              : "Hunting & holding boars, Guardian",
  "breedGroup"           : "Working",
  "lifeSpan"             : "7 - 10 years",
  "temperament"          : "Friendly, Devoted, Reserved, Gentle, Confident, Loving",
  "heightAverageMetric"  : 76,
  "heightAverageImperial": 30
}
```

---
