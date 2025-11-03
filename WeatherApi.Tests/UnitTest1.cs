using RichardSzalay.MockHttp;

namespace WeatherApi.Tests
{
    public class WeatherServiceSimpleTests
    {
        [Fact]
        public async Task GetWeather_ReturnsResult()
        {
            // 1️⃣ Mock configuration with a fake API key
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new System.Collections.Generic.Dictionary<string, string>
                {
                    { "Weather:ApiKey", "FAKE_KEY" }
                })
                .Build();

            // 2️⃣ Mock HTTP responses
            var mockHttp = new MockHttpMessageHandler();

            // Weather API mock
            mockHttp.When("https://api.openweathermap.org/data/2.5/weather*")
                    .Respond("application/json", @"
                    {
                        ""coord"": { ""lat"": 35.6944, ""lon"": 51.4215 },
                        ""main"": { ""temp"": 25, ""humidity"": 50 },
                        ""wind"": { ""speed"": 3 },
                        ""name"": ""Tehran""
                    }");

            // Air pollution API mock
            mockHttp.When("https://api.openweathermap.org/data/2.5/air_pollution*")
                    .Respond("application/json", @"
                    {
                        ""list"": [
                            {
                                ""main"": { ""aqi"": 3 },
                                ""components"": {
                                    ""co"": 285.21,
                                    ""no"": 0,
                                    ""no2"": 24.56,
                                    ""o3"": 56.62,
                                    ""so2"": 5.53,
                                    ""pm2_5"": 25.4,
                                    ""pm10"": 41.12,
                                    ""nh3"": 4.08
                                }
                            }
                        ]
                    }");

            // 3️⃣ Create the WeatherClient with mocked HttpClient
            var client = new WeatherClient(new HttpClient(mockHttp), config);
            var service = new WeatherService(client);

            // 4️⃣ Call service
            var result = await service.GetWeather("Tehran");

            // 5️⃣ Assertions
            Assert.NotNull(result);
            Assert.NotNull(result.Weather);
            Assert.NotNull(result.Weather.Main);
            Assert.NotNull(result.Weather.Wind);
            Assert.NotNull(result.Weather.Coord);
            Assert.NotNull(result.AirPollution);
            Assert.NotEmpty(result.AirPollution.List);
            Assert.NotNull(result.AirPollution.List[0].Main);
            Assert.NotNull(result.AirPollution.List[0].Components);
        }
    }
}
