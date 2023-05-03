# API Dog Shelter

- [API Dog Shelter](#api-dog-shelver)
    - [Dog](#dog)
    	- [Find available dogs by size endpoint](#dog-find-available-dogs-by-size-endpoint)
    		- [Request parameters](#dog-find-available-dogs-by-size-request-parameters)
			- [Server response](#dog-find-available-dogs-by-size-server-response)
    	- [Add endpoint](#dog-add-endpoint)
    		- [Request parameters](#dog-add-request-parameters)
			- [Server response](#dog-add-server-response)
    	- [Find dogs by temperament endpoint](#dog-find-dogs-by-temperament-endpoint)
    		- [Request parameters](#dog-find-dogs-by-temperament-request-parameters)
			- [Server response](#dog-find-dogs-by-temperament-server-response)
    	- [Find dogs by breed endpoint](#dog-find-dogs-by-breed-endpoint)
    		- [Request parameters](#dog-find-dogs-by-breed-request-parameters)
			- [Server response](#dog-find-dogs-by-breed-server-response)




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

### Dog: Find dogs by temperament - endpoint
```json
GET {{host}}/api/Dog/GetDogsByTemperament?temperament={{temperament(s)}}
```

#### Dog: Find dogs by temperament - request parameters
```json
{
	"temperament": "Lively,Friendly"
}
```
| Attribute        | Required | Type   | Length| Description
|------------------| :------: |--------|------:|-------------
| **temperament**  | yes      | string |    50 | Dog's temperament. For more than one, separate by comma or point and comma


>In the case of more than one informed temperament, the search will be inclusive.

#### Dog: Find dogs by temperament - server response
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
  },
  {
    "id"                   : "21369f4d-21a6-4190-bb77-7dec50a8bee9",
    "name"                 : "Beethoven",
    "breedName"            : "Saint Bernard",
    "bredFor"              : "Draft, search, rescue",
    "breedGroup"           : "Working",
    "lifeSpan"             : "7 - 10 years",
    "temperament"          : "Friendly, Lively, Gentle, Watchful, Calm",
    "heightAverageMetric"  : 67,
    "heightAverageImperial": 26.5
  },
  {
    "id"                   : "a6b860bf-4cec-48ef-aea6-a7212d3abb02",
    "name"                 : "Lessie",
    "breedName"            : "Shetland Sheepdog",
    "bredFor"              : "Sheep herding",
    "breedGroup"           : "Herding",
    "lifeSpan"             : "12 - 14 years",
    "temperament"          : "Affectionate, Lively, Responsive, Alert, Loyal, Reserved, Playful, Gentle, Intelligent, Active, Trainable, Strong",
    "heightAverageMetric"  : 37,
    "heightAverageImperial": 14.5
  }
]
```
> Returns an array with the found items. If no item is found, it returns an empty array.

---

### Dog: Find dogs by breed - endpoint
```json
GET {{host}}/api/Dog/GetDogsbyBreed?BreedId={{breedId}}
```

#### Dog: Find dogs by breed - request parameters
```json
{
	"breedId": 149
}
```
| Attribute    | Required | Type   | Length| Description
|--------------| :------: |--------|------:|-------------
| **breedId**  | yes      | int    |   --- | Dog's breed id.


>Do not check if the breed identifier is valid. Only research in registered dogs those possessed of the informed breed identifier.

#### Dog: Find dogs by breed - server response
```json
[
  {
    "id"                   : "49bbb040-1cfd-402e-ac67-28f0d9db86ab",
    "name"                 : "Marley",
    "breedName"            : "Labrador Retriever",
    "bredFor"              : "Water retrieving",
    "breedGroup"           : "Sporting",
    "lifeSpan"             : "10 - 13 years",
    "temperament"          : "Kind, Outgoing, Agile, Gentle, Intelligent, Trusting, Even Tempered",
    "heightAverageMetric"  : 58,
    "heightAverageImperial": 23
  }
]
```
> Returns an array with the found items. If no item is found, it returns an empty array.

---