using System;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebUI.Data;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;

namespace HelloMvcApp.Controllers
{
    public class HomeController : Controller
    {       
        private readonly MainContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly FootballClubService _footballClubService;

        public HomeController(ILogger<HomeController> logger, FootballClubService footballClubService, MainContext context)
        {
            _context=context;
            _logger = logger;
            _footballClubService = footballClubService;
        }
	
		public IActionResult Index()
		{           
			var homeViewModel = new HomeViewModel(_footballClubService.GetFootballClubs(), NewsService.allNews);
                    
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

        public IActionResult EPLTable()
        {
            var homeViewModel = new HomeViewModel(_footballClubService.GetFootballClubs(), NewsService.allNews);

            return View("~/Views/Home/Table.cshtml", homeViewModel);
        }
    }
}