using Microsoft.AspNetCore.Mvc;

namespace News.Web.Controllers
{
	public class BaseController : Controller
	{
		public IActionResult NotFound()
		{
			return View();
		}
	}
}
