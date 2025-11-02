public class WeatherService
{

    public async Task<string> GetWeather(string city)
    {
        return "It's raining in " + city;
    }
}