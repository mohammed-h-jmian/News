using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Data.Models;
using News.Infrastructure.Services.ClassificationServices;
using News.Infrastructure.Services.NewsServices;

namespace News.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _news;

        public NewsController(INewsService news)
        {
            _news = news;
        }

        // GET: NewsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null || id == 0)
            {
                return Redirect("/Base/NotFound");
            }
            var result = await _news.Get(id);
            if (result == null)
            {
                return Redirect("/Base/NotFound");
            }
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Search(string keyword)
        {
            var searchNews =await _news.Search(keyword);

            ViewBag.Keyword = keyword;
            return View(searchNews);
        }
        public async Task<ActionResult> GetLastJSON()
        {
            var lastNews = await _news.GetLast();
            return Json(lastNews);
        }

    }
}
