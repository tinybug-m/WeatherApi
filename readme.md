# Weather API

## Overview

This .NET 8 Web API provides current environmental conditions for a given city. It combines data from **OpenWeatherMap's Weather API** and **Air Pollution API**.

The API returns structured JSON like this:

```json
{
  "weather": {
    "coord": { "lat": 35.6944, "lon": 51.4215 },
    "main": { "temp": 12.99, "humidity": 38 },
    "wind": { "speed": 4.12 },
    "name": "Tehran"
  },
  "airPollution": {
    "list": [
      {
        "main": { "aqi": 3 },
        "components": {
          "co": 346.91,
          "no": 0.01,
          "no2": 38.51,
          "o3": 47.63,
          "so2": 7.96,
          "pm2_5": 26,
          "pm10": 45.89,
          "nh3": 4.72
        }
      }
    ]
  }
}
```

## Design Approach

- The JSON structure mirrors the source API instead of flattening the data. This makes it easy for front-end developers to access nested fields without searching through a flat structure.
- Small classes are nested where appropriate (`WeatherResponse`, `AirPollutionResponse`) to keep related fields grouped logically.
- Uses dependency injection for `HttpClient` and services to follow Clean Code and SOLID principles.
- Includes unit tests with xUnit and a mock HTTP client to validate functionality without calling the real API.

## Setup Instructions

### Clone the repository

```bash
git clone https://github.com/tinybug-m/WeatherApi.git
cd weather-api
```

### Configure API Key

Add your OpenWeatherMap API key in `appsettings.json`:

```json
{
  "Weather": {
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}
```

### Run the API

```bash
dotnet run
```

### Test the endpoint

Swagger will be available at `https://localhost:5040/swagger/index.html` (development mode).

### Run unit tests

```bash
dotnet test
```

## Features

- Retrieves:

  - Temperature (in Celsius)
  - Humidity (in %)
  - Wind Speed (in meters per second)
  - Air Quality Index (AQI)
  - Major pollutants (PM2.5, CO, NO₂, etc.)
  - Latitude and Longitude

- Clean and maintainable structure
- Easily extendable for additional OpenWeatherMap endpoints
