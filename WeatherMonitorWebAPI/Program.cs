using Serilog;
using Serilog.Extensions.Hosting;
using WeatherMonitor.Application;
using WeatherMonitor.Application.Extensions;
using WeatherMonitorWebAPI.Filters;
using WeatherMonitorWebAPI.Utils;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


builder.Services.AddSingleton(Log.Logger);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.AddSingleton<DiagnosticContext>();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseMiddleware<UnifiedExceptionMiddleware>();

app.MapGet("/api/v1/get-weather/{wmoid}", async (string wmoid, IWeatherDataService service)
    => ResponseHelper.Ok(await service.GetAllWeatherDataAsync(wmoid)));

app.MapGet("/api/v1/get-data-point/{wmoid}/{tag}", async (string wmoid, string tag, IWeatherDataService service) 
    => ResponseHelper.Ok(await service.GetWeatherDataPointAsync(wmoid, tag)));

app.MapGet("/api/v1/get-data-point-tags/", (IWeatherDataService service) => service.GetDataPointTags());

app.MapGet("/api/v1/get-stations/", (IWeatherDataService service) => service.GetStations());

app.Run();


