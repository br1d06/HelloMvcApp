using System;
using Microsoft.AspNetCore.Mvc;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using WOD.WebUI.Data;

namespace HelloMvcApp.Controllers
{
	public class FootballClubsController : Controller
	{		
		private readonly PostgresContext _context;
		private readonly ILogger<FootballClubsController> _logger;
		private readonly FootballClubService _footballClubService;
        
    public FootballClubsController(ILogger<FootballClubsController> logger, FootballClubService footballClubService, PostgresContext context)
		{		
			_context=context;
			_logger = logger;
			_footballClubService = footballClubService;
		}
		public async Task<IActionResult> Index()
		{
			var homeViewModel = new HomeViewModel(_context.FootballClubs.ToList(), NewsService.allNews);

			_footballClubService.GetData();
		
			return View("~/Views/FootballClub/Index.cshtml", homeViewModel);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var footballClub = _context.FootballClubs.FirstOrDefault((p) => p.Id == id);
			if (footballClub != null)
			{
				return View("~/Views/FootballClub/Details.cshtml", footballClub);
			}
			return NotFound();
		}
		public IActionResult LastResults()
		{
			var homeViewModel = new HomeViewModel(_context.FootballClubs.ToList(), NewsService.allNews);

			return View("~/Views/FootballClub/LastResults.cshtml", homeViewModel);
		}
		
	}
}
