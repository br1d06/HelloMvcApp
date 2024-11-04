using System.Reflection;
using WOD.Domain.Models;

namespace WOD.WebUI.Services
{
	public class NewsService
	{
		public static List<News> allNews = new()
		{
			{
				new News ("Ronaldo in Al-Nassr",
				"R7 in Saudi",
				"https://tochka.by/upload/iblock/409/a5y6w3tibw2pa2ds3oi18vkm4fbvx1ge.jpg", 
				1)
				
			},
			{
				new News ("Ronaldo in Manchester United", 
					"R7 again in England", 
					"https://avatars.mds.yandex.net/i?id=63a1e21d0c3e579ffdee5aa5fcc0cad6_l-5221698-images-thumbs&n=13",
					2)
			},
			{
				new News("Ronaldo in Juventus",
					"R7 in Italy", 
					"https://avatars.mds.yandex.net/i?id=fd0b3b7e40e5863c0479acc6454ec43f_l-11924570-images-thumbs&n=13",
					3)
			}
		};
		public static readonly News DefaultNews = 
			new ("Mbappe is in Madrid", 
			"FC Real Madrid finally after 4 years talking signed the most valuable player in the world Mbappe, according to our sources he will take Ronaldo's first number in Real Madrid - 9.", 
			"https://i.pinimg.com/originals/69/ce/68/69ce6844ec139cf6f324506b675cddd3.jpg", 
			0);

		public static List<News> GetContainerNews(List<News> allNews)
		{
			if (allNews.Count >= 10)			
				return allNews.GetRange(allNews.Count - 10, 10);
			
			else
			return allNews;
		}
	}
}
