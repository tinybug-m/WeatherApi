public class CombinedWeatherResult
{
    public WeatherResponse Weather { get; set; } = null!;
    public AirPollutionResponse AirPollution { get; set; } = null!;
}