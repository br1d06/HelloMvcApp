using Microsoft.AspNetCore.Mvc;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WOD.WebUI.ViewModels;

public class HomeViewModel : PageModel
{
    public List<FootballClub> FootballClubs { get; private set; }
    public List<ClubLogo> ClubsLogos { get; private set; }
    public Dictionary<string, int> Table {  get; private set; }
    public List<News> ContainerNews { get; private set; }
    public News DefaultNews { get; }
	[BindProperty]
	public News News { get; set; }
	public void OnPost(List<News> containerNews, int index)
	{
        News = containerNews[index];
	}

	public HomeViewModel(List<ClubLogo> clubsLogos, List<FootballClub> footballClubs,List<News> allNews)
    {       
        ClubsLogos = clubsLogos;
        FootballClubs = footballClubs;
        Table = FootballClubService.GetTable(FootballClubs);
        ContainerNews = NewsService.GetContainerNews(allNews);
        News = ContainerNews[0];
        DefaultNews= NewsService.DefaultNews;
	}
}

