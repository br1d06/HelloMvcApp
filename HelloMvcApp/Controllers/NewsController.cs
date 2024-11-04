using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WOD.Domain.Models;
using WOD.WebUI.Services;
using WOD.WebUI.ViewModels;
using WOD.WebUI.Data;

namespace HelloMvcApp.Controllers
{
	public class NewsController : Controller
	{
		private readonly PostgresContext _context;
		private readonly FootballClubService _footballClubService;
		private readonly ILogger<NewsController> _logger;
		private readonly NewsService _newsService;
				
		public NewsController(ILogger<NewsController> logger, NewsService newsService, FootballClubService footballClubService, PostgresContext context)
		{
			_context=context;
			_logger = logger;
			_newsService = newsService;
			_footballClubService = footballClubService;
		}
		public IActionResult Index()
		{			
			var newsViewModel = new NewsViewModel(_context.News.ToList());

			return View("~/Views/News/Index.cshtml", newsViewModel);
		}

		[HttpGet]
		public IActionResult GetTranslayedNews(int index)
		{
			var homeViewModel = new HomeViewModel(_context.FootballClubs.ToList(), _context.News.ToList(), index);

			return View("/Views/Home/Index.cshtml", homeViewModel); 
		}
		public IActionResult Create() 
		{
			return View("~/Views/News/Create.cshtml");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(News news)
		{
			if (ModelState.IsValid)
			{
				_context.News.Add(news);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(news);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (ModelState.IsValid)
			{
				var news = await _context.News.FirstOrDefaultAsync(n => n.Id == id);

				if(news!=null) 
					return View(news);
			}

			return NotFound();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(News news)
		{
			_context.News.Update(news);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		public IActionResult Delete()
		{
            var newsViewModel = new NewsViewModel(_context.News.ToList());

            return View("~/Views/News/Delete.cshtml", newsViewModel);
		}
       
        // POST: Movies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
			var news = await _context.News.FindAsync(id);
			if (ModelState.IsValid && news!=null)
			{               
				_context.News.Remove(news);
				await _context.SaveChangesAsync();
				return RedirectToAction("Delete");
			}
            return NotFound();
        }
        public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var news = await _context.News
				.FirstOrDefaultAsync(m => m.Id == id);
	
			if (news == null)
			{
				return NotFound();
			}

			return View(news);
		}
		
	}
}
