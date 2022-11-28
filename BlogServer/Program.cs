using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlogServer.Data;
using BlogServer.Facades;
using BlogServer.Controller;

var builder = WebApplication.CreateBuilder(args);

MainController mainController = new MainController();
mainController.Init();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<ContextService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
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
