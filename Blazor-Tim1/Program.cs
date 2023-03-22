using Blazor_Tim1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DataAccessLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Razor Pages can be added. MVC? probably.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>(); // One instance for entire application
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IPeopleData, PeopleData>(); 

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
