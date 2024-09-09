using WOD.Domain.Models;

namespace WOD.WebUI.Services
{
	public class NewsService
	{
		public static List<News> allNews = new();
		public static readonly News DefaultNews = new("Mbappe is in Madrid", "FC Real Madrid finally after 4 years talking signed the most valuable player in the world Mbappe, according to our sources he will take Ronaldo's first number in Real Madrid - 9.", "https://i.pinimg.com/originals/69/ce/68/69ce6844ec139cf6f324506b675cddd3.jpg");

		public static List<News> GetContainerNews(List<News> allNews)
		{
			if (allNews.Count >= 10)
			{
				return allNews.GetRange(allNews.Count - 10, 10);
			}
			else
				return allNews;
		}
	}
}
