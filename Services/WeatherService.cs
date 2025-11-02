using System.Text.Json;

public class WeatherService
{
    private readonly HttpClient fetch = new(); // :) js is alive 

    public async Task<WeatherResult> GetWeather(string city)
    {
        var apiKey = "bbf753e64a697f857269e43e6a938c7f";
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        var response = await fetch.GetStringAsync(url);
        var weather = JsonSerializer.Deserialize<WeatherResult>(response)!;

        return weather;
    }
}