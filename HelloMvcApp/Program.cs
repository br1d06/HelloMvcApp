using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MainContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<FootballClubService>();
builder.Services.AddScoped<NewsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

