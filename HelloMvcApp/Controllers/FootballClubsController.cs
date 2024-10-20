using System;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HelloMvcApp.Controllers
{
	public class FootballClubsController : Controller
	{
		private readonly MainContext _context;
		private readonly ILogger<FootballClubsController> _logger;
		private readonly FootballClubService _footballClubService;

		public FootballClubsController(ILogger<FootballClubsController> logger, FootballClubService footballClubService, MainContext context)
		{
			_context=context;
			_logger = logger;
			_footballClubService = footballClubService;
		}
		public IActionResult Index()
		{
			var homeViewModel = new HomeViewModel(_footballClubService.GetFootballClubs(), NewsService.allNews);

			return View("~/Views/FootballClub/Index.cshtml", homeViewModel);
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var footballClub = _context.FootballClubs.FirstOrDefault((p) => p.Id == id);
			if (footballClub == null)
			{
				return NotFound();
			}
			return View(footballClub);
		}
		public IActionResult LastResults()
		{
			var homeViewModel = new HomeViewModel(_footballClubService.GetFootballClubs(), NewsService.allNews);

			return View("~/Views/FootballClub/LastResults.cshtml", homeViewModel);
		}
	}
}
