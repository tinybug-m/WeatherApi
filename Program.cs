using Microsoft.AspNetCore.Mvc;

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
app.MapGet("/weather", async ([FromQuery] string city) => await weatherService.GetWeather(city));


app.Run();