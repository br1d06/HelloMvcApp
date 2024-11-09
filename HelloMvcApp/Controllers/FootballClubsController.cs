using System;
using Microsoft.AspNetCore.Mvc;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using WOD.WebUI.Data;
using Newtonsoft.Json;

namespace HelloMvcApp.Controllers
{
	public class FootballClubsController : Controller
	{
		Uri baseAddress = new Uri("");
		private readonly HttpClient _client;
		private readonly PostgresContext _context;
		private readonly ILogger<FootballClubsController> _logger;
		private readonly FootballClubService _footballClubService;

		public FootballClubsController(ILogger<FootballClubsController> logger, FootballClubService footballClubService, PostgresContext context)
		{
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;
			_context=context;
			_logger = logger;
			_footballClubService = footballClubService;
		}
		public IActionResult Index()
		{
			var homeViewModel = new HomeViewModel(_context.FootballClubs.ToList(), NewsService.allNews);

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
		[HttpGet]
		public IActionResult GetData()
		{
			List<FootballClub> footballClubList = new List<FootballClub>();
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "").Result;

			if(response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;

				footballClubList = JsonConvert.DeserializeObject<List<FootballClub>>(data);
			}
			return View(footballClubList);
		}
	}
}
