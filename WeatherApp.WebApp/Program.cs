using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WeatherApp.UseCases;
using WeatherApp.UseCases.Interfaces;
using WeatherApp.UseCases.PluginInterfaces;
using WeatherApp.Plugins;
using Syncfusion.Blazor;
using WeatherApp.Plugins.API;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to access enviornment variables
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddSingleton<ICityForecastRepository, CityForecastRepositoryAPI>();
builder.Services.AddSingleton<IViewCityForecastUseCase, ViewCityForecastUseCase>();
builder.Services.AddTransient<ZipCodeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
