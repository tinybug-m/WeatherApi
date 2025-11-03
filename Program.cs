var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<WeatherClient>();
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

app.MapControllers();

app.Run();
