
using System.ComponentModel.DataAnnotations;


namespace WOD.Domain.Models
{
	public class News
	{
		public int Id { get;  set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string? Title { get; set; }
		public string Text { get;  set; }
		public string Image { get;  set; } 
		public DateTime ReleaseDate { get; }

		public News(string title, string text, string image, int id) 
		{
			Title=title; 
			Text=text; 
			Image=image;
			ReleaseDate = DateTime.Now;
			Id = id;
		}

		public News() { }
	}
}
