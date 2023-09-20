using Microsoft.AspNetCore.Mvc;
using News.Data.Models;
using News.Infrastructure.Services.LandingServices;
using System.Diagnostics;

namespace News.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ILandingService _landing;

		public HomeController(ILogger<HomeController> logger
			, ILandingService landing)
		{
			_logger = logger;
			_landing = landing;
		}

		public async Task<IActionResult> Index()
		{
			
			return View(await _landing.Get());
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}