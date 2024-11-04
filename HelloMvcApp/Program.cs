using Microsoft.EntityFrameworkCore;
using WOD.WebUI.Data;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkNpgsql().
    AddDbContext<PostgresContext>(options => options.UseNpgsql
    ("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=250702iI;"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<FootballClubService>();
builder.Services.AddScoped<NewsService>();

var app = builder.Build();

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

