using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Terminal.Gui;
using WeatherMonitor;
using WeatherMonitor.Extensions;
using WeatherMonitor.GUI;
using WeatherMonitor.Models;

var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((ctx, config) => config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
    .ConfigureLogging(l => l.ClearProviders())
    .ConfigureServices((ctx, services) =>
    {
        IConfiguration configuration = ctx.Configuration;
        services.AddHttpClient()
        .AddSingleton(configuration)
        .AddTransient<IAPIClient, APIClient>()
        .AddTransient<IDataProvider, DataProvider>();

    }).Build();


try
{

    _ = host.StartAsync();

    var client = host.Services.GetService<IAPIClient>() ?? throw new InvalidDataException("IAPIClient can not be null");
    var config = host.Services.GetService<IConfiguration>() ?? throw new InvalidDataException("IConfiguration can not be null");
    var provider = host.Services.GetService<IDataProvider>() ?? throw new InvalidDataException("IDataProvider can not be null");
    var httpClient = host.Services.GetService<HttpClient>() ?? throw new InvalidDataException("HttpClient can not be null");

    string baseurl = config.GetItem("Weather.Data.EndPoint"); 

    httpClient.BaseAddress = new Uri(baseurl);

    string defaultSationid = config.GetItem("Default.Station:ID");
    string defaultStationName = config.GetItem("Default.Station:Name");

    //setting up the default station
    Station defaultStation = new Station(defaultSationid, defaultStationName);


    Application.Init();
    SplashWindow spwin = new SplashWindow(client, config, defaultStation, provider);
    Application.Top.Add(spwin);
    Application.Run();
    
    Application.Shutdown();
    await host.StopAsync();

}
catch (Exception ex)
{
    Console.Clear();
    Console.WriteLine(ex.ToString());
    Console.ReadLine();
}




