using Microsoft.AspNetCore.Mvc;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HelloMvcApp.Controllers;

namespace WOD.WebUI.ViewModels;

public class HomeViewModel
{
	public List<FootballClub> FootballClubs { get; set; }
    public List<FootballClub> ClubsLogos { get; set; }
    public Dictionary<string, int> Table {  get; set; }
    public List<News> ContainerNews { get; set; }
    public News DefaultNews { get; }
    public News TranslayedNews { get; set; } 

	public HomeViewModel(List<FootballClub> footballClubs,List<News> allNews, int index=0)
    {
        FootballClubs = footballClubs;
        Table = FootballClubService.GetTable(FootballClubs);
        ContainerNews = NewsService.GetContainerNews(allNews);
        DefaultNews= NewsService.DefaultNews;
        TranslayedNews = ContainerNews[index];
	}

    public HomeViewModel(List<FootballClub> footballClubs, List<Match> matches)
    {
		FootballClubs = footballClubs;


	}
    
    public HomeViewModel() 
    {   
    }
}
	
		
