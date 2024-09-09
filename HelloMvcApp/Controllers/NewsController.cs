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
	public class NewsController : Controller
	{
		private readonly ILogger<NewsController> _logger;
		private readonly NewsService _newsService;
		public NewsController(ILogger<NewsController> logger, NewsService newsService)
		{
			_logger = logger;
			_newsService = newsService;
		}
		public IActionResult Index()
		{
			var newsViewModel = new NewsViewModel(NewsService.allNews);

			return View("~/Views/News/Index.cshtml", newsViewModel);
		}

		public IActionResult Create()
		{
			var newsViewModel = new NewsViewModel(NewsService.allNews);
			return View("~/Views/News/Create.cshtml");
		}
		public IActionResult Edit()
		{
			return View();
		}
		public IActionResult Delete()
		{
			return View();
		}
		
	}
}
