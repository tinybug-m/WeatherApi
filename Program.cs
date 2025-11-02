var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// bbf753e64a697f857269e43e6a938c7f

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "API is running");

var weatherService = new WeatherService();

app.MapGet("/weather", async (string? city) =>
{
    if (string.IsNullOrWhiteSpace(city))
        return "Please enter a city";

    return await weatherService.GetWeather(city);
});

app.Run();