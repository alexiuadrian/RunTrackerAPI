# RunTrackerAPI
Run Tracker API developed in .NET Core 6

## Getting Started
To get started, you will need to have the following installed on your machine:
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) (optional)


## Running the API
To run the API, you can either run it from Visual Studio 2022 or from the command line.

## API Endpoints
The API has the following endpoints:

| Endpoint | Description |
| --- | --- |
| GET /api/runs | Returns all runs |
| GET /api/runs/{id} | Returns a single run |
| POST /api/runs | Creates a new run |
| PUT /api/runs/{id} | Updates an existing run |
| DELETE /api/runs/{id} | Deletes a run |

## API Documentation
The API is documented using Swagger. To view the documentation, run the API and navigate to the following URL: https://localhost:5001/swagger/index.html

## Request and Response Examples

### GET /api/runs
#### Request
```bash
curl -X GET "https://localhost:5001/api/runs" -H "accept: application/json"
```

#### Response
```json
[
  {
    "id": "ee96c552-8f50-4582-a42c-efc78e55c5c4",
    "name": "Run 1",
    "date": "2021-10-01T00:00:00",
    "distance": 5.2,
    "duration": "3.2",
    "averageSpeed": "00:05:48",
    "description": "Great run!"
  },
  {
    "id": "f0b5c5a5-5b5a-4b5a-8c5a-5b5a5b5a5b5a",
    "name": "Run 2",
    "date": "2021-10-02T00:00:00",
    "distance": 10.4,
    "duration": "6.4",
    "averageSpeed": "00:05:48",
    "description": "Great run!"
  }
]
```


### GET /api/runs/{id}
#### Request
```bash
curl -X GET "https://localhost:5001/api/runs/ee96c552-8f50-4582-a42c-efc78e55c5c4" -H "accept: application/json"
```

#### Response
```json
{
  "id": "ee96c552-8f50-4582-a42c-efc78e55c5c4",
  "name": "Run 1",
  "date": "2021-10-01T00:00:00",
  "distance": 5.2,
  "duration": "3.2",
  "averageSpeed": "00:05:48",
  "description": "Great run!"
}
```


### POST /api/runs
#### Request
```bash
curl -X POST "https://localhost:5001/api/runs" -H "accept: application/json" -H "Content-Type: application/json" -d "{ \"name\": \"Run 3\", \"date\": \"2021-10-03T00:00:00\", \"distance\": 15.6, \"duration\": \"9.6\", \"averageSpeed\": \"00:05:48\", \"description\": \"Great run!\"}"
```

#### Response
```json
{
  "id": "f0b5c5a5-5b5a-4b5a-8c5a-5b5a5b5a5b5a",
  "name": "Run 3",
  "date": "2021-10-03T00:00:00",
  "distance": 15.6,
  "duration": "9.6",
  "averageSpeed": "00:05:48",
  "description": "Great run!"
}
```

### PUT /api/runs/{id}
#### Request
```bash
curl -X PUT "https://localhost:5001/api/runs/f0b5c5a5-5b5a-4b5a-8c5a-5b5a5b5a5b5a" -H "accept: application/json" -H "Content-Type: application/json" -d "{ \"name\": \"Run 3\", \"date\": \"2021-10-03T00:00:00\", \"distance\": 15.6, \"duration\": \"9.6\", \"averageSpeed\": \"00:05:48\", \"description\": \"Great run!\"}"
```

### DELETE /api/runs/{id}
#### Request
```bash
curl -X DELETE "https://localhost:5001/api/runs/f0b5c5a5-5b5a-4b5a-8c5a-5b5a5b5a5b5a" -H "accept: application/json"
```
