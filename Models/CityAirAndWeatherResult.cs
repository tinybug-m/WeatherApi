public class CityAirAndWeatherResult
{
    public WeatherResult Weather { get; set; } = null!;
    public AirPollutionResponse AirPollution { get; set; } = null!;
}