using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using WebUI.Data;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;

namespace HelloMvcApp.Controllers
{
	public class NewsController : Controller
	{
		private readonly MainContext _context;
		private readonly FootballClubService _footballClubService;
		private readonly ILogger<NewsController> _logger;
		private readonly NewsService _newsService;
				
		public NewsController(ILogger<NewsController> logger, NewsService newsService, FootballClubService footballClubService, MainContext context)
		{
			_context=context;
			_logger = logger;
			_newsService = newsService;
			_footballClubService = footballClubService;
		}
		public IActionResult Index()
		{			
			var newsViewModel = new NewsViewModel(NewsService.allNews);

			return View("~/Views/News/Index.cshtml", newsViewModel);
		}

		[HttpGet]
		public IActionResult GetTranslayedNews(int index)
		{
			var homeViewModel = new HomeViewModel(_footballClubService.GetFootballClubs(), NewsService.allNews, index);

			return View("/Views/Home/Index.cshtml", homeViewModel); 
		}
		public IActionResult Create() 
		{
			var newsViewModel = new NewsViewModel(NewsService.allNews);
			return View("~/Views/News/Create.cshtml");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,Text,ReleaseDate")] News news)
		{
			if (ModelState.IsValid)
			{
				_context.Add(news);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(news);
		}

		public IActionResult Edit()
		{
			return View();
		}
		public IActionResult Delete()
		{
			return View();
		}
		public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var movie = await _context.News
        .FirstOrDefaultAsync(m => m.Id == id);
	
    if (movie == null)
    {
        return NotFound();
    }

    return View(movie);
}
		
	}
}
