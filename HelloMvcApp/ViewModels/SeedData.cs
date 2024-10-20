using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Data;
using System;
using System.Linq;
using WOD.Domain.Models;

namespace WOD.WebUI.ViewModels;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
		using var context = new MainContext(
			serviceProvider.GetRequiredService<
				DbContextOptions<MainContext>>());
		// Look for any news.
		if (context.News.Any())
		{
			return;   // DB has been seeded
		}
		context.News.AddRange(
			new News
			{
				Title = "Ronaldo in Al-Nassr",
				Text = "R7 in Saudi",
				Image = "https://tochka.by/upload/iblock/409/a5y6w3tibw2pa2ds3oi18vkm4fbvx1ge.jpg",
				Id = 1
			},
			new News
			{
				Title = "Ronaldo in Manchester United",
				Text = "R7 again in England",
				Image = "https://avatars.mds.yandex.net/i?id=63a1e21d0c3e579ffdee5aa5fcc0cad6_l-5221698-images-thumbs&n=13",
				Id=2
			},
			new News
			{
				Title = "Ronaldo in Juventus",
				Text = "R7 in Italy",
				Image = "https://avatars.mds.yandex.net/i?id=fd0b3b7e40e5863c0479acc6454ec43f_l-11924570-images-thumbs&n=13",
				Id=3
			}
			); ; ;
		context.SaveChanges();
	}
}
