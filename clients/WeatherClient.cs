
public class WeatherClient
{
    private readonly HttpClient fetch;
    private readonly string apiKey;

    public WeatherClient(HttpClient http, IConfiguration config)
    {
        fetch = http;
        apiKey = config["Weather:ApiKey"] ?? throw new InvalidOperationException("Missing API key");
    }

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        var weather = await fetch.GetFromJsonAsync<WeatherResponse>(url);
        return weather ?? throw new InvalidOperationException($"Failed to fetch weather for {city}");
    }

    public async Task<AirPollutionResponse> GetAirPollutionAsync(double latitude, double longitude)
    {
        var url = $"https://api.openweathermap.org/data/2.5/air_pollution?lat={latitude}&lon={longitude}&appid={apiKey}";
        var pollution = await fetch.GetFromJsonAsync<AirPollutionResponse>(url);
        return pollution ?? throw new InvalidOperationException($"Failed to fetch air pollution data for {latitude}, {longitude}");
    }
}
