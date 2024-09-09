using WOD.Domain.Models;
using WOD.WebUI.Services;

namespace WOD.WebUI.ViewModels;

public class HomeViewModel
{
    public List<FootballClub> FootballClubs { get; private set; }
    public List<ClubLogo> ClubsLogos { get; private set; }
    public Dictionary<string, int> Table {  get; private set; }
    public List<News> ContainerNews { get; private set; }
    public News DefaultNews { get; }

    public HomeViewModel(List<ClubLogo> clubsLogos, List<FootballClub> footballClubs,List<News> allNews)
    {
        ClubsLogos = clubsLogos;
        FootballClubs = footballClubs;
        Table = FootballClubService.GetTable(FootballClubs);
        ContainerNews = NewsService.GetContainerNews(allNews);
        DefaultNews= NewsService.DefaultNews;
	}
}

