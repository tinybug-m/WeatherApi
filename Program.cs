var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<WeatherClient>();
builder.Services.AddScoped<WeatherService>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
