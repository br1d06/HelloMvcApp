using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Data;
using System;
using System.Linq;
using WOD.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WOD.WebUI.ViewModels;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MainContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MainContext>>()))
        {
            // Look for any movies.
            if (context.News.Any())
            {
                return;   // DB has been seeded
            }
            context.News.AddRange(
                //добавить новости в БД
            ); ; ;
            context.SaveChanges();
        }
    }
}
