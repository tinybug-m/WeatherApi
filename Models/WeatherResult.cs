// WeatherResult.cs
public class WeatherResult
{
    public required Coordinates Coord { get; set; }
    public required MainWeather Main { get; set; }
    public required WindInfo Wind { get; set; }
    public required string Name { get; set; }

    public class Coordinates
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }

    public class MainWeather
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}
