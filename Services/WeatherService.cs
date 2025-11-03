public class WeatherService
{
    private readonly HttpClient fetch = new(); // :) js is alive 


    public async Task<CombinedWeatherResult?> GetWeather(string city)
    {
        var apiKey = "bbf753e64a697f857269e43e6a938c7f";
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        var weather = await fetch.GetFromJsonAsync<WeatherResponse>(url);
        if (weather is null)
            return null;

        url = $"https://api.openweathermap.org/data/2.5/air_pollution?lat={weather.Coord.Lat}&lon={weather.Coord.Lon}&appid={apiKey}";
        var pollution = await fetch.GetFromJsonAsync<AirPollutionResponse>(url);
        if (pollution is null)
            return null;

        var WeatherResponse = new WeatherResponse
        {
            Name = city,
            Main = weather.Main,
            Wind = weather.Wind,
            Coord = weather.Coord
        };

        var PolutionResponse = new AirPollutionResponse
        {
            List = pollution.List
        };

        return new CombinedWeatherResult
        {
            Weather = WeatherResponse,
            AirPollution = PolutionResponse
        };
    }
}