using System;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;

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

		public IHttpActionResult Details(int? id)
		{
			var footballClub = _footballClubService.FootballClubs.FirstOrDefault((p) => p.Id == id);
			if (footballClub == null)
			{
				return (IHttpActionResult)NotFound();
			}
			return (IHttpActionResult)Ok(footballClub);
		}
	}
}
