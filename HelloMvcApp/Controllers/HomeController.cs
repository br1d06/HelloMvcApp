using System;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;

namespace HelloMvcApp.Controllers
{
    public class HomeController : Controller
    {       
        private readonly ILogger<HomeController> _logger;
        private readonly FootballClubService _footballClubService;

        public HomeController(ILogger<HomeController> logger, FootballClubService footballClubService)
        {
            _logger = logger;
            _footballClubService = footballClubService;
        }

        public IActionResult Index()
        {
            var clubsLogos = new List<ClubLogo>()
            {
                new ClubLogo("https://media.api-sports.io/football/teams/42.png","Arsenal"),
                new ClubLogo("https://media.api-sports.io/football/teams/66.png","Aston Villa"),
                new ClubLogo("https://media.api-sports.io/football/teams/44.png","Burnley"),
                new ClubLogo("https://media.api-sports.io/football/teams/35.png","Bournemouth"),
                new ClubLogo("https://media.api-sports.io/football/teams/55.png","Brentford"),
                new ClubLogo("https://media.api-sports.io/football/teams/51.png","Brighton"),
                new ClubLogo("https://media.api-sports.io/football/teams/49.png","Chelsea"),
                new ClubLogo("https://media.api-sports.io/football/teams/52.png","Crystal Palace"),
                new ClubLogo("https://media.api-sports.io/football/teams/45.png","Everton"),
                new ClubLogo("https://media.api-sports.io/football/teams/36.png","Fulham"),
                new ClubLogo("https://media.api-sports.io/football/teams/40.png","Liverpool"),
                new ClubLogo("https://i.pinimg.com/originals/ac/2b/f5/ac2bf526e0bb93f8712d63c7ad088c32.png","Luton Town"),
                new ClubLogo("https://media.api-sports.io/football/teams/50.png","Manchester City"),
                new ClubLogo("https://media.api-sports.io/football/teams/33.png","Manchester United"),
                new ClubLogo("https://media.api-sports.io/football/teams/34.png","Newcastle United"),
                new ClubLogo("https://media.api-sports.io/football/teams/65.png","Nottingham Forest"),
                new ClubLogo("https://media.api-sports.io/football/teams/47.png","Tottenham Hotspur"),
                new ClubLogo("https://media.api-sports.io/football/teams/62.png","Sheffield United"),
                new ClubLogo("https://media.api-sports.io/football/teams/48.png","West Ham United"),
                new ClubLogo("https://media.api-sports.io/football/teams/39.png","Wolverhampton Wanderers")
            };
     
            var footballClubs = new List<FootballClub>();
			
            for (int i = 0; i < clubsLogos.Count; i++)
			{
				footballClubs.Add(new FootballClub(clubsLogos[i]));
			}
            
			var homeViewModel = new HomeViewModel(clubsLogos, footballClubs, NewsService.allNews);
          
            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }

        public IActionResult Error()
        {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        

        public IActionResult Privacy()
        {           
            return View(new PrivacyViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

    }
}