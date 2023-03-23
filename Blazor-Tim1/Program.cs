using Blazor_Tim1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DataAccessLibrary;

var builder = WebApplication.CreateBuilder(args);

// This dependency injection can be replaced by a more sophisticated system if you need
// it for some reason.

// Add services to the container.
// Razor Pages can be added. MVC? probably.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add interface for instance of class - Globally available
//builder.Services.AddSingleton<IDataAccess, DummyDataAccess>();
builder.Services.AddTransient<IDataAccess, DummyDataAccess>();

// Singleton makes instance for entire application and lasts the life of the application.
// Not necessarily good if you are reading data. Scope is wrong for that. 
//builder.Services.AddSingleton<WeatherForecastService>();

// Like Singleton, but only per user or session... hmmm tried 2 browsers and were the same 
//builder.Services.AddScoped<WeatherForecastService>();

// Get a new instance every time it is called.
// ***Notice, the optional interface was not added, just the type/class
 builder.Services.AddTransient<WeatherForecastService>();

builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IPeopleData, PeopleData>();

/* Dependency Injection is running, but then it has to be @inject at the page... 
   It can also be injected into a class as a constructor parameter. 
 */

// There is some logging here by default, configured in appsettings.json
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

app.UseRouting(); // Default for ASP.Net Core

app.MapBlazorHub(); // Where Signal R is mapped

// In case we don't know where we are going. Hosts.shtml knows.
// Unlike in 3.1, the _Hosts.shtml file contents have been moved to _Layout.shtml and Hosts.shtm pretty much just redirects there.
// _Layout.shtml does a lot (css, js, RenderBody()) .... That makes it the starter page.
app.MapFallbackToPage("/_Host"); 

app.Run();
