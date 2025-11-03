

public class WeatherClient
{
    private readonly HttpClient fetch;
    private readonly string apiKey;

    public WeatherClient(HttpClient http, IConfiguration config)
    {
        fetch = http;
        apiKey = config["Weather:ApiKey"] ?? throw new InvalidOperationException("Missing API key");
    }

    public async Task<WeatherResponse?> GetWeatherAsync(string city)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        return await fetch.GetFromJsonAsync<WeatherResponse>(url);
    }


    public async Task<AirPollutionResponse?> GetAirPollutionAsync(double lat, double lon)
    {
        var url = $"https://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid={apiKey}";
        return await fetch.GetFromJsonAsync<AirPollutionResponse>(url);
    }
}
