public class WeatherService
{
    private readonly WeatherClient _client;

    public WeatherService(WeatherClient client)
    {
        _client = client;
    }

    public async Task<CombinedWeatherResult?> GetWeather(string city)
    {
        var weather = await _client.GetWeatherAsync(city);
        if (weather is null) return null;

        var pollution = await _client.GetAirPollutionAsync(weather.Coord.Lat, weather.Coord.Lon);
        if (pollution is null) return null;

        return new CombinedWeatherResult
        {
            Weather = weather,
            AirPollution = pollution
        };
    }
}
