using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WeatherApp.Plugins.InMemory;
using WeatherApp.UseCases;
using WeatherApp.UseCases.Interfaces;
using WeatherApp.UseCases.PluginInterfaces;
using WeatherApp.Plugins;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddSingleton<ICityForecastRepository, CityForecastRepository>();
builder.Services.AddSingleton<IViewCityForecastUseCase, ViewCityForecastUseCase>();
builder.Services.AddSingleton<IViewCitiesByNameUseCase, ViewCitiesByNameUseCase>();

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
